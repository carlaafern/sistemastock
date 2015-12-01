<%@ Page Title="Login" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Centro_Salud.Login.Login" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Login" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Login
    </h2>
    <p>
        Por favor ingrese usuario y contraseña
    </p>
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Información de la Cuenta</legend>
            <p>
                <asp:Label ID="lb_nombreU" runat="server" Text="Nombre Usuario: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_nombre" runat="server" CssClass="passwordEntry" Width="227px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lb_password" runat="server" Text="Contraseña:     " CssClass="passwordEntry"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_password" runat="server" CssClass="passwordEntry" TextMode="Password"
                    Width="227px"></asp:TextBox>
            </p>
            <%--  <p>
                <asp:CheckBox ID="RememberMe" runat="server" />
                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Mantener iniciada la sesión.</asp:Label>
            </p>--%>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Login" OnClick="loginUsuario" />
        </p>
    </div>
</asp:Content>
