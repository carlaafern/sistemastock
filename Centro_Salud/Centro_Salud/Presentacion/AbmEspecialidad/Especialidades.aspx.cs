using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;

namespace Centro_Salud.Presentacion.AbmEspecialidad
{
    public partial class Especialidades : System.Web.UI.Page
    {
        Especialidad especialidad;
        IEspecialidad iEsp=new IEspecialidad();
    

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int generarCodigo()
        {
            int codigo=0;
            List<Especialidad> cantEsp=iEsp.getAll<Especialidad>();

            if (cantEsp.Count == 0)
                return 1;
            else
            {
                codigo = cantEsp.First<Especialidad>().codigoEspecialidad;
                foreach (Especialidad e in cantEsp)
                    if (codigo < e.codigoEspecialidad)
                        codigo = e.codigoEspecialidad;
                return ++codigo;
            }
        }



        public void crearEspecialidad(object sender, EventArgs e)
        {
            try
            {
                String comparar;
                Especialidad compEsp;
                especialidad = new Especialidad();

                    especialidad.descripcionEspecialidad = txt_nombre.Text.ToString();
                    especialidad.complejidad = int.Parse(ddl_complejidad.SelectedItem.Value);
                    especialidad.añosEspecialidad = int.Parse(txt_anios.Text);

                    especialidad.codigoEspecialidad = generarCodigo();

                    iEsp.save<Especialidad>(especialidad);
                    txt_nombre.Text = "";
                    ddl_complejidad.SelectedIndex = 0;
                    txt_anios.Text = "";
                    String msj = "La especialidad ha sido creado correctamente.";
                    Intermediario.confirmarCambios();
                    mostrarMensaje(msj);
              }
        
            catch (Exception) { }
        }

        protected void CompararEspecialidad(object sender, EventArgs e)
        {
            String comparar;
            comparar = txt_nombre.Text.ToString();
            String mensaje;
            IList<Especialidad> lista=iEsp.getPorCriterio<Especialidad>(comparar);
            if ( lista.Count!=0)
            {
                mensaje = "Ya existe Especialidad con este nombre";
                txt_nombre.Text = "";
                mostrarMensaje(mensaje);
            }
        }

        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }
    }
}