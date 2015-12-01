using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;

namespace Centro_Salud.Presentacion.AbmUsuario
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        Usuario usuario;
        IUsuario iUs=new IUsuario();
        IPersona iPers = new IPersona();
        IPerfil iPerf = new IPerfil();
        Persona persona;
        Perfil perf = new Perfil();
        private List<Perfil> perfiles = new List<Perfil>();
        private List<Object> lista = new List<object>();
        String password;

        protected void Page_Load(object sender, EventArgs e)
        {
           
           
                             
        }


        private int generarCodigoUsuario()
        {
            int codigo = 0;
            List<Usuario> cantUsers = iUs.getAll<Usuario>();

            if (cantUsers == null || cantUsers.Count == 0)
                return 1;
            else
            {
                codigo = cantUsers.First<Usuario>().codigoUsuario;
                foreach (Usuario p in cantUsers)
                    if (codigo < p.codigoUsuario)
                        codigo = p.codigoUsuario;
                return ++codigo;
            }
        }

        protected void crearUsuario(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> existen = iUs.getByCriterio<Usuario>("", "", txt_username.Text);
                if (existen.Count == 0 )
                {
                    if (ddl_perfil.SelectedValue == "0")
                    {

                        String msj = "Seleccione un perfil.";        
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

                    }
                    else { 
                    usuario = new Usuario();
                    usuario.login = txt_username.Text.Trim();
                    password = txt_password.Text.Trim();
                    String hash = Encripta.EncodePassword(string.Concat(usuario.login, password));
                    usuario.contraseña = hash;
                    usuario.fechaVigencia = DateTime.Now.Date;
                    //verificar el tipo del estado
                    usuario.estado = true;
                    Persona p = iPers.getByCriterio<Persona>("", "", txt_persona.Text).First<Persona>();
                    usuario.codigoPersona = p.codigoPersona;
                    usuario.codigoUsuario = generarCodigoUsuario();
                    usuario.mail = txt_correo.Text;
                    usuario.recibeAlertas = cheq_alerta.Checked;

                    perf = iPerf.getPorCriterio<Perfil>(ddl_perfil.SelectedValue.ToString()).First<Perfil>();
                    usuario.perfil = perf.codigoPerfil;

                    iUs.save<Usuario>(usuario);
                    String msj = "El usuario ha sido creado correctamente.";
                    Intermediario.confirmarCambios();
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

                    txt_apellido.Text = "";
                    txt_codigo.Text = "";
                    txt_nombre.Text = "";
                    txt_password.Text = "";
                    txt_persona.Text = "";
                    txt_username.Text = "";
                    txt_correo.Text = "";
                    cheq_alerta.Checked = false;
                    }
                }
                else {

                    String msj = "El nombre de usuario ingresado ya existe. Por favor ingrese otro usuario.";
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");
                    txt_username.Text = "";
                    txt_password.Text = "";
                
                }

            }
            catch (Exception) {
               
            }
        }

        protected void bt_buscarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                List<Persona> personas = iPers.getByCriterio<Persona>("", "", txt_persona.Text);

                if (personas.Count == 0) {
                    String msj = "No existe persona para el documento ingresado.";
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");
                    txt_persona.Text = "";
                
                }
                else
                {
                    persona = iPers.getByCriterio<Persona>("", "", txt_persona.Text).First<Persona>();
                  
                    txt_nombre.Text = persona.nombre;
                    txt_apellido.Text = persona.apellido;
                    txt_codigo.Text = persona.codigoPersona.ToString();
                    txt_username.Enabled = true;
                    txt_password.Enabled = true;


                    if (perfiles.Count == 0)
                    {
                        perfiles = iPerf.getAll<Perfil>();

                        foreach (Perfil p in perfiles)
                        {
                            lista.Add(p.descripcion);
                        }
                        ddl_perfil.DataSource = lista;
                        ddl_perfil.DataBind();
                    }
                }

            }
            catch (Exception) { }

        }

        protected void buscarPerfiles(object sender, EventArgs e)
        {
            String perfilito = ddl_perfil.SelectedValue;
            Perfil p = iPerf.getPorCriterio<Perfil>(perfilito).First<Perfil>();

        }

      
       
    }
}