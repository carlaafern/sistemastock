using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;

namespace Centro_Salud.Presentacion.ParametrosSistema
{
    public partial class ConfigurarStockM : System.Web.UI.Page
    {
        //IList<StockMedicamento> stockmedicamento = null;
        //IStockMedicamento iStockMed = new IStockMedicamento();

        IList<Medicamento> medicamento = null;
        IMedicamento iMed = new IMedicamento();

        CentroSaludDatosDataContext med = new CentroSaludDatosDataContext();
        //este bool es para obligarme a actualizar antes de guardar
        static bool guardado = false;
        string conque;
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Buscar_Click(object sender, EventArgs e)
        {
            conque = txt_nombreMed.Text;
            llenar(conque);
        }

        //Método para llenar la grilla de Enfermedades
        public void llenar(string conque)
        {
            String msj;
            List<Medicamento> listaMed = new List<Medicamento>();
            gv_Enfermedad.ShowHeaderWhenEmpty = true;
            try
            {
                //Busca según lo que ingrese en el textbox
                bt_guardar.Visible = true;
                bt_cancelar.Visible = true;
                if (conque != "")
                {
                    medicamento = iMed.getCriterioById<Medicamento>("","", Convert.ToInt32(conque));
                    
                    if (medicamento.Count == 0)
                    {
                        msj = "El medicamento no existe. Por favor verifique.";
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");
                        bt_guardar.Visible = false;
                        bt_cancelar.Visible = false;
                    }
                    else
                    {
                        gv_Enfermedad.DataSource = medicamento;
                        gv_Enfermedad.DataBind();
                        bt_guardar.Visible = true;
                        bt_cancelar.Visible = true;
                    }
                }
                //Si no ingresa nada, busca todas los medicamentos
                else
                {
                    medicamento = iMed.getAll<Medicamento>();

                    foreach (Medicamento e in medicamento)
                    {
                        listaMed.Add(e);

                    }
                    //Si hay medicamento
                    if (listaMed.Count != 0)
                    {

                        gv_Enfermedad.DataSource = listaMed;
                        gv_Enfermedad.DataBind();
                        bt_guardar.Visible = true;
                        bt_cancelar.Visible = true;
                    }
                    //si no hay ningun medicamento
                    else
                    {
                        bt_guardar.Visible = false;
                        bt_cancelar.Visible = false;
                        msj = "No hay medicamentos";
                        mostrarMensaje(msj);
                    }
                }
            }

            catch (Exception)
            {
            }
        }

        //Este método implementa mensajes
        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }

        protected void gvEnfermedad_Editar(object sender, GridViewEditEventArgs e)
        {
            int fila = e.NewEditIndex;
            gv_Enfermedad.EditIndex = e.NewEditIndex;
            GridViewRow row = gv_Enfermedad.Rows[fila];
            conque = row.Cells[1].Text;
            llenar(conque);

        }

        public void ActualizarEnfermedades(String cod, String stockMin, String stockAlert, String stockMax, String diasAlert)
        {
            Medicamento medicamento1 = iMed.getCriterioById<Medicamento>("","",Convert.ToInt32(cod)).First();

            medicamento1.stockMinimo = Convert.ToInt32(stockMin);
            medicamento1.stockAlerta = Convert.ToInt32(stockAlert);
            medicamento1.stockMaximo = Convert.ToInt32(stockMax);
            medicamento1.diasAlertas = Convert.ToInt32(diasAlert);

            guardado = true;
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            if (guardado == false)
            {
                String msj1 = "Debe actualizar la grilla antes de guardar.";
                mostrarMensaje(msj1);

            }
            else
            {
                Intermediario.confirmarCambios();
                String msj = "Los cambios han sido guardados correctamente";

                mostrarMensaje(msj);
                txt_nombreMed.Text = "";

                guardado = false;
            }
        }

        //Este método le coloca una fecha de baja a la Enfermedad, y se deja de mostrar en la grilla
        protected void gvEnfermedad_Eliminar(object sender, GridViewDeleteEventArgs e)
        {
            int codigo = Convert.ToInt32(gv_Enfermedad.Rows[e.RowIndex].Cells[1].Text);
            String nombre = gv_Enfermedad.Rows[e.RowIndex].Cells[2].Text;

            iMed.Delete(codigo);
            txt_nombreMed.Text = "";
            guardado = true;
            //En caso que elimine un solo elemento
            IList<Medicamento> sp = iMed.getPorCriterio<Medicamento>(nombre);
            gv_Enfermedad.DataSource = sp;
            gv_Enfermedad.DataBind();
        }

        protected void bt_cancelar_Click(object sender, EventArgs e)
        {
            //Antes tengo que mostrar un mensaje
            bt_guardar.Visible = false;
            bt_cancelar.Visible = false;
            gv_Enfermedad.Visible = false;
        }

        protected void gvEnfermedad_Actualizar(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = gv_Enfermedad.Rows[e.RowIndex];
            gv_Enfermedad.EditIndex = -1;
            String codigo = row.Cells[1].Text;

            String stockMin = ((TextBox)(row.Cells[4].Controls[0])).Text;
            String stockAlert = ((TextBox)(row.Cells[5].Controls[0])).Text;
            String stockMax = ((TextBox)(row.Cells[6].Controls[0])).Text;
            String diasAlert = ((TextBox)(row.Cells[7].Controls[0])).Text;

            
            ActualizarEnfermedades(codigo, stockMin, stockAlert, stockMax, diasAlert);
            llenar(codigo);
        }
    }
}
