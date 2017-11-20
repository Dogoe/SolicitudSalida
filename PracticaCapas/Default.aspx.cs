using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace PracticaCapas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            /*if(!IsPostBack)
            {
                N_Usuario nUsuario = new N_Usuario();
                DataSet datosLista = nUsuario.ListaUsuarioUabc();
                if (datosLista.Tables.Count > 0)
                {
                    GridView1.DataSource = datosLista;
                    GridView1.DataBind();
                    Console.Out.Write(datosLista);
                }
                else
                {
                    msj.Text = "Ocurrio un error al intentar cargar los datos de la base de datos.";
                }

            }     */    

        }
        //--------------------------------------------
        /*protected void btnCargarPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://google.com");
        }*/
        protected void btnTryLogin_click(object sender, EventArgs e)
        {
            N_Usuario nUsuario = new N_Usuario();
            EUsuario user = nUsuario.AutenticarUsuarioUabc(EmailLogin.Text,PassUser.Text);
            if (user != null)
            {
                //Response.Redirect("");
                Server.Transfer("Usuarios/Inicio.aspx", true);
            }
            else
            {
                msj.Text = "El usuario no existe, o la contraseña es incorrecta";
            }
            //SqlDataReader dr = nUsuario.SeleccionaUsuarioUabc("a338694@uabc.edu.mx","pruebas123");
        }
    }
}