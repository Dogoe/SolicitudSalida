namespace Entidades
{
    public class EUsuario_Uabc
    {
        #region Atributos
        private string _Nombre;
        private string _Apellido;
        private string _Email;
        private string _Contra;
        private int _NoEmpleado;
       
        #endregion

        #region Constructor
        public EUsuario_Uabc()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Email = string.Empty;
            Contra = string.Empty;
            NoEmpleado = 0;
            
        }
        #endregion

        #region Encapsulamineto
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Contra
        {
            get { return _Contra; }
            set { _Contra = value; }
        }

        public int NoEmpleado
        {
            get { return _NoEmpleado; }
            set { _NoEmpleado = value; }
        }
     
        #endregion
    }
}
