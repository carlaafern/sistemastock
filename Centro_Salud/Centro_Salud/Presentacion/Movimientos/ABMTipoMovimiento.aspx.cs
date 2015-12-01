using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Centro_Salud.Persistencia;
using Centro_Salud.Presentacion.DTOs;

namespace Centro_Salud.Presentacion.Movimientos
{
    public partial class ABMTipoMovimiento : System.Web.UI.Page
    {
       
        private List<Object> lista = new List<Object>();
        private ITipoMovimiento iTM = new ITipoMovimiento();
        private List<TipoMovimiento> TiposM = new List<TipoMovimiento>();
        TipoMovimiento tipoM;
        private int numerogenerado; 
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void crearTipoMov(object sender, EventArgs e)
        {
            try
            {
                numerogenerado = generarCodigo();
                tipoM = new TipoMovimiento();
                tipoM.codigoTipoMov = numerogenerado;
                tipoM.descripcionTipoMov = txt_descripcionTM.Text;
                tipoM.tipo = ddl_tipoMov.SelectedValue; 

                iTM.save<TipoMovimiento>(tipoM);

                txt_descripcionTM.Text = "";
                
                 
                String msj = "El tipo de movimiento ha sido creado correctamente";
                Intermediario.confirmarCambios();
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

            }
            catch (Exception) { }
        }
       
        private int generarCodigo()
        {
            int codigo = 0;
            List<TipoMovimiento> cantTM = iTM.getAll<TipoMovimiento>();

            if (cantTM.Count == 0)
                return 1;
            else
            {
                codigo = cantTM.First<TipoMovimiento>().codigoTipoMov;
                foreach (TipoMovimiento e in cantTM)
                    if (codigo < e.codigoTipoMov)
                        codigo = e.codigoTipoMov;
                return ++codigo;
            }
        }
    }
}