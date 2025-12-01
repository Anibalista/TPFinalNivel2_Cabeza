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
                acceso.SetComando("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Id AS MarcaId, M.Descripcion AS MarcaDescripcion, C.Id AS CategoriaId, C.Descripcion AS CategoriaDescripcion FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id order by c.Descripcion, m.Descripcion, a.Codigo, a.Nombre");

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

        public Articulo consultarRepetido(string codigo)
        {
            try
            {
                acceso.SetComando("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Id AS MarcaId, M.Descripcion AS MarcaDescripcion, C.Id AS CategoriaId, C.Descripcion AS CategoriaDescripcion FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE Codigo = @Codigo");
                acceso.AgregarParametro("@Codigo", codigo);
                var tabla = acceso.EjecutarConsulta();
                if (tabla.Rows.Count > 0)
                {
                    System.Data.DataRow row = tabla.Rows[0];
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

                    return aux;
                }
                else
                {
                    return null; // No se encontró ningún artículo con el código proporcionado
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar código repetido (Capa Negocio). \n" + ex.Message);
            }
        }

        public void Agregar(Articulo nuevo)
        {
            if (nuevo == null)
                throw new ArgumentNullException("El artículo a agregar no puede ser nulo.");

            try
            {
                acceso.SetComando("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, ImagenUrl, IdMarca, IdCategoria) VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @ImagenUrl, @IdMarca, @IdCategoria)");
                acceso.AgregarParametro("@Codigo", nuevo.Codigo);
                acceso.AgregarParametro("@Nombre", nuevo.Nombre);
                acceso.AgregarParametro("@Descripcion", nuevo.Descripcion);
                acceso.AgregarParametro("@Precio", nuevo.Precio);
                acceso.AgregarParametro("@ImagenUrl", nuevo.ImagenUrl ?? "");
                acceso.AgregarParametro("@IdMarca", nuevo.Marca.Id);
                acceso.AgregarParametro("@IdCategoria", nuevo.Categoria.Id);
                acceso.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar artículo (Capa Negocio). \n" + ex.Message);
            }
        }

        public void Modificar(Articulo articulo)
        {
            if (articulo == null)
                throw new ArgumentNullException("El artículo a modificar no puede ser nulo.");

            try
            {
                acceso.SetComando("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, ImagenUrl = @ImagenUrl, IdMarca = @IdMarca, IdCategoria = @IdCategoria WHERE Id = @Id");
                acceso.AgregarParametro("@Codigo", articulo.Codigo);
                acceso.AgregarParametro("@Nombre", articulo.Nombre);
                acceso.AgregarParametro("@Descripcion", articulo.Descripcion);
                acceso.AgregarParametro("@Precio", articulo.Precio);
                acceso.AgregarParametro("@ImagenUrl", articulo.ImagenUrl ?? "");
                acceso.AgregarParametro("@IdMarca", articulo.Marca.Id);
                acceso.AgregarParametro("@IdCategoria", articulo.Categoria.Id);
                acceso.AgregarParametro("@Id", articulo.Id);
                acceso.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar artículo (Capa Negocio). \n" + ex.Message);
            }
        }
    }
}
