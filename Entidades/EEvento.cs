using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EEvento
    {
        int _Id;
        string _Nombre_Evento;
        float _Costo;
        string _Lugar;
        DateTime _Fecha_Hora_Salida;
        DateTime _Fecha_Hora_Regreso;

        public EEvento()
        {

        }

        public EEvento(int Id, string Nombre_Evento, float Costo, string lugar, DateTime Fecha_Hora_Salida, DateTime Fecha_Hora_Regreso)
        {
            _Id = Id;
            _Nombre_Evento = Nombre_Evento;
            _Costo = Costo;
            _Lugar = lugar;
            _Fecha_Hora_Salida = Fecha_Hora_Salida;
            _Fecha_Hora_Regreso = Fecha_Hora_Regreso;
        }

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre_Evento { get => _Nombre_Evento; set => _Nombre_Evento = value; }
        public float Costo { get => _Costo; set => _Costo = value; }
        public string Lugar { get => _Lugar; set => _Lugar = value; }
        public DateTime Fecha_Hora_Salida { get => _Fecha_Hora_Salida; set => _Fecha_Hora_Salida = value; }
        public DateTime Fecha_Hora_Regreso { get => _Fecha_Hora_Regreso; set => _Fecha_Hora_Regreso = value; }
    }
}
