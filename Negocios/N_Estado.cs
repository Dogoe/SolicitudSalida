using Datos;
using System;
using System.Data;

namespace Negocios
{
    public class N_Estado
    {
        private D_Estado objNegocioEstado = new D_Estado();
        public N_Estado()
        {
           
        }
        public DataSet listaEstado()
        {
            return objNegocioEstado.ListaEstado();
        }
    }
}
