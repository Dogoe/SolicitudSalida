using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;


namespace Datos
{
    public class D_Usuario
    {
        
        
        //-------------------------------------------------------------------------------------------------------------
        //Aqui se encuentran los datos de conexion de cada base de datos utilizada
        //Son utilizadas en esta clase todos los metodos y entidades que hacen referencia al usuario en el sistema
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        private D_ConexionDB UsuariosUABC = new D_ConexionDB(NombreBasesDeDatos.UsuariosUabcConnectionString.ToString()); //base de datos para autenticacion de usarios uabc
        private D_ConexionDB UsuariosFIAD = new D_ConexionDB(NombreBasesDeDatos.UsuariosFiadConnectionString.ToString()); //base de datos usuarios docentes FIAD
        //-------------------------------------------------
        public D_Usuario()
        { 
        }
        //---------------------------------------------------------------
        //Funcion que retorna al usuario, en caso de que exista en la base de datos de usuarios del sistema
        public EUsuario ObtenerUsuarioPorCorreo(string correo)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[abcUsuario]";

                cmd.Parameters.AddWithValue("@Accion","CONSULTAR");
                cmd.Parameters.AddWithValue("@Id",-1);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Id_Rol",-1);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["Correo"].ToString() == correo)
                    {
                        EUsuario usuarioEncontrado = new EUsuario();
                        usuarioEncontrado.Id = Convert.ToInt32(dr["Id"].ToString());
                        usuarioEncontrado.Correo = dr["Correo"].ToString();
                        usuarioEncontrado.Id_Rol = Convert.ToInt32(dr["Id_Rol"].ToString());
                        dr.Close();
                        return usuarioEncontrado;
                        //-----------------------------
                    }
                }

            }
            catch (Exception e)
            {
               throw new Exception("Error al solicitar los datos del Usuario ", e);
            }
            finally
            {
                dbSS.CerrarConexion();
                cmd.Dispose();
            }
            return null;
        }
        //------------------------------------------------------------------------
        public ERol_Usuario OptenerRolUsuarioPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            ERol_Usuario rol_usuario_encontrado = new ERol_Usuario();

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SeleccionaUsuarioRol]";

                cmd.Parameters.AddWithValue("@Id", id);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    rol_usuario_encontrado.IdRol = Convert.ToInt32(dr["Id"].ToString());
                    rol_usuario_encontrado.NombreRol = dr["Nombre"].ToString();
                    rol_usuario_encontrado.DescripcionRol = dr["Descripcion"].ToString();
                    dr.Close();
                    //-----------------------------
                    
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos del Usuario ", e);
            }
            finally
            {
                dbSS.CerrarConexion();
                cmd.Dispose();
            }
            return rol_usuario_encontrado;
        }
        //-----------------------------------------------------------------------
        //Funcion que retorna la comparacion de los datos ingresados en login, y la tabla de usuarios de la base de datos UABC usuarios
        public EUsuario_Uabc AutenticarUsuarioUabc(string email, string contrasenia)
        {
 
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            EUsuario_Uabc usuarioEncontrado = new EUsuario_Uabc();
                
 
            try
            {
                UsuariosUABC.AbrirConexion();
                cmd.Connection = UsuariosUABC.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SeleccionaUsuario]";

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contraseña", contrasenia);

                dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    if (dr["Email"].ToString() == email)
                    {
                        
                        if (dr["Contraseña"].ToString() == contrasenia)
                        {
                            usuarioEncontrado.Email = dr["Email"].ToString();
                            usuarioEncontrado.Contra = string.Empty;
                            usuarioEncontrado.Nombre = dr["Nombre"].ToString();
                            usuarioEncontrado.Apellido = dr["Apellido"].ToString();
                            usuarioEncontrado.NoEmpleado = Convert.ToInt32(dr["Numero_Empleado"].ToString());
                        }
                        dr.Close();
                        //-----------------------------
                    }
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos del Usuario ", e);
            }
            finally
            { 
                UsuariosUABC.CerrarConexion();
                cmd.Dispose();
            }
            return usuarioEncontrado;
        }
        public bool AutenticarUsuarioFiad(string email)
        {
 
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
 
            try
            {
                UsuariosFIAD.AbrirConexion();
                cmd.Connection = UsuariosFIAD.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SeleccionaUsuario]";

                cmd.Parameters.AddWithValue("@Email", email);

                dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    if (dr["Email"].ToString() == email)
                    {
                        return true;
                        //-----------------------------

                    }
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos del Usuario ", e);
            }
            finally
            {
                UsuariosFIAD.CerrarConexion();
                cmd.Dispose();

            }
            return false;
        }
        //----------------------------------------------------------
        public bool CrearUsuario(EUsuario nuevoUsuario)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
 
            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[abcUsuario]";

                cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
                cmd.Parameters.AddWithValue("@Id",-1);
                cmd.Parameters.AddWithValue("@Correo", nuevoUsuario.Correo);
                cmd.Parameters.AddWithValue("@Id_Rol", nuevoUsuario.Id_Rol);

                dr = cmd.ExecuteReader();

                if (dr.RecordsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos del Usuario ", e);
            }
            finally
            {
                dbSS.CerrarConexion();
                cmd.Dispose();

            }
            //-------------------
        }
        //---------------------------------------------------------------
        //Funcion que retorna la lista completa de los datos de la tabla
        public DataSet ListaUsuario()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ListadoUsuario]";

                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos la tabla", e);
            }
            finally
            {
                dbSS.CerrarConexion();
                cmd.Dispose();
            }
            return ds;
        }
        //---------------------------------------------------------------
        //Funcion que retorna la lista completa de los datos de la tabla
        public DataSet ListaUsuariosUABC()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                UsuariosUABC.AbrirConexion();
                cmd.Connection = UsuariosUABC.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ListadoUsuariosUABC]";

                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos la tabla", e);
            }
            finally
            {
                UsuariosUABC.CerrarConexion();
                cmd.Dispose();
            }
            return ds;
        }
    }
}