using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class HistorialSolicitudes : System.Web.UI.Page
    {
        EUsuario_Uabc usuario;
        ERol_Usuario rolUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (EUsuario_Uabc)Session["Usuario"];
            rolUser = (ERol_Usuario)Session["Rol_Usuario"];
            if (!IsPostBack && usuario != null)
            {

             

            }
        }
    }
}