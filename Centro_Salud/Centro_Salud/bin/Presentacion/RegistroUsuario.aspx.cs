using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;

namespace Centro_Salud.Presentacion
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        Usuario usuario;
        IUsuario iUs=new IUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void crearUsuario(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();
                usuario.login = txt_nombre.Text.Trim();
                usuario.contraseña = txt_password.Text.Trim();
                usuario.fechaVigencia = DateTime.Now.Date;
                //verificar el tipo del estado
                usuario.estado = null;

                iUs.save<Usuario>(usuario);
                String msj="El usuario ha sido creado correctamente.";
                Intermediario.confirmarCambios();
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

                //string continueUrl = "Inicio.aspx";

                //if (String.IsNullOrEmpty(continueUrl))
                //{
                //    continueUrl = "~/";
                //}
                //Response.Redirect(continueUrl);


            }
            catch (Exception) {
               
            }
        }


       
    }
}