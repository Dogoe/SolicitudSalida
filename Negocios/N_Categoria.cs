using Datos;
using System;
using System.Data;

namespace Negocios
{
    public class N_Categoria
    {
        private D_Categoria objNegocioCategoria = new D_Categoria();
        public N_Categoria()
        {
           

        }
        //--------------------------
        public DataSet ListaCategoria()
        {
            return objNegocioCategoria.ListaCategoria();
        }
    }
}
