using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Estado
    {
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        public D_Estado()
        {

        }
        //------------------------------------------------------------
        public DataSet ListaEstado()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ListaEstado]";

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
    }
}
