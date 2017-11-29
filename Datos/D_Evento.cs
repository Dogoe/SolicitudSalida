using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Evento
    {
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        public D_Evento()
        {

        }
        //-----------------------------------------
        public int Guardar_Evento(EEvento tempEvento, string instruccion)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCEvento]";

                cmd.Parameters.AddWithValue("@Accion", instruccion);
                if (instruccion == "INSERTAR")
                {
                    cmd.Parameters.AddWithValue("@Id", -1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Id", tempEvento.Id);
                }

                cmd.Parameters.AddWithValue("@Nombre_Evento", tempEvento.Nombre_Evento);
                cmd.Parameters.AddWithValue("@Costo", tempEvento.Costo);
                cmd.Parameters.AddWithValue("@Lugar", tempEvento.Lugar);
                cmd.Parameters.AddWithValue("@Fecha_Hora_Salida", tempEvento.Fecha_Hora_Salida);
                cmd.Parameters.AddWithValue("@Fecha_Hora_Regreso", tempEvento.Fecha_Hora_Regreso);

                dr = cmd.ExecuteReader();
                int i = 0;
                if (dr.Read())
                {
                    i = Convert.ToInt32(dr["id"].ToString());
                    //-----------------------------
                }
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos de Eventos ", e);
            }
            finally
            {
                dbSS.CerrarConexion();
                cmd.Dispose();

            }
        }
        //----------------------------------------------------
        public bool EliminarEventoPorId(int idEvento)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCEvento]";

                cmd.Parameters.AddWithValue("@Accion", "BORRAR");
                cmd.Parameters.AddWithValue("@Id", idEvento);
                //En este caso solo nos sirve el id, los parametros ue sigen solo se mandan para ue no suceda un error
                cmd.Parameters.AddWithValue("@Nombre_Evento", string.Empty);
                cmd.Parameters.AddWithValue("@Costo", 0.0);
                cmd.Parameters.AddWithValue("@Lugar", string.Empty);
                cmd.Parameters.AddWithValue("@Fecha_Hora_Salida", "");
                cmd.Parameters.AddWithValue("@Fecha_Hora_Regreso", "");

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
                throw new Exception("Error al eliminar los datos de la actividad ", e);
            }
            finally
            {
                dbSS.CerrarConexion();
                cmd.Dispose();

            }
        }
        //--------------------------------------------------------------
        public DataSet ConsultarEventos()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCEvento]";
                cmd.Parameters.AddWithValue("@Accion", "CONSULTAR");
                //En este caso no necesita ningun parametro, pero se mandan para no tener algun error
                cmd.Parameters.AddWithValue("@Id", -1);
                cmd.Parameters.AddWithValue("@Nombre_Evento", string.Empty);
                cmd.Parameters.AddWithValue("@Costo", 0.0);
                cmd.Parameters.AddWithValue("@Lugar", string.Empty);
                cmd.Parameters.AddWithValue("@Fecha_Hora_Salida", "");
                cmd.Parameters.AddWithValue("@Fecha_Hora_Regreso", "");

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
