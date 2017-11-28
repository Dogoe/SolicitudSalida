using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos
{
    class D_Solicitud
    {
        private D_ConexionDB dbSS = new D_ConexionDB(NombreBasesDeDatos.DbSsConnectionString.ToString());//base de datos del sistema
        public D_Solicitud()
        {

        }
        //-----------------------------------------------
        public bool Crear_Solicitud(ESolicitud nuevaSolicitud)
        {
            
            return false;
        }
        //-----------------------------
    }
}
