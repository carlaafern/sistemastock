<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ReporteEspecialidad.aspx.cs" Inherits="Centro_Salud.Presentacion.Informes.ReporteEspecialidad" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Reporte Especialidad
    </h2>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <br />
   
    <rsweb:ReportViewer ID="ReporteEsp" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1284px" 
        ondatabinding="Page_Load" Height="29px" SizeToReportContent="True">
        <LocalReport ReportPath="Reportes\ReporteEspecialidad.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="LinqDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
   
   
   
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="Centro_Salud.CentroSaludDatosDataContext" EntityTypeName="" 
        OrderBy="codigoEspecialidad" 
        Select="new (codigoEspecialidad, complejidad, descripcionEspecialidad, añosEspecialidad)" 
        TableName="Especialidads">
    </asp:LinqDataSource>

   
   
</asp:Content>
