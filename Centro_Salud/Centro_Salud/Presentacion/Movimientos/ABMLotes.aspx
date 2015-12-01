<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ABMLotes.aspx.cs" Inherits="Centro_Salud.Presentacion.Movimientos.ABMLotes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Lotes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h2>
    <p>
        Utilice el siguiente formulario para ingresar Lotes de Medicamentos.&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <asp:Panel ID="panelLotes" runat="server" Width="1032px">
        &nbsp;&nbsp; &nbsp; &nbsp;<asp:Panel ID="Panel1" runat="server" Width="954px" Height="49px">
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp; Nº de Lote:&nbsp; &nbsp;<asp:TextBox ID="nroLote" runat="server" 
                CssClass="textEntry"></asp:TextBox>
&nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" />
            <script type="text/javascript">
                Type.registerNamespace("ScriptLibrary");
                ScriptLibrary.BorderAnimation = function (color, duration) {
                    this._color = color;
                    this._duration = duration;
                }
                ScriptLibrary.BorderAnimation.prototype = {
                    animatePanel: function (panelElement) {
                        var s = panelElement.style;
                        s.borderWidth = '1px';
                        s.borderColor = this._color;
                        s.borderStyle = 'solid';
                        window.setTimeout(
                    function () { { s.borderWidth = 0; } },
                    this._duration
                );
                    }
                }
                ScriptLibrary.BorderAnimation.registerClass('ScriptLibrary.BorderAnimation', null);

                var panelUpdatedAnimation = new ScriptLibrary.BorderAnimation('blue', 1000);
                var postbackElement;
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequest);
                Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoaded);

                function beginRequest(sender, args) {
                    postbackElement = args.get_postBackElement();
                }
                function pageLoaded(sender, args) {
                    var updatedPanels = args.get_panelsUpdated();
                    if (typeof (postbackElement) === "undefined") {
                        return;
                    }
                    else if (postbackElement.id.toLowerCase().indexOf('extrashow') > -1) {
                        for (i = 0; i < updatedPanels.length; i++) {
                            panelUpdatedAnimation.animatePanel(updatedPanels[i]);
                        }
                    }

                }
            </script>
            <div class="UpdatePanelContainer">
                <%--<p>
                    
                    <asp:LinkButton ID="ExtraShow1" runat="server" OnClick="ExtraShow_Click" />
                    and
                    <asp:LinkButton ID="ExtraShow2" runat="server" OnClick="ExtraShow_Click" />. Don't
                    forget curtain time is at 7:00pm sharp. No late arrivals.
                </p>--%>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                   <%-- <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ExtraShow1" />
                        <asp:AsyncPostBackTrigger ControlID="ExtraShow2" />
                    </Triggers>--%>
                    <ContentTemplate>
                        <fieldset>
                            &nbsp;Fecha de Elaboración:
                            <asp:TextBox runat="server" ID="ChosenDate" 
                                OnTextChanged="ChosenDate_TextChanged" CssClass="textEntry" />
                            <asp:ImageButton runat="server" ID="ShowDatePickerPopOut" OnClick="ShowDatePickerPopOut_Click"
                                ImageUrl="/Imagenes/calendario.jpg" AlternateText="Choose a date." Height="20px"
                                Width="20px" />
                            <asp:Panel ID="DatePickerPopOut" CssClass="PopUpCalendarStyle" Visible="false" runat="server">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Calendar ID="CalendarPicker" runat="server" 
                                    OnSelectionChanged="CalendarPicker_SelectionChanged" BackColor="White" 
                                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                                    ForeColor="#003399" Height="200px" Width="220px">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                                        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                                <br />
                            </asp:Panel>
                           
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                   <%-- <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ExtraShow1" />
                        <asp:AsyncPostBackTrigger ControlID="ExtraShow2" />
                    </Triggers>--%>
                    <ContentTemplate>
                        <fieldset>
                            &nbsp;Fecha de Vencimiento:
                            <asp:TextBox runat="server" ID="fechaVencimiento" 
                                OnTextChanged="FechaVto_TextChanged" CssClass="textEntry" />
                            <asp:ImageButton runat="server" ID="ImageButton1" OnClick="ShowDatePickerPopOut1_Click"
                                ImageUrl="/Imagenes/calendario.jpg" AlternateText="Choose a date." Height="20px"
                                Width="20px" />
                            <asp:Panel ID="DatePickerPopOut1" CssClass="PopUpCalendarStyle" Visible="false" runat="server">
                                <asp:Calendar ID="CalendarPicker1" runat="server" 
                                    OnSelectionChanged="CalendarPicker1_SelectionChanged" BackColor="White" 
                                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                                    ForeColor="#003399" Height="200px" Width="220px">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                                        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                                <br />
                            </asp:Panel>
                            
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            &nbsp;&nbsp;&nbsp;

            <div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="bt_guardar" runat="server" OnClick="crearLote" Text="Guardar" 
                    CssClass="prgAvBtn" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                 ID="bt_cancelar" runat="server" Text="Cancelar" onclick="bt_cancelar_Click" 
                    CssClass="prgAvBtn" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            
        </asp:Panel>

        
    </asp:Panel>
    
   
</asp:Content>
