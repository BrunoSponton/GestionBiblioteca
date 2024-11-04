using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosConexionBD
    {
        public static SqlConnection conexion = new SqlConnection("server=BRUNO\\SQLEXPRESS; database=BIBLIOTECA; integrated security=true");

        #region Constructor
        public static SqlConnection AbrirConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Broken || conexion.State == ConnectionState.Closed)
                    conexion.Open();
                return conexion; // Devolver la conexión abierta
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de abrir la conexión", e);
            }
        }

        public static void CerrarConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexión", e);
            }
        }
        #endregion
    }
}

