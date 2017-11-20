using System;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using Entidades;


namespace Datos
{
    public class D_Usuario
    {
        
        
        //-------------------------------------------------------------------------------------------------------------
        //Aqui se encuentran los datos de conexion de cada base de datos utilizada
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        private D_ConexionDB UsuariosUABC = new D_ConexionDB(NombreBasesDeDatos.UsuariosUabcConnectionString.ToString()); //base de datos para autenticacion de usarios uabc
        private D_ConexionDB UsuariosFIAD = new D_ConexionDB(NombreBasesDeDatos.UsuariosFiadConnectionString.ToString()); //base de datos usuarios FIAD
        //-------------------------------------------------
        public D_Usuario()
        { 
        }
        //---------------------------------------------------------------
        //Funcion que retorna la comparacion de los datos ingresados en login, y la tabla de usuarios de la base de datos UABC usuarios
        /*public DataSet SeleccionaUsuarioUabc(string email, string contrasenia)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                UsuariosUABC.AbrirConexion();
                cmd.Connection = UsuariosUABC.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SeleccionaUsuario]";

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contraseña", contrasenia);

                da.SelectCommand = cmd;
                da.Fill(ds);
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
            return ds;
        }*/
        public EUsuario AutenticarUsuarioUabc(string email, string contrasenia)
        {
 
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
 
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
                            EUsuario usuarioEncontrado = new EUsuario();
                            usuarioEncontrado.Email = dr["Email"].ToString();
                            usuarioEncontrado.Contra = string.Empty;
                            usuarioEncontrado.Nombre = dr["Nombre"].ToString();
                            usuarioEncontrado.Apellido = dr["Apellido"].ToString();
                            usuarioEncontrado.NoEmpleado = Convert.ToInt32(dr["Numero_Empleado"].ToString());
                            dr.Close();
                            return usuarioEncontrado;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos del Usuario ", e);
                //EUsuario usuarioEncontrado = null;
            }
            finally
            {
                
                UsuariosUABC.CerrarConexion();
                cmd.Dispose();
            }
            return null;
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