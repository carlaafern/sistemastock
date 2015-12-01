using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;

namespace Centro_Salud.Presentacion.AbmEnfermedad
{
    public partial class EditarEnfermedad : System.Web.UI.Page
    {
        IList<Enfermedad> enfermedad = null;
        IEnfermedad iEnf = new IEnfermedad();
        CentroSaludDatosDataContext enf = new CentroSaludDatosDataContext();
        //este bool es para obligarme a actualizar antes de guardar
        static bool guardado = false;
        string conque;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Buscar_Click(object sender, EventArgs e)
        {
            conque = txt_nombreEnf.Text;
            llenar(conque);
        }

        //Método para llenar la grilla de Enfermedades
        public void llenar(string conque)
        {
            String msj;
            List<Enfermedad> listaEnf = new List<Enfermedad>();
            gv_Enfermedad.ShowHeaderWhenEmpty = true;
            try
            {
                //Busca según lo que ingrese en el textbox
                bt_guardar.Visible = true;
                bt_cancelar.Visible = true;
                if (conque != "")
                {
                    enfermedad = iEnf.getPorCriterio<Enfermedad>(conque);

                    if (enfermedad.Count == 0)
                    {
                        msj = "La enfermedad no existe. Por favor verifique.";
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");
                        bt_guardar.Visible = false;
                        bt_cancelar.Visible = false;
                    }
                    else
                    {
                        gv_Enfermedad.DataSource = enfermedad;
                        gv_Enfermedad.DataBind();
                        bt_guardar.Visible = true;
                        bt_cancelar.Visible = true;
                    }
                }
                //Si no ingresa nada, busca todas las enfermedades
                else
                {
                    enfermedad = iEnf.getAll<Enfermedad>();

                    foreach (Enfermedad e in enfermedad)
                    {
                        if (e.fechaBaja == null)
                            listaEnf.Add(e);

                    }
                    //Si hay enfermedades
                    if (listaEnf.Count != 0)
                    {

                        gv_Enfermedad.DataSource = listaEnf;
                        gv_Enfermedad.DataBind();
                        bt_guardar.Visible = true;
                        bt_cancelar.Visible = true;
                    }
                    //si no hay ninguna especialidad
                    else
                    {
                        bt_guardar.Visible = false;
                        bt_cancelar.Visible = false;
                        msj = "No hay enfermedades";
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

        public void ActualizarEnfermedades(String nom, int diasReposo, String tratamiento)
        {
            Enfermedad enfermedad = iEnf.getPorCriterio<Enfermedad>(nom).First();
            enfermedad.tratamiento = tratamiento;
            enfermedad.diasReposo = diasReposo;

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
                txt_nombreEnf.Text = "";

                guardado = false;
            }
        }

        //Este método le coloca una fecha de baja a la Enfermedad, y se deja de mostrar en la grilla
        protected void gvEnfermedad_Eliminar(object sender, GridViewDeleteEventArgs e)
        {
            int codigo = Convert.ToInt32(gv_Enfermedad.Rows[e.RowIndex].Cells[1].Text);
            String nombre = gv_Enfermedad.Rows[e.RowIndex].Cells[2].Text;
            
            iEnf.Delete(codigo);
            txt_nombreEnf.Text = "";
            guardado = true;
            //En caso que elimine un solo elemento
            IList<Enfermedad> sp = iEnf.getPorCriterio<Enfermedad>(nombre);
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

            DropDownList combo = (DropDownList)gv_Enfermedad.Rows[e.RowIndex].Cells[3].FindControl("ddl_complejidad");
            //int diasReposo = Convert.ToInt32(combo.SelectedValue);

            String diasReposo = ((TextBox)(row.Cells[4].Controls[0])).Text;
            String nombre = row.Cells[2].Text;
            String tratamiento = ((TextBox)(row.Cells[3].Controls[0])).Text;

            ActualizarEnfermedades(nombre, Convert.ToInt32(diasReposo), tratamiento);
            llenar(nombre);
        }  
    }
  }
