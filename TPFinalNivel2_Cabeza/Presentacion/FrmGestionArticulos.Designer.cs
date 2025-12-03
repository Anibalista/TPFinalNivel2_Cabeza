namespace Presentacion
{
    partial class FrmGestionArticulos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxBotones = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dataGridArticulos = new System.Windows.Forms.DataGridView();
            this.picBoxImagen = new System.Windows.Forms.PictureBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiarFiltro = new System.Windows.Forms.Button();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cbCampo = new System.Windows.Forms.ComboBox();
            this.lblCampo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.lblRutaImagen = new System.Windows.Forms.Label();
            this.groupBoxImagen = new System.Windows.Forms.GroupBox();
            this.groupBoxBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImagen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxImagen.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBotones
            // 
            this.groupBoxBotones.Controls.Add(this.btnEliminar);
            this.groupBoxBotones.Controls.Add(this.btnConsultar);
            this.groupBoxBotones.Controls.Add(this.btnSalir);
            this.groupBoxBotones.Controls.Add(this.btnInsertar);
            this.groupBoxBotones.Controls.Add(this.btnModificar);
            this.groupBoxBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxBotones.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBotones.Location = new System.Drawing.Point(0, 568);
            this.groupBoxBotones.Name = "groupBoxBotones";
            this.groupBoxBotones.Size = new System.Drawing.Size(1069, 86);
            this.groupBoxBotones.TabIndex = 0;
            this.groupBoxBotones.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnEliminar.Location = new System.Drawing.Point(531, 19);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(169, 56);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConsultar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnConsultar.Location = new System.Drawing.Point(356, 19);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(169, 56);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Ver Detalles";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSalir.Location = new System.Drawing.Point(892, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(163, 56);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir ";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsertar.BackColor = System.Drawing.Color.YellowGreen;
            this.btnInsertar.Location = new System.Drawing.Point(6, 19);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(169, 56);
            this.btnInsertar.TabIndex = 0;
            this.btnInsertar.Text = "Nuevo";
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModificar.BackColor = System.Drawing.Color.Goldenrod;
            this.btnModificar.Location = new System.Drawing.Point(181, 19);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(169, 56);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dataGridArticulos
            // 
            this.dataGridArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridArticulos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridArticulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridArticulos.Location = new System.Drawing.Point(6, 68);
            this.dataGridArticulos.MultiSelect = false;
            this.dataGridArticulos.Name = "dataGridArticulos";
            this.dataGridArticulos.RowHeadersVisible = false;
            this.dataGridArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridArticulos.Size = new System.Drawing.Size(694, 505);
            this.dataGridArticulos.TabIndex = 1;
            this.dataGridArticulos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridArticulos_CellFormatting);
            this.dataGridArticulos.SelectionChanged += new System.EventHandler(this.dataGridArticulos_SelectionChanged);
            // 
            // picBoxImagen
            // 
            this.picBoxImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxImagen.Location = new System.Drawing.Point(3, 23);
            this.picBoxImagen.Name = "picBoxImagen";
            this.picBoxImagen.Size = new System.Drawing.Size(343, 220);
            this.picBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxImagen.TabIndex = 2;
            this.picBoxImagen.TabStop = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(93, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(128, 27);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 50);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro Rápido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(269, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 19);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(339, 17);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(349, 27);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtDescipcion_TextChanged);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(29, 23);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(58, 19);
            this.lblCodigo.TabIndex = 5;
            this.lblCodigo.Text = "Código:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimpiarFiltro);
            this.groupBox2.Controls.Add(this.cbCategoria);
            this.groupBox2.Controls.Add(this.lblCategoria);
            this.groupBox2.Controls.Add(this.cbMarca);
            this.groupBox2.Controls.Add(this.lblMarca);
            this.groupBox2.Controls.Add(this.cbCriterio);
            this.groupBox2.Controls.Add(this.lblCriterio);
            this.groupBox2.Controls.Add(this.cbCampo);
            this.groupBox2.Controls.Add(this.lblCampo);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.lblValor);
            this.groupBox2.Controls.Add(this.txtFiltroAvanzado);
            this.groupBox2.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(706, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 264);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Búsqueda Avanzada";
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiarFiltro.BackColor = System.Drawing.Color.Goldenrod;
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(184, 220);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(157, 38);
            this.btnLimpiarFiltro.TabIndex = 6;
            this.btnLimpiarFiltro.Text = "Limpiar Filtro";
            this.btnLimpiarFiltro.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(90, 177);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(253, 27);
            this.cbCategoria.TabIndex = 4;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(8, 180);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(80, 19);
            this.lblCategoria.TabIndex = 14;
            this.lblCategoria.Text = "Categoría: ";
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(90, 137);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(253, 27);
            this.cbMarca.TabIndex = 3;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(30, 140);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(57, 19);
            this.lblMarca.TabIndex = 12;
            this.lblMarca.Text = "Marca: ";
            // 
            // cbCriterio
            // 
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.Enabled = false;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(90, 61);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(253, 27);
            this.cbCriterio.TabIndex = 1;
            this.cbCriterio.SelectedIndexChanged += new System.EventHandler(this.cbCriterio_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(25, 64);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(65, 19);
            this.lblCriterio.TabIndex = 10;
            this.lblCriterio.Text = "Criterio: ";
            // 
            // cbCampo
            // 
            this.cbCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo.FormattingEnabled = true;
            this.cbCampo.Location = new System.Drawing.Point(90, 23);
            this.cbCampo.Name = "cbCampo";
            this.cbCampo.Size = new System.Drawing.Size(253, 27);
            this.cbCampo.TabIndex = 0;
            this.cbCampo.SelectedIndexChanged += new System.EventHandler(this.cbCampo_SelectedIndexChanged);
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(6, 26);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(86, 19);
            this.lblCampo.TabIndex = 8;
            this.lblCampo.Text = "Buscar por: ";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBuscar.Location = new System.Drawing.Point(6, 220);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(157, 38);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar en Catálogo";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(36, 102);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(47, 19);
            this.lblValor.TabIndex = 7;
            this.lblValor.Text = "Valor:";
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Enabled = false;
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(90, 99);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(253, 27);
            this.txtFiltroAvanzado.TabIndex = 2;
            this.txtFiltroAvanzado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroAvanzado_KeyPress);
            // 
            // lblRutaImagen
            // 
            this.lblRutaImagen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRutaImagen.AutoSize = true;
            this.lblRutaImagen.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaImagen.Location = new System.Drawing.Point(709, 529);
            this.lblRutaImagen.Name = "lblRutaImagen";
            this.lblRutaImagen.Size = new System.Drawing.Size(99, 15);
            this.lblRutaImagen.TabIndex = 8;
            this.lblRutaImagen.Text = "Ruta de la Imagen";
            // 
            // groupBoxImagen
            // 
            this.groupBoxImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImagen.Controls.Add(this.picBoxImagen);
            this.groupBoxImagen.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxImagen.Location = new System.Drawing.Point(706, 283);
            this.groupBoxImagen.Name = "groupBoxImagen";
            this.groupBoxImagen.Size = new System.Drawing.Size(349, 246);
            this.groupBoxImagen.TabIndex = 8;
            this.groupBoxImagen.TabStop = false;
            this.groupBoxImagen.Text = "Imagen del Artículo";
            // 
            // FrmGestionArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 654);
            this.Controls.Add(this.lblRutaImagen);
            this.Controls.Add(this.groupBoxImagen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridArticulos);
            this.Controls.Add(this.groupBoxBotones);
            this.MinimumSize = new System.Drawing.Size(1085, 661);
            this.Name = "FrmGestionArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Artículos";
            this.Load += new System.EventHandler(this.FrmGestionArticulos_Load);
            this.groupBoxBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImagen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxImagen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBotones;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dataGridArticulos;
        private System.Windows.Forms.PictureBox picBoxImagen;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.ComboBox cbCampo;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnLimpiarFiltro;
        private System.Windows.Forms.Label lblRutaImagen;
        private System.Windows.Forms.GroupBox groupBoxImagen;
    }
}

