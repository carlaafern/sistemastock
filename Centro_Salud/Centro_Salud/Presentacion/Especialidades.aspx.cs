using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;

namespace Centro_Salud.Presentacion
{
    public partial class Especialidades : System.Web.UI.Page
    {

        Especialidad especialidad;
        IEspecialidad iEsp=new IEspecialidad();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void crearEspecialidad(object sender, EventArgs e)
        {
            try
            {
                especialidad = new Especialidad();
                especialidad.descripcionEspecialidad = txt_nombre.Text.ToString();
                especialidad.complejidad =int.Parse(txt_complejidad.Text);
                especialidad.añosEspecialidad = int.Parse(txt_anios.Text);
                especialidad.codigoEspecialidad = int.Parse(txt_codigo.Text);

                iEsp.save<Especialidad>(especialidad);
                String msj = "El usuario ha sido creado correctamente.";
                Intermediario.confirmarCambios();
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

            }
            catch (Exception) { }
        }
    }
}