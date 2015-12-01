<%@ Page Title="Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="Especialidades.aspx.cs" Inherits="Centro_Salud.Presentacion.AbmEspecialidad.Especialidades" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 97px;
            height: 86px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Nueva Especialidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      </h2>
      
 <p>
     &nbsp;
     Utilice el siguiente formulario para crear una nueva especialidad.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <img alt="especialidad" class="style1" src="../../Imagenes/especialidad.png" /></p>
<div class="accountInfo">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<fieldset class="register">
<legend>Especialidad</legend>
<p>
    <asp:Label ID="lb_nombreE" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txt_nombre" runat="server" CssClass="textEntry"
        AutoPostBack="True" ontextchanged="CompararEspecialidad"></asp:TextBox>
   
</p>
<p>
    <asp:Label ID="lb_anios" runat="server" Text="Años: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_anios" runat="server" CssClass="textEntry"></asp:TextBox>
   
</p>

<p>
<asp:Label ID="lb_complejidad" runat="server" Text="Complejidad: "></asp:Label>
    &nbsp;&nbsp;
     <%--<asp:DropDownList ID="dl_complejidad" runat="server" Width="200px" >
         <asp:ListItem>-</asp:ListItem>
         <asp:ListItem>1</asp:ListItem>
         <asp:ListItem>2</asp:ListItem>
         <asp:ListItem>3</asp:ListItem>
         <asp:ListItem>4</asp:ListItem>
         <asp:ListItem>5</asp:ListItem>
    </asp:DropDownList>--%>
    <asp:DropDownList ID="ddl_complejidad" runat="server" 
        DataSourceID="dsComplejidad" DataTextField="codComplejidad" 
        DataValueField="codComplejidad" Height="30px" Width="250px">
    </asp:DropDownList>
    <asp:SqlDataSource ID="dsComplejidad" runat="server" 
        ConnectionString="<%$ ConnectionStrings:centro_saludConnectionString1 %>" 
        SelectCommand="SELECT * FROM [Complejidad]"></asp:SqlDataSource>
</p>

</fieldset>
 <p class="submitButton">
      <asp:Button ID="bt_crearEspecialidad" runat="server"  Text="Guardar" 
          onclick="crearEspecialidad" CssClass="prgAvBtn" />                                
  </p>
</div>
</asp:Content>


