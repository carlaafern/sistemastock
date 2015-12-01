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
    public partial class ABMLotes : System.Web.UI.Page
    {  
        private List<Object> lista = new List<Object>();
        private ILote iLote = new ILote();
        private List<Lote> lotis = new List<Lote>();
        Lote lote;
        
        protected void FechaVto_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            DateTime.TryParse(ChosenDate.Text, out dt);

            CalendarPicker1.SelectedDate = dt;
            CalendarPicker1.VisibleDate = dt;
        }

        protected void ChosenDate_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            DateTime.TryParse(ChosenDate.Text, out dt);

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
                ChosenDate.Text = CalendarPicker.SelectedDate.ToShortDateString();
                DatePickerPopOut.Visible = false;
        }
        private void SetDateSelectionAndVisible1()
        {
            if (CalendarPicker1.SelectedDates.Count != 0)
                fechaVencimiento.Text = CalendarPicker1.SelectedDate.ToShortDateString();
                DatePickerPopOut1.Visible = false;
        }
 

        protected void Page_Load(object sender, EventArgs e)
        {
            //bt_guardar.Visible = false;
            //bt_cancelar.Visible = false;
        }

        //Guarda el lote
        public void crearLote(object sender, EventArgs e)
        {
            try
            {
               lote = new Lote();
               lote.nroLote = int.Parse(nroLote.Text);
               lote.fechaElaboracion = DateTime.Parse(ChosenDate.Text);
               lote.fechaVto = DateTime.Parse(fechaVencimiento.Text);
               
                //comparar ambas fechas para que fechaElab < fechaVto
            
                iLote.save<Lote>(lote);
                
   
                String msj = "El lote ha sido creado correctamente.";
                Intermediario.confirmarCambios();
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

                nroLote.Text = null;
                ChosenDate.Text = null;
                fechaVencimiento.Text = null;

            }
            catch (Exception) { }
        }

        protected void bt_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Presentacion/Inicio.aspx");

        }

       
        

        

      
       
    }
}