using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class MarcasNegocio
    {
        //Abro la instancia de acceso a datos
        private AccesoDatos acceso = new AccesoDatos();

        //Método para listar las marcas sin filtros
        public List<Marca> Listar()
        {
            //Creo la lista de marcas
            List<Marca> lista = new List<Marca>();
            try
            {
                //Seteo el comando para la consulta
                acceso.SetComando("SELECT Id, Descripcion FROM MARCAS");

                //Ejecuto la consulta y obtengo el datatable
                var tabla = acceso.EjecutarConsulta();

                //Recorro las filas del datatable y las agrego a la lista
                foreach (System.Data.DataRow row in tabla.Rows)
                {
                    Marca aux = new Marca();
                    aux.Id = (int)row["Id"];
                    aux.Descripcion = row["Descripcion"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                //Capturo cualquier error y lo tiro a la capa superior para su manejo (o a un archivo log con un helper)
                throw new Exception("Error al listar marcas (Capa Negocio). \n" + ex.Message);
            }
        }
    }
}
