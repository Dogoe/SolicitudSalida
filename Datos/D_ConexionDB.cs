using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class D_ConexionDB
    {
        public SqlConnection Conexion;
        ///public string NombreConexionBaseDatos;
        public String connectionString;
        public D_ConexionDB(string nombreConexionBaseDatos)
        {
            //NombreConexionBaseDatos = nombreConexionBaseDatos;
            connectionString = ConfigurationManager.ConnectionStrings[nombreConexionBaseDatos].ConnectionString;
            //Conexion = new SqlConnection(connectionString);      
        }
        //------------------------------
        public void AbrirConexion()
        {
            try
            {
                Conexion = new SqlConnection(connectionString);
                if (Conexion.State == ConnectionState.Broken || Conexion.State == ConnectionState.Closed)
                    Conexion.Open();
            }
            catch(Exception e)
            {
                throw new Exception("Error al tratar de abrir la conexion", e);
            }
        }
        //-------------------------------
        public void CerrarConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Dispose();
                    Conexion.Close();
                }
                    
            }
            catch(Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexion", e);
            }
        }
    }
}