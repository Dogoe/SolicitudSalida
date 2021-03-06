﻿using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Actividad
    {
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        public D_Actividad()
        {

        }
        //---------------------------------------------------
        public int Guardar_Actividad(EActividad tempActividad, string instruccion)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {

                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCActividad]";

                cmd.Parameters.AddWithValue("@Accion", instruccion);
                if (instruccion == "INSERTAR")
                { 
                    cmd.Parameters.AddWithValue("@Id", -1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Id", tempActividad.Id);
                }
                
                cmd.Parameters.AddWithValue("@CACEI", tempActividad.CACEI);
                cmd.Parameters.AddWithValue("@Licenciatura", tempActividad.Licenciatura);
                cmd.Parameters.AddWithValue("@Personal", tempActividad.Personal);
                cmd.Parameters.AddWithValue("@ISO", tempActividad.ISO);
                cmd.Parameters.AddWithValue("@Posgrado", tempActividad.Posgrado);
                cmd.Parameters.AddWithValue("@Otro", tempActividad.Otro);

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
        public bool EliminarActividadPorId(int idActividad)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCActividad]";

                cmd.Parameters.AddWithValue("@Accion", "BORRAR");
                cmd.Parameters.AddWithValue("@Id", idActividad);
                //En este caso solo nos sirve el id, los parametros ue sigen solo se mandan para ue no suceda un error
                cmd.Parameters.AddWithValue("@CACEI", false);
                cmd.Parameters.AddWithValue("@Licenciatura", false);
                cmd.Parameters.AddWithValue("@Personal", false);
                cmd.Parameters.AddWithValue("@ISO", false);
                cmd.Parameters.AddWithValue("@Posgrado", false);
                cmd.Parameters.AddWithValue("@Otro", "Nada");

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
        public DataSet ConsultarActividades()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                dbSS.AbrirConexion();
                cmd.Connection = dbSS.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[ABCActividad]";
                cmd.Parameters.AddWithValue("@Accion", "CONSULTAR");
                //En este caso no necesita ningun parametro, pero se mandan para no tener algun error
                cmd.Parameters.AddWithValue("@Id", -1);
                cmd.Parameters.AddWithValue("@CACEI", false);
                cmd.Parameters.AddWithValue("@Licenciatura", false);
                cmd.Parameters.AddWithValue("@Personal", false);
                cmd.Parameters.AddWithValue("@ISO", false);
                cmd.Parameters.AddWithValue("@Posgrado", false);
                cmd.Parameters.AddWithValue("@Otro", "Nada");

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
