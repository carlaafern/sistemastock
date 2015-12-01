<%@ Page Title="Login" Language="C#"  MasterPageFile="~/Site2.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Centro_Salud.Presentacion.Login" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Login" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        &nbsp;</h2>
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
                &nbsp;
                <asp:RequiredFieldValidator ID="UserRequerido" runat="server" 
                    BorderColor="Black" ErrorMessage="El campo usuario es requerido." 
                    ControlToValidate="txt_nombre" CssClass="failureNotification" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lb_password" runat="server" Text="Contraseña:     " CssClass="passwordEntry"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_password" runat="server" CssClass="passwordEntry" TextMode="Password"
                    Width="227px"></asp:TextBox>
                &nbsp;
                <asp:RequiredFieldValidator ID="PasswordRequerida" runat="server" 
                    BorderColor="Black" ErrorMessage="El campo contraseña es requerido." 
                    ControlToValidate="txt_password" CssClass="failureNotification" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </p>
            <%--  <p>
                <asp:CheckBox ID="RememberMe" runat="server" />
                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Mantener iniciada la sesión.</asp:Label>
            </p>--%>
        </fieldset>
         &nbsp;&nbsp;
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <p class="submitButton">
            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar" OnClick="loginUsuario" CssClass="prgAvBtn" />
        </p>
    </div>

</asp:Content>
