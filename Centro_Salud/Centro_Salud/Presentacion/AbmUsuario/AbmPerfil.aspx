<%@ Page Title="Abm Perfil" Language="C#" AutoEventWireup="true" CodeBehind="AbmPerfil.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Centro_Salud.Presentacion.AbmUsuario.AbmPerfil" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Alta Perfil</h2>
    <p>
        Utilice el siguiente formulario para crear un nuevo perfil.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../../Imagenes/usuario.png" style="height: 53px; width: 57px" />
    </p>
    <br />
    <br />
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Perfil</legend>
            <p>
                <asp:Label ID="lb_Descripcion" runat="server" Text="Descripción:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_descripcion" runat="server" CssClass="textEntry" Width="196px"></asp:TextBox>
            </p>
          <%--  <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Permiso:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddl_privilegio" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="buscarPrivilegios">
                  <asp:ListItem Value="0" Text="Seleccione un privilegio"></asp:ListItem>
                </asp:DropDownList>
            </p>
           --%>
               
           
        </fieldset>
    <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_crearPerfil" runat="server" Text="Crear" OnClick="crearPerfil"
                    Width="150px" CssClass="prgAvBtn" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_cancelar" runat="server" Text="Cancelar" OnClick="cancelar" 
                    Width="150px" CssClass="prgAvBtn" /></p>
    </div>
</asp:Content>
