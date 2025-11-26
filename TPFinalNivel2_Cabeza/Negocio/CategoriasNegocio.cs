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
        private Acceso acceso = new Acceso();

        //Método para listar las categorías sin filtros
        public List<Categoria> Listar()
        {
            //Creo la lista de categorías
            List<Categoria> lista = new List<Categoria>();
            try
            {
                //Seteo el comando para la consulta
                acceso.SetComando("SELECT Id, Descripcion FROM CATEGORIAS");

                //Ejecuto la consulta y obtengo el datatable
                var tabla = acceso.EjecutarConsulta();

                //Recorro las filas del datatable y las agrego a la lista
                foreach (System.Data.DataRow row in tabla.Rows)
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)row["Id"];
                    aux.Descripcion = row["Descripcion"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                //Capturo cualquier error y lo tiro a la capa superior para su manejo (o a un archivo log con un helper)
                throw new Exception("Error al listar categorías (Capa Negocio). \n" + ex.Message);
            }
        }

    }
}
