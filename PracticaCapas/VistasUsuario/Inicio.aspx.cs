using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //this.MasterPageFile.
            //string nombre = Session["Nombre"].ToString();
            despliegaNombre.Text = "Bienvenido Usuario: "+Session["Nombre"].ToString();

        }
    }
}