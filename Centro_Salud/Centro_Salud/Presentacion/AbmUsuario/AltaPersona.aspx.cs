using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using System.Globalization;

namespace Centro_Salud.Presentacion.AbmUsuario
{
    public partial class AltaPersona : System.Web.UI.Page
    {
        public CultureInfo Culture { get; set; }
        IPersona iPers = new IPersona();
        IProvincia iProv = new IProvincia();
        IDepartamento iDpto = new IDepartamento();
        ILocalidad iLoc = new ILocalidad();
        IDireccion iDir = new IDireccion();
        ITIpoPersona iTPers = new ITIpoPersona();

        List<Provincia> provincias;
        IList<Departamento> departamentos;
        IList<Localidad> localidades;
        IList<TipoPersona> tipoPers;



        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.Culture == null){
            // this.Culture = CultureInfo.CurrentCulture;
            // this.dateMaskedEditExtender.CultureName = this.Culture.Name;
            // this.cexCalendarExtender.Format = this.Culture.DateTimeFormat.ShortDatePattern;
            //}
            List<String> lista = new List<string>();
            List<String> listaTipos = new List<String>();
            provincias = iProv.getAll<Provincia>();
            tipoPers = iTPers.getAll<TipoPersona>();
            foreach (Provincia p in provincias)
            {
                lista.Add(p.nombreProvincia);
            }
            
            foreach (TipoPersona t in tipoPers)
            {
                listaTipos.Add(t.tipo);
            }
            ddl_provincia.DataSource = lista;
            ddl_tipoPersona.DataSource = listaTipos;
            ddl_provincia.DataBind();
            ddl_tipoPersona.DataBind();
            
        }
        private int generarCodigoPersona()
        {
            int codigo = 0;
            List<Persona> cantPers = iPers.getAll<Persona>();

            if (cantPers == null || cantPers.Count == 0)
                return 1;
            else
            {
                codigo = cantPers.First<Persona>().codigoPersona;
                foreach (Persona p in cantPers)
                    if (codigo < p.codigoPersona)
                        codigo = p.codigoPersona;
                return ++codigo;
            }
        }

        private void limpiarCampos()
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_calle.Text = "";
            txt_nroCalle.Text = "";
            txt_numero.Text = "";
            txt_telefono.Text = "";
            ddl_provincia.SelectedIndex = 0;
            ddl_localidad.SelectedIndex = 0;
            ddl_dpto.SelectedIndex = 0;

        }
        private int generarCodigoDireccion()
        {
            int codigo = 0;
            List<Direccion> cantDirs = iDir.getAll<Direccion>();

            if (cantDirs == null || cantDirs.Count == 0)
                return 1;
            else
            {
                codigo = cantDirs.First<Direccion>().codigoDireccion;
                foreach (Direccion p in cantDirs)
                    if (codigo < p.codigoDireccion)
                        codigo = p.codigoDireccion;
                return ++codigo;
            }
        }

        protected void crearUsuario(object sender, EventArgs e)
        {
            try
            {

                Persona persona = new Persona();
                Direccion direccion = new Direccion();
                String msj;
                persona.nombre = txt_nombre.Text;
                persona.apellido = txt_apellido.Text;
                persona.tipoDocumento = dl_tipoDocumento.Text;
                persona.telefono = txt_telefono.Text;
                persona.dni = txt_numero.Text;
                persona.esActiva = true;
                //  persona.= int.Parse(ddl_persona.Text);

                direccion.calle = txt_calle.Text;
                direccion.codigoDireccion = generarCodigoDireccion();
                direccion.nroCalle = int.Parse(txt_nroCalle.Text);
                Provincia prov = iProv.getPorCriterio<Provincia>(ddl_provincia.SelectedValue.ToString()).First<Provincia>();
                Departamento dpto = iDpto.getPorCriterio<Departamento>(ddl_dpto.SelectedValue.ToString()).First<Departamento>();
                Localidad loc = iLoc.getPorCriterio<Localidad>(ddl_localidad.SelectedValue.ToString()).First<Localidad>();
                direccion.codigoProvincia = prov.codigoProvincia;
                direccion.codigoDepartamento = dpto.codigoDepartamento;
                direccion.codigoLocalidad = loc.codigoLocalidad;

                persona.codigoPersona = generarCodigoPersona();
                persona.codigoDireccion = direccion.codigoDireccion;


                iPers.save<Persona>(persona);
                iDir.save<Direccion>(direccion);

                Intermediario.confirmarCambios();
                msj = "La persona ha sido creada correctamente.";
                mostrarMensaje(msj);
                limpiarCampos();


            }
            catch (Exception)
            {

            }
        }
        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");

            // this.Page.Response.Write("<script languaje='JavaScript'> respuesta=confirm('¿hablas castellano?');if(respuesta){location.href="RegistroUsuario";} else {location.href="LoginView";} </script>");
        }

        protected void buscarDepartamentos(object sender, EventArgs e)
        {
            String usar = ddl_provincia.SelectedValue;
            Provincia provincia = iProv.getPorCriterio<Provincia>(usar).First<Provincia>();
            departamentos = iDpto.getCriterioById<Departamento>("", "", provincia.codigoProvincia);

            List<String> lista = new List<string>();

            foreach (Departamento d in departamentos)
            {
                lista.Add(d.nombreDepartamento);
            }
            ddl_dpto.DataSource = lista;
            ddl_dpto.DataBind();

        }

        protected void buscarLocalidades(object sender, EventArgs e)
        {
            String usar = ddl_dpto.SelectedValue;
            Departamento departamento = iDpto.getPorCriterio<Departamento>(usar).First<Departamento>();
            localidades = iLoc.getCriterioById<Localidad>("", "", departamento.codigoDepartamento);
            List<String> lista = new List<string>();

            foreach (Localidad l in localidades)
            {
                lista.Add(l.nombreLocalidad);
            }
            ddl_localidad.DataSource = lista;
            ddl_localidad.DataBind();
        }

        //protected void elegirFecha(object sender, EventArgs e)
        //{
        //    txt_FechaIngreso.Text = calendario.SelectedDate.ToShortDateString();
        //}

        protected void txt_FechaIngreso_TextChanged(object sender, EventArgs e)
        {

        }




        //protected void txt_FechaIngreso_TextChanged(object sender, EventArgs e)
        //{
        //    txt_FechaIngreso.Text = calendario.SelectedDate.ToShortDateString();
        //}

    }
}