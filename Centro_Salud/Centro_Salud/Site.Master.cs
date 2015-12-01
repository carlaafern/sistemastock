using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Presentacion;

namespace Centro_Salud
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tipo = Session["PerfilUser"].ToString();
                switch (tipo)
                {
                    case "1": MenuAdmin();
                        break;
                    case "2": MenuEmployee();
                        break;
                    default:
                        break;
                }
            
                
            }

        }
        protected void MenuAdmin()
        {
            String menu = String.Format(@"
                    <li><a href='/Default.aspx'>Inicio</a> </li>
                    <li><a href='#'>Clasificadores</a>
                        <ul>
                            <li><a href='/Presentacion/AbmEnfermedad/Enfermedades.aspx'>Enfermedades</a>
                                 <ul>
                                        <li><a href='/Presentacion/AbmEnfermedad/Enfermedades.aspx'>Crear Nueva</a></li>
                                        <li><a href='/Presentacion/AbmEnfermedad/EditarEnfermedad.aspx'>Modificar</a></li>
                                  </ul>
                            </li>
                            <li><a href='/Presentacion/AbmEspecialidad/Especialidades.aspx'>Especialidades</a>
                                  <ul>
                                        <li><a href='/Presentacion/AbmEspecialidad/Especialidades.aspx'>Crear Nueva</a></li>
                                        <li><a href='/Presentacion/AbmEspecialidad/EditarEspecialidad.aspx'>Modificar</a></li>
                                    </ul>
                            </li> 
                             <li><a href='/Presentacion/AbmMedicamentos/AbmMedicamento.aspx'>Medicamentos</a>
                                 <ul>
                                        <li><a href='/Presentacion/AbmMedicamentos/AbmMedicamento.aspx'>Crear Nuevo</a></li>
                                        <li><a href='/Presentacion/AbmMedicamentos/EditarMedicamento.aspx'>Modificar</a></li>
                                 </ul>
                            </li>
                            <li><a href='/Presentacion/Movimientos/ABMTipoMovimiento.aspx'>Tipo de Movimientos</a>
                        </ul>
                    </li>
                    <li><a href='/Presentacion/Inicio.aspx'>Stock</a>
                        <ul>
                           <li><a href='/Presentacion/Inicio.aspx'>Movimientos</a>

                               <ul>
                                   <li><a href='/Presentacion/Movimientos/Entradas.aspx'>Entrada</a></li>
                                   <li><a href='/Presentacion/Movimientos/Salidas.aspx'>Salida</a></li>
                               </ul>
                            </li> 
                            <li><a href='/Presentacion/Movimientos/ABMLotes.aspx'>Lotes</a></li>
                            <li><a href='/Presentacion/Movimientos/PedidoStk.aspx'>Realizar Pedido</a></li>
                        </ul>      
                    </li>
                    <li><a href='/Presentacion/Consultas.aspx'>Informes</a>
                         <ul>
                            <li><a href='/Presentacion/Informes/ReporteEspecialidad.aspx'>Rep Especialidades</a></li>
                            <li><a href='/Presentacion/Informes/ReporteUsuarios.aspx'>Rep Usuarios</a></li>   
                            <li><a href='/Presentacion/Movimientos/ConsultarMovimientos.aspx'>Consultar Movimientos</a></li>
                            <li><a href='/Presentacion/Movimientos/Vencimientos.aspx'>Vencimientos</a></li>
                            <li><a href='/Presentacion/AbmMedicamentos/ConsultarMedicamentos.aspx'>Consultar Stock</a></li>
                            <li><a href='/Presentacion/AcercaDe.aspx'></a></li>                   
                        </ul>  
                     </li>        
                    <li><a href='/Presentacion/AcercaDe.aspx'>Parametros</a>
                      <ul>
                        
                            <li><a href='/Presentacion/ParametrosSistema/ConfigurarStockM.aspx'>Configurar Stock</a></li>
                            
                        </ul>
                    </li>
                    <li><a href='/Presentacion/AcercaDe.aspx'>Usuarios</a>  
                        <ul>
                            <li><a href='/Presentacion/AbmUsuario/AltaPersona.aspx'>Alta Personas</a></li>
                            <li><a href='/Presentacion/AbmUsuario/RegistroUsuario.aspx'>Registrar Usuario</a></li>
                             <li><a href='/Presentacion/AbmUsuario/ConsultaUsuarios.aspx'>Gestionar Usuarios</a></li>
                            <li><a href='/Presentacion/AbmUsuario/AbmPerfil.aspx'>Crear Perfil</a></li>
                        </ul>
                    </li>");
            this.ltMenu.Text = menu;

        }
        protected void MenuEmployee()
        {
            String menu = String.Format(@"
                    <li><a href='/Default.aspx'>Inicio</a> </li>
                    <li><a href='#'>Clasificadores</a>
                        <ul>
                            <li><a href='/Presentacion/AbmEnfermedad/Enfermedades.aspx'>Enfermedades</a>
                                 <ul>
                                        <li><a href='/Presentacion/AbmEnfermedad/Enfermedades.aspx'>Crear Nueva</a></li>
                                        <li><a href='/Presentacion/AbmEnfermedad/EditarEnfermedad.aspx'>Modificar</a></li>
                                  </ul>
                            </li>
                            <li><a href='/Presentacion/AbmEspecialidad/Especialidades.aspx'>Especialidades</a>
                                  <ul>
                                        <li><a href='/Presentacion/AbmEspecialidad/Especialidades.aspx'>Crear Nueva</a></li>
                                        <li><a href='/Presentacion/AbmEspecialidad/EditarEspecialidad.aspx'>Modificar</a></li>
                                    </ul>
                            </li> 
                             <li><a href='/Presentacion/AbmMedicamentos/AbmMedicamento.aspx'>Medicamentos</a>
                                 <ul>
                                        <li><a href='/Presentacion/AbmMedicamentos/AbmMedicamento.aspx'>Crear Nuevo</a></li>
                                        <li><a href='/Presentacion/AbmMedicamentos/EditarMedicamento.aspx'>Modificar</a></li>
                                 </ul>
                            </li>
                            <li><a href='/Presentacion/Movimientos/ABMTipoMovimiento.aspx'>Tipo de Movimientos</a>
                        </ul>
                    </li>
                    <li><a href='/Presentacion/Inicio.aspx'>Stock</a>
                        <ul>
                           <li><a href='/Presentacion/Inicio.aspx'>Movimientos</a>

                               <ul>
                                   <li><a href='/Presentacion/Movimientos/Entradas.aspx'>Entrada</a></li>
                                   <li><a href='/Presentacion/Movimientos/Salidas.aspx'>Salida</a></li>
                               </ul>
                            </li> 
                            <li><a href='/Presentacion/Movimientos/ABMLotes.aspx'>Lotes</a></li>
                            <li><a href='/Presentacion/Movimientos/PedidoStk.aspx'>Realizar Pedido</a></li>
                        </ul>      
                    </li>
                    <li><a href='/Presentacion/Consultas.aspx'>Informes</a>
                         <ul>
                            <li><a href='/Presentacion/Informes/ReporteEspecialidad.aspx'>Rep Especialidades</a></li>
                            <li><a href='/Presentacion/Informes/ReporteUsuarios.aspx'>Rep Usuarios</a></li>   
                            <li><a href='/Presentacion/Movimientos/ConsultarMovimientos.aspx'>Consultar Movimientos</a></li>
                            <li><a href='/Presentacion/Movimientos/Vencimientos.aspx'>Vencimientos</a></li>
                            <li><a href='/Presentacion/AbmMedicamentos/ConsultarMedicamentos.aspx'>Consultar Stock</a></li>
                            <li><a href='/Presentacion/AcercaDe.aspx'></a></li>                   
                        </ul>  
                     </li> ");
            this.ltMenu.Text = menu;
            
        }
    }
}

