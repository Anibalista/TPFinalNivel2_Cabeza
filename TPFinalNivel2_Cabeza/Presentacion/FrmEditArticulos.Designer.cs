namespace Presentacion
{
    partial class FrmEditArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.groupBoxCampos = new System.Windows.Forms.GroupBox();
            this.lblPesos = new System.Windows.Forms.Label();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblMrca = new System.Windows.Forms.Label();
            this.txtImagen = new System.Windows.Forms.TextBox();
            this.lblImagen = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pictureBoxImagen = new System.Windows.Forms.PictureBox();
            this.groupBoxImagen = new System.Windows.Forms.GroupBox();
            this.btnImagen = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBoxBotones = new System.Windows.Forms.GroupBox();
            this.errorProviderCampos = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).BeginInit();
            this.groupBoxImagen.SuspendLayout();
            this.groupBoxBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCampos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(27, 37);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(54, 18);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // groupBoxCampos
            // 
            this.groupBoxCampos.Controls.Add(this.lblPesos);
            this.groupBoxCampos.Controls.Add(this.cbMarca);
            this.groupBoxCampos.Controls.Add(this.cbCategoria);
            this.groupBoxCampos.Controls.Add(this.lblCategoria);
            this.groupBoxCampos.Controls.Add(this.lblMrca);
            this.groupBoxCampos.Controls.Add(this.txtImagen);
            this.groupBoxCampos.Controls.Add(this.lblImagen);
            this.groupBoxCampos.Controls.Add(this.txtPrecio);
            this.groupBoxCampos.Controls.Add(this.lblPrecio);
            this.groupBoxCampos.Controls.Add(this.txtDescripcion);
            this.groupBoxCampos.Controls.Add(this.lblDescripcion);
            this.groupBoxCampos.Controls.Add(this.txtNombre);
            this.groupBoxCampos.Controls.Add(this.lblNombre);
            this.groupBoxCampos.Controls.Add(this.txtCodigo);
            this.groupBoxCampos.Controls.Add(this.lblCodigo);
            this.groupBoxCampos.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxCampos.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCampos.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCampos.Name = "groupBoxCampos";
            this.groupBoxCampos.Size = new System.Drawing.Size(479, 474);
            this.groupBoxCampos.TabIndex = 1;
            this.groupBoxCampos.TabStop = false;
            this.groupBoxCampos.Text = "Detalles del Artículo";
            // 
            // lblPesos
            // 
            this.lblPesos.AutoSize = true;
            this.lblPesos.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesos.Location = new System.Drawing.Point(84, 217);
            this.lblPesos.Name = "lblPesos";
            this.lblPesos.Size = new System.Drawing.Size(15, 18);
            this.lblPesos.TabIndex = 16;
            this.lblPesos.Text = "$";
            // 
            // cbMarca
            // 
            this.cbMarca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(88, 342);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(363, 26);
            this.cbMarca.TabIndex = 5;
            // 
            // cbCategoria
            // 
            this.cbCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(88, 406);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(363, 26);
            this.cbCategoria.TabIndex = 6;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(8, 409);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(71, 18);
            this.lblCategoria.TabIndex = 13;
            this.lblCategoria.Text = "Categoría:";
            // 
            // lblMrca
            // 
            this.lblMrca.AutoSize = true;
            this.lblMrca.Location = new System.Drawing.Point(27, 345);
            this.lblMrca.Name = "lblMrca";
            this.lblMrca.Size = new System.Drawing.Size(49, 18);
            this.lblMrca.TabIndex = 12;
            this.lblMrca.Text = "Marca:";
            // 
            // txtImagen
            // 
            this.txtImagen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagen.Location = new System.Drawing.Point(88, 279);
            this.txtImagen.MaxLength = 990;
            this.txtImagen.Name = "txtImagen";
            this.txtImagen.Size = new System.Drawing.Size(363, 26);
            this.txtImagen.TabIndex = 4;
            this.txtImagen.Leave += new System.EventHandler(this.txtImagen_Leave);
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Location = new System.Drawing.Point(22, 282);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(56, 18);
            this.lblImagen.TabIndex = 10;
            this.lblImagen.Text = "Imagen:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecio.Location = new System.Drawing.Point(102, 214);
            this.txtPrecio.MaxLength = 29;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(349, 26);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(27, 217);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(51, 18);
            this.lblPrecio.TabIndex = 6;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Location = new System.Drawing.Point(88, 155);
            this.txtDescripcion.MaxLength = 149;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(363, 26);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(1, 158);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(82, 18);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(88, 91);
            this.txtNombre.MaxLength = 49;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(363, 26);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 94);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 18);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Location = new System.Drawing.Point(90, 34);
            this.txtCodigo.MaxLength = 49;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(361, 26);
            this.txtCodigo.TabIndex = 0;
            // 
            // pictureBoxImagen
            // 
            this.pictureBoxImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImagen.Location = new System.Drawing.Point(25, 26);
            this.pictureBoxImagen.Name = "pictureBoxImagen";
            this.pictureBoxImagen.Size = new System.Drawing.Size(287, 254);
            this.pictureBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImagen.TabIndex = 2;
            this.pictureBoxImagen.TabStop = false;
            // 
            // groupBoxImagen
            // 
            this.groupBoxImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImagen.Controls.Add(this.btnImagen);
            this.groupBoxImagen.Controls.Add(this.pictureBoxImagen);
            this.groupBoxImagen.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxImagen.Location = new System.Drawing.Point(485, 8);
            this.groupBoxImagen.Name = "groupBoxImagen";
            this.groupBoxImagen.Size = new System.Drawing.Size(332, 337);
            this.groupBoxImagen.TabIndex = 3;
            this.groupBoxImagen.TabStop = false;
            this.groupBoxImagen.Text = "Imagen del Artículo";
            // 
            // btnImagen
            // 
            this.btnImagen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImagen.Location = new System.Drawing.Point(52, 286);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(229, 45);
            this.btnImagen.TabIndex = 0;
            this.btnImagen.Text = "Cargar Imagen";
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSalir.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSalir.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(186, 28);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 63);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnGuardar.BackColor = System.Drawing.Color.Lime;
            this.btnGuardar.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(6, 28);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(142, 63);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBoxBotones
            // 
            this.groupBoxBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBotones.Controls.Add(this.btnGuardar);
            this.groupBoxBotones.Controls.Add(this.btnSalir);
            this.groupBoxBotones.Location = new System.Drawing.Point(485, 351);
            this.groupBoxBotones.Name = "groupBoxBotones";
            this.groupBoxBotones.Size = new System.Drawing.Size(332, 111);
            this.groupBoxBotones.TabIndex = 4;
            this.groupBoxBotones.TabStop = false;
            // 
            // errorProviderCampos
            // 
            this.errorProviderCampos.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCampos.ContainerControl = this;
            // 
            // FrmEditArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 474);
            this.Controls.Add(this.groupBoxBotones);
            this.Controls.Add(this.groupBoxImagen);
            this.Controls.Add(this.groupBoxCampos);
            this.MinimumSize = new System.Drawing.Size(839, 513);
            this.Name = "FrmEditArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Artículo";
            this.Load += new System.EventHandler(this.FrmEditArticulos_Load);
            this.groupBoxCampos.ResumeLayout(false);
            this.groupBoxCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).EndInit();
            this.groupBoxImagen.ResumeLayout(false);
            this.groupBoxBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCampos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox groupBoxCampos;
        private System.Windows.Forms.PictureBox pictureBoxImagen;
        private System.Windows.Forms.GroupBox groupBoxImagen;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtImagen;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblMrca;
        private System.Windows.Forms.GroupBox groupBoxBotones;
        private System.Windows.Forms.Label lblPesos;
        private System.Windows.Forms.ErrorProvider errorProviderCampos;
    }
}