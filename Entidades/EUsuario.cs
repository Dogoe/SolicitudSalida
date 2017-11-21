namespace Entidades
{
    public class EUsuario
    {
        #region Atributos
        private int _Id;
        private string _Correo;
        private int _Id_Rol;
        #endregion

        #region Constructor
        public EUsuario()
        {
            _Id = 0;
        _Correo = string.Empty;
        _Id_Rol = 0;
        }


        #endregion

        #region Encapsulamientos
        public int Id { get => _Id; set => _Id = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public int Id_Rol { get => _Id_Rol; set => _Id_Rol = value; }
        #endregion
    }
}
