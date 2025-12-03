using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class CategoriasNegocio
    {
        //Abro la instancia de acceso a datos
        private AccesoDatos acceso = new AccesoDatos();

        //Método para listar las categorías sin filtros
        public List<Categoria> Listar()
        {
            //Creo la lista de categorías
            List<Categoria> lista = new List<Categoria>();
            try
            {
                //Seteo el comando para la consulta
                acceso.SetComando("SELECT Id, Descripcion FROM CATEGORIAS");

                //Ejecuto la consulta
                acceso.EjecutarConsulta();

                //Recorro las filas del datatable y las agrego a la lista
                while (acceso.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                //Capturo cualquier error y lo tiro a la capa superior para su manejo (o a un archivo log con un helper)
                throw new Exception("Error al listar categorías (Capa Negocio). \n" + ex.Message);
            }
            finally
            {
                //Cierro la conexión
                acceso.CerrarConexion();
            }
        }

    }
}
