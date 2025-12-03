using System;
using System.Collections.Generic;
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
                acceso.EjecutarConsulta();
                while (acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Codigo = acceso.Lector["Codigo"].ToString();
                    aux.Nombre = acceso.Lector["Nombre"].ToString();
                    aux.Descripcion = acceso.Lector["Descripcion"].ToString();
                    aux.Precio = (decimal)acceso.Lector["Precio"];

                    if (acceso.Lector["ImagenUrl"] != DBNull.Value)
                        aux.ImagenUrl = acceso.Lector["ImagenUrl"].ToString();

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)acceso.Lector["MarcaId"];
                    aux.Marca.Descripcion = acceso.Lector["MarcaDescripcion"].ToString();

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)acceso.Lector["CategoriaId"];
                    aux.Categoria.Descripcion = acceso.Lector["CategoriaDescripcion"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos (Capa Negocio). \n" + ex.Message);
            } finally
            {
                acceso.CerrarConexion();
            }
        }

        public Articulo consultarRepetido(string codigo)
        {
            try
            {
                acceso.SetComando("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Id AS MarcaId, M.Descripcion AS MarcaDescripcion, C.Id AS CategoriaId, C.Descripcion AS CategoriaDescripcion FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE Codigo = @Codigo");
                acceso.AgregarParametro("@Codigo", codigo);
                acceso.EjecutarConsulta();
                if (acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Codigo = acceso.Lector["Codigo"].ToString().ToUpper();
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];
                    aux.Precio = (decimal)acceso.Lector["Precio"];

                    if (acceso.Lector["ImagenUrl"] != DBNull.Value)
                        aux.ImagenUrl = (string)acceso.Lector["ImagenUrl"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)acceso.Lector["MarcaId"];
                    aux.Marca.Descripcion = (string)acceso.Lector["MarcaDescripcion"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)acceso.Lector["CategoriaId"];
                    aux.Categoria.Descripcion = (string)acceso.Lector["CategoriaDescripcion"];

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
            finally
            {
                acceso.CerrarConexion();
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
            finally
            {
                acceso.CerrarConexion();
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
            } finally
            {
                acceso.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                acceso.SetComando("DELETE FROM ARTICULOS WHERE Id = @Id");
                acceso.AgregarParametro("@Id", id);
                acceso.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar artículo (Capa Negocio). \n" + ex.Message);
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }

        public List<Articulo> BusquedaAvanzada(Marca marca, Categoria categoria, string campo, string criterio, string filtro)
        {
            int marcaId = marca != null ? marca.Id : 0;
            int categoriaId = categoria != null ? categoria.Id : 0;
            string clausula = " WHERE";
            if (!string.IsNullOrEmpty(campo))
            {
                clausula +=  " A."+ campo;
            }
            if (!string.IsNullOrEmpty(criterio) && !string.IsNullOrEmpty(filtro) && !string.IsNullOrEmpty(campo))
            {
                switch (criterio)
                {
                    case "Comienza con":
                        clausula += " LIKE '" + filtro + "%'";
                        break;
                    case "Termina con":
                        clausula += " LIKE '%" + filtro + "'";
                        break;
                    case "Contiene":
                        clausula += " LIKE '%" + filtro + "%'";
                        break;
                    case "Igual a":
                        clausula += " = '" + filtro + "'";
                        break;
                    case "Mayor a":
                        clausula += " > " + filtro;
                        break;
                    case "Menor a":
                        clausula += " < " + filtro;
                        break;
                    default:
                        clausula = string.Empty;
                        break;
                }
            }
            if (categoriaId != 0)
            {
                clausula += clausula == " WHERE" ? " A.IdCategoria = " + categoriaId : " AND A.IdCategoria = " + categoriaId;
            }
            if (marcaId != 0)
            {
                clausula += clausula == " WHERE" ? " A.IdMarca = " + marcaId : " AND A.IdMarca = " + marcaId;
            }
            List<Articulo> lista = new List<Articulo>();
            try
            {
                acceso.SetComando("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Id AS MarcaId, M.Descripcion AS MarcaDescripcion, C.Id AS CategoriaId, C.Descripcion AS CategoriaDescripcion FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id " + clausula + " order by c.Descripcion, m.Descripcion, a.Codigo, a.Nombre");
                acceso.EjecutarConsulta();
                while (acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Codigo = (string)acceso.Lector["Codigo"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];
                    aux.Precio = (decimal)acceso.Lector["Precio"];

                    if (acceso.Lector["ImagenUrl"] != DBNull.Value)
                        aux.ImagenUrl = (string)acceso.Lector["ImagenUrl"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)acceso.Lector["MarcaId"];
                    aux.Marca.Descripcion = (string)acceso.Lector["MarcaDescripcion"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)acceso.Lector["CategoriaId"];
                    aux.Categoria.Descripcion = (string)acceso.Lector["CategoriaDescripcion"];

                    lista.Add(aux);
                }
                return lista;
            } catch (Exception ex)
            {
                throw new Exception("Error en la búsqueda avanzada de artículos (Capa Negocio). \n" + ex.Message);
            }
            finally
            {
                acceso.CerrarConexion();
            }

        }
    }
}
