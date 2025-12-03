using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class FrmGestionArticulos : Form
    {
        private bool cerrando = false;
        private List<Articulo> listaArticulos;
        private Articulo seleccionado;

        public FrmGestionArticulos()
        {
            InitializeComponent();
        }

        //Eventos
        private void FrmGestionArticulos_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        //Botones
        private void btnSalir_Click(object sender, EventArgs e)
        {
            cerrando = true;
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                CerrarFormulario();
            }
            else
            {
                cerrando = false;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (picBoxImagen.Image != null)
            {
                picBoxImagen.Dispose();
                picBoxImagen.Image = null;
            }
            FrmEditArticulos agregar = new FrmEditArticulos();
            agregar.ShowDialog();
            Cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
                return;
            DialogResult respuesta = MessageBox.Show($"¿Desea modificar el articulo {seleccionado.Nombre}?", "Confirmar modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                if (picBoxImagen.Image != null)
                {
                    picBoxImagen.Image = null;
                }
                FrmEditArticulos modificar = new FrmEditArticulos();
                modificar.setArticulo(seleccionado);
                modificar.ShowDialog();
                seleccionado = null;
                picBoxImagen.Image = Image.FromFile(HelperImagenes.ObtenerImagenSeleccionada(""));
                Cargar();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
                return;
            try
            {
                FrmEditArticulos consultar = new FrmEditArticulos();
                consultar.setArticulo(seleccionado);
                consultar.setModoConsulta();
                consultar.ShowDialog();
                seleccionado = null;
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de consulta. \n" + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
                return;
            DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea eliminar el artículo {seleccionado.Nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.No)
                return;
            DialogResult segundaRespuesta = MessageBox.Show("Esta acción no se puede deshacer. ¿Desea continuar?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (segundaRespuesta == DialogResult.No)
                return;

            string imagen = seleccionado.ImagenUrl;
            try
            {
                picBoxImagen.Image = null;
                ArticulosNegocio negocio = new ArticulosNegocio();
                negocio.Eliminar(seleccionado.Id);
                seleccionado = null;
                picBoxImagen.Image = Image.FromFile(HelperImagenes.ObtenerImagenSeleccionada(""));
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el artículo. \n" + ex.Message);
            }
            try
            {
                HelperImagenes.EliminarImagen(imagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BusquedaAvanzada();
        }

        //Eventos para Filtros rápidos
        private void txtDescipcion_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        //Evento de Seleccionado de articulo
        private void dataGridArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (cerrando)
                return;
            seleccionado = null;
            if (dataGridArticulos.Rows.Count == 0)
                return;
            try
            {
                if (dataGridArticulos.CurrentRow != null)
                {
                    seleccionado = (Articulo)dataGridArticulos.CurrentRow.DataBoundItem;
                }
                if (seleccionado != null)
                {
                    cargarImagen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el artículo. \n" + ex.Message);
            }
        }

        private void cargarImagen()
        {
            try
            {
                string urlImagen = HelperImagenes.ObtenerImagenSeleccionada(seleccionado.ImagenUrl);

                if (urlImagen.StartsWith("http")) 
                {
                    picBoxImagen.Load(urlImagen);
                } else
                {
                    HelperImagenes.CargarImagenSinLock(picBoxImagen, urlImagen);
                }

            }
            catch (Exception ex)
            {
                try
                {
                    HelperImagenes.CargarImagenSinLock(picBoxImagen, IconosImagenes.ImagenesPorDefecto["ImagenError"]);
                }
                catch (Exception)
                {
                    picBoxImagen.Image = null;
                    MessageBox.Show("Error en el cuadro de imágenes. \n" + ex.Message);
                }
            }
        }

        //Eventos de los Combos de Búsqueda Avanzada
        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cerrando)
                return;
            CargarCriterios();
        }

        private void cbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cerrando)
                return;
            txtFiltroAvanzado.Enabled = cbCriterio.SelectedIndex != -1;
        }

        //Méttodos de Carga
        private void Cargar()
        {
            CargarArticulos();
            CargarMarcas();
            CargarCategorias();
            CargarCampos();
        }

        private void refrescarGrilla()
        {
            try
            {
                dataGridArticulos.DataSource = listaArticulos;
                ocultarColumnas("Id");
                dataGridArticulos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridArticulos.Columns["Precio"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar la grilla. \n" + ex.Message);
            }
        }

        private void CargarArticulos()
        {
            listaArticulos = null;
            picBoxImagen.Image = null;
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                listaArticulos = negocio.Listar();
                refrescarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los artículos. \n" + ex.Message);
            }
        }

        private void CargarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            try
            {
                MarcasNegocio negocio = new MarcasNegocio();
                listaMarcas = negocio.Listar();

                cbMarca.DataSource = null;
                cbMarca.DataSource = listaMarcas;
                cbMarca.ValueMember = "Id";
                cbMarca.DisplayMember = "Descripcion";
                cbMarca.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las marcas. \n" + ex.Message);
            }
        }

        private void CargarCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            try
            {
                CategoriasNegocio negocio = new CategoriasNegocio();
                listaCategorias = negocio.Listar();

                cbCategoria.DataSource = null;
                cbCategoria.DataSource = listaCategorias;
                cbCategoria.ValueMember = "Id";
                cbCategoria.DisplayMember = "Descripcion";
                cbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías. \n" + ex.Message);
            }
        }

        private void CargarCampos()
        {
            if (cerrando)
                return;
            List<string> listaCampos = new List<string>() { "Precio", "Nombre", "Descripción", "Código Artículo" };
            try
            {
                cbCampo.DataSource = null;
                cbCampo.DataSource = listaCampos;
                cbCampo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los campos de búsqueda. \n" + ex.Message);
            }

        }

        private void CargarCriterios()
        {
            if (cerrando)
                return;

            int indice = cbCampo.SelectedIndex;
            List<string> listaCriterios = new List<string>();
            cbCriterio.DataSource = null;
            switch (indice)
            {
                case -1:
                    cbCriterio.Enabled = false;
                    return;
                case 0:
                    listaCriterios.Add("Mayor a");
                    listaCriterios.Add("Menor a");
                    listaCriterios.Add("Igual a");
                    break;
                default:
                    listaCriterios.Add("Comienza con");
                    listaCriterios.Add("Termina con");
                    listaCriterios.Add("Contiene");
                    break;
            }
            try
            {
                cbCriterio.DataSource = listaCriterios;
                cbCriterio.Enabled = true;
                cbCriterio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los criterios de búsqueda. \n" + ex.Message);
            }
        }

        //Consultado por IA para darle formato de pesos argentinos a la columna precio
        private void dataGridArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (cerrando) return;

            if (dataGridArticulos.Columns[e.ColumnIndex].Name == "Precio" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal precio))
                {
                    // Formato argentino: símbolo pesos y 2 decimales
                    e.Value = precio.ToString("C2", new System.Globalization.CultureInfo("es-AR"));
                    e.FormattingApplied = true;
                }
            }
        }

        //Métodos de Filtrado
        private void Filtrar()
        {
            if (cerrando)
                return;
            if (listaArticulos == null)
                return;
            string filtroCodigo = txtCodigo.Text.Trim().ToLower();
            string filtroNombre = txtNombre.Text.Trim().ToLower();
            try
            {
                dataGridArticulos.DataSource = null;
                if (String.IsNullOrEmpty(filtroCodigo) && (String.IsNullOrEmpty(filtroNombre) || filtroNombre.Length < 3))
                {
                    dataGridArticulos.DataSource = listaArticulos;
                    return;
                }
                List<Articulo> listaFiltrada = listaArticulos.FindAll(a => (string.IsNullOrWhiteSpace(filtroCodigo) || a.Codigo.IndexOf(filtroCodigo, StringComparison.OrdinalIgnoreCase) >= 0)
                                                    && (string.IsNullOrWhiteSpace(filtroNombre) || a.Nombre.IndexOf(filtroNombre, StringComparison.OrdinalIgnoreCase) >= 0));
                dataGridArticulos.DataSource = listaFiltrada;
            } catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los artículos. \n" + ex.Message);
            }
        }

        private void BusquedaAvanzada()
        {
            if (cerrando)
                return;
            //creo un mensaje de error vacío
            string mensaje = string.Empty;

            //instancio las variables para los filtros
            string campo = string.Empty;
            string criterio = string.Empty;
            string filtro = string.Empty;
            try
            {
                //Acá la idea es que pueda buscar por marca sola o por categoria sola
                //pero si quiere usar campo, criterio y valor, que los complete todos
                if (!ValidarFiltrosObligatorios(ref mensaje))
                {
                    if (!validarFiltrosOpcionales(ref mensaje))
                    {
                        MessageBox.Show("No se puede filtrar:" + mensaje, "Validación de filtro avanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //Si no completó los campos obligatorios, pero sí alguno opcional, limpio los obligatorios
                        cbCampo.SelectedIndex = -1;
                        cbCriterio.SelectedIndex = -1;
                        txtFiltroAvanzado.Clear();
                        //Muestro la sugerencia de busqueda avanzada
                        MessageBox.Show(mensaje, "Sugerencias de filtro avanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //Si pasó las validaciones, obtengo los valores de los filtros obligatorios
                    campo = cbCampo.SelectedItem.ToString();
                    criterio = cbCriterio.SelectedItem.ToString();
                    filtro = txtFiltroAvanzado.Text.Trim().ToLower();
                }

                //instancio los filtros opcionales y los obtengo si fueron seleccionados
                Marca marca = null;
                if (cbMarca.SelectedIndex != -1)
                {
                    marca = (Marca)cbMarca.SelectedItem;
                }
                Categoria categoria = null;
                if (cbCategoria.SelectedIndex != -1)
                {
                    categoria = (Categoria)cbCategoria.SelectedItem;
                }

                //Llamo al negocio para que realice la búsqueda avanzada
                ArticulosNegocio negocio = new ArticulosNegocio();
                List<Articulo> listaFiltrada = negocio.BusquedaAvanzada(marca, categoria, campo, criterio, filtro);

                //Refresco la grilla con los resultados
                dataGridArticulos.DataSource = null;
                listaArticulos = null;
                listaArticulos = listaFiltrada;
                refrescarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los artículos. \n" + ex.Message);
                //Si hay error, recargo la lista original
                CargarArticulos();
            }
        }

        //Validaciones
        private bool ValidarFiltrosObligatorios(ref string mensaje)
        {
            
            try
            {
                if (cbCampo.SelectedIndex == -1)
                {
                    mensaje = "\nSeleccionar un campo para un filtro avanzado.";
                    return false;
                }
                if (cbCriterio.SelectedIndex == -1)
                {
                    mensaje += "\nSeleccionar un criterio para un filtro avanzado.";
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtFiltroAvanzado.Text))
                {
                    mensaje += "\nIngrese un valor para un filtro avanzado.";
                    return false;
                }
                mensaje = string.Empty;
                return true;
            }
            catch (Exception)
            {
                mensaje = "Error al validar el filtro avanzado.";
                return false;
            }
        }

        //Validar campos opcionales
        private bool validarFiltrosOpcionales(ref string mensaje)
        {
            try
            {
                mensaje += "\nSugerencia:";
                //Si se selecciona marca o categoría, no es obligatorio completar campo, criterio y valor
                //Pero se deja una sugerencia en caso que no ponga nada
                if (cbMarca.SelectedIndex != -1 || cbCategoria.SelectedIndex != -1)
                {
                    mensaje = "\nPara un mejor resultado en la búsqueda avanzada, complete campo, criterio y valor.";
                    return true;
                }
                mensaje += "\nPuede seleccionar una marca o categoría para filtrar ";
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Si el campo es numérico, validar que se ingresen solo números y el punto decimal
        private void txtFiltroAvanzado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cerrando)
                return;
            if (cbCampo.SelectedIndex == 0) //Campo Precio
            {
                if (!Validadores.EsCaracterDecimal(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }


        //Métodos Auxiliares
        private void LimpiarFiltroAvanzado()
        {
            try
            {
                cbCampo.SelectedIndex = -1;
                cbCriterio.SelectedIndex = -1;
                txtFiltroAvanzado.Clear();
                cbMarca.SelectedIndex = -1;
                cbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar el filtro avanzado. \n" + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            LimpiarFiltroAvanzado();
            Cargar();
        }

        private void ocultarColumnas(string columna)
        {
            try
            {
                dataGridArticulos.Columns[columna].Visible = false;
            } catch (Exception ex)
            {
                throw ex;
            }

        }

        //Esto es algo que aprendí con otros proyectos
        //Cuando hay eventos textChanged u otros que se disparan y el formulario se está cerrando a veces da error
        //Me pasó en la presentación final de las PP y lo solucioné con esta bandera
        private void CerrarFormulario()
        {
            cerrando = true;
            Close();
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            LimpiarFiltroAvanzado();
            Cargar();
        }
    }
}
