<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enfermedades.aspx.cs" Inherits="Centro_Salud.Presentacion.AbmEnfermedad.Enfermedades" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Nueva ENFERMEDAD&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      </h2>
      
 <p>
     &nbsp;
     Utilice el siguiente formulario para crear una nueva enfermedad.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <img alt="especialidad" src="../../Imagenes/logo3.png" 
         style="height: 42px; width: 82px" /></p>
<div class="accountInfo">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<fieldset class="register">
<legend>Enfermedad</legend>
<p>
    <asp:Label ID="lb_nombreEnf" runat="server" Text="Nombre: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txt_nombre" runat="server" CssClass="textEntry"></asp:TextBox>
   
</p>

<p>
    <asp:Label ID="lb_nombreE0" runat="server" Text="Descripcion: "></asp:Label>
    <asp:TextBox ID="txt_descripcion" runat="server" CssClass="textEntry"></asp:TextBox>
   
</p>

<p>
    <asp:Label ID="lb_tratamiento" runat="server" Text="Tratamiento: "></asp:Label>
    <asp:TextBox ID="txt_tratamiento" runat="server" CssClass="textEntry"></asp:TextBox>
   
</p>
    <p>
<asp:Label ID="lb_complejidad" runat="server" Text="Gravedad: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:DropDownList ID="dl_gravedad" runat="server" Width="250px" Height="30px" >
         <asp:ListItem Value="1">Baja</asp:ListItem>
         <asp:ListItem Value="2">Media</asp:ListItem>
         <asp:ListItem Value="3">Alta</asp:ListItem>
    </asp:DropDownList>
</p>
    <p>
<asp:Label ID="lb_complejidad0" runat="server" Text="Dias de Reposo: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
     <asp:DropDownList ID="dl_diasReposo" runat="server" Width="250px" Height="30px" >
         <asp:ListItem>-</asp:ListItem>
         <asp:ListItem>1</asp:ListItem>
         <asp:ListItem>2</asp:ListItem>
         <asp:ListItem>3</asp:ListItem>
         <asp:ListItem>4</asp:ListItem>
         <asp:ListItem>5</asp:ListItem>
         <asp:ListItem>6</asp:ListItem>
         <asp:ListItem>7</asp:ListItem>
         <asp:ListItem>8</asp:ListItem>
         <asp:ListItem>9</asp:ListItem>
         <asp:ListItem>10</asp:ListItem>
    </asp:DropDownList>
</p>
    <p>
<asp:Label ID="lb_complejidad1" runat="server" Text="Internacion: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList 
            ID="dl_internacion" runat="server" Width="250px" Height="30px" >
         <asp:ListItem Value="1">Si</asp:ListItem>
         <asp:ListItem Value="0">No</asp:ListItem>
    </asp:DropDownList>
</p>

</fieldset><p class="submitButton">
      <asp:Button ID="bt_crearEnfermedad" runat="server"  Text="Crear" 
          onclick="crearEnfermedad" CssClass="prgAvBtn" />                                
  </p>
</div>
</asp:Content>
