<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Inicio.aspx.cs" Inherits="Centro_Salud.Presentacion.Inicio" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>
        Bienvenido a Centro de Salud!
    </h2>
    <br />
    <br />
    <br />
    <br />
    <br />
     
    <p>
        
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image1" runat="server" Height="300px" 
            ImageUrl="~/Imagenes/logo1.jpg" style="text-align: center" Width="850px" />    
    </p>
    <div style="height: 336px">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
     
      <asp:Panel ID="panelMensajes" runat="server" Visible="False">
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
         <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <div id="divGrid" style="overflow: auto; height: 350px">
          <asp:GridView ID="grillaMsjs" runat="server" AutoGenerateColumns="False" 
              CellPadding="4" ForeColor="#333333" GridLines="None" Width="1328px">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:BoundField DataField="codigo" HeaderText="Código Medicamento" />
                  <asp:BoundField DataField="descripcion" HeaderText="Nombre" />
                  <asp:BoundField DataField="mensaje" HeaderText="Mensaje" />
                  <asp:BoundField DataField="fecha" HeaderText="Fecha Vencimiento" />
                  <asp:BoundField DataField="lote" HeaderText="Nro Lote" />
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <SortedAscendingCellStyle BackColor="#FDF5AC" />
              <SortedAscendingHeaderStyle BackColor="#4D0000" />
              <SortedDescendingCellStyle BackColor="#FCF6C0" />
              <SortedDescendingHeaderStyle BackColor="#820000" />
          </asp:GridView>
          </div>
    </asp:Panel>
    </div>
   
</asp:Content>

