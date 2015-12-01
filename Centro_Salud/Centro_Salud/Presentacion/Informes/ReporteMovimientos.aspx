<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteMovimientos.aspx.cs" Inherits="Centro_Salud.Presentacion.Informes.ReporteMovimientos" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Reporte Movimientos
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <br />
   
    <rsweb:ReportViewer ID="ReporteMov" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1284px" 
        ondatabinding="Page_Load" Height="29px" SizeToReportContent="True">
        <LocalReport ReportPath="Reportes\ReporteMovimientos.rdlc">
            
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                    Name="DataSetMovimientos" />
            </DataSources>
            
        </LocalReport>
    </rsweb:ReportViewer>
   
   
   
   
   
   
   
  
  
   
    <asp:ObjectDataSource ID="Objetos" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">
    </asp:ObjectDataSource>
   
   
   
   
   
   
   
  
  
   
</asp:Content>

