using Datos;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Negocios
{
    public class N_Usuario
    {
        
        private D_Usuario objNegocioUsuarios= new D_Usuario();
        
        
        public N_Usuario()
        {
            
        }
        public EUsuario ObtenerUsuarioPorCorreo(string correo)
        {
            return objNegocioUsuarios.ObtenerUsuarioPorCorreo(correo);
        }
        //--------------------------------------
        public ERol_Usuario OptenerRolUsuarioPorId(int id_Rol)
        {
            return objNegocioUsuarios.OptenerRolUsuarioPorId(id_Rol);
        }
        //------------------------------------------------
        public EUsuario_Uabc AutenticarUsuarioUabc(string loginEmail, string loginContra)
        {
            return objNegocioUsuarios.AutenticarUsuarioUabc(loginEmail, loginContra);
        }
        //------------------------------------------
        public bool AutenticarUsuarioFiad(string loginEmail)
        {
            return objNegocioUsuarios.AutenticarUsuarioFiad(loginEmail);
        }
        //--------------------------------------
        public bool CrearUsuario(EUsuario nuevoUsuario)
        {
            return objNegocioUsuarios.CrearUsuario(nuevoUsuario);
        }
        //--------------------------------------------
        public bool ActualizarUsuario(EUsuario Usuario)
        {
            return objNegocioUsuarios.ActualizarUsuario(Usuario);
        }
        //-------------------------------------
        public bool EliminarUsuarioPorId(int Id)
        {
            return objNegocioUsuarios.EliminarUsuarioPorId(Id);
        }
        //---------------------------------------------
        public DataSet ListaUsuario()
        {
            return objNegocioUsuarios.ListaUsuario();
        }
        //---------------------------------------------
        public DataSet ListaUsuarioUabc()
        {
            return objNegocioUsuarios.ListaUsuariosUABC();
        }
        /*public DataSet ListaRoles()
        {
            return objNegocioUsuarios.ListaRoles();
        }*/
        //----------------------
        /*public DataSet ListaCarrera()
        {
            return objNegocioUsuarios.ListaCarrera();
        }*/
        //--------------------------
        /*public ECarrera ObtenerCarreraCoordinador(int idCoordinadorUsuario)
        {
            return objNegocioUsuarios.ObtenerCarreraCoordinador(idCoordinadorUsuario);
        }*/
    }
    //------------------------------------
    
}