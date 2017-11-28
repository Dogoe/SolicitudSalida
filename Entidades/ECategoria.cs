using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ECategoria
    {
        #region Atributos
        int _Id;
        string _Nombre_Categoria;
        #endregion
        #region Constructor
        public ECategoria()
        {

        }

        public ECategoria(int Id, string Nombre_Categoria)
        {
            _Id = Id;
            _Nombre_Categoria = Nombre_Categoria;
        }

        #endregion
        #region Encapsulamiento

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre_Categoria { get => _Nombre_Categoria; set => _Nombre_Categoria = value; }
        #endregion

    }
}
