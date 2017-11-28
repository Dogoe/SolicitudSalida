namespace Entidades
{
    public class ECarrera
    {
        #region Atributos
        private int _Id;
        private string _NombreCarrera;
        private int _Id_Usuario_Coordinador;
        #endregion


        public ECarrera()
        {
            _Id = 0;
            _NombreCarrera = string.Empty;
            _Id_Usuario_Coordinador =0;
        }
        public ECarrera(int id, string nombreCarrera, int idUsuarioCoordinador)
        {
            _Id = id;
            _NombreCarrera = nombreCarrera;
            _Id_Usuario_Coordinador = idUsuarioCoordinador;
        }
        //----------------------------------

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string NombreCarrera
        {
            get { return _NombreCarrera; }
            set { _NombreCarrera = value; }
        }

        public int IdUsuarioCoordinador
        {
            get { return _Id_Usuario_Coordinador; }
            set { _Id_Usuario_Coordinador = value; }
        }
    }
}