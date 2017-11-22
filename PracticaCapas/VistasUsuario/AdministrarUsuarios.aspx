<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="PracticaCapas.VistasUsuario.AdministrarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div>
        <asp:GridView ID="gvUsuario" class="table table-bordered table-hover" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Id" ItemStyle-Width="110px" ItemStyle-CssClass="Id">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Id") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Correo" ItemStyle-Width="150px" ItemStyle-CssClass="Correo">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Correo") %>' runat="server" />
                        <asp:TextBox Text='<%# Eval("Correo") %>' runat="server" Style="display: none" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Id_Rol" ItemStyle-Width="150px" ItemStyle-CssClass="Id_Rol">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Id_Rol") %>' runat="server" />
                        <asp:TextBox Text='<%# Eval("Id_Rol") %>' runat="server" Style="display: none" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Edit" runat="server" CssClass="Edit btn btn-primary" />
                        <asp:LinkButton Text="Update" runat="server" CssClass="Update btn btn-success" Style="display: none" />
                        <asp:LinkButton Text="Cancel" runat="server" CssClass="Cancel btn btn-danger" Style="display: none" />
                        <asp:LinkButton Text="Delete" runat="server" CssClass="Delete btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <!--<table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>
                <td style="width: 150px">
                    Correo:<br />
                    <asp:TextBox ID="txtCorreo" runat="server" Width="140" />
                </td>
                <td style="width: 150px">
                    Id_Rol:<br />
                    <asp:TextBox ID="txtId_Rol" runat="server" Width="140" />
                </td>
                <td style="width: 100px">
                    <br />
                    <asp:Button ID="btnAdd" runat="server" Text="Add" />
                </td>
            </tr>
        </table>-->
        <!-- Scrip-->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js "></script>
        <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "AdministrarUsuarios.aspx/GetUsuario",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess
            });
        });

        function OnSuccess(response) {
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var Usuario = xml.find("Table");
            var row = $("[id*=gvUsuario] tr:last-child").clone(true);
            $("[id*=gvUsuario] tr").not($("[id*=gvUsuario] tr:first-child")).remove();
            $.each(Usuario, function () {
                var customer = $(this);
                AppendRow(row, $(this).find("Id").text(), $(this).find("Correo").text(), $(this).find("Id_Rol").text())
                row = $("[id*=gvUsuario] tr:last-child").clone(true);
            });
        }

        function AppendRow(row, Id, Correo, Id_Rol) {
            //Bind Id.
            $(".Id", row).find("span").html(Id);

            //Bind Correo.
            $(".Correo", row).find("span").html(Correo);
            $(".Correo", row).find("input").val(Correo);

            //Bind Id_Rol.
            $(".Id_Rol", row).find("span").html(Id_Rol);
            $(".Id_Rol", row).find("input").val(Id_Rol);
            $("[id*=gvUsuario]").append(row);
        }

        //Add event handler.
        $("body").on("click", "[id*=btnAdd]", function () {
            var txtCorreo = $("[id*=txtCorreo]");
            var txtId_Rol = $("[id*=txtId_Rol]");
            $.ajax({
                type: "POST",
                url: "AdministrarUsuarios.aspx/CrearUsuario",
                data: '{Correo: "' + txtCorreo.val() + '", Id_Rol: "' + txtId_Rol.val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var row = $("[id*=gvUsuario] tr:last-child").clone(true);
                    AppendRow(row, response.d, txtCorreo.val(), txtId_Rol.val());
                    txtCorreo.val("");
                    txtId_Rol.val("");
                }
            });
            return false;
        });

        //Edit event handler.
        $("body").on("click", "[id*=gvUsuario] .Edit", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find("input").length > 0) {
                    $(this).find("input").show();
                    $(this).find("span").hide();
                }
            });
            row.find(".Update").show();
            row.find(".Cancel").show();
            row.find(".Delete").hide();
            $(this).hide();
            return false;
        });

        //Update event handler.
        $("body").on("click", "[id*=gvUsuario] .Update", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find("input").length > 0) {
                    var span = $(this).find("span");
                    var input = $(this).find("input");
                    span.html(input.val());
                    span.show();
                    input.hide();
                }
            });
            row.find(".Edit").show();
            row.find(".Delete").show();
            row.find(".Cancel").hide();
            $(this).hide();

            var Id = row.find(".Id").find("span").html();
            var Correo = row.find(".Correo").find("span").html();
            var Id_Rol = row.find(".Id_Rol").find("span").html();
            $.ajax({
                type: "POST",
                url: "AdministrarUsuarios.aspx/UpdateCustomer",
                data: '{Id: ' + Id + ', Correo: "' + Correo + '", Id_Rol: "' + Id_Rol + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            });

            return false;
        });

        //Cancel event handler.
        $("body").on("click", "[id*=gvUsuario] .Cancel", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find("input").length > 0) {
                    var span = $(this).find("span");
                    var input = $(this).find("input");
                    input.val(span.html());
                    span.show();
                    input.hide();
                }
            });
            row.find(".Edit").show();
            row.find(".Delete").show();
            row.find(".Update").hide();
            $(this).hide();
            return false;
        });

        //Delete event handler.
        $("body").on("click", "[id*=gvUsuario] .Delete", function () {
            if (confirm("Do you want to delete this row?")) {
                var row = $(this).closest("tr");
                var Id = row.find("span").html();
                $.ajax({
                    type: "POST",
                    url: "AdministrarUsuarios.aspx/DeleteCustomer",
                    data: '{Id: ' + Id + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        row.remove();
                    }
                });
            }

            return false;
        });
    </script>
    </div>
</asp:Content>
