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
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            N_Usuario nUsuario = new N_Usuario();
            ERol_Usuario rolUser = new ERol_Usuario();
            string nombre = (string)Session["Nombre"];
            //--------------------------------------------------------------------
            if (nombre != null)
            {
                labelNombreUsuario.Text = " " + nombre;//nombreUsuario.InnerText.Insert(0, nombre);
                ///int rol = (int)Session["Id_Rol"];
                rolUser = nUsuario.OptenerRolUsuarioPorId((int)Session["Id_Rol"]);
                if (rolUser.NombreRol == "Académico")
                {
                    //BtnVerNotificaciones.Visible = false;
                    //BtnAdminUsuarios.Visible = false;
                    //BtnAdminUsuarios.Disabled = true;
                   

                }
                else
                {
                    if (rolUser.NombreRol == "Docente")
                    {
                        //BtnAdminUsuarios.Disabled = true;
                        BtnVerNotificaciones.Disabled = true;
                       // BtnAdminUsuarios.Visible = false;
                        BtnHistorialSolicitud.Disabled = true;
                        //BtnVerNotificaciones
                        //verNotificacione.Attributes.Add("hidden", "hidden");
                        //.Visible = false;

                    }
                }
                //nombreUsuario.InnerText = nombre;
                //verNotificaciones.InnerText = " VERGASSS";
                //verNotificacione.InnerText = " VERGAAAAA";

            }
            else
            {
                labelNombreUsuario.Text = "Usuario Anonimo";//nombreUsuario.InnerText.Insert(0,"Anonimo");
            }

        }
        //-------------------------------------------
        protected void BtnAdministracionUsuario_click(object sender, EventArgs e)
        {
            //if()
            //sender.GetHashCode.TemplateSourceDirectory != "~/VistasUsuario/Inicio.aspx";
            //sender.GetHashCode.AppRelativeTemplateSourceDirectory = "";
            //AppRelativeTemplateSourceDirectory();
            //ender.Equals("~/VistasUsuario/Inicio.aspx");
            /* if(sender.Equals("~/VistasUsuario/Inicio.aspx"))
             {
                 Server.Transfer("~/VistasUsuario/AdministrarUsuarios.aspx", true);
             }*/
            HttpRequest rq ;
            //Server.Transfer
            /*if(rq.CurrentExecutionFilePath == "~/VistasUsuario/AdministrarUsuarios.aspx")
            {

            }*/
            Server.Transfer("~/VistasUsuario/AdministrarUsuarios.aspx", true);

        }
    }
}