<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="SolicitudesRealizadas.aspx.cs" Inherits="PracticaCapas.VistasUsuario.SolicitudesRealizadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="formSolicitudesRealizadas" runat="server"> 
    <div>
        <asp:Label ID="msj" Text="" runat="server" />
        <asp:GridView ID="gvSolicitudesRealizadas" CssClass="table table-responsive table-bordered table-striped" 
            runat="server" PageSize="6" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Nombre Rol"  ItemStyle-CssClass="Nombre_Rol control-label">
                    <ItemTemplate>
                        <small><asp:Label Text='<%# Eval("Nombre_Rol") %>' runat="server" CssClass="control-label"/></small>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripcion" ItemStyle-Width="" ItemStyle-CssClass="Descripcion control-label">
                    <ItemTemplate>
                        <small><asp:Label Text='<%# Eval("Descripcion") %>' runat="server" CssClass="control-label" /></small>
                        <asp:TextBox Text='<%# Eval("Descripcion") %>' runat="server" Style="display: none" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Carrera" ItemStyle-Width="" ItemStyle-CssClass="Descripcion control-label">
                    <ItemTemplate>
                        <small><asp:Label Text='<%# Eval("Nombre_carrera") %>' runat="server" /></small>
                        <asp:TextBox Text='<%# Eval("Nombre_carrera") %>' runat="server" Style="display: none" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Correo"  ItemStyle-CssClass="Correo control-label">
                    <ItemTemplate>
                        <small> <asp:Label Text='<%# Eval("Correo") %>' runat="server" CssClass="control-label"/></small> 
                        <asp:TextBox Text='<%# Eval("Correo") %>' runat="server" Style="display: none" />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <button type="button" class="Editar btn btn-primary btn-xs glyphicon glyphicon-pencil"></button>
                        <asp:Button ID="BtnDelete" Text="" runat="server" CssClass="Eliminar btn btn-danger btn-xs glyphicon glyphicon-remove-sign" Style="display: none"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <i>Estas viendo <%=gvSolicitudesRealizadas.PageIndex + 1%> de <%=gvSolicitudesRealizadas.PageCount%> Registros</i>

         <!-- Modal -->
        <!-- Modal Eliminar-->
    
    </div>
    </form>
</asp:Content>
