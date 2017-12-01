using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Solicitud
    {
       
        
        public N_Solicitud()
        {
            
        }
        //---------------------------------------------
        public int Crear_Solicitud(int Id, string Folio, string Nombre_Solicitante, int Numero_Empleado, 
            int Id_Categoria, int Id_Carrera, EEvento evento, ERecurso_Solicitado recurso, EActividad actividad,
            EValidacion validacion, int Id_Estado, DateTime Fecha_Creacion, DateTime Fecha_Modificacion, 
            string URL_Reporte, string Correo_Solicitante, string Comentario_Rechazado, bool Leido)
        {
            D_Solicitud daoSolicitud = new D_Solicitud();
            D_Evento daoEvento =  new D_Evento();
            D_Recurso daoRecurso = new D_Recurso();
            D_Actividad daoActividad = new D_Actividad();
            D_Validacion daoValidacion = new D_Validacion();
            //------------------------------------
            ESolicitud nuevaSolicitud = new ESolicitud();
            nuevaSolicitud.Folio = Folio;
            nuevaSolicitud.Nombre_Solicitante = Nombre_Solicitante;
            nuevaSolicitud.Numero_Empleado = Numero_Empleado;
            nuevaSolicitud.Id_Categoria = Id_Categoria;
            nuevaSolicitud.Id_Carrera = Id_Carrera;
           
            nuevaSolicitud.Id_Evento = daoEvento.Guardar_Evento(evento, "INSERTAR");
            nuevaSolicitud.Id_Recurso_Solicitado = daoRecurso.Guardar_Recurso(recurso, "INSERTAR");
            nuevaSolicitud.Id_Actividad = daoActividad.Guardar_Actividad(actividad, "INSERTAR");
            nuevaSolicitud.Id_Validacion = daoValidacion.Guardar_Validacion(validacion, "INSERTAR");

            nuevaSolicitud.Id_Estado = Id_Estado;
            nuevaSolicitud.Fecha_Creacion = Fecha_Creacion;
            nuevaSolicitud.Fecha_Modificacion = Fecha_Modificacion;
            nuevaSolicitud.URL_Reporte = URL_Reporte;
            nuevaSolicitud.Correo_Solicitante = Correo_Solicitante;
            nuevaSolicitud.Comentario_Rechazado = Comentario_Rechazado;
            nuevaSolicitud.Leido = Leido;
            //----------------------------------------------
            int idSolicitudCreada = daoSolicitud.Guardar_Solicitud(nuevaSolicitud,"INSERTAR");
            /*int _Id_Evento = daoEvento.Guardar_Evento(evento,"INSERTAR");
            int _Id_Recurso = daoRecurso.Guardar_Recurso(recurso,"INSERTAR");
            int _Id_Actividad = daoActividad.Guardar_Actividad(actividad, "INSERTAR");
            int _Id_Validacion = daoValidacion.Guardar_Validacion(validacion,"INSERTAR");*/
            //-----------------------------------------

            return idSolicitudCreada;
        }
        //----------------------------------------------------------
        public DataSet ConsultarMisSolicitudes(string correo)
        {
            D_Solicitud daoSolicitud = new D_Solicitud();
            return daoSolicitud.ConsultarSolicitudes(correo);
        }
        //-----------------
        public DataSet ConsultarTodasLasSolicitudes(string correo)
        {
            D_Solicitud daoSolicitud = new D_Solicitud();
            return daoSolicitud.ConsultarSolicitudes(null);
        }
    }
}
