using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class AdministrarUsuarios : System.Web.UI.Page
    {
        EUsuario_Uabc usuario;
        ERol_Usuario rolUser;
        protected static N_Usuario nUsuario;
        protected static DataSet datosListaUsuario;
        protected static DataSet datosLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (EUsuario_Uabc)Session["Usuario"];
            rolUser = (ERol_Usuario)Session["Rol_Usuario"];
            if (!IsPostBack && usuario != null)
            {

                nUsuario = new N_Usuario();
                //datosListaUsuario = nUsuario.ListaRoles()
               /* nUsuario = new N_Usuario();
                datosListaUsuario = nUsuario.ListaRoles();
                foreach (DataRow row in datosListaUsuario.Tables[0].Rows)
                {
                    ListItem oItem = new ListItem(row.ItemArray[1].ToString() + " - " + row.ItemArray[2].ToString(), row.ItemArray[0].ToString());
                    ddlRolPermisoForm.Items.Add(oItem);
                }
                ddlRolPermisoForm.DataBind();*/
                //if()
                CargarTablaUsuarios();
               

            }
        }
        //-------------------------------------------------
        protected void Guardar_Usuario_click(object sender, EventArgs e)
        {
            string CorreoAnterior = txtCorreoAnterior.Text;
            string NuevoCorreo = txtNuevoCorreo.Text;
            //------------------
            EUsuario usuario = nUsuario.ObtenerUsuarioPorCorreo(CorreoAnterior);
            //-----------------
            if (nUsuario.AutenticarUsuarioFiad(NuevoCorreo))
            {
                usuario.Correo = NuevoCorreo;
                nUsuario.ActualizarUsuario(usuario);
                CargarTablaUsuarios();
                //return true;
            }
            else
            {
                
                /*$.notify({
                 message: 'Notificacion'
                    }, {
                 type: 'danger'
                  });*/
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " notificacion('Si funciono', 'danger');", true);
                lblNotificacionCorreoValido.Text = "El correo no pertenece a la FIAD";
                //return false;
            }
            
       
        }
        //----------------------------------------------------
        protected void Eliminar_Usuario_click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtEliminarIdFormHide.Text.ToString());
            if (nUsuario.EliminarUsuarioPorId(Id))
            {

            }
            CargarTablaUsuarios();
        }
        

        //------------------------------------------------
        //------------------------------------
        private void CargarTablaUsuarios()
        {
            /*N_Usuario nUsuario = new N_Usuario();
            DataSet datosLista = nUsuario.ListaUsuario();*/
            datosLista = nUsuario.ListaUsuario();
         
            //ddlRolPermisoForm = new DropDownList();
            if (datosLista.Tables.Count > 0)
            {

                gvUsuario.DataSource = datosLista;
                gvUsuario.DataBind();
                //-------------------------
                
                //Console.Out.Write(datosLista);
            }
            else
            {
                msj.Text = "Ocurrio un error al intentar cargar los datos de la base de datos.";
            }
        }
        //------------------------------------------------------
        protected void gvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuario.PageIndex = e.NewPageIndex;
            CargarTablaUsuarios();
            //gvUsuario.DataBind();
        }
        /*protected DropDownList ObtenerNombreRolesParaDropDownL(DropDownList list)
        {
            foreach (DataRow row in datosListaUsuario.Tables[0].Rows)
            {
                ListItem oItem = new ListItem(row.ItemArray[1].ToString() + " - " + row.ItemArray[2].ToString(), row.ItemArray[0].ToString());
                list.Items.Add(oItem);
            }
            return list;
        }*/
        //------------------------------------------
        /* protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
         {
             /*N_Usuario nUsuario = new N_Usuario();
             DataSet datosListaUsuario = nUsuario.ListaRoles();
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 DropDownList ddlPermisosRol = (e.Row.FindControl("ddlPermisosRol") as DropDownList);
                 DropDownList ddlTemporal = new DropDownList();
                 //ddlPermisosRol = ObtenerNombreRolesParaDropDownL(ddlPermisosRol);
                 foreach (DataRow row in datosListaUsuario.Tables[0].Rows)
                 {
                     ListItem iItem = new ListItem(row.ItemArray[1].ToString() + " - " + row.ItemArray[2].ToString(), row.ItemArray[0].ToString());
                     //ddlPermisosRol.Items.Add(oItem);
                     ddlTemporal.Items.Add(iItem);

                 }
                 //ddlPermisosRol.DataBind();
                 ddlTemporal.DataBind();
                 string id_rol = (e.Row.FindControl("lblPermisosRol") as Label).Text;
                 //ddlPermisosRol.Items.FindByValue(customerId).Selected = true;
                 ddlTemporal.Items.FindByValue(id_rol).Selected = true;
                 ListItem oItem = ddlTemporal.Items.FindByValue(id_rol);
                 ddlPermisosRol.Items.Add(oItem);
                 ddlPermisosRol.DataBind();
             }
         }*/
    }
}