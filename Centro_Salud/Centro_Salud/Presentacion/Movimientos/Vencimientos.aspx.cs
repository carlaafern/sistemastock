using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;
using System.Data;
using System.IO;
using System.Text;

namespace Centro_Salud.Presentacion.Movimientos
{
    public partial class Vencimientos : System.Web.UI.Page
    {
        
        IMedicamento iMed = new IMedicamento();
        IStockMedicamento iStkM = new IStockMedicamento();
        ILote iLote = new ILote();

        CentroSaludDatosDataContext med = new CentroSaludDatosDataContext();
        //este bool es para obligarme a actualizar antes de guardar
        static bool guardado = false;
        string conque;
        DataTable vto = null;
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Buscar_Click(object sender, EventArgs e)
        {
            conque = txt_nombreMed.Text;
            llenar(conque);
            bt_Imprimir.Visible = true;
            bt_cancelar.Visible = true;
        }

        //Método para llenar la grilla de Enfermedades
        public void llenar(string conque)
        {
            String msj;
            List<Medicamento> listaMed = new List<Medicamento>();
            listaMed = iMed.getAll<Medicamento>();

            List<StockMedicamento> listaStkM = new List<StockMedicamento>();
            listaStkM = iMed.getAll<StockMedicamento>();


            IList<StockMedicamento> listaStk;
        
            List<Lote> listaLote = new List<Lote>();

            int totalActual = 0;

            vto = new DataTable();

            vto.Columns.Add("codigoMedicamento");
            vto.Columns.Add("descripcion");
            vto.Columns.Add("nroLote");
            vto.Columns.Add("fechaVto");
            vto.Columns.Add("cantidad");
            vto.AcceptChanges();

            foreach (Medicamento m in listaMed)
            {
                if (m.fechaBaja == null)
                {

                    listaStk = iStkM.getCriterioById<StockMedicamento>("", "", m.codigo);

                   
                    foreach (StockMedicamento stk in listaStk)
                    {
                      
                        totalActual = totalActual + Convert.ToInt32(stk.stockActual);
                        //med = iMed.getCriterioById<Medicamento>("", "", Convert.ToInt32(stk.codigoMedicamento)).First<Medicamento>();
                        listaLote = iLote.getByCriterio<Lote>("", "", Convert.ToString(stk.lote));
                      
                        foreach (Lote l in listaLote)
                        {
                            DataRow fila = vto.NewRow();
                            fila["codigoMedicamento"] = m.codigo;
                            fila["descripcion"] = m.descripcion;
                            fila["nroLote"] = stk.lote;
                            fila["fechaVto"] = l.fechaVto;
                            fila["cantidad"] = stk.stockActual;
                            vto.Rows.Add(fila);
                            totalActual = 0;
                        }
                    
                    }
                }
            }
            gv_Enfermedad.ShowHeaderWhenEmpty = true;
            gv_Enfermedad.DataSource = vto;
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

        //Imprime pdf de reportes, y además lo envía por mail
        protected void bt_Imprimir_Clic(object sender, EventArgs e)
        {
            Response.Redirect("/Presentacion/Informes/ReporteVencimientos.aspx", false);

            
        }

              
    }
}
