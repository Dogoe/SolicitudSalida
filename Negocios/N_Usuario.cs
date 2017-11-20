using Datos;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Negocios
{
    public class N_Usuario
    {
        //private NombreBasesDeDatos nombre;
        private D_Usuario objNegocioUsuarios= new D_Usuario();
        //private D_Usuario objBdUabcUsuario= new D_Usuario("UsuariosUABCConnectionString");
        
        public N_Usuario()
        {
            
        }
        //--------------------------------------
        public EUsuario AutenticarUsuarioUabc(string loginEmail, string loginContra)
        {
            return objNegocioUsuarios.AutenticarUsuarioUabc(loginEmail, loginContra);
        }
        //------------------------------------------
        public DataSet ListaUsuario()
        {
            return objNegocioUsuarios.ListaUsuario();
        }
        public DataSet ListaUsuarioUabc()
        {
            return objNegocioUsuarios.ListaUsuariosUABC();
        }
    }
    //------------------------------------
    
}