using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;


namespace Centro_Salud.Presentacion.Informes
{
    public partial class ReporteMovim : System.Web.UI.Page
    {
   
        private List<TipoMovimiento> listaTM = new List<TipoMovimiento>();
        private ITipoMovimiento iTM = new ITipoMovimiento();
        private List<Object> listaT = new List<object>();
        TipoMovimiento tipoMov = new TipoMovimiento();
        private Medicamento med = new Medicamento();
        IMedicamento iMed = new IMedicamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = false;

            if (listaTM.Count == 0)
            {
                listaTM = iTM.getAll<TipoMovimiento>();

                foreach (TipoMovimiento tm in listaTM)
                {
                    listaT.Add(tm.descripcionTipoMov);
                }
                ddl_tipos.Enabled = true;
                ddl_tipos.DataSource = listaT;
                ddl_tipos.DataBind();

            }
        }

        protected void bt_Imprimir_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
        }
    }
}