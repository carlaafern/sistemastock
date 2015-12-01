<%@ Page Title="Registrar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Centro_Salud.Presentacion.RegistroUsuario" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Registrar Usuario</h2>
 <p>
     Utilice el siguiente formulario para crear un nuevo usuario.
 </p>
<div class="accountInfo">
<fieldset class="register">
<legend>Informacion de la Cuenta</legend>
<p>
    <asp:Label ID="lb_nombreU" runat="server" Text="Nombre Usuario: "></asp:Label>
    <asp:TextBox ID="txt_nombre" runat="server" CssClass="textEntry" Width="196px"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lb_password" runat="server" Text="Contraseña:              "></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    
    <asp:TextBox ID="txt_password" runat="server" CssClass="passwordEntry" TextMode="Password"
        Width="196px"></asp:TextBox>
</p>

</fieldset>
 <p class="submitButton">
      <asp:Button ID="bt_crearUsuario" runat="server"  Text="Crear Usuario" 
          onclick="crearUsuario" />                                
  </p>
</div>
</asp:Content>

