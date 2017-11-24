//Edit event handler.
$("body").on("click", "[id*=gvUsuario] .Editar", function () {
    var row = $(this).closest("tr");
    //-----------------------------------
    var Id = row.find(".Id").find("span").html();
    var Correo = row.find(".Correo").find("span").html();
    var Id_Rol = row.find(".Id_Rol").find("span").html();
    //------------
    $('#ContentPlaceHolder_txtIdForm').val(Id);
    $('#ContentPlaceHolder_txtIdFormHide').val(Id);
    $('#ContentPlaceHolder_txtCorreoForm').val(Correo);
    $('#ContentPlaceHolder_txtIdRolForm').val(Id_Rol);
    $('#ContentPlaceHolder_ddlRolPermisoForm').val(Id_Rol);
    //-------------------
    $('#UsuariosAgregarEditarModal').modal('show');
   
    return false;
});
//Eliminar event
$("body").on("click", "[id*=gvUsuario] .Eliminar", function () {
    var row = $(this).closest("tr");
    //-----------------------------------
    var Id = row.find(".Id").find("span").html();
    //------------
    //$('#ContentPlaceHolder_txtIdForm').val(Id);
    //txtEliminarIdFormHide
    $('#ContentPlaceHolder_txtEliminarIdFormHide').val(Id);
    //-------------------
    $('#UsuariosEliminarModal').modal('show');

    return false;
});

