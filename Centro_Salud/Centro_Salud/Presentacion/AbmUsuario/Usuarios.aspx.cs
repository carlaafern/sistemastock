using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Centro_Salud.Presentacion.AbmUsuario
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            mostrarMensaje("Algo");

        }
        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'> var answer=confirm(¿Desea crear usuario para esta persona?) if(answer) alert (msj) else alert (msj)</script>");
        }
    }
}