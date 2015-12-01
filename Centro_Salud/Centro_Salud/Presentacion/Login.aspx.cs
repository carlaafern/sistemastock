using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud;
using Centro_Salud.Persistencia;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Centro_Salud.Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        IUsuario iUsuario = new IUsuario();
        Usuario usuario;
        String msj = null;
        String continueUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            // RegisterHyperLink.NavigateUrl = "~/Presentacion/RegistroUsuario.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!IsPostBack)
                Session["VariableUser"] = null;
                
          
        }

        public void mostrarMensaje(String mensaje)
        {

            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }


        public static bool Autenticar(string usuario, string password)
        {
            //Declaramos la sentencia SQL
            string sql = @"SELECT COUNT(*)
                       FROM Usuario
                       WHERE login = @usuario AND contraseña = @password";

            //utilizamos using para indicarle al compilador que dentro de este bloque se llame al Método Dispose.
            //para así liberar recursos cuanto antes mejor. en este caso no ocupamos decirle que cierre la conexión a la base de datos.
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["centro_saludConnectionString1"].ToString()))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@usuario", usuario);
                string hash = Encripta.EncodePassword(string.Concat(usuario, password));
                command.Parameters.AddWithValue("@password", hash);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 0)
                    return false;
                else
                    return true;

            }
        }

        protected void loginUsuario(object sender, EventArgs e)
        {
            //ESTE ES EL CODIGO QUE TIENE QUE QUEDAR
            try
            {
                Session["VariableUser"] = txt_nombre.Text;
                IList<Usuario> u = iUsuario.getPorCriterio<Usuario>(txt_nombre.Text);
                if (u.Count == 0)
                {
                    msj = "El usuario no existe. Por favor verifique.";
                    mostrarMensaje(msj);
                    txt_nombre.Text = "";
                    continueUrl = "~/";

                }
                else
                {
                    usuario = u.First<Usuario>();
                    if (Autenticar(usuario.login, txt_password.Text) == true)
                    {
                        Session["PerfilUser"] = usuario.perfil.ToString();

                        FormsAuthentication.RedirectFromLoginPage(txt_nombre.Text.Trim(), false);

                    }
                    else
                    {

                        msj = "El usuario o password ingresado es incorrecto. Intente nuevamente o regístrese";
                        mostrarMensaje(msj);
                        txt_nombre.Text = "";
                        continueUrl = "~/";

                    }
                }
            }
            catch (Exception)
            {
               
            }


        }
        //ESTO TIENE QUE QUEDAR COMENTADO PARA DESPUÉS BORRARLO
        //Con la contraseña carla el password queda como mOgBua6IjE3Xi4H4uhBFZiVAOn/43/Jhy5xiq9MumR53s5fL0chwSu3gbd1Slr5xKpZLgnUC3AGTf1zIoJkpAw==
        //    try
        //    {
        //        Session["VariableUser"] = txt_nombre.Text;
        //        //Response.Redirect("~/Default.aspx");
        //        String msj = "";
        //        String continueUrl;

        //        //Verifica si ingresa nombre de Usuario   
        //        //Si no ingresa entra acá
        //        if (Session["VariableUser"] == null)
        //        {

        //            msj = "Debe ingresar Usuario para ingresar al sistema";
        //            mostrarMensaje(msj);
        //            continueUrl = "~/";

        //        }
        //        //Si ingresa usuario, lo busca
        //        else
        //        {
        //            IList<Usuario> u = iUsuario.getPorCriterio<Usuario>(txt_nombre.Text);

        //            //si no existe
        //            if (u.Count == 0)
        //            {
        //                String msj2 = "El usuario no existe. Por favor verifique.";
        //                mostrarMensaje(msj2);
        //                txt_nombre.Text = "";
        //                continueUrl = "~/";    //Response.Redirect("Login.aspx", false);
        //            }
        //            else
        //            {
        //                //si existe verifica su password
        //                usuario = u.First<Usuario>();
        //                // String hash = Encripta.EncodePassword(string.Concat(usuario.login, usuario.contraseña));

        //                if (usuario.contraseña != txt_password.Text.Trim())
        //                {
        //                    msj = "El usuario o password ingresado es incorrecto. Intente nuevamente o regístrese";
        //                    mostrarMensaje(msj);
        //                    txt_nombre.Text = "";
        //                    continueUrl = "~/";
        //                }
        //                else
        //                {
        //                    //Da el permiso al usuario para poder acceder al menú
        //                    //Guarda el perfil del usuario para corroborar si tiene permisos

        //                    Session["PerfilUser"] = usuario.perfil.ToString();
        //                    FormsAuthentication.RedirectFromLoginPage(txt_nombre.Text.Trim(), false);
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
    }
}
        