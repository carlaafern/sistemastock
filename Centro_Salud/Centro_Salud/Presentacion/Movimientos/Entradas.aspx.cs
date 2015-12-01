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
    public partial class Entradas : System.Web.UI.Page
    {

        #region Declaraciones
        private static int contador = 0;
        private String valor = null;
        private IMedicamento iMed = new IMedicamento();
        private IMovimientoStock iMovStk = new IMovimientoStock();
        private IDetalleMovimientoStock iDetMovStk = new IDetalleMovimientoStock();
        private ITipoMovimiento iTM = new ITipoMovimiento();

        private Medicamento med = new Medicamento();
        private StockMedicamento stockNuevo;
        private List<Medicamento> listaMed = new List<Medicamento>();
        private List<Object> lista = new List<Object>();
        private List<Object> listaL = new List<Object>();
        private ILote iLote = new ILote();
        private List<Lote> listaLote = new List<Lote>();
        private List<Object> listaT = new List<object>();
        private List<TipoMovimiento> listaTM = new List<TipoMovimiento>();
        Medicamento remedio = new Medicamento();
        List<Medicamento> remedios = new List<Medicamento>();
        IStockMedicamento iStockM = new IStockMedicamento();
        Lote lote;
        //agregado
        private List<MovimientoStock> entradas = new List<MovimientoStock>();
        bool guardado = false;
        int numerogenerado = 0;
        private DtoEntrada dtoE;
        private IDtoEntrada iDtoEnt = new IDtoEntrada();
        private List<DtoEntrada> listaEntradas = null;
        private String msj;
        public int i = 0;
        TipoMovimiento tipoMov = new TipoMovimiento();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            txt_fecha.Text = DateTime.Now.Date.ToString();
            bt_guardar.Visible = false;
            bt_cancelar.Visible = false;

            if (!IsPostBack)
            {
                Session["DataTableMovimientosE"] = null;



                if (listaTM.Count == 0)
                {
                    listaTM = iTM.getAll<TipoMovimiento>();

                    foreach (TipoMovimiento tm in listaTM)
                    {
                        if (tm.tipo == "E") listaT.Add(tm.descripcionTipoMov);
                    }

                    ddl_tipoMovE.Enabled = true;
                    ddl_tipoMovE.DataSource = listaT;
                    ddl_tipoMovE.DataBind();
                    bt_cancel.Visible = false;
                    bt_Nuevo.Visible = false;
                }

            }
        }
        //Agrega un nuevo medicamento 
        //Muestra los lotes
        protected void bt_agregar_Click(object sender, EventArgs e)
        {
            String msj;
            String tipoSeleccionado = ddl_tipoMovE.SelectedValue;
            
            if (tipoSeleccionado!= "Seleccione TipoMovimiento")
            {

                listaMed = iMed.getAll<Medicamento>();
                panelMedicamento.Visible = true;
                bt_cancel.Visible = true;
                bt_Nuevo.Visible = true;

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
            else 
            {
                msj = "Debe seleccionar tipo de movimiento";
                mostrarMensaje(msj);
            }
        }

        //Cuando selecciona un medicamento del codigo completa los datos del medicamento
        protected void completarDatos(object sender, EventArgs e)
        {
            String usar = ddl_medicamentos.SelectedValue;
            remedio = iMed.getPorCriterio<Medicamento>(usar).First<Medicamento>();
            txt_descripcionMed.Text = remedio.descripcion;
            txt_codigoMed.Text = Convert.ToString(remedio.codigo);
            txt_cantidad.Text = "";
            bt_cancel.Visible = true;
            bt_Nuevo.Visible = true;
        }

        //Cuando selecciona un medicamento del codigo completa los datos del lote para llenar el combo
        protected void completarDatosLote(object sender, EventArgs e)
        {
            String usarL = ddl_lotes.SelectedValue;
            lote = iLote.getByCriterio<Lote>("", "", usarL).First<Lote>();
            txt_FechaVto.Text = Convert.ToString(lote.fechaVto);
            txt_FechElab.Text = Convert.ToString(lote.fechaElaboracion);
            txt_lote1.Text = Convert.ToString(lote.nroLote);
            bt_cancel.Visible = true;
            bt_Nuevo.Visible = true;


        }

        //Busca los stockMovimientos asociados a ese lote
        //Si existen stockMedicamentos-->Actualizar ese stock existente
        //Si no existe stockMedicamento-->Crear un nuevo stockMedicamento e indicarle el stock
        //Guarda el movimiento generado con todos sus detalles
        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                numerogenerado = generarCodigo();
                String tipoM = ddl_tipoMovE.SelectedValue;
                //Busca el tipo de movimiento seleccionado
                tipoMov = iTM.getPorCriterio<TipoMovimiento>(tipoM).First<TipoMovimiento>();
                //Crea el movimiento
                DetalleMovimientoStock f;
                MovimientoStock movimiento = new MovimientoStock();
                IList<StockMedicamento> stockM;

                //Generaciòn del movimiento
                movimiento.fechaMovimiento = DateTime.Now.Date;
                movimiento.nroMovimiento = numerogenerado; // generarCodigo();
                //Este tipo=1 indica que son movimienots de tipo entrada
                movimiento.tipoMovimiento = tipoMov.codigoTipoMov;
                movimiento.nroComprobante = int.Parse(txt_comprobante.Text);

                //Guarda el movimiento de stock
                iMovStk.save<MovimientoStock>(movimiento);
                Intermediario.confirmarCambios();

                DataTable dt = Session["DataTableMovimientosE"] as DataTable;

                //Guarda los elementos de la grilla--crea un detalle para cada uno

                foreach (DataRow row in dt.Rows)
                {

                    f = new DetalleMovimientoStock();
                    f.codigoMedicamento = Convert.ToInt32(row["codigo"]);
                    f.cantidad = Convert.ToInt32(row["cantidad"]);
                    f.nroLote = Convert.ToInt32(row["lote"]);
                    f.codDetalle = generarCodigoDetalles();
                    f.nroMovimiento = movimiento.nroMovimiento;
                    iDetMovStk.save<DetalleMovimientoStock>(f);
                    Intermediario.confirmarCambios();

                    //Busca el stock actual para el codigo seleccionado

                    stockM = iStockM.getCriterioById<StockMedicamento>("", "", Convert.ToInt32(Convert.ToInt32(row["codigo"])));
                    //Verifica si tiene creado stock para ese lote
                    bool existe=false;
                    foreach (StockMedicamento stk in stockM)
                    {
                        if (stk.lote == Convert.ToInt32(row["lote"])) existe = true;
                                               
                    }
                    if (stockM.Count == 0 || existe==false)
                    {
                        stockNuevo = new StockMedicamento();
                        stockNuevo.codigoMedicamento = Convert.ToInt32(row["codigo"]);
                        stockNuevo.codigoStock = generarCodigoStock();
                        stockNuevo.stockActual = Convert.ToInt32(row["cantidad"]);
                        stockNuevo.lote = Convert.ToInt32(row["lote"]);

                        iStockM.save<StockMedicamento>(stockNuevo);

                    }
                    else
                    {

                        StockMedicamento stockMed = stockM.First<StockMedicamento>();   // = iStockM.getCriterioById<StockMedicamento>("", "", Convert.ToInt32(Convert.ToInt32(row["codigo"]))).First<StockMedicamento>();
                        stockMed.stockActual = stockMed.stockActual + Convert.ToInt32(row["cantidad"]);
                        iStockM.Update<StockMedicamento>(stockMed);

                    }

                    Intermediario.confirmarCambios();
                }


                msj = "El Movimiento ha sido creado correctamente, con el nro: " + numerogenerado;

                Session["DataTableMovimientosE"] = null;

                txt_comprobante.Text = "";
                txt_cantidad.Text = "";
                txt_descripcionMed.Text = "";
                txt_codigoMed.Text = "";
                txt_lote1.Text = "";
                panelMedicamento.Visible = false;
                panel_grilla.Visible = false;
                gv_Movimientos.Visible = false;
                bt_Nuevo.Visible = false;
                bt_cancel.Visible = false;
                bt_guardar.Visible = false;
                bt_cancelar.Visible = false;
                ddl_lotes.Items.Clear();
                ddl_medicamentos.Items.Clear();
                //ddl_tipoMovE.Items.Clear();

                mostrarMensaje(msj);
            }

            catch (Exception) { }
        }

        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }

        protected void bt_Nuevo_Click(object sender, ImageClickEventArgs e)
        {
            
            String msj;
            if (txt_cantidad.Text == "" || ddl_medicamentos.SelectedValue=="Seleccione Medicamento"||ddl_lotes.SelectedValue=="Seleccione Lote") {
                msj = "Por favor indique medicamento, cantidad a ingresar y lote.";
              mostrarMensaje(msj);
            }
            else {
            llenar(valor);
            panel_grilla.Visible = true;
            gv_Movimientos.Visible = true;
            bt_guardar.Visible = true;
            bt_cancelar.Visible = true;

            }
        }

        //En este metodo llenamos la grilla con todos los datos
        public void llenar(String v)
        {
            List<MovimientoStock> listaMovim = new List<MovimientoStock>();
            bool llena = false;

          
            gv_Movimientos.ShowHeaderWhenEmpty = true;
            
            DataTable entrada = null;
            try
            {

                if (Session["DataTableMovimientosE"] != null)
                {
                    entrada = Session["DataTableMovimientosE"] as DataTable;

                    DataRow fila;
                    fila = entrada.NewRow();
                    fila["codigo"] = Convert.ToInt32(txt_codigoMed.Text);
                    fila["cantidad"] = Convert.ToInt32(txt_cantidad.Text);
                    fila["descripcion"] = txt_descripcionMed.Text;
                    fila["lote"] = txt_lote1.Text;
                    fila["item"] = i + 1;
                    entrada.Rows.Add(fila);

                    Session["DataTableMovimientosE"] = entrada;

                }
                else
                {

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
                    fila1["item"] = i + 1;
                    fila1["lote"] = txt_lote1.Text;
                    entrada.Rows.Add(fila1);

                    Session["DataTableMovimientosE"] = entrada;

                }
                gv_Movimientos.DataSource = Session["DataTableMovimientosE"];
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

        private int generarCodigoStock()
        {
            int codigo = 0;
            List<StockMedicamento> cantStocks = iStockM.getAll<StockMedicamento>();

            if (cantStocks.Count == 0)
                return 1;
            else
            {
                codigo = cantStocks.First<StockMedicamento>().codigoStock;
                foreach (StockMedicamento s in cantStocks)
                    if (codigo < s.codigoStock)
                        codigo = s.codigoStock;
                return ++codigo;
            }
        }

        #endregion

        //Al seleccionar el medicamento, el lote y la cantidad lo agrega a una grilla
        //Esta grilla se actualiza cada vez que se agrega un nuevo medicamento
        //Luego estos datos de la grilla se van a guardar en un movimiento cuando el usuario presione en aceptar


        protected void bt_cancel_Click(object sender, ImageClickEventArgs e)
        {

        }



    }
}