<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultaUsuarios.aspx.cs" Inherits="Centro_Salud.Presentacion.AbmUsuario.ConsultaUsuarios" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Usuarios&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h2>
    <p>
        Utilice el siguiente formulario para editar usuarios.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <img src="../../Imagenes/usuario.png" style="height: 53px; width: 57px" />
    </p><br />
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Modificar Usuarios</legend>
            <p>
                Usuario:<asp:TextBox ID="txt_nombreUs" runat="server" CssClass="textEntry" Width="200px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Buscar" runat="server" Text="Buscar" Height="31px" Width="109px"
                    OnClick="bt_Buscar_Click" CssClass="prgAvBtn" />
            </p>
            <p>
                <asp:GridView ID="gv_Usuarios" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnRowDeleting="gvUsuario_Eliminar" OnRowEditing="gvUsuario_Editar"
                    OnRowUpdating="gvUsuario_Actualizar" Width="964px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="Eliminar" EditText="Editar" ShowCancelButton="False"
                            ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="codigoUsuario" HeaderText="Código" ReadOnly="true" />
                        <asp:BoundField DataField="login" HeaderText="Nombre" ReadOnly="true" />
                        <asp:BoundField DataField="contraseña" HeaderText="Contraseña" DataFormatString="******" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lbEstado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_estados" runat="server">
                                    <asp:ListItem Value="1">True</asp:ListItem>
                                    <asp:ListItem Value="2">False</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Perfil">
                            <ItemTemplate>
                                <asp:Label ID="lbPefil" runat="server" Text='<%# Bind("perfil") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_perfiles" runat="server" DataSourceID="ds_perfil" DataTextField="descripcion"
                                    DataValueField="descripcion">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="ds_perfil" runat="server" ConnectionString="<%$ ConnectionStrings:centro_saludConnectionString1%>"
                                    SelectCommand="SELECT * FROM [Perfil]"></asp:SqlDataSource>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="mail" HeaderText="Correo" />
                        <asp:TemplateField HeaderText="Alerta">
                            <ItemTemplate>
                                <asp:Label ID="lbAlerta" runat="server" Text='<%# Bind("recibeAlertas") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_alertas" runat="server">
                                    <asp:ListItem Value="1">True</asp:ListItem>
                                    <asp:ListItem Value="2">False</asp:ListItem>
                                </asp:DropDownList>
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
                    <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
                    <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
                    <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
                    <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_guardar" runat="server" Text="Guardar" Width="109px" OnClick="bt_guardar_Click"
                    Visible="False" CssClass="prgAvBtn" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Imprimir" 
                    runat="server" 
                    Text="Imprimir" Width="108px" onclick="bt_Imprimir_Click" 
                    Visible="False" CssClass="prgAvBtn" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_cancelar" runat="server" Text="Cancelar" Width="109px" Visible="False"
                    OnClick="bt_cancelar_Click" CssClass="prgAvBtn" />
            </p>
        </fieldset>
    </div>
</asp:Content>
