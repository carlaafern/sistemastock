using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Centro_Salud.Persistencia;
using Centro_Salud;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace Centro_Salud.Presentacion.Movimientos
{
    public partial class PedidoStk : System.Web.UI.Page
    {
        // Definicion de variables, listas, Entidades e Intermediarios
        IStockMedicamento iStockMed = new IStockMedicamento();
        IPedido iPedido = new IPedido();
        IDetallePedido iDetalle = new IDetallePedido();
        Pedido nvoPedido;
        IList<Medicamento> medicamento = null;
        IUsuario logueado = new IUsuario();
        IMedicamento iMed = new IMedicamento();
        DataTable pedido = null;
        SmtpClient client = new SmtpClient();
        MailMessage msg = new MailMessage();
        Attachment adjunto;
        String destinatario=null;
        Usuario userLogueado=new Usuario();
        
        CentroSaludDatosDataContext med = new CentroSaludDatosDataContext();
        static bool guardado = false;
        string conque;
        // Metodo que carga la pagina principal, setea usuario logeado
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UsuarioLogueado"] = Session["VariableUser"].ToString();
          
        }
        // Busca un medicamento especifico o todos si ingresa vacio
        protected void bt_Buscar_Click(object sender, EventArgs e)
        {
            conque = txt_nombreMed.Text;
            llenar(conque);
        }

        // Metodo que muestra mensajes en pantalla, recibe como paremetro el mensaje a mostrar
        public void mostrarMensaje(String mensaje)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }

        // Metodo que genera el codigo unico para el nro de Pedido, busca el ultimo, suma 1 
        private int generarCodigo()
        {
            int codigo = 0;
            List<Pedido> cantPed = iPedido.getAll<Pedido>();

            if (cantPed.Count == 0)
                return 1;
            else
            {
                codigo = cantPed.First<Pedido>().nroPedido;
                foreach (Pedido p in cantPed)
                    if (codigo < p.nroPedido)
                        codigo = p.nroPedido;
                return ++codigo;
            }
        }

        // Metodo que genera el nro de detalle unico
        private int generarNroDetalle()
        {
            int codigo = 0;
            List<DetallePedido> cantDet = iDetalle.getAll<DetallePedido>();

            if (cantDet.Count == 0)
                return 1;
            else
            {
                codigo = cantDet.First<DetallePedido>().nroDetallePedido;
                foreach (DetallePedido det in cantDet)
                    if (codigo < det.nroDetallePedido)
                        codigo = det.nroDetallePedido;
                return ++codigo;
            }
        }

        // Metodo que guarda la cabecera del Pedido y los detalles del mismo
        // se envia el pedido por mail al usuario logeado y al proveedor
        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            DetallePedido detallePed;

            nvoPedido = new Pedido();
            nvoPedido.nroPedido = generarCodigo();
            nvoPedido.fechaPedido = DateTime.Today.Date;
            nvoPedido.proveedor = 1;

            iPedido.save<Pedido>(nvoPedido);

            DataTable dt = Session["DtPedidos"] as DataTable;

            foreach (DataRow row in dt.Rows)
            {

                detallePed = new DetallePedido();
                detallePed.nroDetallePedido = generarNroDetalle();
                detallePed.nroPedido = nvoPedido.nroPedido;
                detallePed.codigoMedicamento = Convert.ToInt32(row["codigo"]);
                detallePed.cantidad = Convert.ToInt32(row["cantidadPedida"]);

                iDetalle.save<DetallePedido>(detallePed);
                Intermediario.confirmarCambios();

            }

            //Recupera el usuario logueado al sistema
            String usLogueado=Session["UsuarioLogueado"].ToString();       
            Usuario userLogueado = logueado.getPorCriterio<Usuario>(usLogueado).First<Usuario>();
            destinatario = userLogueado.mail;

            //Si tiene permiso para recibir mails, lo agrega a los destinatarios
            if (userLogueado.recibeAlertas == true)
            {
                msg.To.Add(destinatario);
            }

            //enviar mail al proveedor y al usuario logueado
            msg.To.Add("sistema.salud.maipu@gmail.com");
           
            //Busca el mail del pedido 
            string Body = System.IO.File.ReadAllText(Server.MapPath("MailPedidos.htm"));
            msg.Body = Body;
            msg.IsBodyHtml = true;

            //Busca el adjunto-debe enviarle el pedido adjunto--
           // adjunto = new Attachment("C:adjunto.txt"); //lo adjuntamos
          //  msg.Attachments.Add(new Attachment(@"C:\Users\CarlaFern\Downloads\ReporteVto.pdf"));

            //Envìa desdel el mail del sistema
            msg.From = new MailAddress("sistema.salud.maipu@gmail.com");

            //Configura el asunto del mail
            msg.Subject = "Centro Salud-Información";

            client.Credentials = new NetworkCredential("sistema.salud.maipu@gmail.com", "sistemamaipu");
            client.Host = "smtp.gmail.com";
            client.Port = 25;
            client.EnableSsl = true;

            //Envìa el mail
            client.Send(msg);

            //Enviar mensaje de pedido generado
            String msj = "Se ha creado un nuevo pedido. Nro Pedido: " + nvoPedido.nroPedido;
            mostrarMensaje(msj);
            txt_nombreMed.Text = "";
          
        }

        // Limpia la pantalla
        protected void bt_cancelar_Click(object sender, EventArgs e)
        {
            //Antes tengo que mostrar un mensaje
            bt_guardar.Visible = false;
            bt_cancelar.Visible = false;
            gv_Pedidos.Visible = false;
        }

        //Método para llenar la grilla 
        public void llenar(string conque)
        {
            String msj;
            List<Medicamento> listaMed = new List<Medicamento>();
            Medicamento remedio;
            IList<StockMedicamento> listaStk;

            int totalActual = 0;

            //Este es el caso en que se realiza un pedido para todos los medicamentos
            if (conque == "")
            {
                listaMed = iMed.getAll<Medicamento>();

                if (Session["DtPedidos"] == null)
                {

                    pedido = new DataTable();
                    pedido.Columns.Add("codigo");
                    pedido.Columns.Add("descripcion");
                    pedido.Columns.Add("stockActual");
                    pedido.Columns.Add("stockMinimo");
                    pedido.Columns.Add("stockMaximo");
                    pedido.Columns.Add("cantidadPedida");
                    pedido.AcceptChanges();

                    foreach (Medicamento m in listaMed)
                    {
                        listaStk = iStockMed.getCriterioById<StockMedicamento>("", "", m.codigo);

                        foreach (StockMedicamento stk in listaStk)
                        {
                          if (stk.fechaBaja == null)  totalActual = totalActual + Convert.ToInt32(stk.stockActual);
                        }


                        DataRow fila = pedido.NewRow();
                        fila["codigo"] = m.codigo;
                        fila["descripcion"] = m.descripcion;
                        fila["stockActual"] = totalActual;
                        fila["stockMinimo"] = m.stockMinimo;
                        fila["stockMaximo"] = m.stockMaximo;

                        if (m.stockMaximo - totalActual <= 0)
                        {
                            fila["cantidadPedida"] = 0;
                        }
                        else
                        {
                            fila["cantidadPedida"] = m.stockMaximo - totalActual;
                        }


                        pedido.Rows.Add(fila);
                        totalActual = 0;
                        Session["DtPedidos"] = pedido;
                    }
                }

                pedido = Session["DtPedidos"] as DataTable;
                gv_Pedidos.ShowHeaderWhenEmpty = true;
                gv_Pedidos.DataSource = Session["DtPedidos"];
                gv_Pedidos.DataBind();
                bt_guardar.Visible = true;
                bt_cancelar.Visible = true;
            }
            else
                //Esto es para buscar solo el medicamento indicado, por descripciòn
                
            {
                if (Session["DtPedidos"] == null)
                {
                    pedido = new DataTable();
                    pedido.Columns.Add("codigo");
                    pedido.Columns.Add("descripcion");
                    pedido.Columns.Add("stockActual");
                    pedido.Columns.Add("stockMinimo");
                    pedido.Columns.Add("stockMaximo");
                    pedido.Columns.Add("cantidadPedida");
                    pedido.AcceptChanges();

                    remedio = iMed.getPorCriterio<Medicamento>(conque).First<Medicamento>();        
                    listaStk = iStockMed.getCriterioById<StockMedicamento>("", "", remedio.codigo);

                    foreach (StockMedicamento stk in listaStk)
                    {
                       if (stk.fechaBaja == null) totalActual = totalActual + Convert.ToInt32(stk.stockActual);
                    }

                    DataRow fila = pedido.NewRow();
                    fila["codigo"] = remedio.codigo;
                    fila["descripcion"] = remedio.descripcion;
                    fila["stockActual"] = totalActual;
                    fila["stockMinimo"] = remedio.stockMinimo;
                    fila["stockMaximo"] = remedio.stockMaximo;
                    if (remedio.stockMaximo - totalActual <= 0)
                    {
                        fila["cantidadPedida"] = 0;
                    }
                    else
                    {
                        fila["cantidadPedida"] = remedio.stockMaximo - totalActual;
                    }

                    pedido.Rows.Add(fila);
                    totalActual = 0;
                    Session["DtPedidos"] = pedido;

                }
                pedido = Session["DtPedidos"] as DataTable;
                gv_Pedidos.ShowHeaderWhenEmpty = true;
                gv_Pedidos.DataSource = Session["DtPedidos"];
                gv_Pedidos.DataBind();
               

                bt_guardar.Visible = true;
                bt_cancelar.Visible = true;
            }
        }

        public void ActualizarPedidos()
        {
            guardado = true;
        }

        // Este metodo edita habilita la edicion del pedido
        protected void gvPedidos_Editar(object sender, GridViewEditEventArgs e)
        {
            int fila = e.NewEditIndex;
            gv_Pedidos.EditIndex = e.NewEditIndex;
            GridViewRow row = gv_Pedidos.Rows[fila];
            conque = row.Cells[1].Text;
            llenar(conque);
        }

        // Confirma los datos editados
        protected void gvPedidos_Actualizar(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gv_Pedidos.Rows[e.RowIndex];
                gv_Pedidos.EditIndex = -1;
                String cant = ((TextBox)(row.Cells[6].Controls[0])).Text;
                pedido = Session["DtPedidos"] as DataTable;
                pedido.Rows[row.DataItemIndex]["cantidadPedida"] = cant;

                String msj = "Se ha actualizado la cantidad a pedir.";
                mostrarMensaje(msj);
              
                llenar("");
                gv_Pedidos.DataBind();
            }
            catch (Exception) { }
        }

    }
}
