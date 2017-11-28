using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EActividad
    {
        #region Atributos
        int _Id;
        bool _CACEI;
        bool _Licenciatura;
        bool _Personal;
        bool _ISO;
        bool _Posgrado;
        string _Otro;
        #endregion
        #region Constructor
        public EActividad()
        {

        }

        public EActividad(int Id, bool CACEI, bool Licenciatura, bool Personal, bool ISO, bool Posgrado, string Otro)
        {
            _Id = Id;
            _CACEI = CACEI;
            _Licenciatura = Licenciatura;
            _Personal = Personal;
            _ISO = ISO;
            _Posgrado = Posgrado;
            _Otro = Otro;
        }




        #endregion
        #region Encapsulamiento
        public int Id { get => _Id; set => _Id = value; }
        public bool CACEI { get => _CACEI; set => _CACEI = value; }
        public bool Licenciatura { get => _Licenciatura; set => _Licenciatura = value; }
        public bool Personal { get => _Personal; set => _Personal = value; }
        public bool ISO { get => _ISO; set => _ISO = value; }
        public bool Posgrado { get => _Posgrado; set => _Posgrado = value; }
        public string Otro { get => _Otro; set => _Otro = value; }
        #endregion


    }
}
