<%@ Page Title="Registrar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegistroUsuario.aspx.cs" Inherits="Centro_Salud.Presentacion.AbmUsuario.RegistroUsuario" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Registrar Usuario</h2>
    <p>
        Utilice el siguiente formulario para crear un nuevo usuario.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../../Imagenes/usuario.png" style="height: 48px; width: 59px" />
    </p>
    <br />
    <div class="accountInfo">
        <fieldset class="register"> <br />
            <legend>Información de la Cuenta</legend>
            <p>
                Buscar Persona:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_persona" runat="server" CssClass="textEntry" Width="196px" 
                    AutoCompleteType="Search"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_buscarPersona" runat="server" Text="Buscar" CssClass="prgAvBtn"
                    OnClick="bt_buscarPersona_Click" /></p> <br />
            <p>
                <asp:Label ID="lb_nombre" runat="server" Text="Nombre:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_nombre" runat="server"  ReadOnly="True" 
                    CssClass="textEntry"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label 
                    ID="lb_apellido" runat="server" Text="Apellido:"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txt_apellido" runat="server" ReadOnly="True" 
                    CssClass="textEntry"></asp:TextBox>
                &nbsp;
            </p>
            <p>
                <asp:Label ID="lb_codigo" runat="server" Text="Código:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_codigo" runat="server" ReadOnly="True" 
                    CssClass="textEntry"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Label ID="lb_correo" runat="server" Text="Correo:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_correo" runat="server" Width="278px" CssClass="textEntry"></asp:TextBox>
            </p>
            <br />
            <p>
                &nbsp;<asp:Label ID="lb_nombreU" runat="server" Text="Nombre Usuario: "></asp:Label>
                <asp:TextBox ID="txt_username" runat="server" CssClass="textEntry" ></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            </p>
            <p>
                &nbsp;<asp:Label ID="lb_password" runat="server" Text="Contraseña:              "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            </p>
            <p>
                <asp:Label ID="lb_perfil" runat="server" Text="Label">Perfil:</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddl_perfil" runat="server" Width="270px"
                    OnSelectedIndexChanged="buscarPerfiles" AppendDataBoundItems="True" 
                    Height="30px">
                    <asp:ListItem Value="0" Text="Seleccione Perfil"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lb_ra" runat="server" Text="Label">Recibe Alertas:</asp:Label>
                <asp:CheckBox ID="cheq_alerta" runat="server" />
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="bt_crearUsuario" runat="server" Text="Crear Usuario" 
                OnClick="crearUsuario" CssClass="prgAvBtn" Visible="True"/>
        </p>
    </div>
</asp:Content>
