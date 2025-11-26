using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

//Uso comentarios para facilitar la lectura
namespace Datos
{
    public class Acceso //Clase para manejar el acceso a datos (Consultas, Etc.)
    {
        //Instancia de la clase Conexion para manejar la conexión a la base de datos
        private Conexion conexion;
        //Tambien el comando para poder setar las consultas con parámetros o usar SP más adelante
        private SqlCommand comando;

        //Constructor que inicializa la instancia de Conexion
        public Acceso()
        {
            conexion = new Conexion();
            comando = new SqlCommand();
        }

        //Seteo el comando para la consulta
        public void SetComando(string consulta, CommandType tipo = CommandType.Text) //Por defecto es texto pero sirve si quiero usar SP
        {
            comando.CommandText = consulta;
            comando.CommandType = tipo;
        }



        /*Desde acá van los CRUDs y demás operaciones de acceso a datos
         que van a devolver datatable para manejarlos desde la capa negocio*/
        //Consultas SELECT
        public DataTable EjecutarConsulta()
        {
            //Creo la conexión y la abro
            SqlConnection connection = null;
            try
            {
                connection = conexion.GetConnection();
                comando.Connection = connection;
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;

            }
            catch (Exception ex)
            { 
                //Capturo cualquier error y lo tiro a la capa superior para su manejo
                throw new Exception("Error al ejecutar la consulta (Capa Datos). \n"+ex.Message);
            } finally
            {
                //Cierro la conexión si está abierta
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                comando.Parameters.Clear(); //Limpio los parámetros para la próxima consulta
            }
        }

        //Método para ejecutar comandos INSERT, UPDATE, DELETE
        /// (el intelisense es impresionante me adivina lo que quiero desde el ejemplo de arriba jaja)
        public int EjecutarComando()
        {
            SqlConnection connection = null;
            try
            {
                connection = conexion.GetConnection();
                comando.Connection = connection;
                connection.Open();

                //Devuelvo cuantas tablas fueron afectadas
                return comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el comando (Capa Datos). \n" + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                comando.Parameters.Clear();
            }
        }

        //Método para setear parámetros en el comando (para futuras implementaciones con SP)
        public void AgregarParametro(string clave, object valor)
        {
            comando.Parameters.AddWithValue(clave, valor);
        }

    }
}
