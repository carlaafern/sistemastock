<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfigurarStockM.aspx.cs" Inherits="Centro_Salud.Presentacion.ParametrosSistema.ConfigurarStockM" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Configurar Stock&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h2>
    <p>
        Utilice el siguiente formulario para configurar el stock de medicamentos.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Modificar Stock</legend>
            <p>
                Medicamento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_nombreMed" runat="server" CssClass="textEntry" 
                    Width="200px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Buscar" runat="server" Text="Buscar" Height="31px"
                    OnClick="bt_Buscar_Click" CssClass="prgAvBtn" />
         
                </p>
            <p align="left">        
                <asp:GridView ID="gv_Enfermedad" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    onrowdeleting="gvEnfermedad_Eliminar" onrowediting="gvEnfermedad_Editar" 
                    onrowupdating="gvEnfermedad_Actualizar" Width="818px">         
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="" EditText="Editar" 
                            ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="codigo" HeaderText="Código" 
                            ReadOnly="true"/>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="stockInicioMes" HeaderText="StockInicial" />
                        <asp:BoundField DataField="stockMinimo" 
                            HeaderText="StockMinimo" />
                      
                        <asp:BoundField DataField="stockAlerta" HeaderText="StockAlerta" />
                        <asp:BoundField DataField="stockMaximo" HeaderText="StockMaximo" />
                      
                        <asp:BoundField DataField="diasAlertas" HeaderText="DiasAlertas" />
                      
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
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_guardar" runat="server" Text="Guardar" 
                    onclick="bt_guardar_Click" Visible="False" CssClass="prgAvBtn" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_cancelar" runat="server" Text="Cancelar" 
                    Visible="False" onclick="bt_cancelar_Click" CssClass="prgAvBtn" />
            </p>
           
        </fieldset>
    </div>
</asp:Content>
