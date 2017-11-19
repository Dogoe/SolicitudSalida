using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;


namespace Datos
{
    public class D_Usuario : D_ConexionDB
    {
        public D_Usuario()
        {
            
        }
        //---------------------------------------------------------------
        //Funcion que retorna la comparacion de los datos ingresados en login, y la tabla de usuarios de la base de datos UABC usuarios
        public DataTable SeleccionaUsuario(string email, string contrasenia)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SeleccionaUsuario]";

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contraseña", contrasenia);

                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos del Usuario ", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return dt;
        }
    }
}