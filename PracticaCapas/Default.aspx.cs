using System;
using Entidades;
using Negocios;
using System.Web;

namespace PracticaCapas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        //--------------------------------------------
        /*protected void btnCargarPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://google.com");
        }*/
        protected void btnTryLogin_click(object sender, EventArgs e)
        {
            //Server.Transfer("~/VistasUsuario/Inicio.aspx", true);
            N_Usuario nUsuario = new N_Usuario();
            bool userFiad;
            EUsuario usuario;
            EUsuario_Uabc user = nUsuario.AutenticarUsuarioUabc(EmailLogin.Text,PassUser.Text);
            ERol_Usuario rolUser = new ERol_Usuario();
            if (user.Email == string.Empty)
            {
                msj.Text = "El Correo no se encuentra registrado, o la contraseña es incorrecta, favor de revisar que los datos este correctamente escritos";
                divMsjErrorLogin.Attributes.Remove("hidden");

            }
            else
            {
                userFiad = nUsuario.AutenticarUsuarioFiad(EmailLogin.Text);
                if (userFiad)
                {
                    usuario = nUsuario.ObtenerUsuarioPorCorreo(EmailLogin.Text);//Se verifica si el usuario es usuario academico o administrador
                    if (usuario != null)//si no es null, entonces es usuario academico o administrador
                    {
                        rolUser = nUsuario.OptenerRolUsuarioPorId(usuario.Id); //Se sacan los datos de la base de datos del sistema

                    }
                    //Si no existe en la base de datos del sistema, entonces se procede a crear dicho usuario con privilegios default(rol docente)
                    else
                    {
                        rolUser.NombreRol = "Docente";
                        rolUser.DescripcionRol = "Docente";
                        rolUser.IdRol = -1;
                        
                    }
                    //Se guardan todos los datos necesarios del usuario, los cuales se van a necesitar durante la sesion
                    Session["Usuario"] = user; //Todos los datos del usuario de la base de datos de usuarios Uabc
                    Session["Rol_Usuario"] = rolUser;// se saca el rol del usuario de la base de datos del sistema
                    Server.Transfer("~/VistasUsuario/Inicio.aspx", true);//Se redirije a la pagina de inicio del sistema
                }
                else
                {
                    msj.Text = "El Usuario no pertenece a la Faculta de Ingenieria, Arquitectura y Diseño";
                    divMsjErrorLogin.Attributes.Remove("hidden");
                }


            }

        }
    }
}