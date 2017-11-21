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
                labelPrueba.Text = " " + nombre;//nombreUsuario.InnerText.Insert(0, nombre);
                ///int rol = (int)Session["Id_Rol"];
                rolUser = nUsuario.OptenerRolUsuarioPorId((int)Session["Id_Rol"]);
                if (rolUser.NombreRol == "Académico")
                {



                }
                else
                {
                    if (rolUser.NombreRol == "Docente")
                    {
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
                labelPrueba.Text = "Usuario Anonimo";//nombreUsuario.InnerText.Insert(0,"Anonimo");
            }

        }
    }
}