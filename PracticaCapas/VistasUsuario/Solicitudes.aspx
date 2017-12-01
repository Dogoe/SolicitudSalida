<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="PracticaCapas.VistasUsuario.Solicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="formSolicitudesRealizadas" runat="server"> 
    <div>
        <button id="btnNuevaSolicitud" data-toggle="modal" data-target="#SolicitudesAgregarEditarModal" class="btn btn-info glyphicon glyphicon-plus">Generar Nueva Solicitud</button>
        <h3>Solicitudes Realizadas</h3>
        <asp:Label ID="msj" Text="" runat="server" />
        <asp:GridView ID="gvMisSolicitudes" CssClass="table table-responsive table-bordered table-striped" 
            runat="server" OnPageIndexChanging="gvMisSolicitudes_PageIndexChanging" AllowPaging="True" PageSize="6" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Id"  ItemStyle-CssClass="Id control-label">
                    <ItemTemplate>
                        <small><asp:Label Text='<%# Eval("Id") %>' runat="server" CssClass="control-label"/></small>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Numero de Empleado" ItemStyle-Width="" ItemStyle-CssClass="Numero_Empleado control-label">
                    <ItemTemplate>
                        <small><asp:Label Text='<%# Eval("Numero_Empleado") %>' runat="server" CssClass="control-label" /></small>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre" ItemStyle-Width="" ItemStyle-CssClass="Nombre_Solicitante control-label">
                    <ItemTemplate>
                        <small><asp:Label Text='<%# Eval("Nombre_Solicitante") %>' runat="server" /></small>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Salida"  ItemStyle-CssClass="Fecha_Hora_Salida control-label">
                    <ItemTemplate>
                        <small> <asp:Label Text='<%# Eval("Fecha_Hora_Salida") %>' runat="server" CssClass="control-label"/></small>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado"  ItemStyle-CssClass="Estado control-label">
                    <ItemTemplate>
                        <small> <asp:Label Text='<%# Eval("Tipo") %>' runat="server" CssClass="control-label"/></small>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <button type="button" class="btn btn-primary btn-xs glyphicon glyphicon-pencil"></button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <i>Estas viendo <%=gvMisSolicitudes.PageIndex + 1%> de <%=gvMisSolicitudes.PageCount%> Registros</i>

         <!-- Modal -->
        <!-- Modal Eliminar-->
    
    </div>
    </form>
</asp:Content>
