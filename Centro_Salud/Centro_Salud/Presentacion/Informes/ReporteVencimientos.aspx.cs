using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace Centro_Salud.Presentacion.Informes
{
    public partial class ReporteVencimientos : System.Web.UI.Page
    {
        IUsuario logueado = new IUsuario();
        SmtpClient client = new SmtpClient();
        MailMessage msg = new MailMessage();
        Attachment adjunto;
        String destinatario = null;
        Usuario userLogueado = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtiene usuario logueado
            Session["UsuarioLogueado"] = Session["VariableUser"].ToString();
            
        }

        protected void bt_Enviar_Click(object sender, EventArgs e)
        {
            //Recupera el usuario logueado al sistema
            String usLogueado = Session["UsuarioLogueado"].ToString();
            Usuario userLogueado = logueado.getPorCriterio<Usuario>(usLogueado).First<Usuario>();
            destinatario = userLogueado.mail;

            //Si tiene permiso para recibir mails, lo agrega a los destinatarios
            if (userLogueado.recibeAlertas == true)
            {
                msg.To.Add(destinatario);
            }

            //enviar mail al proveedor y al usuario logueado
            msg.To.Add("sistema.salud.maipu@gmail.com");

            //Busca el mail del pedido 
            string Body = System.IO.File.ReadAllText(Server.MapPath("MailVencimientos.htm"));
            msg.Body = Body;
            msg.IsBodyHtml = true;

            //Busca el adjunto-debe enviarle el pedido adjunto--
            // adjunto = new Attachment("C:adjunto.txt"); //lo adjuntamos
            msg.Attachments.Add(new Attachment(@"C:\Users\ale\Downloads\ReporteVto.pdf"));

            //Envìa desdel el mail del sistema
            msg.From = new MailAddress("sistema.salud.maipu@gmail.com");

            //Configura el asunto del mail
            msg.Subject = "Centro Salud-Información";

            client.Credentials = new NetworkCredential("sistema.salud.maipu@gmail.com", "sistemamaipu");
            client.Host = "smtp.gmail.com";
            client.Port = 25;
            client.EnableSsl = true;

            //Envìa el mail
            client.Send(msg);

            //Enviar mensaje de pedido generado
            String msj = "El reporte ha sido enviado correctamente.";

            mostrarMensaje(msj);
          
        }
        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }

        protected void bt_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }


    }
}