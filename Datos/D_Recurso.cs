using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Recurso
    {
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        public D_Recurso()
        {

        }
        //---------------------------------------------
        public int Guardar_Recurso(ERecurso_Solicitado tempRecurso, string instruccion)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCRecurso]";

                cmd.Parameters.AddWithValue("@Accion", instruccion);
                if (instruccion == "INSERTAR")
                {
                    cmd.Parameters.AddWithValue("@Id", -1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Id", tempRecurso.Id);
                }

                cmd.Parameters.AddWithValue("@Hospedaje", tempRecurso.Hospedaje);
                cmd.Parameters.AddWithValue("@Transporte", tempRecurso.Transporte);
                cmd.Parameters.AddWithValue("@Combustible", tempRecurso.Combustible);
                cmd.Parameters.AddWithValue("@Viatico", tempRecurso.Viatico);
                cmd.Parameters.AddWithValue("@Oficio_Comision", tempRecurso.Oficio_Comision);
                cmd.Parameters.AddWithValue("@Otro", tempRecurso.Otro);

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
        public bool EliminarRecursoPorId(int idRecurso)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCRecurso]";

                cmd.Parameters.AddWithValue("@Accion","BORRAR");
                cmd.Parameters.AddWithValue("@Id", idRecurso);
                //En este caso solo nos sirve el id, los parametros ue sigen solo se mandan para ue no suceda un error
                cmd.Parameters.AddWithValue("@Hospedaje", false);
                cmd.Parameters.AddWithValue("@Transporte", false);
                cmd.Parameters.AddWithValue("@Combustible", false);
                cmd.Parameters.AddWithValue("@Viatico", false);
                cmd.Parameters.AddWithValue("@Oficio_Comision", false);
                cmd.Parameters.AddWithValue("@Otro", "NADA");

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
        public DataSet ConsultarRecurso()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCRecurso]";

                cmd.Parameters.AddWithValue("@Accion", "CONSULTAR");
                //En este caso no necesita ningun parametro, pero se mandan para no tener algun error
                cmd.Parameters.AddWithValue("@Id", -1);
                cmd.Parameters.AddWithValue("@Hospedaje", false);
                cmd.Parameters.AddWithValue("@Transporte", false);
                cmd.Parameters.AddWithValue("@Combustible", false);
                cmd.Parameters.AddWithValue("@Viatico", false);
                cmd.Parameters.AddWithValue("@Oficio_Comision", false);
                cmd.Parameters.AddWithValue("@Otro", "NADA");

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
