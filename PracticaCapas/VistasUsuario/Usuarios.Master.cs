using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class Usuarios : System.Web.UI.MasterPage
    {
        EUsuario_Uabc usuario;
        ERol_Usuario rolUser;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["Usuario"] == null) {
                Server.Transfer("~/Default.aspx", true);
            }
            else
            {
                N_Usuario nUsuario = new N_Usuario();
                //ERol_Usuario rolUser = new ERol_Usuario();
                //--------------------------------------
                usuario = (EUsuario_Uabc)Session["Usuario"];
                rolUser = (ERol_Usuario)Session["Rol_Usuario"];
                labelNombreUsuario.Text = " " + usuario.Nombre;
                if (rolUser.NombreRol == "Académico")
                {
                    linkAdministrarUsuarios.Style.Add("display", "none");
                }
                else
                {
                    if(rolUser.NombreRol == "Docente")
                    {
                        linkAdministrarUsuarios.Style.Add("display", "none");
                        linkHistorialSol.Style.Add("display", "none");
                    }
                }
                /*if (Session["Id_Rol"] != null)
                {
                    rolUser = nUsuario.OptenerRolUsuarioPorId((int)Session["Id_Rol"]);
                    if (rolUser.NombreRol == "Académico")
                    {

                        linkAdministrarUsuarios.Style.Add("display", "none");
                    }
                }
                else
                {
                    linkAdministrarUsuarios.Style.Add("display", "none");
                }*/
            }
            /*N_Usuario nUsuario = new N_Usuario();
            ERol_Usuario rolUser = new ERol_Usuario();
            //string nombre = (string)Session["Nombre"];
            EUsuario_Uabc usuario= (EUsuario_Uabc)Session["Usuario"];
            //--------------------------------------------------------------------
            if (usuario.Nombre != null )
            {
                labelNombreUsuario.Text = " " + usuario.Nombre;
                rolUser = nUsuario.OptenerRolUsuarioPorId((int)Session["Id_Rol"]);
                if (rolUser.NombreRol == "Académico")
                {
                   
                    linkAdministrarUsuarios.Style.Add("display", "none");
                  


                }
                else
                {
                    if (rolUser.NombreRol == "Docente")
                    {
                        linkAdministrarUsuarios.Style.Add("display", "none"); 
                        linkVerNotificaciones.Style.Add("display", "none");
                     

                    }
                }
               

            }
            else
            {
                labelNombreUsuario.Text = "Usuario Anonimo";
            }*/

        }
        //-------------------------------------------
        public void Cerrar_Session()
        {
            
             Session.Abandon();
             Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            
        }

    }
}