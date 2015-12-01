using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Centro_Salud.Login
{
    public partial class Login : System.Web.UI.Page
    {
        IUsuario iUsuario = new IUsuario();
        Usuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
          //  RegisterHyperLink.NavigateUrl = "~/Presentacion/RegistroUsuario.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        public void mostrarMensaje(String mensaje)
        {

            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }

        protected void loginUsuario(object sender, EventArgs e)
        {
            try
            {
                String msj = "";
                String continueUrl;

                //Verifica si ingresa nombre de Usuario   
                //Si no ingresa entra acá
                if (txt_nombre.Text == "")
                {

                    msj = "Debe ingresar Usuario para ingresar al sistema";
                    mostrarMensaje(msj);
                    continueUrl = "~/";

                }
                //Si ingresa usuario, lo busca
                else
                {
                    IList<Usuario> u = iUsuario.getPorCriterio<Usuario>(txt_nombre.Text);

                   //si no existe
                    if (u.Count == 0)
                    {
                        String msj2 = "El usuario no existe. Por favor verifique.";
                        mostrarMensaje(msj2);
                        txt_nombre.Text = "";
                        continueUrl = "~/";    //Response.Redirect("Login.aspx", false);
                    }
                    else
                    {
                        //si existe verifica su password
                        usuario = u.First<Usuario>();    

                        if (usuario.contraseña != txt_password.Text.Trim())
                        {
                            msj = "El usuario o password ingresado es incorrecto. Intente nuevamente o regístrese";
                            mostrarMensaje(msj);
                            txt_nombre.Text = "";
                            continueUrl = "~/";
                        }
                        else
                        {
                            //Da el permiso al usuario para poder acceder al menú

                            FormsAuthentication.RedirectFromLoginPage(txt_nombre.Text.Trim(), false);
                        }

                    }
                }
            }

            catch (Exception)
            {

            }
         
         

        }
      
    }
}

        