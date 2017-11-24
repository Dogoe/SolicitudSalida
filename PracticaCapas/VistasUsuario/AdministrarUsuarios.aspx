<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="PracticaCapas.VistasUsuario.AdministrarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div>
        <asp:Label ID="msj" Text="" runat="server" />
        <asp:GridView ID="gvUsuario" class="table table-bordered table-hover" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Id"  ItemStyle-CssClass="Id">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Id") %>' runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Correo"  ItemStyle-CssClass="Correo">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Correo") %>' runat="server"/>
                        <asp:TextBox Text='<%# Eval("Correo") %>' runat="server" Style="display: none" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Id_Rol" ItemStyle-Width="90px" ItemStyle-CssClass="Id_Rol">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Id_Rol") %>' runat="server" />
                        <asp:TextBox Text='<%# Eval("Id_Rol") %>' runat="server" Style="display: none" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "Rol-Permisos">
                    <ItemTemplate>
                        <asp:Label ID="lblPermisosRol" Text='<%# Eval("Id_Rol") %>' runat="server" Visible = "false"/>
                        <asp:DropDownList ID="ddlPermisosRol" runat="server" CssClass="form-control" disabled="true">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
               
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <button id="<%# Eval("Id") %>" type="button" class="Editar btn btn-info">Editar</button>
                        <asp:Button ID="BtnDelete" Text="Eliminar" runat="server" CssClass="Eliminar btn btn-danger"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

         <!-- Trigger the modal with a button -->

         <!-- Modal -->
         <div id="UsuariosAgregarEditarModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Editar</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                          <label for="txtIdForm"><span class="glyphicon glyphicon-user"></span> ID Usuario:</label>
                          <asp:TextBox ID="txtIdFormHide" class="form-control" text="" runat="server" placeholder="Id Usuario" Style="display: none"/>
                          <asp:TextBox ID="txtIdForm" class="form-control" text="" runat="server" placeholder="Id Usuario" disabled="true"/>
                
                        </div>
                        <div class="form-group">
                          <label for="txtCorreoForm">Correo:</label>
                          <asp:TextBox ID="txtCorreoForm" class="form-control" text="" runat="server" placeholder="Correo"/>
                        </div>
                        <div class="form-group">
                          <label for="txtIdRolForm">Id_Rol:</label>
                          <asp:TextBox ID="txtIdRolForm" class="form-control" text="" runat="server" placeholder="Rol" Style="display: none"/>
                        </div>
                        <div class="form-group">
                          <label for="txtIdRolForm">Rol-Permiso:</label>
                          <asp:DropDownList ID="ddlRolPermisoForm" runat="server" CssClass="form-control"> 
                          </asp:DropDownList>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnUpdate" onclick="Guardar_Usuario_click" Text="Guardar Cambios" runat="server" CssClass="Actualizar btn btn-success"/>
                        <asp:Button ID="BtnCancelar" Text="Cancelar" runat="server" CssClass="Actualizar btn btn-danger"/>
                    </div>
                </div>

             </div>
         </div>
        <!-- Modal Eliminar-->
        <div id="UsuariosEliminarModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Eliminar</h4>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox ID="txtEliminarIdFormHide" class="form-control" text="" runat="server"  Style="display: none"/>
                        <h4 class="">Seguro que deseas eliminar a este Usuario?</h4>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnEliminar" onclick="Eliminar_Usuario_click" Text="Eliminar" runat="server" CssClass="btn btn-danger"/>
                        <asp:Button ID="Button2" Text="Cancelar" runat="server" CssClass="btn btn-default" />
                    </div>
                </div>

             </div>
         </div>
         <script src="../Resources/Jquery-3.2.1/js/jquery-3.2.1.min.js"></script> 
        <script src="../VistasUsuario/js/AdmiUsuarios.js"></script>
    
    </div>
</asp:Content>
