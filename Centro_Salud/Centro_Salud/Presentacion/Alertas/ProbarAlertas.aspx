
<%@ Page Title="ProbarAlertas" Language="C#"  AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ProbarAlertas.aspx.cs" Inherits="Centro_Salud.Presentacion.Alertas.ProbarAlertas"%>
                                                                                                                                       
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Página de pruebas
    </h2>
   <div>

       <asp:Button ID="bt_enviar" runat="server" Text="Enviar" 
           onclick="bt_enviar_Click" />
   
   
   </div>
   
</asp:Content>

