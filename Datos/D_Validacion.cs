using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Validacion
    {
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        public D_Validacion()
        {

        }
        //------------------------------------------
        public int Guardar_Validacion(EValidacion tempValidacion, string instruccion)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCValidacion]";

                cmd.Parameters.AddWithValue("@Accion", instruccion);
                if (instruccion == "INSERTAR")
                {
                    cmd.Parameters.AddWithValue("@Id", -1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Id", tempValidacion.Id);
                }

                cmd.Parameters.AddWithValue("@Coordinador", tempValidacion.Coordinador);
                cmd.Parameters.AddWithValue("@Subdirector", tempValidacion.Subdirector);
                cmd.Parameters.AddWithValue("@Administrador", tempValidacion.Administrador);
                cmd.Parameters.AddWithValue("@Director", tempValidacion.Director);
                cmd.Parameters.AddWithValue("@Posgrado", tempValidacion.Posgrado);
                cmd.Parameters.AddWithValue("@Unica", tempValidacion.Unica);

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
        public bool EliminarValidacionPorId(int idValidacion)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCValidacion]";

                cmd.Parameters.AddWithValue("@Accion", "BORRAR");
                cmd.Parameters.AddWithValue("@Id", idValidacion);
                //En este caso solo nos sirve el id, los parametros ue sigen solo se mandan para ue no suceda un error
                cmd.Parameters.AddWithValue("@Coordinador", false);
                cmd.Parameters.AddWithValue("@Subdirector", false);
                cmd.Parameters.AddWithValue("@Administrador", false);
                cmd.Parameters.AddWithValue("@Director", false);
                cmd.Parameters.AddWithValue("@Posgrado", false);
                cmd.Parameters.AddWithValue("@Unica", false);

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
        public DataSet ConsultarValidaciones()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCValidacion]";
                cmd.Parameters.AddWithValue("@Accion", "CONSULTAR");
                //En este caso no necesita ningun parametro, pero se mandan para no tener algun error
                cmd.Parameters.AddWithValue("@Coordinador", false);
                cmd.Parameters.AddWithValue("@Subdirector", false);
                cmd.Parameters.AddWithValue("@Administrador", false);
                cmd.Parameters.AddWithValue("@Director", false);
                cmd.Parameters.AddWithValue("@Posgrado", false);
                cmd.Parameters.AddWithValue("@Unica", false);

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
