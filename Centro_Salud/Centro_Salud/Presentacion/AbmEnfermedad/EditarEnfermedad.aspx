<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEnfermedad.aspx.cs" Inherits="Centro_Salud.Presentacion.AbmEnfermedad.EditarEnfermedad" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Editar ENFERMEDAD&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h2>
    <p>
        Utilice el siguiente formulario para editar una enfermedad existente.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../../Imagenes/logo3.png" style="height: 44px; width: 71px" />
    </p>
    <div class="accountInfo">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <fieldset class="register">
            <legend>Modificar Enfermedad</legend>
            <p>
                <asp:Label ID="lb_enfermedad" runat="server" Text="Enfermedad: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>

            <p>
                <asp:TextBox ID="txt_nombreEnf" runat="server" CssClass="textEntry" Width="200px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_Buscar" runat="server" Text="Buscar" Height="31px" Width="109px"
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
                        <asp:BoundField DataField="codigoEnfermedad" HeaderText="Código" ReadOnly="true"/>
                        <asp:BoundField DataField="descripcionEnfermedad" HeaderText="Nombre" ReadOnly="true" />
                        <asp:BoundField DataField="tratamiento" HeaderText="Tratamiento" />
                        <asp:BoundField DataField="diasReposo" HeaderText="Dias Reposo" />
                        <asp:BoundField DataField="requiereInternacion" HeaderText="Internación" />
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
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_guardar" runat="server" Text="Guardar" Width="109px" 
                    onclick="bt_guardar_Click" Visible="False" CssClass="prgAvBtn" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_cancelar" runat="server" Text="Cancelar" Width="109px" 
                    Visible="False" onclick="bt_cancelar_Click" CssClass="prgAvBtn" />
            </p>
           
        </fieldset>
    </div>
</asp:Content>
