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

namespace Centro_Salud.Presentacion.AbmUsuario
{
    public partial class ConsultaUsuarios : System.Web.UI.Page
    {
        IList<Usuario> usuario = null;
        IUsuario iUs = new IUsuario();
        CentroSaludDatosDataContext med = new CentroSaludDatosDataContext();
        //este bool es para obligarme a actualizar antes de guardar
        static bool guardado = false;
        string conque;
        private Perfil per = new Perfil();
        IPerfil iPerf = new IPerfil();
        
  
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Buscar_Click(object sender, EventArgs e)
        {   
            conque = txt_nombreUs.Text;
            llenar(conque);
            
        }

        //Método para llenar la grilla de Enfermedades
        public void llenar(string conque)
        {
            String msj;
            List<Usuario> listaUS = new List<Usuario>();
            gv_Usuarios.ShowHeaderWhenEmpty = true;
            try
            {
                //Busca según lo que ingrese en el textbox
                bt_guardar.Visible = true;
                bt_Imprimir.Visible = true;
                bt_cancelar.Visible = true;
                if (conque != "")
                {
                    usuario = iUs.getPorCriterio<Usuario>(conque);

                    if (usuario.Count == 0)
                    {
                        msj = "El usuario no existe. Por favor verifique.";
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");
                        bt_guardar.Visible = false;
                        bt_Imprimir.Visible = false;
                        bt_cancelar.Visible = false;
                    }
                    else
                    {
                        gv_Usuarios.DataSource = usuario;
                        gv_Usuarios.DataBind();
                        bt_guardar.Visible = true;
                        bt_Imprimir.Visible = true;
                        bt_cancelar.Visible = true;
                    }
                }
                //Si no ingresa nada, busca todas los usuarios
                else
                {
                    usuario = iUs.getAll<Usuario>();

                    //al editar la contraseña encriptar antes de guardar el objeto en bd
                    foreach (Usuario e in usuario)
                    {
                        if (e.estado == true)
                        {
                          listaUS.Add(e);
                        }
                    }
                    //Si hay usuarios
                    if (listaUS.Count != 0)
                    {

                        gv_Usuarios.DataSource = listaUS;
                        gv_Usuarios.DataBind();
                        bt_guardar.Visible = true;
                        bt_Imprimir.Visible = true;
                        bt_cancelar.Visible = true;
                    }
                    //si no hay ningun usuario
                    else
                    {
                        bt_guardar.Visible = false;
                        bt_Imprimir.Visible = true;
                        bt_cancelar.Visible = false;
                        msj = "No hay usuarios";
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


        public void ActualizarUsuarios(String nombre, String password, String estado, int perfil, string email, string alerta)
        {
            Usuario usuario = iUs.getPorCriterio<Usuario>(nombre).First();
            usuario.contraseña = password;
            usuario.estado = bool.Parse(estado);
            usuario.perfil = perfil;
            usuario.mail = email;
            usuario.recibeAlertas = bool.Parse(alerta);

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
                txt_nombreUs.Text = "";

                guardado = false;
            }
        }

        protected void bt_cancelar_Click(object sender, EventArgs e)
        {
            //Antes tengo que mostrar un mensaje
            bt_guardar.Visible = false;
            bt_Imprimir.Visible = true;
            bt_cancelar.Visible = false;
            gv_Usuarios.Visible = false;
        }

        
        //Este método le coloca el estado en false, y se deja de mostrar en la grilla
        protected void gvUsuario_Eliminar(object sender, GridViewDeleteEventArgs e)
        {
            int codigo = Convert.ToInt32(gv_Usuarios.Rows[e.RowIndex].Cells[1].Text);
            String nombre = gv_Usuarios.Rows[e.RowIndex].Cells[2].Text;

            iUs.Delete(codigo);
            txt_nombreUs.Text = "";
            guardado = true;
            //En caso que elimine un solo elemento
            IList<Usuario> sp = iUs.getPorCriterio<Usuario>(nombre);
            gv_Usuarios.DataSource = sp;
            gv_Usuarios.DataBind();

        }

        protected void gvUsuario_Editar(object sender, GridViewEditEventArgs e)
        {
            int fila = e.NewEditIndex;
            gv_Usuarios.EditIndex = e.NewEditIndex;
            GridViewRow row = gv_Usuarios.Rows[fila];
            conque = row.Cells[2].Text;
            llenar(conque);
        }

        protected void gvUsuario_Actualizar(object sender, GridViewUpdateEventArgs e)
        {
           
            GridViewRow row = gv_Usuarios.Rows[e.RowIndex];
            gv_Usuarios.EditIndex = -1;
            String codigo = row.Cells[1].Text;
            String nombre = row.Cells[2].Text;
            //Encripta la contraseña 123456
           // String cel1 = ((TextBox)(row.Cells[2].Controls[0])).Text;
            String cel2=((TextBox)(row.Cells[3].Controls[0])).Text;
            String password = Encripta.EncodePassword(String.Concat(nombre,cel2));   //Encripta.EncodePassword(string.Concat(,"123456"));
           
            DropDownList comboPerfil = (DropDownList)gv_Usuarios.Rows[e.RowIndex].Cells[5].FindControl("ddl_perfiles");
            String perfil = comboPerfil.SelectedValue;
            per = iPerf.getPorCriterio<Perfil>(perfil).First();

            DropDownList comboEstado = (DropDownList)gv_Usuarios.Rows[e.RowIndex].Cells[4].FindControl("ddl_estados");
            String estado = comboEstado.SelectedItem.Text;

            String email = ((TextBox)(row.Cells[6].Controls[0])).Text;

            DropDownList comboAlertas = (DropDownList)gv_Usuarios.Rows[e.RowIndex].Cells[7].FindControl("ddl_alertas");
            String alerta = comboAlertas.SelectedItem.Text;
           
            ActualizarUsuarios(nombre, password, estado, per.codigoPerfil, email, alerta);
            llenar(nombre);
        }

        protected void bt_Imprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Presentacion/Informes/ReporteUsuarios.aspx", false);
        }
 
    }
  }
