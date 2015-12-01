<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarMedicamento.aspx.cs" Inherits="Centro_Salud.Presentacion.AbmMedicamentos.EditarMedicamento" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 42px;
            height: 37px;
        }
    </style>
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Editar Medicamento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h2>
    <p>
        Utilice el siguiente formulario para editar una medicamento existente.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <img alt="" class="style2" src="../../Imagenes/maletin.jpg" /></p>
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Modificar Medicamento</legend>
            <p>
                Medicamento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_nombreMed" runat="server" CssClass="textEntry" 
                    Width="200px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Buscar" runat="server" Text="Buscar" Height="31px"
                    OnClick="bt_Buscar_Click" CssClass="prgAvBtn" />
         
                </p>
            <p>        
                <asp:GridView ID="gv_Enfermedad" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    onrowdeleting="gvEnfermedad_Eliminar" onrowediting="gvEnfermedad_Editar" 
                    onrowupdating="gvEnfermedad_Actualizar">         
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="Eliminar" EditText="Editar" 
                            ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="codigo" HeaderText="Código" ReadOnly="true"/>
                        <asp:BoundField DataField="descripcion" HeaderText="Nombre" ReadOnly="true" />
                        <asp:BoundField DataField="monoDroga" HeaderText="Monodroga" />
                        <asp:BoundField DataField="descripcionAmpliada" 
                            HeaderText="Descripcion Ampliada" />
                        <%--<asp:BoundField DataField="formato" HeaderText="Formato" />
                        <asp:BoundField DataField="unidadMedida" HeaderText="UnidadMedida" />
--%>
                        <asp:TemplateField HeaderText="Formato">
                            <ItemTemplate>
                                <asp:Label ID="lbFormato" runat="server" Text='<%# Bind("formato") %>'></asp:Label> 
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:DropDownList ID="ddl_formato" runat="server" 
                                    DataSourceID="ds_formato" DataTextField="descripcionPresentacion" DataValueField="descripcionPresentacion">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="ds_formato" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:centro_saludConnectionString1 %>" 
                                    SelectCommand="SELECT * FROM [Formato]"></asp:SqlDataSource>                            
                            </EditItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="UnidadMedida">
                            <ItemTemplate>
                                <asp:Label ID="lbUnidadMed" runat="server" Text='<%# Bind("unidadmedida") %>'></asp:Label> 
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:DropDownList ID="ddl_unidadMed" runat="server" 
                                    DataSourceID="ds_unidadMed" DataTextField="descripcionUnidadMed" DataValueField="descripcionUnidadMed">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="ds_unidadMed" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:centro_saludConnectionString1 %>" 
                                    SelectCommand="SELECT * FROM [UnidadMedida]"></asp:SqlDataSource>                            
                            </EditItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_guardar" runat="server" Text="Guardar" 
                    onclick="bt_guardar_Click" Visible="False" CssClass="prgAvBtn" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_cancelar" runat="server" Text="Cancelar" 
                    Visible="False" onclick="bt_cancelar_Click" CssClass="prgAvBtn" />
            </p>
           
        </fieldset>
    </div>
</asp:Content>
