<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidoStk.aspx.cs" Inherits="Centro_Salud.Presentacion.Movimientos.PedidoStk" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Realizar Pedido&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h2>
    <p>
        Utilice el siguiente formulario para realizar el pedido de stock de medicamentos.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Pedido</legend>
            <p>
                Medicamento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_nombreMed" runat="server" CssClass="textEntry" 
                    Width="200px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Buscar" runat="server" Text="Buscar"
                    OnClick="bt_Buscar_Click" CssClass="prgAvBtn" />
         
                </p>
            <p>
                &nbsp;</p>
            <p align="left">        
                <asp:GridView ID="gv_Pedidos" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" onrowediting="gvPedidos_Editar" 
                    onrowupdating="gvPedidos_Actualizar" Width="932px">         
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="" EditText="Editar" 
                            ShowCancelButton="False" ShowEditButton="True" />
                        <asp:BoundField DataField="codigo" HeaderText="Código" 
                            ReadOnly="true"/>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="stockActual" HeaderText="StockActual" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="stockMinimo" 
                            HeaderText="StockMinimo" ReadOnly="True" />
                      
                        <asp:BoundField DataField="stockMaximo" HeaderText="StockMaximo" 
                            ReadOnly="True" />
                      
                        <asp:BoundField HeaderText="CantidadPedida" DataField="cantidadPedida"   />
                      
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_guardar" runat="server" Text="Generar Pedido" 
                    onclick="bt_guardar_Click" Visible="False" CssClass="prgAvBtn" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_cancelar" runat="server" Text="Cancelar" 
                    Visible="False" onclick="bt_cancelar_Click" CssClass="prgAvBtn" />
            </p>
           
        </fieldset>
    </div>
</asp:Content>
