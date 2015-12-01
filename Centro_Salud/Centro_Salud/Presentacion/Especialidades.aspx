<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="Centro_Salud.Presentacion.Especialidades" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Nueva Especialidad</h2>
 <p>
     Utilice el siguiente formulario para crear una nueva especialidad.
 </p>
<div class="accountInfo">
<fieldset class="register">
<legend>Especialidad</legend>
<p>
    <asp:Label ID="lb_nombreE" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txt_nombre" runat="server" CssClass="textEntry" Width="196px"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lb_complejidad" runat="server" Text="Complejidad:"></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    
    <asp:TextBox ID="txt_complejidad" runat="server" CssClass="textEntry" Width="196px"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lb_codigo" runat="server" Text="Codigo:"></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    
    <asp:TextBox ID="txt_codigo" runat="server" CssClass="textEntry" Width="196px"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lb_años" runat="server" Text="Años Especialidad:"></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    
    <asp:TextBox ID="txt_anios" runat="server" CssClass="textEntry" Width="196px"></asp:TextBox>
</p>
</fieldset>
 <p class="submitButton">
      <asp:Button ID="bt_crearEspecialidad" runat="server"  Text="Guardar" 
          onclick="crearEspecialidad" />                                
  </p>
</div>
</asp:Content>


