using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ERecurso_Solicitado
    {
        int _Id;
        bool _Hospedaje;
        bool _Transporte;
        bool _Combustible;
        bool _Viatico;
        bool _Oficio_Comision;
        string _Otro;

        public ERecurso_Solicitado()
        {

        }

        public ERecurso_Solicitado(int Id, bool Hospedaje, bool Transporte, bool Combustible, bool Viatico, bool Oficio_Comision, string Otro)
        {
            _Id = Id;
            _Hospedaje = Hospedaje;
            _Transporte = Transporte;
            _Combustible = Combustible;
            _Viatico = Viatico;
            _Oficio_Comision = Oficio_Comision;
            _Otro = Otro;
        }

        public int Id { get => _Id; set => _Id = value; }
        public bool Hospedaje { get => _Hospedaje; set => _Hospedaje = value; }
        public bool Transporte { get => _Transporte; set => _Transporte = value; }
        public bool Combustible { get => _Combustible; set => _Combustible = value; }
        public bool Viatico { get => _Viatico; set => _Viatico = value; }
        public bool Oficio_Comision { get => _Oficio_Comision; set => _Oficio_Comision = value; }
        public string Otro { get => _Otro; set => _Otro = value; }
    }
}
