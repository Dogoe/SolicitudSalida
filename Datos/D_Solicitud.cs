using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace Datos
{
    public class D_Solicitud
    {
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        public D_Solicitud()
        {

        }
        //-----------------------------------------------
        public int Guardar_Solicitud(ESolicitud tempSolicitud, string instruccion)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCUSolicitud]";

                cmd.Parameters.AddWithValue("@Accion", instruccion);
                if (instruccion == "INSERTAR")
                {
                    cmd.Parameters.AddWithValue("@Id", -1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Id", tempSolicitud.Id);
                }

                cmd.Parameters.AddWithValue("@Folio", tempSolicitud.Folio);
                cmd.Parameters.AddWithValue("@Nombre_Solicitante", tempSolicitud.Nombre_Solicitante);
                cmd.Parameters.AddWithValue("@Numero_Empleado", tempSolicitud.Numero_Empleado);
                cmd.Parameters.AddWithValue("@Id_Categoria", tempSolicitud.Id_Categoria);
                cmd.Parameters.AddWithValue("@Id_Carrera", tempSolicitud.Id_Categoria);
                cmd.Parameters.AddWithValue("@Id_Evento", tempSolicitud.Id_Evento);
                cmd.Parameters.AddWithValue("@Id_Recurso_Solicitado", tempSolicitud.Id_Recurso_Solicitado);
                cmd.Parameters.AddWithValue("@Id_Actividad", tempSolicitud.Id_Actividad);
                cmd.Parameters.AddWithValue("@Id_Validacion", tempSolicitud.Id_Validacion);
                cmd.Parameters.AddWithValue("@Id_Estado", tempSolicitud.Id_Estado);
                cmd.Parameters.AddWithValue("@Fecha_Creacion", tempSolicitud.Fecha_Creacion);
                cmd.Parameters.AddWithValue("@Fecha_Modificacion", tempSolicitud.Fecha_Modificacion);
                cmd.Parameters.AddWithValue("@URL_Reporte", tempSolicitud.URL_Reporte);
                cmd.Parameters.AddWithValue("@Correo_Solicitante", tempSolicitud.Correo_Solicitante);
                cmd.Parameters.AddWithValue("@Comentario_Rechazado", tempSolicitud.Comentario_Rechazado);
                cmd.Parameters.AddWithValue("@Leido", tempSolicitud.Leido);

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
                throw new Exception("Error al solicitar los datos de Actividades ", e);
            }
            finally
            {
                dbSS.CerrarConexion();
                cmd.Dispose();

            }
        }
        //----------------------------------------------------
        public bool EliminarSolicitudPorId(int idSolicitud)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[EliminarSolicitudPorID]";

                cmd.Parameters.AddWithValue("@Id", idSolicitud);

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
        public DataSet ConsultarSolicitudes()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ConsultasSolicitudes]";
                cmd.Parameters.AddWithValue("@Accion", "CONSULTAR_TODO");
        
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
