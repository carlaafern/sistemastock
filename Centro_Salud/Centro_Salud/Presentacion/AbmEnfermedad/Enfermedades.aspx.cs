using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;

namespace Centro_Salud.Presentacion.AbmEnfermedad
{
     public partial class Enfermedades : System.Web.UI.Page   
    {
        Enfermedad enfermedad;
        IEnfermedad iEnf = new IEnfermedad();
        //String us;
        //IUsuario iUsuario = new IUsuario();
        //Usuario usu = new Usuario();
        //int per;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
         private int generarCodigo()
         {
             int codigo = 0;
             List<Enfermedad> cantEnf = iEnf.getAll<Enfermedad>();

             if (cantEnf.Count == 0)
                 return 1;
             else
             {
                 codigo = cantEnf.First<Enfermedad>().codigoEnfermedad;
                 foreach (Enfermedad e in cantEnf)
                     if (codigo < e.codigoEnfermedad)
                         codigo = e.codigoEnfermedad;
                 return ++codigo;
             }
         }

         public void crearEnfermedad(object sender, EventArgs e)
         {
             try
             {
                 enfermedad = new Enfermedad();
                 enfermedad.descripcionEnfermedad = txt_nombre.Text.ToString();
                 enfermedad.gravedad = int.Parse(dl_gravedad.SelectedItem.Value);
                 enfermedad.tratamiento = txt_tratamiento.Text.ToString();
                 enfermedad.diasReposo = int.Parse(dl_diasReposo.SelectedItem.Value);
                 //enfermedad.requiereInternacion= Boolean.Parse(dl_internacion.SelectedItem.Value);
                 
                 enfermedad.codigoEnfermedad = generarCodigo();

                 iEnf.save<Enfermedad>(enfermedad);
                 txt_nombre.Text = "";
                 dl_gravedad.SelectedIndex = 0;
                 txt_tratamiento.Text = "";
                 String msj = "La enfermedad ha sido creado correctamente.";
                 Intermediario.confirmarCambios();
                 this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

             }
             catch (Exception) { }
         }
    }
}