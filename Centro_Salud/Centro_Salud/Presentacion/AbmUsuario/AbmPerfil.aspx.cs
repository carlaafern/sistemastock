using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;


namespace Centro_Salud.Presentacion.AbmUsuario
{
    public partial class AbmPerfil : System.Web.UI.Page
    {
        Perfil perfil;
        IPerfil iPer = new IPerfil();

        //IPrivilegio iPriv = new IPrivilegio();
        //IList<Privilegio> privilegios;

        int nivel_requerido;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int generarCodigo()
        {
            int codigo = 0;
            List<Perfil> cantPer = iPer.getAll<Perfil>();

            if (cantPer.Count == 0)
                return 1;
            else
            {
                codigo = cantPer.First<Perfil>().codigoPerfil;
                foreach (Perfil p in cantPer)
                    if (codigo < p.codigoPerfil)
                        codigo = p.codigoPerfil;
                return ++codigo;
            }
        }

        public void cancelar(object sender, EventArgs e) { txt_descripcion.Text = ""; }

        public void crearPerfil(object sender, EventArgs e)
        {
            try
            {
                perfil = new Perfil();
                perfil.descripcion = txt_descripcion.Text.ToString();
                //Privilegio priv = iPriv.getPorCriterio<Privilegio>(ddl_privilegio.SelectedValue.ToString()).First<Privilegio>();
                //perfil.privilegio = priv.codigoPrivilegio;


                perfil.codigoPerfil = generarCodigo();

                iPer.save<Perfil>(perfil);

                txt_descripcion.Text = "";

                String msj = "El perfil ha sido creado correctamente.";
                Intermediario.confirmarCambios();
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

            }
            catch (Exception) { }
        }
        //protected void buscarPrivilegios(object sender, EventArgs e)
        //{
        //    String usar = ddl_privilegio.SelectedValue;
        //    Privilegio permiso = iPriv.getPorCriterio<Privilegio>(usar).First<Privilegio>();

        //    privilegios = iPriv.getCriterioById<Privilegio>("", "", permiso.codigoPrivilegio);
        //    List<String> lista = new List<string>();

        //    foreach (Privilegio l in privilegios)
        //    {
        //        lista.Add(l.descripcion);
        //    }

        //    ddl_privilegio.DataSource = lista;

        //    ddl_privilegio.DataBind();

        //}

    }
}
