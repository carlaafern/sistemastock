using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;
using System.Data;

namespace Centro_Salud.Presentacion.AbmMedicamentos
{
    public partial class ConsultarMedicamentos : System.Web.UI.Page
    {

        IMedicamento iMed = new IMedicamento();
        IStockMedicamento iStkM = new IStockMedicamento();

        CentroSaludDatosDataContext med = new CentroSaludDatosDataContext();

        string conque;
        DataTable medic = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Buscar_Click(object sender, EventArgs e)
        {
            conque = txt_nombreMed.Text;
            llenar(conque);
        }

        //Método para llenar la grilla de Enfermedades
        public void llenar(string conque)
        {

            List<Medicamento> listaMed = new List<Medicamento>();
            listaMed = iMed.getAll<Medicamento>();

            IList<StockMedicamento> listaStk;


            int totalActual = 0;

            medic = new DataTable();

            medic.Columns.Add("codigoMedicamento");
            medic.Columns.Add("descripcion");
            medic.Columns.Add("lote");
            medic.Columns.Add("stockInicial");
            medic.Columns.Add("stockMinimo");
            medic.Columns.Add("stockMaximo");
            medic.Columns.Add("stockActual");
            medic.AcceptChanges();

            foreach (Medicamento m in listaMed)
            {
                if (m.fechaBaja == null)
                {

                    listaStk = iStkM.getCriterioById<StockMedicamento>("", "", m.codigo);

                    foreach (StockMedicamento stk in listaStk)
                    {
                        if (stk.fechaBaja == null)
                        {
                            totalActual = totalActual + Convert.ToInt32(stk.stockActual);
                            //med = iMed.getCriterioById<Medicamento>("", "", Convert.ToInt32(stk.codigoMedicamento)).First<Medicamento>();


                            DataRow fila = medic.NewRow();
                            fila["codigoMedicamento"] = m.codigo;
                            fila["descripcion"] = m.descripcion;
                            fila["lote"] = stk.lote;
                            fila["stockInicial"] = m.stockInicioMes;
                            fila["stockMinimo"] = m.stockMinimo;
                            fila["stockMaximo"] = m.stockMaximo;

                            fila["stockActual"] = stk.stockActual;

                            medic.Rows.Add(fila);
                            totalActual = 0;

                        }

                    }
                }
            }
            gv_Enfermedad.ShowHeaderWhenEmpty = true;
            gv_Enfermedad.DataSource = medic;
            gv_Enfermedad.DataBind();
        }

        //Este método implementa mensajes
        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }


        protected void bt_cancelar_Click(object sender, EventArgs e)
        {
            //Antes tengo que mostrar un mensaje
            bt_cancelar.Visible = false;
            gv_Enfermedad.Visible = false;
        }

    }
}
