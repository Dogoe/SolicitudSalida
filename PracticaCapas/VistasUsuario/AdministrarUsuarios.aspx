<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="PracticaCapas.VistasUsuario.AdministrarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
   
    <form id="formUsuariosAcademicos" runat="server"> 
    <div>
        <asp:Label ID="msj" Text="" runat="server" />
        <asp:GridView ID="gvUsuario" CssClass="table table-responsive table-bordered table-striped" 
            runat="server" OnPageIndexChanging="gvUsuario_PageIndexChanging" AllowPaging="True" PageSize="6" AutoGenerateColumns="false">
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
                <asp:TemplateField HeaderText="Carrera" ItemStyle-Width="" ItemStyle-CssClass="Carrera control-label">
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
        <i>Estas viendo <%=gvUsuario.PageIndex + 1%> de <%=gvUsuario.PageCount%> Registros</i>
         <!-- Trigger the modal with a button -->

         <!-- Modal -->
        <div id="UsuariosAgregarEditarModal" class="modal fade" data-backdrop="static" data-keyboard="false" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Editar</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:TextBox ID="txtIdUsuario" class="form-control" Text="" runat="server" Style="display: none" />
                            <label for="txtNombreRol"><span class="glyphicon glyphicon-user"></span>Nombre Rol:</label>
                            <asp:TextBox ID="txtNombreRolHide" class="form-control" Text="" runat="server" Style="display: none" />
                            <asp:TextBox ID="txtNombreRol" class="form-control" Text="" runat="server" placeholder="Id Usuario" disabled="true" />

                        </div>
                        <div class="form-group">
                            <label for="txtDescripcion">Descripcion:</label>
                            <asp:TextBox ID="txtDescripcionHide" class="form-control" Text="" runat="server" placeholder="Descripcion" Style="display: none" />
                            <asp:TextBox ID="txtDescripcion" class="form-control" Text="" runat="server" placeholder="Correo" disabled="true" />
                        </div>
                        <div class="form-group">
                            <label for="txtCarrera">Carrera:</label>
                            <asp:TextBox ID="txtCarreraHide" class="form-control" Text="" runat="server" Style="display: none" />
                            <asp:TextBox ID="txtCarrera" class="form-control" Text="" runat="server" placeholder="Carrera" disabled="true" />
                        </div>
                        <div class="form-group">
                            <label for="txtNuevoCorreo">Correo:</label>
                            <asp:TextBox ID="txtCorreoAnterior" Text="" runat="server" Style="display: none" />
                            <asp:TextBox ID="txtNuevoCorreo" class="form-control" Text="" runat="server" placeholder="Correo" />
                            <asp:Label ID="lblNotificacionCorreoValido" Text="" runat="server" CssClass="control-label" />
                        </div>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnUpdate" OnClick="Guardar_Usuario_click" Text="Guardar Cambios" runat="server" CssClass="btn btn-success" />
                        <asp:Button ID="BtnCancelar" Text="Cancelar" runat="server" CssClass="Actualizar btn btn-danger" />
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
    </form>
</asp:Content>
