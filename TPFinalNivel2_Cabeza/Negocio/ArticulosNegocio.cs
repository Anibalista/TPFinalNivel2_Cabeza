using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class ArticulosNegocio
    {
        private AccesoDatos acceso = new AccesoDatos();

        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                acceso.SetComando("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Id AS MarcaId, M.Descripcion AS MarcaDescripcion, C.Id AS CategoriaId, C.Descripcion AS CategoriaDescripcion FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");

                var tabla = acceso.EjecutarConsulta();

                foreach (System.Data.DataRow row in tabla.Rows)
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)row["Id"];
                    aux.Codigo = row["Codigo"].ToString();
                    aux.Nombre = row["Nombre"].ToString();
                    aux.Descripcion = row["Descripcion"].ToString();
                    aux.Precio = (decimal)row["Precio"];

                    if (row["ImagenUrl"] != DBNull.Value)
                        aux.ImagenUrl = row["ImagenUrl"].ToString();

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)row["MarcaId"];
                    aux.Marca.Descripcion = row["MarcaDescripcion"].ToString();

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)row["CategoriaId"];
                    aux.Categoria.Descripcion = row["CategoriaDescripcion"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos (Capa Negocio). \n" + ex.Message);
            }
        }
    }
}
