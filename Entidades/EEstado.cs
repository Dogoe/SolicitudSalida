using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EEstado
    {
        int _Id;
        string _Tipo;

        public EEstado()
        {

        }

        public EEstado(int Id, string Tipo)
        {
            _Id = Id;
            _Tipo = Tipo;
        }

        public int Id { get => _Id; set => _Id = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
    }
}
