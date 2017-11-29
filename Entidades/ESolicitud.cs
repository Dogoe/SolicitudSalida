using System;

namespace Entidades
{
    public class ESolicitud
    {
        int _Id;
        string _Folio;
        string _Nombre_Solicitante;
        int _Numero_Empleado;
        int _Id_Categoria;
        int _Id_Carrera;
        int _Id_Evento;
        int _Id_Recurso_Solicitado;
        int _Id_Actividad;
        int _Id_Validacion;
        int _Id_Estado;
        DateTime _Fecha_Creacion;
        DateTime _Fecha_Modificacion;
        string _URL_Reporte;
        string _Correo_Solicitante;
        string _Comentario_Rechazado;
        bool _Leido;

        public ESolicitud()
        {
    
        }

        public ESolicitud(int Id, string Folio, string Nombre_Solicitante, int Numero_Empleado, int Id_Categoria, int Id_Carrera, int Id_Evento, int Id_Recurso_Solicitado, int Id_Actividad, int Id_Validacion, int Id_Estado, DateTime Fecha_Creacion, DateTime Fecha_Modificacion, string URL_Reporte, string Correo_Solicitante, string Comentario_Rechazado, bool Leido)
        {
            _Id = Id;
            _Folio = Folio;
            _Nombre_Solicitante = Nombre_Solicitante;
            _Numero_Empleado = Numero_Empleado;
            _Id_Categoria = Id_Categoria;
            _Id_Carrera = Id_Carrera;
            _Id_Evento = Id_Evento;
            _Id_Recurso_Solicitado = Id_Recurso_Solicitado;
            _Id_Actividad = Id_Actividad;
            _Id_Validacion = Id_Validacion;
            _Id_Estado = Id_Estado;
            _Fecha_Creacion = Fecha_Creacion;
            _Fecha_Modificacion = Fecha_Modificacion;
            _URL_Reporte = URL_Reporte;
            _Correo_Solicitante = Correo_Solicitante;
            _Comentario_Rechazado = Comentario_Rechazado;
            _Leido = Leido;
        }

        public int Id { get => _Id; set => _Id = value; }
        public string Folio { get => _Folio; set => _Folio = value; }
        public string Nombre_Solicitante { get => _Nombre_Solicitante; set => _Nombre_Solicitante = value; }
        public int Numero_Empleado { get => _Numero_Empleado; set => _Numero_Empleado = value; }
        public int Id_Categoria { get => _Id_Categoria; set => _Id_Categoria = value; }
        public int Id_Carrera { get => _Id_Carrera; set => _Id_Carrera = value; }
        public int Id_Evento { get => _Id_Evento; set => _Id_Evento = value; }
        public int Id_Recurso_Solicitado { get => _Id_Recurso_Solicitado; set => _Id_Recurso_Solicitado = value; }
        public int Id_Actividad { get => _Id_Actividad; set => _Id_Actividad = value; }
        public int Id_Validacion { get => _Id_Validacion; set => _Id_Validacion = value; }
        public int Id_Estado { get => _Id_Estado; set => _Id_Estado = value; }
        public DateTime Fecha_Creacion { get => _Fecha_Creacion; set => _Fecha_Creacion = value; }
        public DateTime Fecha_Modificacion { get => _Fecha_Modificacion; set => _Fecha_Modificacion = value; }
        public string URL_Reporte { get => _URL_Reporte; set => _URL_Reporte = value; }
        public string Correo_Solicitante { get => _Correo_Solicitante; set => _Correo_Solicitante = value; }
        public string Comentario_Rechazado { get => _Comentario_Rechazado; set => _Comentario_Rechazado = value; }
        public bool Leido { get => _Leido; set => _Leido = value; }
    }
}
