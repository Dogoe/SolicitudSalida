using Datos;
using System;
using System.Data;

namespace Negocios
{
    public class N_Carrera
    {
        private D_Carrera objNegocioCarrera = new D_Carrera();
        //----------------------------------
        public N_Carrera()
        {

        }
        //-----------------------------
        public DataSet ListaCarrera()
        {
            return objNegocioCarrera.ListaCarrera();
        }
    }
}
