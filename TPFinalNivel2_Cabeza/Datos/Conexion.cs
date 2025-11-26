using System.Configuration;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion //Clase separada para manejar la conexión a la base de datos
    {
        //La idea es manejar la cadena de conexión desde la configuración de la aplicación
        private string connectionString;
        public Conexion()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CatalogoDB"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
