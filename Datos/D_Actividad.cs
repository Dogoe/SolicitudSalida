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
    public class D_Actividad
    {
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        public D_Actividad()
        {

        }
        //---------------------------------------------------
        public int Crear_Actividad(EActividad nuevaActividad)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCActividad]";

                cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
                cmd.Parameters.AddWithValue("@Id", -1);
                cmd.Parameters.AddWithValue("@CACEI",nuevaActividad.CACEI);
                cmd.Parameters.AddWithValue("@Licenciatura",nuevaActividad.Licenciatura);
                cmd.Parameters.AddWithValue("@Personal", nuevaActividad.Personal);
                cmd.Parameters.AddWithValue("@ISO", nuevaActividad.ISO);
                cmd.Parameters.AddWithValue("@Posgrado", nuevaActividad.Posgrado);
                cmd.Parameters.AddWithValue("@Otro", nuevaActividad.Otro);

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
    }
}
