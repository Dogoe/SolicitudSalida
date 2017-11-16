using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class E_Usuario
  {
    #region Atributos
        private int    _IdUsuario;
        private int    _IdTipoUsuario;      
        private string _NombreUsuario;
        private string _LoginUsuario;
        private string _PasswordUsuario;
        private char _Status;
        #endregion

        #region Constructor
        public E_Usuario()
        {
            _IdUsuario = 0;
            _IdTipoUsuario = 0;
            _NombreUsuario = string.Empty;
            _LoginUsuario = string.Empty;
            _PasswordUsuario = string.Empty;
            _Status = 'A';
        }
        #endregion

        #region Encapsulamineto
       
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        public int IdTipoUsuario
        {
            get { return _IdTipoUsuario; }
            set { _IdTipoUsuario = value; }
        }
      
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        public string LoginUsuario
        {
            get { return _LoginUsuario; }
            set { _LoginUsuario = value; }
        }
        public string PasswordUsuario
        {
            get { return _PasswordUsuario; }
            set { _PasswordUsuario = value; }
        }
        public char Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

  }

  public class E_TipoUsuario
  {
    #region Atributos
    private int _IdTipoUsuario;
    private string _DescripcionTipoUsuario;
    #endregion

    #region Constructor
    public E_TipoUsuario()
    {
      _IdTipoUsuario = 0;
      _DescripcionTipoUsuario = string.Empty;
    }
    #endregion

    #region Encapsulamientos
    public int IdTipoUsuario
    {
      get { return _IdTipoUsuario; }
      set { _IdTipoUsuario = value; }
    }

    public string DescripcionTipoUsuario
    {
      get { return _DescripcionTipoUsuario; }
      set { _DescripcionTipoUsuario = value; }
    }
    #endregion
  }
}
