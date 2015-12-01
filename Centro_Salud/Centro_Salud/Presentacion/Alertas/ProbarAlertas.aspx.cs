using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Configuration;
using System.IO;

namespace Centro_Salud.Presentacion.Alertas
{
    public partial class ProbarAlertas : System.Web.UI.Page
    {
        SmtpClient client=new SmtpClient();
        MailMessage msg=new MailMessage();
        Attachment adjunto;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void bt_enviar_Click(object sender, EventArgs e)
        {
            
            string Body = System.IO.File.ReadAllText(Server.MapPath("Mails/mail.htm"));
            adjunto = new Attachment("C:adjunto.txt"); //lo adjuntamos
            msg.Attachments.Add(adjunto);

            msg.Body = Body;
            msg.IsBodyHtml = true;
           
            msg.From = new MailAddress("sistema.salud.maipu@gmail.com");
            msg.To.Add("alelopez10@gmail.com");
            msg.Subject = "Centro Salud-Información";
            client.Credentials = new NetworkCredential("sistema.salud.maipu@gmail.com", "sistemamaipu");
            client.Host = "smtp.gmail.com";
            client.Port = 25;
            client.EnableSsl = true;
            client.Send(msg);
            //falta mostrar mensaje de mail enviado!!!!!!!!!!!!!!
            //Darle mejor formato al mail
            //Configurar donde se van guardar los adjuntos..
            //habría que ver donde se generan los reportes!

            

        }
    
    }
}