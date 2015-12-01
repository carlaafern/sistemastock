using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;

namespace Centro_Salud.Presentacion.AbmEspecialidad
{
    public partial class EditarEspecialidad : System.Web.UI.Page
    {
        IList<Especialidad> especialidad = null;
        IEspecialidad iEsp = new IEspecialidad();
        CentroSaludDatosDataContext esp = new CentroSaludDatosDataContext();
        List<Especialidad> sp;
        
        //este bool es para obligarme a actualizar antes de guardar
        static bool guardado = false;
        //variable usada para hacer la búsqueda de la Especialidad
        String conque;

        protected void Page_Load(object sender, EventArgs e)
        {

        }  

        //tomar el valor ingresado en el textbox para buscar
        //o busca todo si no se ingresa valor
        protected void bt_Buscar_Click(object sender, EventArgs e)
        {
            conque = txt_nombreEsp.Text;
            llenar(conque);
        }


       //Método para llenar la grilla de Especialidades
        public void llenar(string conque)
        {
            String msj;
            List<Especialidad> listaEsp=new List<Especialidad>();
            gv_Especialidad.ShowHeaderWhenEmpty = true;
            try
            {
                //Busca según lo que ingrese en el textbox
                bt_Guardar.Visible = true;
                bt_Cancelar.Visible = true;
                if (conque != "")
                {
                    especialidad = iEsp.getPorCriterio<Especialidad>(conque);

                    if (especialidad.Count == 0)
                    {
                        msj = "La especialidad no existe. Por favor verifique.";
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");
                        bt_Guardar.Visible = false;
                        bt_Cancelar.Visible = false;
                    }
                    else
                    {
                        gv_Especialidad.DataSource = especialidad;
                        gv_Especialidad.DataBind();
                        bt_Guardar.Visible = true;
                        bt_Cancelar.Visible = true;
                    }
                }
                //Si no ingresa nada, busca todas las especialidades
                else
                {
                    especialidad = iEsp.getAll<Especialidad>();

                    foreach (Especialidad e in especialidad){
                        if (e.fechaBaja == null) 
                            listaEsp.Add(e);
                        
                    }
                    //Si hay especialidades
                    if (listaEsp.Count != 0)
                    {

                        gv_Especialidad.DataSource = listaEsp;
                        gv_Especialidad.DataBind();
                        bt_Guardar.Visible = true;
                        bt_Cancelar.Visible = true;
                    }
                    //si no hay ninguna especialidad
                    else
                    {
                        bt_Guardar.Visible = false;
                        bt_Cancelar.Visible = false;
                        msj = "No hay especialidades";
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

        protected void gvEspecialidad_Editar(object sender, GridViewEditEventArgs e)
        {
            int fila=e.NewEditIndex;
            gv_Especialidad.EditIndex = e.NewEditIndex;
            GridViewRow row = gv_Especialidad.Rows[fila];          
            conque = row.Cells[2].Text;
            llenar(conque);

        }

        //actualiza la base de datos
        public void ActualizarEspecialidades(String nom, int complejidad, int anios)
        {
            Especialidad especialidad = iEsp.getPorCriterio<Especialidad>(nom).First();
            especialidad.complejidad = complejidad;
            especialidad.añosEspecialidad = anios;

            guardado = true;
        }

        //Toma los nuevos valores ingresados en la grilla   
        protected void gvEspecialidad_Actualizar(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gv_Especialidad.Rows[e.RowIndex];
            gv_Especialidad.EditIndex = -1;
            String codigo = row.Cells[1].Text;

            DropDownList combo = (DropDownList)gv_Especialidad.Rows[e.RowIndex].Cells[3].FindControl("ddl_complejidad");
            int complejidad=Convert.ToInt32(combo.SelectedValue);
        
            String anios = ((TextBox)(row.Cells[4].Controls[0])).Text;
            String nombre = row.Cells[2].Text;

            //llama al metodo para actualizar la base de datos
            ActualizarEspecialidades(nombre, complejidad, Convert.ToInt32(anios));

            //este metodo es para refrescar el contenido de la grilla
            llenar(nombre);
        }

        protected void bt_Guardar_Click(object sender, EventArgs e)
        {
            //para asegurarme que se haya actualizado la base de datos
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
                txt_nombreEsp.Text = "";

                guardado = false;
            }
        }

        //Este método le coloca una fecha de baja a la Especialidad, y se deja de mostrar en la grilla
        protected void gvEspecialidad_Eliminar(object sender, GridViewDeleteEventArgs e)
        {
            int codigo = Convert.ToInt32(gv_Especialidad.Rows[e.RowIndex].Cells[1].Text);
            String nombre = gv_Especialidad.Rows[e.RowIndex].Cells[2].Text;
            iEsp.Delete(codigo);
            txt_nombreEsp.Text = "";
            guardado = true;
            //En caso que elimine un solo elemento
            //Muestra solo el encabezado de la grilla, sin esa especialidad
            IList<Especialidad> sp = iEsp.getPorCriterio<Especialidad>(nombre);
            gv_Especialidad.DataSource = sp;
            gv_Especialidad.DataBind();
        }

        protected void bt_Cancelar_Click(object sender, EventArgs e)
        {
            //Antes tengo que mostrar un mensaje
            bt_Guardar.Visible = false;
            bt_Cancelar.Visible = false;
            gv_Especialidad.Visible = false;
        }    
      
    }
}