<%@ Page Title="Alta Persona" Language="C#" AutoEventWireup="true" CodeBehind="AltaPersona.aspx.cs"
    MasterPageFile="~/Site.Master" Inherits="Centro_Salud.Presentacion.AbmUsuario.AltaPersona" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Alta Persona</h2>
    <p>
        Utilice el siguiente formulario para crear una nueva persona.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../../Imagenes/usuario.png" style="height: 53px; width: 57px" />
    </p>
    <br />
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Datos Personales</legend>
            <p>
                <asp:Label ID="lb_nombre" runat="server" Text="Nombre: "></asp:Label>
                &nbsp;
                <asp:TextBox ID="txt_nombre" runat="server" CssClass="textEntry" ></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lb_apelllido" runat="server" Text="Apellido:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_apellido" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                Tipo Doc:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:DropDownList ID="dl_tipoDocumento"
                    runat="server" Width="250px" Height="30px">
                    <asp:ListItem Value="1">DNI</asp:ListItem>
                    <asp:ListItem Value="2">LE</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Nº Doc:&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_numero" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_calle" runat="server" Text="Calle: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_calle" runat="server" CssClass="textEntry" ></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lb_nroCalle" runat="server" Text="Nº Calle:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_nroCalle" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_Provincia" runat="server" Text="Provincia: "></asp:Label>
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:DropDownList ID="ddl_provincia" runat="server"
                    Width="250px" OnSelectedIndexChanged="buscarDepartamentos" AutoPostBack="True"
                    AppendDataBoundItems="True" Height="30px">
                    <asp:ListItem Value="0" Text="Seleccione Provincia"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="ddl_departamento" runat="server" Text="Departamento:"></asp:Label>
                &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                <asp:DropDownList ID="ddl_dpto" runat="server"  AutoPostBack="True"
                    OnSelectedIndexChanged="buscarLocalidades" AppendDataBoundItems="True" 
                    Height="30px" Width="250px">
                    <asp:ListItem Value="0" Text="Seleccione Departamento"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Localidad:&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 
                <asp:DropDownList 
                    ID="ddl_localidad" runat="server"
                    Width="250px" AutoPostBack="True" AppendDataBoundItems="True" 
                    Height="30px">
                    <asp:ListItem Value="0" Text="Seleccione Localidad"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lb_telefono" runat="server" Text="Teléfono: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_telefono" runat="server" CssClass="textEntry" ></asp:TextBox>
            </p>
            <p>
                Puesto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; 
                <asp:DropDownList ID="ddl_tipoPersona" runat="server"  AutoPostBack="false"
                    AppendDataBoundItems="True" Height="30px" Width="250px">
                    <asp:ListItem Value="0" Text="Seleccione Puesto"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
                
          
        </fieldset>

     <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_crearUsuario" runat="server" Text="Crear" OnClick="crearUsuario" CssClass="prgAvBtn" Width="150px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Button ID="bt_cancelar" runat="server" Text="Cancelar" Width="150px" CssClass="prgAvBtn" /></p>
    </div>
</asp:Content>
