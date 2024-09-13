namespace Presentacion
{
    partial class frmArticulos
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
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblCampo = new System.Windows.Forms.Label();
            this.rdbNombre = new System.Windows.Forms.RadioButton();
            this.rdbPrecio = new System.Windows.Forms.RadioButton();
            this.rdbDescripcion = new System.Windows.Forms.RadioButton();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.pbxImagenArticulo = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.chbFiltroAvanzado = new System.Windows.Forms.CheckBox();
            this.gbxFiltroAvanzado = new System.Windows.Forms.GroupBox();
            this.llbSalir = new System.Windows.Forms.LinkLabel();
            this.lblAyuda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.gbxFiltroAvanzado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriterio.Location = new System.Drawing.Point(157, 26);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(55, 19);
            this.lblCriterio.TabIndex = 10;
            this.lblCriterio.Text = "Criterio";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampo.Location = new System.Drawing.Point(7, 26);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(54, 19);
            this.lblCampo.TabIndex = 9;
            this.lblCampo.Text = "Campo";
            // 
            // rdbNombre
            // 
            this.rdbNombre.AutoSize = true;
            this.rdbNombre.Checked = true;
            this.rdbNombre.Location = new System.Drawing.Point(11, 62);
            this.rdbNombre.Name = "rdbNombre";
            this.rdbNombre.Size = new System.Drawing.Size(71, 20);
            this.rdbNombre.TabIndex = 1;
            this.rdbNombre.TabStop = true;
            this.rdbNombre.Text = "Nombre";
            this.rdbNombre.UseVisualStyleBackColor = true;
            this.rdbNombre.CheckedChanged += new System.EventHandler(this.rdbNombre_CheckedChanged);
            // 
            // rdbPrecio
            // 
            this.rdbPrecio.AutoSize = true;
            this.rdbPrecio.Location = new System.Drawing.Point(11, 126);
            this.rdbPrecio.Name = "rdbPrecio";
            this.rdbPrecio.Size = new System.Drawing.Size(61, 20);
            this.rdbPrecio.TabIndex = 3;
            this.rdbPrecio.Text = "Precio";
            this.rdbPrecio.UseVisualStyleBackColor = true;
            this.rdbPrecio.CheckedChanged += new System.EventHandler(this.rdbPrecio_CheckedChanged);
            // 
            // rdbDescripcion
            // 
            this.rdbDescripcion.AutoSize = true;
            this.rdbDescripcion.Location = new System.Drawing.Point(11, 95);
            this.rdbDescripcion.Name = "rdbDescripcion";
            this.rdbDescripcion.Size = new System.Drawing.Size(93, 20);
            this.rdbDescripcion.TabIndex = 2;
            this.rdbDescripcion.Text = "Descripción";
            this.rdbDescripcion.UseVisualStyleBackColor = true;
            this.rdbDescripcion.CheckedChanged += new System.EventHandler(this.rdbDescripcion_CheckedChanged);
            // 
            // cboCriterio
            // 
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(162, 62);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(195, 23);
            this.cboCriterio.TabIndex = 4;
            this.cboCriterio.Text = "Seleccione Criterio";
            this.cboCriterio.SelectedIndexChanged += new System.EventHandler(this.cboCriterio_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 610);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(179, 37);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(201, 610);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(179, 37);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // pbxImagenArticulo
            // 
            this.pbxImagenArticulo.Location = new System.Drawing.Point(981, 272);
            this.pbxImagenArticulo.Name = "pbxImagenArticulo";
            this.pbxImagenArticulo.Size = new System.Drawing.Size(246, 329);
            this.pbxImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImagenArticulo.TabIndex = 3;
            this.pbxImagenArticulo.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(391, 611);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(179, 35);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.Location = new System.Drawing.Point(12, 23);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(61, 19);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Buscar:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(11, 53);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(416, 26);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.EnabledChanged += new System.EventHandler(this.txtBusqueda_EnabledChanged);
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.AllowUserToResizeRows = false;
            this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvArticulos.ColumnHeadersHeight = 34;
            this.dgvArticulos.Location = new System.Drawing.Point(11, 272);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.RowHeadersWidth = 62;
            this.dgvArticulos.RowTemplate.Height = 28;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(964, 329);
            this.dgvArticulos.TabIndex = 11;
            this.dgvArticulos.TabStop = false;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // chbFiltroAvanzado
            // 
            this.chbFiltroAvanzado.AutoSize = true;
            this.chbFiltroAvanzado.Location = new System.Drawing.Point(433, 59);
            this.chbFiltroAvanzado.Name = "chbFiltroAvanzado";
            this.chbFiltroAvanzado.Size = new System.Drawing.Size(137, 20);
            this.chbFiltroAvanzado.TabIndex = 1;
            this.chbFiltroAvanzado.Text = "Busqueda Avanzado";
            this.chbFiltroAvanzado.UseVisualStyleBackColor = true;
            this.chbFiltroAvanzado.CheckedChanged += new System.EventHandler(this.chbFiltroAvanzado_CheckedChanged);
            // 
            // gbxFiltroAvanzado
            // 
            this.gbxFiltroAvanzado.Controls.Add(this.lblCampo);
            this.gbxFiltroAvanzado.Controls.Add(this.lblCriterio);
            this.gbxFiltroAvanzado.Controls.Add(this.cboCriterio);
            this.gbxFiltroAvanzado.Controls.Add(this.rdbDescripcion);
            this.gbxFiltroAvanzado.Controls.Add(this.rdbNombre);
            this.gbxFiltroAvanzado.Controls.Add(this.rdbPrecio);
            this.gbxFiltroAvanzado.Location = new System.Drawing.Point(11, 95);
            this.gbxFiltroAvanzado.Name = "gbxFiltroAvanzado";
            this.gbxFiltroAvanzado.Size = new System.Drawing.Size(361, 171);
            this.gbxFiltroAvanzado.TabIndex = 2;
            this.gbxFiltroAvanzado.TabStop = false;
            this.gbxFiltroAvanzado.Text = "Filtro Avanzado";
            // 
            // llbSalir
            // 
            this.llbSalir.ActiveLinkColor = System.Drawing.Color.LimeGreen;
            this.llbSalir.AutoSize = true;
            this.llbSalir.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbSalir.Location = new System.Drawing.Point(1152, 9);
            this.llbSalir.Name = "llbSalir";
            this.llbSalir.Size = new System.Drawing.Size(56, 25);
            this.llbSalir.TabIndex = 6;
            this.llbSalir.TabStop = true;
            this.llbSalir.Text = "Salir";
            this.llbSalir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSalir_LinkClicked);
            // 
            // lblAyuda
            // 
            this.lblAyuda.AutoSize = true;
            this.lblAyuda.Location = new System.Drawing.Point(388, 139);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(11, 16);
            this.lblAyuda.TabIndex = 12;
            this.lblAyuda.Text = " ";
            // 
            // frmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 661);
            this.ControlBox = false;
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.llbSalir);
            this.Controls.Add(this.gbxFiltroAvanzado);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.pbxImagenArticulo);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.chbFiltroAvanzado);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "frmArticulos";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artículos";
            this.Load += new System.EventHandler(this.frmArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.gbxFiltroAvanzado.ResumeLayout(false);
            this.gbxFiltroAvanzado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.PictureBox pbxImagenArticulo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.RadioButton rdbPrecio;
        private System.Windows.Forms.RadioButton rdbDescripcion;
        private System.Windows.Forms.RadioButton rdbNombre;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.CheckBox chbFiltroAvanzado;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.GroupBox gbxFiltroAvanzado;
        private System.Windows.Forms.LinkLabel llbSalir;
        private System.Windows.Forms.Label lblAyuda;
    }
}

