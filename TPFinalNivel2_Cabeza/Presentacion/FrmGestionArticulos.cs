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
        private bool cargando = true;
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
                FrmEditArticulos modificar = new FrmEditArticulos();
                modificar.setArticulo(seleccionado);
                modificar.ShowDialog();
                seleccionado = null;
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

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        //Eventos para Filtros rápidos
        private void txtDescipcion_TextChanged(object sender, EventArgs e)
        {
            if (cerrando)
                return;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (cerrando)
                return;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el artículo. \n" + ex.Message);
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

        private void CargarArticulos()
        {
            listaArticulos = null;
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                listaArticulos = negocio.Listar();
                dataGridArticulos.DataSource = listaArticulos;
                ocultarColumnas("Id");
                dataGridArticulos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridArticulos.Columns["Precio"].SortMode = DataGridViewColumnSortMode.Automatic;
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

        }

        private void BusquedaAvanzada()
        {

        }

        //Validaciones
        private bool ValidarFiltroAvanzado()
        {
            return true;
        }


        private void txtFiltroAvanzado_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        //Métodos Auxiliares
        private void LimpiarFiltroAvanzado()
        {

        }

        private void LimpiarCampos()
        {

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
        private void CerrarFormulario()
        {
            cerrando = true;
            Close();
        }

    }
}
