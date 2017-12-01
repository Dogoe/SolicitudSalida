using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class Solicitudes : System.Web.UI.Page
    {
        EUsuario_Uabc usuario;
        ERol_Usuario rolUser;
        protected static N_Solicitud nSolicitud;
        protected static DataSet datosListaMisSolicitudes;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (EUsuario_Uabc)Session["Usuario"];
            rolUser = (ERol_Usuario)Session["Rol_Usuario"];
            if (!IsPostBack && usuario != null)
            {
                CargarTablaUsuarios();
            }

        }
        //------------------------------------
        private void CargarTablaUsuarios()
        {
            
            N_Solicitud nSolicitud = new N_Solicitud();
            datosListaMisSolicitudes = nSolicitud.ConsultarMisSolicitudes(usuario.Email);

            if (datosListaMisSolicitudes.Tables.Count > 0)
            {

                gvMisSolicitudes.DataSource = datosListaMisSolicitudes;
                gvMisSolicitudes.DataBind();
                //-------------------------
            }
            else
            {
                msj.Text = "Ocurrio un error al intentar cargar los datos de la base de datos.";
            }
        }
        //------------------------------------------------------
        protected void gvMisSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMisSolicitudes.PageIndex = e.NewPageIndex;
            CargarTablaUsuarios();
            //gvUsuario.DataBind();
        }
    }
}