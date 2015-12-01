using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Centro_Salud.Presentacion.Movimientos
{
    public partial class ConsultarMovimientos : System.Web.UI.Page
    {
       
        IMovimientoStock iMovStk = new IMovimientoStock();
        IDetalleMovimientoStock iDet = new IDetalleMovimientoStock();
        String conque;
                
        DataTable mov = null;
        private List<TipoMovimiento> listaTM = new List<TipoMovimiento>();
        private ITipoMovimiento iTM = new ITipoMovimiento();
        private List<Object> listaT = new List<object>();
        TipoMovimiento tipoMov = new TipoMovimiento();
        private Medicamento med = new Medicamento();
        IMedicamento iMed = new IMedicamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (listaTM.Count == 0)
            {
                listaTM = iTM.getAll<TipoMovimiento>();

                foreach (TipoMovimiento tm in listaTM)
                {
                    listaT.Add(tm.descripcionTipoMov);
                }

                ddl_tipoMov.Enabled = true;
                ddl_tipoMov.DataSource = listaT;
                ddl_tipoMov.DataBind();
                
            }
        }

        protected void bt_Buscar_Click(object sender, EventArgs e)
        {   
            conque = ddl_tipoMov.SelectedValue;
            tipoMov = iTM.getPorCriterio<TipoMovimiento>(conque).First<TipoMovimiento>();

            llenar(tipoMov.codigoTipoMov);
            
        }

        //Método para llenar la grilla 
        public void llenar(int conque)
        {
           
            List<MovimientoStock> listaMov = new List<MovimientoStock>();
              
            listaMov = iMovStk.getAll<MovimientoStock>();
            IList<DetalleMovimientoStock> listaStk;

            IList<DetalleMovimientoStock> listaDet;
            
            int totalActual = 0;
           
            mov = new DataTable();

            mov.Columns.Add("nroMovimiento");
            mov.Columns.Add("tipo");
            mov.Columns.Add("nroComprobante");
            mov.Columns.Add("fecha");
            mov.Columns.Add("codigoMedicamento");
            mov.Columns.Add("descripcion");
            mov.Columns.Add("cantidad");
            mov.Columns.Add("lote");
            mov.AcceptChanges();



            foreach (MovimientoStock m in listaMov)
            {
                if (m.tipoMovimiento == Convert.ToInt32(conque))
                {
                    if (m.fechaMovimiento >= Convert.ToDateTime(txt_fechaDesde.Text)) 
                    {
                        if (m.fechaMovimiento <= Convert.ToDateTime(txt_fechaHasta.Text))
                        {

                        listaStk = iDet.getCriterioById<DetalleMovimientoStock>("", "", m.nroMovimiento);

                        foreach (DetalleMovimientoStock stk in listaStk)
                        {
                            totalActual = totalActual + Convert.ToInt32(stk.cantidad);
                            med = iMed.getCriterioById<Medicamento>("", "", Convert.ToInt32(stk.codigoMedicamento)).First<Medicamento>();


                            DataRow fila = mov.NewRow();
                            fila["nroMovimiento"] = m.nroMovimiento;
                            fila["tipo"] = m.tipoMovimiento;
                            fila["nroComprobante"] = m.nroComprobante;
                            fila["fecha"] = m.fechaMovimiento;

                            fila["codigoMedicamento"] = stk.codigoMedicamento;
                            fila["descripcion"] = med.descripcion;
                            fila["cantidad"] = stk.cantidad;
                            fila["lote"] = stk.nroLote;

                            mov.Rows.Add(fila);
                            totalActual = 0;

                        }
                    }
                   }
                 }
            }

            gv_Movimientos.ShowHeaderWhenEmpty = true;
            gv_Movimientos.DataSource = mov; 
            gv_Movimientos.DataBind();

        }

        //Este método implementa mensajes
        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }

        protected void bt_cancelar_Click(object sender, EventArgs e)
        {
            //Antes tengo que mostrar un mensaje
            
            bt_cancelar.Visible = false;
            gv_Movimientos.Visible = false;
        }

                
        protected void bt_Imprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Presentacion/Informes/ReporteMovimientos.aspx", false);
        }

       
        protected void FechaVto_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            DateTime.TryParse(txt_fechaDesde.Text, out dt);

            CalendarPicker1.SelectedDate = dt;
            CalendarPicker1.VisibleDate = dt;
        }

        protected void ChosenDate_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            DateTime.TryParse(txt_fechaDesde.Text, out dt);

            CalendarPicker.SelectedDate = dt;
            CalendarPicker.VisibleDate = dt;
        }
        protected void Close_Click(object sender, EventArgs e)
        {
            SetDateSelectionAndVisible();
        }

        protected void ShowDatePickerPopOut_Click(object sender, ImageClickEventArgs e)
        {
            DatePickerPopOut.Visible = !DatePickerPopOut.Visible;
        }
        protected void ShowDatePickerPopOut1_Click(object sender, ImageClickEventArgs e)
        {
            DatePickerPopOut1.Visible = !DatePickerPopOut1.Visible;
        }

        protected void CalendarPicker_SelectionChanged(object sender, EventArgs e)
        {
            SetDateSelectionAndVisible();
        }
        protected void CalendarPicker1_SelectionChanged(object sender, EventArgs e)
        {
            SetDateSelectionAndVisible1();
        }

        private void SetDateSelectionAndVisible()
        {
            if (CalendarPicker.SelectedDates.Count != 0)
                txt_fechaDesde.Text = CalendarPicker.SelectedDate.ToShortDateString();
            DatePickerPopOut.Visible = false;
        }
        private void SetDateSelectionAndVisible1()
        {
            if (CalendarPicker1.SelectedDates.Count != 0)
                txt_fechaHasta.Text = CalendarPicker1.SelectedDate.ToShortDateString();
            DatePickerPopOut1.Visible = false;
        }
 
    }
  }
