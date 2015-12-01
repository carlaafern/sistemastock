<%@ Page Title="Editar Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditarEspecialidad.aspx.cs" Inherits="Centro_Salud.Presentacion.AbmEspecialidad.EditarEspecialidad" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 82px;
            height: 82px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Editar Especialidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h2>
    <p>
        Utilice el siguiente formulario para editar una especialidad existente.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img class="style1" src="../../Imagenes/especialidad.png" />
    </p>
    <div class="accountInfo">
        &nbsp;<fieldset class="register">
            <legend>Modificar Especialidad</legend>
            <p>
                <asp:Label ID="lb_especialidad" runat="server" Text="Especialidad: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
            <p>
                <asp:TextBox ID="txt_nombreEsp" runat="server" CssClass="textEntry"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Buscar" runat="server" Text="Buscar" Height="31px"
                    OnClick="bt_Buscar_Click" CssClass="prgAvBtn" />
            </p>
            <p>
                <asp:GridView ID="gv_Especialidad" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    onrowdeleting="gvEspecialidad_Eliminar" onrowediting="gvEspecialidad_Editar" 
                    onrowupdating="gvEspecialidad_Actualizar" Width="750px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="Eliminar" EditText="Editar" 
                            ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="codigoEspecialidad" HeaderText="Código" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="descripcionEspecialidad" HeaderText="Nombre" 
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="Complejidad">
                            <ItemTemplate>
                                <asp:Label ID="lbComplej" runat="server" Text='<%# Bind("complejidad") %>'></asp:Label> 
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:DropDownList ID="ddl_complejidad" runat="server" 
                                    DataSourceID="ds_complejidad" DataTextField="valor" DataValueField="valor">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="ds_complejidad" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:centro_saludConnectionString1%>" 
                                    SelectCommand="SELECT * FROM [Complejidad]"></asp:SqlDataSource>                            
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="añosEspecialidad" HeaderText="Años" />
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
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Guardar" runat="server" onclick="bt_Guardar_Click" 
                    Text="Guardar" Visible="False" CssClass="prgAvBtn" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Cancelar" runat="server" onclick="bt_Cancelar_Click" 
                    Text="Cancelar" Visible="False" CssClass="prgAvBtn" />
            </p>
            
        </fieldset>
    </div>
</asp:Content>
