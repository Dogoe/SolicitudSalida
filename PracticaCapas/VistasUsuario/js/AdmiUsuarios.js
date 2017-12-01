$("body").on("click", "[id*=gvUsuario] .Editar", function () {
    //Edit event handler.
    var row = $(this).closest("tr");
    //-----------------------------------
    //var Id = row.find(".Id").find("span").html();
    var Nombre_Rol = row.find(".Nombre_Rol").find("span").html();
    var Descripcion = row.find(".Descripcion").find("span").html();
    var Carrera = row.find(".Carrera").find("span").html();
    var Correo = row.find(".Correo").find("span").html();
    //console.log(Nombre_Rol + Descripcion + Carrera + Correo);
    //--------------------------------------------------------
    //$('#ContentPlaceHolder_txtIdUsuario').val(Id);
    //$('#ContentPlaceHolder_txtIdUsuarioHide').val(Id);

    $('#ContentPlaceHolder_txtNombreRol').val(Nombre_Rol);
    $('#ContentPlaceHolder_txtNombreRolHide').val(Nombre_Rol);

    $('#ContentPlaceHolder_txtDescripcion').val(Descripcion);
    $('#ContentPlaceHolder_txtDescripcionHide').val(Descripcion);

    $('#ContentPlaceHolder_txtCarrera').val(Carrera);
    $('#ContentPlaceHolder_txtCarreraHidde').val(Carrera);

    $('#ContentPlaceHolder_txtCorreoAnterior').val(Correo);
    $('#ContentPlaceHolder_txtNuevoCorreo').val(Correo);
    //-------------------
    $('#UsuariosAgregarEditarModal').modal('show');
   
    return false;
});
function notificacion(mensaje, color){
    $.notify({
        // options
        message: mensaje
    }, {
            // settings
            type: color
        });
}
//Eliminar event
/*$("body").on("click", "[id*=gvUsuario] .Eliminar", function () {
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
});*/

