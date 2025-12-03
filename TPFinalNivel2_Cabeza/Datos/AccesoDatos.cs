using System;
using System.Data;
using System.Data.SqlClient;

//Uso comentarios para facilitar la lectura
namespace Datos
{
    public class AccesoDatos //Clase para manejar el acceso a datos (Consultas, Etc.)
    {
        
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        //Constructor que inicializa la instancia de Conexion Y Comando
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        //Seteo el comando para la consulta
        public void SetComando(string consulta, CommandType tipo = CommandType.Text) //Por defecto es texto pero sirve si quiero usar SP
        {
            comando.CommandText = consulta;
            comando.CommandType = tipo;
        }

        //Consultas SELECT
        public void EjecutarConsulta()
        {
            //Creo la conexión y la abro
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            { 
                //Capturo cualquier error y lo tiro a la capa superior para su manejo
                throw new Exception("Error al ejecutar la consulta (Capa Datos). \n"+ex.Message);
            }
        }

        //Método para ejecutar comandos INSERT, UPDATE, DELETE
        /// (el intelisense es impresionante me adivina lo que quiero desde el ejemplo de arriba jaja)
        public void EjecutarComando()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el comando (Capa Datos). \n" + ex.Message);
            }
        }

        //Cerrar la conexion
        public void CerrarConexion()
        {
            if (lector != null && !lector.IsClosed)
            {
                lector.Close();
            }
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }


        //Método para setear parámetros en el comando (para futuras implementaciones con SP)
        public void AgregarParametro(string clave, object valor)
        {
            comando.Parameters.AddWithValue(clave, valor);
        }

    }
}
