<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteVencimientos.aspx.cs"
    MasterPageFile="~/Site.Master" Inherits="Centro_Salud.Presentacion.Informes.ReporteVencimientos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Reporte de Vencimientos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h2>
    <p>
        En el siguiente reporte podrá visualizar medicamentos vencidos.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../../Imagenes/usuario.png" style="height: 53px; width: 57px" />
    </p>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />

    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="735px">
            <LocalReport ReportPath="Reportes\ReporteVto.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="LinqDataSource1" Name="dsNuevo" />
                    <rsweb:ReportDataSource DataSourceId="LinqDataSource2" Name="dsMedicamento" />
                    <rsweb:ReportDataSource DataSourceId="LinqDataSource3" Name="dsStock" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    
        <asp:LinqDataSource ID="LinqDataSource3" runat="server" 
            ContextTypeName="Centro_Salud.CentroSaludDatosDataContext" EntityTypeName="" 
            Select="new (fechaVto, nroLote)" TableName="Lotes">
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
            ContextTypeName="Centro_Salud.CentroSaludDatosDataContext" EntityTypeName="" 
            Select="new (codigo, descripcion, stockMinimo)" TableName="Medicamentos">
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="Centro_Salud.CentroSaludDatosDataContext" EntityTypeName="" 
            Select="new (stockActual, codigoMedicamento, lote, fechaBaja)" 
            TableName="StockMedicamentos">
        </asp:LinqDataSource>
    
    </div>
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bt_Enviar" runat="server" Text="Enviar Reporte" 
            CssClass="prgAvBtn" onclick="bt_Enviar_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="bt_Cancelar" runat="server" Text="Cancelar" 
            CssClass="prgAvBtn" onclick="bt_Cancelar_Click" />
           
    </div>
</asp:Content>
