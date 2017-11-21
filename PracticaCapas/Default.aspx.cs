using System;
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
            bool userFiad;
            EUsuario usuario;
            EUsuario_Uabc user = nUsuario.AutenticarUsuarioUabc(EmailLogin.Text,PassUser.Text);
            if (user == null)
            {
                msj.Text = "El Correo no se encuentra registrado, o la contraseña es incorrecta, favor de revisar que los datos este correctamente escritos";
                divMsjErrorLogin.Attributes.Remove("hidden");
                //divMsjErrorLogin.Attributes.Add("class", "alert alert-danger");
                //divMsjErrorLogin.Attributes.Add("hidden","false");
                //Response.Redirect("");

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
                        Session["Nombre"] = user.Nombre; //se saca los datos de la busqueda del usuario en la tabla de usuarios de la uabc
                        Session["Id_Rol"] = usuario.Id_Rol;// se saca los datos de la base de datos del sistema
                        Session["Correo"] = user.Email;//se sacan los datos de la base de datos de usuarios uabc
                        Server.Transfer("/VistasAdministrador/Inicio.aspx", true);
                        Server.Transfer("/VistasAdministrador/Inicio.aspx", true);

                    }
                    //Si no existe en la base de datos del sistema, entonces se procede a crear dicho usuario con privilegios default(rol docente)
                    else
                    {
                        EUsuario nuevoUsuario = new EUsuario();
                        nuevoUsuario.Correo = user.Email;
                        nuevoUsuario.Id_Rol = 6;
                        if (nUsuario.CrearUsuario(nuevoUsuario))
                        {
                            Server.Transfer("/VistasAdministrador/Inicio.aspx", true);
                        }
                        else
                        {
                            msj.Text = "No se pudo creear el usuario";
                            divMsjErrorLogin.Attributes.Remove("hidden");
                        }
                        
                        //El index 6 es el rol de docente, el cual se le asigna a cualquier usuario que ingrese(Los admins pueden modificar estos roles)
                       // nUsuario.CrearUsuario();
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