using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Centro_Salud.Persistencia;
using Centro_Salud.Presentacion.DTOs;

namespace Centro_Salud.Presentacion.Movimientos
{
    public partial class Salidas : System.Web.UI.Page
    {
       
        //Definicion de variables        
        private static int contador = 0;
        private String valor = null;
        private IMedicamento iMed = new IMedicamento();
        private IMovimientoStock iMovStk = new IMovimientoStock();
        private IDetalleMovimientoStock iDetMovStk = new IDetalleMovimientoStock();
        private ITipoMovimiento iTM = new ITipoMovimiento();

        private Medicamento med = new Medicamento();
        private List<Medicamento> listaMed = new List<Medicamento>();
        private List<Object> lista = new List<Object>();
        private List<Object> listaL = new List<Object>();
        private List<Object> listaT = new List<object>();
        private IList<StockMedicamento> listaStkM ;
        private IList<StockMedicamento> listaStkM1;
        private List<TipoMovimiento> listaTMS = new List<TipoMovimiento>();
        TipoMovimiento tipoMov = new TipoMovimiento();
        private ILote iLote = new ILote();
        private List<Lote> listaLote = new List<Lote>();
        Medicamento remedio=new Medicamento();
        List<Medicamento> remedios = new List<Medicamento>();
        Lote lote;
        
        private List<MovimientoStock> entradas = new List<MovimientoStock>();
        bool guardado = false;
        int numerogenerado = 0;
        private DtoEntrada dtoE;
        private IDtoEntrada iDtoEnt=new IDtoEntrada();
        private List<DtoEntrada> listaEntradas = null;
        private String msj;
        public int i = 0;
        IStockMedicamento iStockM = new IStockMedicamento();
        StockMedicamento stockMed = new StockMedicamento();

        // carga la pagina y el combo de tipo de movimientos
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_fecha.Text = DateTime.Now.Date.ToString();
            bt_guardar.Visible = false;
            bt_cancelar.Visible = false;
            
            if (listaTMS.Count == 0)
            {
                listaTMS = iTM.getAll<TipoMovimiento>();
                foreach (TipoMovimiento tm in listaTMS)
                {
                    if (tm.tipo == "S") listaT.Add(tm.descripcionTipoMov);
                }
                ddl_tipMov.Enabled = true;
                ddl_tipMov.DataSource = listaT;
                ddl_tipMov.DataBind();
            }
        }
        //carga y visualiza combos de medicamentos y lotes 
        protected void bt_agregar_Click(object sender, EventArgs e)
        {
            listaMed = iMed.getAll<Medicamento>();
            panelMedicamento.Visible = true;

            foreach (Medicamento m in listaMed)
            {
                lista.Add(m.descripcion);
            }
            ddl_medicamentos.Enabled = true;
            ddl_medicamentos.DataSource = lista;
            ddl_medicamentos.DataBind();

            listaLote = iLote.getAll<Lote>();

            foreach (Lote l in listaLote)
            {
                if (l.fechaVto > DateTime.Now.Date)
                    listaL.Add(l.nroLote);

            }
            ddl_lotes.Enabled = true;
            ddl_lotes.DataSource = listaL;
            ddl_lotes.DataBind();

        }

        //Cuando selecciona un medicamento, completa los datos del medicamento
        protected void completarDatos(object sender, EventArgs e)
        {
            int totalActual = 0;
            String usar = ddl_medicamentos.SelectedValue;
            remedio = iMed.getPorCriterio<Medicamento>(usar).First<Medicamento>();
            txt_descripcionMed.Text = remedio.descripcion;
            txt_codigoMed.Text = Convert.ToString(remedio.codigo);

            stockMed = iStockM.getCriterioById<StockMedicamento>("","", remedio.codigo).First<StockMedicamento>();
            listaStkM = iStockM.getCriterioById<StockMedicamento>("", "", remedio.codigo);
            
            //calcula la cantidad total de stock
            foreach (StockMedicamento stk in listaStkM) { 
             if (stk.fechaBaja == null) totalActual = totalActual + Convert.ToInt32(stk.stockActual);
            }
            
            txt_disponible.Text = Convert.ToString(totalActual);
            txt_cantidad.Text = "";
        }
       
        //Cuando selecciona un lote completa los datos del lote y calcula la cantidad de stock disponible para ese lote
        protected void completarDatosLote(object sender, EventArgs e)
        {
            int stkLote=0;
            int usarM = 0;
            String usarL = ddl_lotes.SelectedValue;
            lote = iLote.getByCriterio<Lote>("", "", usarL).First<Lote>();
            txt_FechaVto.Text = Convert.ToString(lote.fechaVto);
            txt_FechElab.Text = Convert.ToString(lote.fechaElaboracion);
            txt_lote1.Text = Convert.ToString(lote.nroLote);
            usarM = Convert.ToInt32(txt_codigoMed.Text);
            listaStkM = iStockM.getCriterioById<StockMedicamento>("", "", usarM);
            
            //calcula la cantidad de stock para el lote
            foreach (StockMedicamento stk in listaStkM)
            {
               if (stk.lote == lote.nroLote && stk.fechaBaja == null)
               {
                 stkLote = stkLote + Convert.ToInt32(stk.stockActual);
               }
            }
            txt_stockLote.Text = Convert.ToString(stkLote); 
        }

        //Guarda el movimiento generado con todos sus detalles. Actualiza el stock
        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                    numerogenerado = generarCodigo();

                    String tipoM = ddl_tipMov.SelectedValue;
                    tipoMov = iTM.getPorCriterio<TipoMovimiento>(tipoM).First<TipoMovimiento>();
    
                    DetalleMovimientoStock f;
                    MovimientoStock movimiento = new MovimientoStock();
                    
                    StockMedicamento stockM;
                    stockM = new StockMedicamento();

                    //guarda la cabecera el movimiento                   
                    movimiento.fechaMovimiento = DateTime.Now.Date;
                    movimiento.nroMovimiento = numerogenerado; 
                    movimiento.tipoMovimiento = tipoMov.codigoTipoMov; 
                    movimiento.nroComprobante = int.Parse(txt_comprobante.Text);

                    iMovStk.save<MovimientoStock>(movimiento);
                    Intermediario.confirmarCambios();

                    // guarda los detalles del movimiento                    
                    DataTable dt = Session["DataTableMovimientos"] as DataTable;
                    foreach (DataRow row in dt.Rows) {

                        f= new DetalleMovimientoStock();
                        f.codigoMedicamento = Convert.ToInt32(row["codigo"]);
                        f.cantidad = Convert.ToInt32(row["cantidad"]);
                        f.nroLote = Convert.ToInt32(row["lote"]);
                        f.codDetalle = generarCodigoDetalles();
                        f.nroMovimiento = movimiento.nroMovimiento;
                        iDetMovStk.save<DetalleMovimientoStock>(f);
                        Intermediario.confirmarCambios();

                        stockM = iStockM.getCriterioById<StockMedicamento>("", "", Convert.ToInt32(Convert.ToInt32(row["codigo"]))).First<StockMedicamento>();
                        listaStkM1 = iStockM.getCriterioById<StockMedicamento>("", "", Convert.ToInt32(Convert.ToInt32(row["codigo"])));
                        
                        //actualiza el stock del medicamento
                        foreach (StockMedicamento stk in listaStkM1)
                        {
                            if (stk.lote == Convert.ToInt32(Convert.ToInt32(row["lote"])))
                            {
                                stk.stockActual = stk.stockActual - Convert.ToInt32(row["cantidad"]);

                                if (stk.stockActual == 0) msj = "Algunos Medicamentos quedaron con stock en cero. ";

                                iStockM.Update<StockMedicamento>(stk);
                                Intermediario.confirmarCambios();
                                mostrarMensaje(msj);
                            }

                        }          
                }
       

                msj = "El Movimiento ha sido creado correctamente, con el nro: " + numerogenerado ;
                mostrarMensaje(msj);
                
                //limpia variables y pantalla
                txt_comprobante.Text = "";
                txt_cantidad.Text = "";
                txt_descripcionMed.Text = "";
                txt_codigoMed.Text = "";
                txt_lote1.Text = "";
                panelMedicamento.Visible = false;
                panel_grilla.Visible = false;
                gv_Movimientos.Visible = false;
                bt_guardar.Visible = false;
                bt_cancelar.Visible = false;
                
            }

            catch (Exception) { }
        }
        
        // metodo que visualiza mensajes en pantalla
        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }     

        //En este metodo llenamos la grilla con todos los datos
        public void llenar(String v)
        {
            List<MovimientoStock> listaMovim = new List<MovimientoStock>();
            
            gv_Movimientos.ShowHeaderWhenEmpty = true;
            DataTable entrada = null;
            try
            {            

            if (Session["DataTableMovimientos"] != null)
            {
                entrada = Session["DataTableMovimientos"] as DataTable;
                              
                DataRow fila;
                fila = entrada.NewRow();
                fila["codigo"] = Convert.ToInt32(txt_codigoMed.Text);
                fila["cantidad"] = Convert.ToInt32(txt_cantidad.Text);
                fila["descripcion"] = txt_descripcionMed.Text;
                fila["lote"] = txt_lote1.Text;
                fila["item"] = i+1;
                entrada.Rows.Add(fila);

                Session["DataTableMovimientos"] = entrada;

            }
            else {

                entrada = new DataTable();
                entrada.Columns.Add("codigo");
                entrada.Columns.Add("cantidad");
                entrada.Columns.Add("descripcion");
                entrada.Columns.Add("item");
                entrada.Columns.Add("lote");


                DataRow fila1 = entrada.NewRow();
                fila1["codigo"] = Convert.ToInt32(txt_codigoMed.Text);
                fila1["cantidad"] = Convert.ToInt32(txt_cantidad.Text);
                fila1["descripcion"] = txt_descripcionMed.Text;
                fila1["item"] = i+1;
                fila1["lote"] = txt_lote1.Text;
                entrada.Rows.Add(fila1);

                Session["DataTableMovimientos"] = entrada;

            }
                gv_Movimientos.DataSource = Session["DataTableMovimientos"];
                gv_Movimientos.DataBind();
            }
            catch (Exception)
            {
            }
        }
#region Generar Codigos
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


        //va incrementando 1 en 1 el código del dtoEntradas
        private int generarCodigoDtoEntradas()
        {
            int codig = 0;
            List<DtoEntrada> cantDtos = iDtoEnt.getAll<DtoEntrada>();

            if (cantDtos.Count == 0)
                return 1;
            else
            {
                codig = cantDtos.First<DtoEntrada>().codigo;
                foreach (DtoEntrada m in cantDtos)
                    if (codig < m.codigo)
                        codig = m.codigo;
                return ++codig;
            }
        }

        //Va incrementando de 1 en 1 el código de los movimientos
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

#endregion
        
        //Al seleccionar el medicamento, el lote y la cantidad lo agrega a una grilla
        //Esta grilla se actualiza cada vez que se agrega un nuevo medicamento
        //Luego estos datos de la grilla se van a guardar en un movimiento cuando el usuario presione guardar
        protected void bt_Nuevo_Click(object sender, ImageClickEventArgs e)
        {
            //busca el stock del medicamento y verifica disponibilidad 
            StockMedicamento stockDisp = new StockMedicamento();
            stockDisp = iStockM.getCriterioById<StockMedicamento>("", "",Convert.ToInt32(txt_codigoMed.Text) ).First<StockMedicamento>();

            if (Convert.ToInt32(txt_cantidad.Text) <= Convert.ToInt32(txt_stockLote.Text))
            {
                llenar(valor);
            }
            else { msj = " Stock Insuficiente en el lote seleccionado "; mostrarMensaje(msj); }

            //activa como visible la grilla
            panel_grilla.Visible = true;
            gv_Movimientos.Visible = true;
            bt_guardar.Visible = true;
            bt_cancelar.Visible = true;
            
            //Limpia variables
            txt_cantidad.Text = "";
            txt_codigoMed.Text = "";
            txt_descripcionMed.Text = "";
            txt_disponible.Text = "";
            txt_FechaVto.Text = "";
            txt_FechElab.Text = "";
            txt_stockLote.Text = "";
            txt_lote1.Text = "";
            
        }

        protected void bt_cancel_Click(object sender, ImageClickEventArgs e)
        {
            //Limpia variables
            txt_cantidad.Text = "";
            txt_codigoMed.Text = "";
            txt_descripcionMed.Text = "";
            txt_disponible.Text = "";
            txt_FechaVto.Text = "";
            txt_FechElab.Text = "";
            txt_stockLote.Text = "";
            txt_lote1.Text = "";
        }
        
       

    }
}