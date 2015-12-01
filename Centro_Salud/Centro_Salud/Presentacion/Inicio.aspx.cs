using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud.Presentacion.DTOs;
using System.Data;

namespace Centro_Salud.Presentacion
{
    public partial class Inicio : System.Web.UI.Page
    {
        private IStockMedicamento iStockMed = new IStockMedicamento();
        private List<StockMedicamento> listaMedicamentos = new List<StockMedicamento>();
        private IMedicamento iMedicamento = new IMedicamento();
        private ILote iLote = new ILote();
        private DataTable mensajes = new DataTable();
        private TimeSpan dif;
        private int i;

        MovimientoStock vencidos = new MovimientoStock();
        IMovimientoStock iMovStk = new IMovimientoStock();
        ITipoMovimiento iTipo=new ITipoMovimiento();
        TipoMovimiento tipito = new TipoMovimiento();
        IDetalleMovimientoStock iDetMovStk = new IDetalleMovimientoStock();
        DetalleMovimientoStock detalle;
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
            
            listaMedicamentos = iStockMed.getAll<StockMedicamento>();
            tipito=iTipo.getPorCriterio<TipoMovimiento>("Vencimiento").First<TipoMovimiento>();
            vencidos.nroMovimiento = generarCodigo();
            vencidos.fechaMovimiento = DateTime.Today;
            vencidos.nroComprobante = 0;
            vencidos.tipoMovimiento = tipito.codigoTipoMov;

            iMovStk.save<MovimientoStock>(vencidos);
           
            mensajes.Columns.Add("codigo");
            mensajes.Columns.Add("descripcion");
            mensajes.Columns.Add("mensaje");
            mensajes.Columns.Add("fecha");
            mensajes.Columns.Add("lote");

//            int det = generarCodigoDetalles();
            
            foreach (StockMedicamento m in listaMedicamentos)
            {
                Lote lote = iLote.getCriterioById<Lote>("", "", Convert.ToInt32(m.lote)).First<Lote>();
                Medicamento remedio = iMedicamento.getCriterioById<Medicamento>("", "", Convert.ToInt32(m.codigoMedicamento)).First<Medicamento>();
                DataRow fila = mensajes.NewRow();
                dif = DateTime.Today.Subtract(Convert.ToDateTime(lote.fechaVto));


                if (m.fechaBaja == null)
                {
                    //VERIFICAR CUANDO EL MEDICAMENTO YA ESTÉ VENCIDO
                    if (-(dif.Days) <= remedio.diasAlertas)
                    {
                        //Agregar el mensaje a un dto mensaje
                        //msj=new DtoMensaje();

                        //Si la fecha es igual o menor a la fecha de hoy le doy de baja
                        if (lote.fechaVto <= DateTime.Today)
                        {
                            m.fechaBaja = DateTime.Today;
                            iStockMed.Update<StockMedicamento>(m);

                            fila["codigo"] = m.codigoMedicamento;
                            fila["descripcion"] = remedio.descripcion;
                            fila["fecha"] = lote.fechaVto.ToString();
                            fila["mensaje"] = "El medicamento con cód: " + m.codigoMedicamento + " está vencido. Fue dado de baja.";
                            fila["lote"] = "Pertenece al lote: " + lote.nroLote;

                           
                            detalle = new DetalleMovimientoStock();
                            detalle.codDetalle = generarCodigoDetalles();
                            detalle.cantidad = Convert.ToInt32(m.stockActual);
                            detalle.codigoMedicamento = m.codigoMedicamento;
                            detalle.nroMovimiento = vencidos.nroMovimiento;
                            detalle.nroLote = m.lote;

                            iDetMovStk.save<DetalleMovimientoStock>(detalle);

                        }
                        else
                        {
                            fila["codigo"] = m.codigoMedicamento;
                            fila["descripcion"] = remedio.descripcion;
                            fila["fecha"] = lote.fechaVto.ToString();
                            fila["mensaje"] = "Faltan " + Convert.ToInt32(-dif.Days) + " días para que el medicamento se venza";
                            fila["lote"] = "Pertenece al lote: " + lote.nroLote;
                        }
                        mensajes.Rows.Add(fila);
                       
                    }

                }

               
            }

            Intermediario.confirmarCambios();

            if (mensajes.Rows.Count > 0)
            {
                panelMensajes.Visible = true;
                grillaMsjs.DataSource = mensajes;
                grillaMsjs.DataBind();
                grillaMsjs.Visible = true;
            }

        }

        private int generarCodigoDetalles()
        {
            int codig = 0;

            List<DetalleMovimientoStock> cantDetalles = iDetMovStk.getAll<DetalleMovimientoStock>();

            if (cantDetalles.Count == 0)
                return 1;
            else
            {
                codig = cantDetalles.First<DetalleMovimientoStock>().codDetalle;
                foreach (DetalleMovimientoStock m in cantDetalles)
                    if (codig < m.codDetalle)
                        codig = m.codDetalle;
                return ++codig;
            }
        }

        private int generarCodigo()
        {
            int codigo = 0;
            List<MovimientoStock> cantMov = iMovStk.getAll<MovimientoStock>();

            if (cantMov.Count == 0)
                return 1;
            else
            {
                codigo = cantMov.First<MovimientoStock>().nroMovimiento;
                foreach (MovimientoStock m in cantMov)
                    if (codigo < m.nroMovimiento)
                        codigo = m.nroMovimiento;
                return ++codigo;
            }
        }
    }
}