using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;

namespace Centro_Salud.Presentacion.AbmMedicamentos
{
    public partial class EditarMedicamento : System.Web.UI.Page
    {
        IList<Medicamento> medicamento = null;
        IMedicamento iMed = new IMedicamento();
        CentroSaludDatosDataContext med = new CentroSaludDatosDataContext();
        //este bool es para obligarme a actualizar antes de guardar
        static bool guardado = false;
        string conque;
        private UnidadMedida UM = new UnidadMedida();
        private Formato format = new Formato();
        IUnidadMedida IUnidadM = new IUnidadMedida();
        IFormato IFormat = new IFormato();
        IStockMedicamento iStock = new IStockMedicamento();
        StockMedicamento stock;

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
                    medicamento = iMed.getPorCriterio<Medicamento>(conque);

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
                        if (e.fechaBaja == null)
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
            conque = row.Cells[2].Text;
            llenar(conque);

        }

        public void ActualizarEnfermedades(String nom, String dscAmpl, String monodr, int format, int unidadM)
        {
            Medicamento medicamento = iMed.getPorCriterio<Medicamento>(nom).First();
            medicamento.monoDroga = monodr;
            medicamento.descripcionAmpliada = dscAmpl;
            medicamento.formato = format;
            medicamento.unidadMedida = unidadM;

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
            String msj1;
            int codigo = Convert.ToInt32(gv_Enfermedad.Rows[e.RowIndex].Cells[1].Text);
            String nombre = gv_Enfermedad.Rows[e.RowIndex].Cells[2].Text;
            stock = new StockMedicamento();
            
            stock = iStock.getCriterioById<StockMedicamento>("","",codigo).First();
            if (stock.stockActual <= 0)
            {
                iMed.Delete(codigo);
                txt_nombreMed.Text = "";
                guardado = true;
            }
            else {
                msj1 = "El medicamento tiene stock disponible, no se puede dar de baja";
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj1 + "');</script>");
            }

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

            DropDownList combo = (DropDownList)gv_Enfermedad.Rows[e.RowIndex].Cells[3].FindControl("ddl_formato");
            string formato = combo.SelectedValue;
            format = IFormat.getPorCriterio<Formato>(formato).First();

            DropDownList comboUM = (DropDownList)gv_Enfermedad.Rows[e.RowIndex].Cells[3].FindControl("ddl_unidadMed");
            string unidadMedida = comboUM.SelectedValue;
            UM = IUnidadM.getPorCriterio<UnidadMedida>(unidadMedida).First();
 
            String descripcionAmpl = ((TextBox)(row.Cells[4].Controls[0])).Text;
            String nombre = row.Cells[2].Text;
            String monodroga = ((TextBox)(row.Cells[3].Controls[0])).Text;

            //String formato = ((TextBox)(row.Cells[5].Controls[0])).Text;
            //String undidadMedida = ((TextBox)(row.Cells[6].Controls[0])).Text;
            
            ActualizarEnfermedades(nombre, descripcionAmpl, monodroga, format.codigoPresentacion, UM.codigoUnidadMed);
            llenar(nombre);
        }  
    }
  }
