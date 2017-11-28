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
                    usuario = nUsuario.ObtenerUsuarioPorCorreo(EmailLogin.Text);
                    //Si ya existe el usuario en la base de datos del sistema, entonces se recuperan sus datos directamente
                    if (usuario != null)
                    {
                        //Datos que se van a ocupar en la sesion
                        Session["Id_Rol"] = usuario.Id_Rol;// se saca el rol del usuario de la base de datos del sistema
                        Session["Usuario"] = user; //Todos los datos del usuario de la base de datos de usuarios Uabc
                        Server.Transfer("~/VistasUsuario/Inicio.aspx", true);

                    }
                    //Si no existe en la base de datos del sistema, entonces se procede a crear dicho usuario con privilegios default(rol docente)
                    else
                    {
                        //El index 6 es el rol de docente, el cual se le asigna a cualquier usuario que ingrese(Los admins pueden modificar estos roles)
                        // nUsuario.CrearUsuario();
                        EUsuario nuevoUsuario = new EUsuario();
                        nuevoUsuario.Correo = user.Email;
                        nuevoUsuario.Id_Rol = 6;
                        if (nUsuario.CrearUsuario(nuevoUsuario))
                        {
                            Session["Id_Rol"] = usuario.Id_Rol;// se saca el rol del usuario de la base de datos del sistema
                            Session["Usuario"] = user; //Todos los datos del usuario de la base de datos de usuarios Uabc
                            Server.Transfer("~/VistasUsuario/Inicio.aspx", true);
                        }
                        else
                        {
                            msj.Text = "No se pudo creear el usuario";
                            divMsjErrorLogin.Attributes.Remove("hidden");
                        }
                        
                       
                    }

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