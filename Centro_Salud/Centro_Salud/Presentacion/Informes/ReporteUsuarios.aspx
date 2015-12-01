<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteUsuarios.aspx.cs" Inherits="Centro_Salud.Presentacion.Informes.ReporteUsuarios" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Reporte Usuarios
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <br />
   
    <rsweb:ReportViewer ID="ReporteEsp" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1284px" 
        ondatabinding="Page_Load" Height="29px" SizeToReportContent="True">
        <LocalReport ReportPath="Reportes\ReporteUsuarios.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="LinqDataSource2" Name="DataSet2" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
   
   
   
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
        ContextTypeName="Centro_Salud.CentroSaludDatosDataContext" EntityTypeName="" 
        OrderBy="codigoUsuario, fechaVigencia" 
        Select="new (codigoUsuario, login, fechaVigencia, estado, perfil, mail, recibeAlertas)" 
        TableName="Usuarios">
    </asp:LinqDataSource>
   
  
   
</asp:Content>

