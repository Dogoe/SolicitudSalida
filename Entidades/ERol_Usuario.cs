namespace Entidades
{
    public class ERol_Usuario
    {
        #region Atributos
        private int _IdRol;
        private string _NombreRol;
        private string _DescripcionRol;
        #endregion

        #region Constructor
        public ERol_Usuario()
        {
            IdRol = 0;
            NombreRol = string.Empty;
            DescripcionRol = string.Empty;
        }
        #endregion

        #region Encapsulamientos
        public int IdRol
        {
            get { return _IdRol; }
            set { _IdRol = value; }
        }

        public string NombreRol
        {
            get { return _NombreRol; }
            set { _NombreRol = value; }
        }

        public string DescripcionRol
        {
            get { return _DescripcionRol; }
            set { _DescripcionRol = value; }
        }
        #endregion
    }
}