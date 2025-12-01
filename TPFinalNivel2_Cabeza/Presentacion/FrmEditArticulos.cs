using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmEditArticulos : Form
    {
        private Articulo articulo;
        private bool cerrando = false;
        private bool consultando = false;

        public FrmEditArticulos()
        {
            InitializeComponent();
        }

        //Carga del formulario
        private void FrmEditArticulos_Load(object sender, EventArgs e)
        {
            cargarFormulario();
        }

        //Método para traer un artículo desde otro formulario
        public void setArticulo(Articulo articulo)
        {
            this.articulo = articulo;
        }

        //Unificador de cargas
        public void cargarFormulario()
        {
            cargarCategorias();
            cargarMarcas();
            cargarArticulo();
            setVisibilidad();
        }

        //Visibilidad de botones según si es consulta o edicion
        public void setModoConsulta()
        {
            consultando = true;
        }

        private void setVisibilidad()
        {
            txtCodigo.Enabled = !consultando;
            txtNombre.Enabled = !consultando;
            txtDescripcion.Enabled = !consultando;
            txtPrecio.Enabled = !consultando;
            txtImagen.Enabled = !consultando;
            cbCategoria.Enabled = !consultando;
            cbMarca.Enabled = !consultando;
            btnImagen.Visible = !consultando;
            btnGuardar.Visible = !consultando;
        }

        //Método para cargar categorias
        private void cargarCategorias()
        {
            if (cerrando) return;
            List<Categoria> categorias = new List<Categoria>();
            CategoriasNegocio negocio = new CategoriasNegocio();
            try
            {
                categorias = negocio.Listar();
                cbCategoria.DataSource = null;
                cbCategoria.DataSource = categorias;
                cbCategoria.DisplayMember = "Descripcion";
                cbCategoria.ValueMember = "Id";
                cbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar las Categorias \n" + ex.ToString());
            }

        }

        //Método para cargar marcas
        private void cargarMarcas()
        {
            if (cerrando) return;
            List<Marca> marcas = new List<Marca>();
            MarcasNegocio negocio = new MarcasNegocio();
            try
            {
                marcas = negocio.Listar();
                cbMarca.DataSource = null;
                cbMarca.DataSource = marcas;
                cbMarca.DisplayMember = "Descripcion";
                cbMarca.ValueMember = "Id";
                cbMarca.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar las Marcas \n" + ex.ToString());
            }

        }

        //Método para cargar el artículo en el formulario
        private void cargarArticulo()
        {
            if (cerrando) return;
            try
            {
                if (articulo != null)
                {
                    this.Text = "Modificar Artículo";
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString("0.00");
                    txtImagen.Text = articulo.ImagenUrl;
                    cbCategoria.SelectedValue = articulo.Categoria.Id;
                    cbMarca.SelectedValue = articulo.Marca.Id;
                    cargarImagen(articulo.ImagenUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el artículo \n" + ex.ToString());
            }
        }

        //Eventos de botones
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea salir? Los cambios no guardados se perderán.", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
                return;
            cerrando = true;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            if (!validarCampos(sender, new CancelEventArgs(), ref mensaje))
            {
                MessageBox.Show($"Error al guardar el artículo.\n{mensaje}\nVERIFIQUE LOS ÍCONOS DE ERROR!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mensaje = string.Empty;
            if (articulo == null)
            {
                DialogResult respuesta = MessageBox.Show("¿Confirma que desea agregar el nuevo artículo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                    return;
                registrarArticulo(ref mensaje);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Confirma que desea modificar el artículo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                    return;
                modificarArticulo(ref mensaje);

            }
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                MessageBox.Show($"Error al guardar el artículo.\n{mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string accion = articulo.Id > 0 ? "Registrado" : "Modificado";
            DialogResult seguir = MessageBox.Show($"Artículo {accion} correctamente.\n¿Desea agregar un artículo nuevo?", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (seguir == DialogResult.Yes)
            {
                limpiarFormulario();
            }
            else
            {
                cerrando = true;
                Close();
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = HelperImagenes.SeleccionarImagen();
                if (!string.IsNullOrEmpty(ruta))
                {
                    txtImagen.Text = ruta;
                    validarImagen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la imagen \n" + ex.ToString());
            }
        }

        //Evento del textbox de imagen
        private void txtImagen_Leave(object sender, EventArgs e)
        {
            validarImagen();
        }

        //Método para limpiar el formulario
        private void limpiarFormulario()
        {
            if (cerrando) return;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtImagen.Clear();
            cbCategoria.SelectedIndex = -1;
            cbMarca.SelectedIndex = -1;
            pictureBoxImagen.Image = null;
            articulo = null;
            this.Text = "Nuevo Artículo";
        }

        //Validador de código existente
        private bool validarCodigoExistente(string codigo)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            try
            {
                Articulo existente = negocio.consultarRepetido(codigo);
                if (existente != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar código existente \n" + ex.ToString());
                return false;
            }
        }

        //Método para cargar imagen
        private void cargarImagen(string ruta)
        {
            if (cerrando) return;
            try
            {
                if (pictureBoxImagen.Image != null)
                {
                    pictureBoxImagen.Image.Dispose();
                    pictureBoxImagen.Image = null;
                }
                if (string.IsNullOrWhiteSpace(ruta))
                    pictureBoxImagen.Load(IconosImagenes.ImagenesPorDefecto["SinImagen"]);
                else if (ruta.StartsWith("http"))
                    pictureBoxImagen.Load(ruta);
                else
                {
                    //Acá me apoye en la IA para un método que me deje reemplazar la imagen si la quiere cambiar el usuario
                    // ya que Image.FromFile bloquea el archivo hasta que se cierra la aplicación igual que el Load
                    using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                    using (var imgTemp = Image.FromStream(fs))
                    {
                        // Clonamos para que no dependa del FileStream
                        pictureBoxImagen.Image = new Bitmap(imgTemp);
                    }

                }
            }
            catch (Exception)
            {
                try
                {
                    pictureBoxImagen.Load(IconosImagenes.ImagenesPorDefecto["ImagenError"]);
                }
                catch (Exception)
                {
                    pictureBoxImagen.Image = null;
                }

            }
        }

        //Método para validar la imagen
        private void validarImagen()
        {
            if (cerrando) return;
            string ruta = HelperImagenes.ObtenerImagenSeleccionada(txtImagen.Text);
            cargarImagen(ruta);
        }

        //Método para errores de texto vacio
        private void errorTextoVacio(object sender, CancelEventArgs e, TextBox campo, string nombreCampo)
        {
            try
            {
                errorProviderCampos.SetError(campo, $"El {nombreCampo} es obligatorio.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Validadores de Campos
        private bool validarCampos(object sender, CancelEventArgs e, ref string mensaje)
        {
            bool camposValidos = true;
            errorProviderCampos.Clear();
            mensaje = "Por favor, corrija los errores antes de ontinuar\n";
            //Código
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                errorTextoVacio(this, e, txtCodigo, "código");
                camposValidos = false;

            }

            //Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorTextoVacio(this, e, txtNombre, "nombre");
                camposValidos = false;
            }

            //Descripción
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorTextoVacio(this, e, txtDescripcion, "descripción");
                camposValidos = false;
            }

            //Precio
            if (!String.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                string precioTexto = txtPrecio.Text;
                if (!Validadores.EsNumeroDecimal(precioTexto))
                {
                    errorProviderCampos.SetError(txtPrecio, "El precio debe ser un número válido mayor a cero.");
                    camposValidos = false;
                    mensaje += "- Precio Incorrecto.\n";
                }
            }
            else
            {
                errorTextoVacio(this, e, txtPrecio, "precio");
                camposValidos = false;
            }

            //Categoría
            if (cbCategoria.SelectedIndex == -1)
            {
                errorProviderCampos.SetError(cbCategoria, "La categoría es obligatoria.");
                camposValidos = false;
            }

            //Marca
            if (cbMarca.SelectedIndex == -1)
            {
                errorProviderCampos.SetError(cbMarca, "La marca es obligatoria.");
                camposValidos = false;
            }


            if (!camposValidos)
            {
                mensaje += "- Campos incompletos.";
            }
            else
            {
                mensaje = string.Empty;
            }

            return camposValidos;
        }



        //método para copiar la imagen al disco
        private string copiarImagenAlDisco(string rutaOriginal)
        {
            if (cerrando) return string.Empty;
            if (String.IsNullOrWhiteSpace(articulo.ImagenUrl))
                return string.Empty;
            if (articulo.ImagenUrl.StartsWith("http"))
                return articulo.ImagenUrl;
            DialogResult respuesta = MessageBox.Show("¿Desea copiar la imagen al disco local? (si ya existe no se duplicará aun si confirma)", "Copiar Imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
                return articulo.ImagenUrl;
            try
            {
                string nuevaRuta = HelperImagenes.CopiarImagenSeleccionada(articulo.ImagenUrl, "img_" + articulo.Codigo);
                return nuevaRuta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al copiar la imagen al disco \n" + ex.ToString());
                return string.Empty;
            }
        }

        //Validador de campo numerico o control
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cerrando) return;
            e.Handled = !Validadores.EsCaracterDecimal(e.KeyChar);
        }

        //Método para cargar un artículo
        public void cargarDatosArticulo()
        {
            try
            {
                articulo.Codigo = txtCodigo.Text.Trim().ToUpper();
                articulo.Nombre = txtNombre.Text.Trim();
                articulo.Descripcion = txtDescripcion.Text.Trim();
                articulo.Precio = decimal.Parse(txtPrecio.Text.Trim());
                articulo.ImagenUrl = txtImagen.Text.Trim();
                articulo.Categoria = (Categoria)cbCategoria.SelectedItem;
                articulo.Marca = (Marca)cbMarca.SelectedItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Validar Artículo existente
        private bool validarArticuloExistente()
        {
            if (cerrando) return false;
            try
            {
                if (articulo == null)
                    return validarCodigoExistente(txtCodigo.Text.Trim());
                else
                {
                    if (articulo.Codigo != txtCodigo.Text.Trim().ToUpper())
                        return validarCodigoExistente(txtCodigo.Text.Trim().ToUpper());
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar artículo existente \n" + ex.ToString());
                return false;
            }
        }

        //Método de registrod del artículo
        private void registrarArticulo(ref string mensaje)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                cargarDatosArticulo();

                if (validarArticuloExistente())
                {
                    mensaje = "El código del artículo ya existe. Por favor, ingrese un código diferente.";
                    return;
                }
                if (!string.IsNullOrWhiteSpace(articulo.ImagenUrl))
                {
                    string nuevaRuta = copiarImagenAlDisco(articulo.ImagenUrl);
                    if (!string.IsNullOrWhiteSpace(nuevaRuta))
                        articulo.ImagenUrl = nuevaRuta;
                }
                negocio.Agregar(articulo);
                
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
        }

        //Método para modificar el artículo
        private void modificarArticulo(ref string mensaje)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            try
            {
                if (validarArticuloExistente())
                {
                    mensaje = "El código del artículo ya existe. Por favor, ingrese un código diferente.";
                    return;
                }
                cargarDatosArticulo();
                if (!string.IsNullOrWhiteSpace(articulo.ImagenUrl))
                {
                    string nuevaRuta = copiarImagenAlDisco(articulo.ImagenUrl);
                    if (!string.IsNullOrWhiteSpace(nuevaRuta))
                        articulo.ImagenUrl = nuevaRuta;
                }
                negocio.Modificar(articulo);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
        }
    }
}
