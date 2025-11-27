using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

//Uso comentarios para facilitar la lectura
namespace Datos
{
    public class AccesoDatos //Clase para manejar el acceso a datos (Consultas, Etc.)
    {
        
        private SqlConnection conexion;
        private SqlCommand comando;

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



        /*Desde acá van los CRUDs y demás operaciones de acceso a datos
         que van a devolver datatable para manejarlos desde la capa negocio*/
        //Consultas SELECT
        public DataTable EjecutarConsulta()
        {
            //Creo la conexión y la abro
            comando.Connection = conexion;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                conexion.Open();

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
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear(); //Limpio los parámetros para la próxima consulta
            }
        }

        //Método para ejecutar comandos INSERT, UPDATE, DELETE
        /// (el intelisense es impresionante me adivina lo que quiero desde el ejemplo de arriba jaja)
        public int EjecutarComando()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();

                //Devuelvo cuantas tablas fueron afectadas
                return comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el comando (Capa Datos). \n" + ex.Message);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
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
