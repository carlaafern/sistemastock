using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;

namespace Centro_Salud.Presentacion.AbmMedicamentos
{
    public partial class AbmMedicamento : System.Web.UI.Page
    {
        List<UnidadMedida> unidadMed;
        List<Formato> format;
        Medicamento remedio;
        StockMedicamento stock;

        IUnidadMedida iUniMed = new IUnidadMedida();
        IFormato iformato = new IFormato();
        IMedicamento iMed = new IMedicamento();
        IStockMedicamento iStock = new IStockMedicamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> lista = new List<string>();
            unidadMed = iUniMed.getAll<UnidadMedida>();
            foreach (UnidadMedida p in unidadMed)
            {
                lista.Add(p.descripcionUnidadMed);
            }
            ddl_unidadMed.DataSource = lista;
            ddl_unidadMed.DataBind();


            List<String> lista1 = new List<string>();
            format = iformato.getAll<Formato>();
            foreach (Formato p in format)
            {
                lista1.Add(p.descripcionPresentacion);
            }
            ddl_Formato.DataSource = lista1;
            ddl_Formato.DataBind();
        }

        private int generarCodigo()
        {
            int codigo = 0;
            List<Medicamento> cantMed = iMed.getAll<Medicamento>();

            if (cantMed.Count == 0)
                return 1;
            else
            {
                codigo = cantMed.First<Medicamento>().codigo;
                foreach (Medicamento e in cantMed)
                    if (codigo < e.codigo)
                        codigo = e.codigo;
                return ++codigo;
            }
        }

        private int generarCodigoStock()
        {
            int codigoS = 0;
            List<StockMedicamento> cantStk = iStock.getAll<StockMedicamento>();

            if (cantStk.Count == 0)
                return 1;
            else
            {
                codigoS = cantStk.First<StockMedicamento>().codigoStock;
                foreach (StockMedicamento e in cantStk)
                    if (codigoS < e.codigoStock)
                        codigoS = e.codigoStock;
                return ++codigoS;
            }
        }
        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                remedio = new Medicamento();
                stock = new StockMedicamento();

                remedio.descripcion = txtName.Text.ToString();
                remedio.monoDroga = txtName0.Text.ToString();
                remedio.codigo = generarCodigo();
                remedio.descripcionAmpliada = txt_ampliada.Text;
                
                //Guarda el stock necesario y de alerta para este tipo de medicamento que está creando
                remedio.stockInicioMes = Convert.ToInt32(txt_stockInicial.Text);
                remedio.stockMinimo = Convert.ToInt32(txt_stockMinimo.Text);
                remedio.stockAlerta = Convert.ToInt32(txt_stockAlerta.Text);
                remedio.stockMaximo = Convert.ToInt32(txt_stockMax.Text);
                remedio.diasAlertas = Convert.ToInt32(txt_diasAlerta.Text);

                stock.codigoMedicamento = remedio.codigo;
                stock.codigoStock = generarCodigoStock();
                stock.stockActual = Convert.ToInt32(txt_stockInicial.Text);
                stock.lote = 4;

                UnidadMedida um = iUniMed.getPorCriterio<UnidadMedida>(ddl_unidadMed.SelectedValue.ToString()).First<UnidadMedida>();
                remedio.unidadMedida = um.codigoUnidadMed;
                Formato form = iformato.getPorCriterio<Formato>(ddl_Formato.SelectedValue.ToString()).First<Formato>();
                remedio.formato = form.codigoPresentacion;

                iMed.save<Medicamento>(remedio);
                iStock.save<StockMedicamento>(stock);

                txtName.Text = "";
                txtName0.Text = "";
                txt_ampliada.Text = "";
                txt_stockInicial.Text = "";
                txt_stockInicial.Text = "";
                txt_stockMinimo.Text = "";
                txt_stockMax.Text = "";
                txt_diasAlerta.Text = "";

                String msj = "El medicamento ha sido creado correctamente, con el nro: " + remedio.codigo;
                Intermediario.confirmarCambios();
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + msj + "');</script>");

            }
            catch (Exception) { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

    }
}