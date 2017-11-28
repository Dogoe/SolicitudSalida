using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EValidacion
    {
        int _Id;
        bool _Coordinador;
        bool _Subdirector;
        bool _Administrador;
        bool _Director;
        bool _Posgrado;
        bool _Unica;

        public EValidacion()
        {

        }

        public EValidacion(int Id, bool Coordinador, bool Subdirector, bool Administrador, bool Director, bool Posgrado, bool Unica)
        {
            _Id = Id;
            _Coordinador = Coordinador;
            _Subdirector = Subdirector;
            _Administrador = Administrador;
            _Director = Director;
            _Posgrado = Posgrado;
            _Unica = Unica;
        }

        public int Id { get => _Id; set => _Id = value; }
        public bool Coordinador { get => _Coordinador; set => _Coordinador = value; }
        public bool Subdirector { get => _Subdirector; set => _Subdirector = value; }
        public bool Administrador { get => _Administrador; set => _Administrador = value; }
        public bool Director { get => _Director; set => _Director = value; }
        public bool Posgrado { get => _Posgrado; set => _Posgrado = value; }
        public bool Unica { get => _Unica; set => _Unica = value; }
    }
}
