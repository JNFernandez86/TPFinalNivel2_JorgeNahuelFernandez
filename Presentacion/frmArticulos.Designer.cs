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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.pbxImagenArticulo = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rdbPrecio = new System.Windows.Forms.RadioButton();
            this.rdbDescripcion = new System.Windows.Forms.RadioButton();
            this.rdbNombre = new System.Windows.Forms.RadioButton();
            this.chbFiltroAvanzado = new System.Windows.Forms.CheckBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.gbxFiltroAvanzado = new System.Windows.Forms.GroupBox();
            this.lblCampo = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.gbxFiltroAvanzado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(13, 521);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(179, 37);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(202, 521);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(179, 37);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // pbxImagenArticulo
            // 
            this.pbxImagenArticulo.Location = new System.Drawing.Point(889, 199);
            this.pbxImagenArticulo.Name = "pbxImagenArticulo";
            this.pbxImagenArticulo.Size = new System.Drawing.Size(338, 313);
            this.pbxImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImagenArticulo.TabIndex = 3;
            this.pbxImagenArticulo.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(392, 522);
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
            this.lblBusqueda.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.Location = new System.Drawing.Point(8, 10);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(85, 27);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Buscar:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(87, 10);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(324, 35);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.AllowUserToResizeRows = false;
            this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvArticulos.ColumnHeadersHeight = 34;
            this.dgvArticulos.Location = new System.Drawing.Point(11, 199);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.RowHeadersWidth = 62;
            this.dgvArticulos.RowTemplate.Height = 28;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(856, 313);
            this.dgvArticulos.TabIndex = 6;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(77, 101);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(333, 34);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rdbPrecio
            // 
            this.rdbPrecio.AutoSize = true;
            this.rdbPrecio.Location = new System.Drawing.Point(6, 143);
            this.rdbPrecio.Name = "rdbPrecio";
            this.rdbPrecio.Size = new System.Drawing.Size(87, 26);
            this.rdbPrecio.TabIndex = 2;
            this.rdbPrecio.Text = "Precio";
            this.rdbPrecio.UseVisualStyleBackColor = true;
            // 
            // rdbDescripcion
            // 
            this.rdbDescripcion.AutoSize = true;
            this.rdbDescripcion.Location = new System.Drawing.Point(6, 112);
            this.rdbDescripcion.Name = "rdbDescripcion";
            this.rdbDescripcion.Size = new System.Drawing.Size(132, 26);
            this.rdbDescripcion.TabIndex = 1;
            this.rdbDescripcion.Text = "Descripción";
            this.rdbDescripcion.UseVisualStyleBackColor = true;
            // 
            // rdbNombre
            // 
            this.rdbNombre.AutoSize = true;
            this.rdbNombre.Location = new System.Drawing.Point(6, 79);
            this.rdbNombre.Name = "rdbNombre";
            this.rdbNombre.Size = new System.Drawing.Size(99, 26);
            this.rdbNombre.TabIndex = 0;
            this.rdbNombre.Text = "Nombre";
            this.rdbNombre.UseVisualStyleBackColor = true;
            this.rdbNombre.CheckedChanged += new System.EventHandler(this.rdbNombre_CheckedChanged);
            // 
            // chbFiltroAvanzado
            // 
            this.chbFiltroAvanzado.AutoSize = true;
            this.chbFiltroAvanzado.Location = new System.Drawing.Point(87, 52);
            this.chbFiltroAvanzado.Name = "chbFiltroAvanzado";
            this.chbFiltroAvanzado.Size = new System.Drawing.Size(195, 26);
            this.chbFiltroAvanzado.TabIndex = 7;
            this.chbFiltroAvanzado.Text = "Busqueda Avanzado";
            this.chbFiltroAvanzado.UseVisualStyleBackColor = true;
            this.chbFiltroAvanzado.CheckedChanged += new System.EventHandler(this.chbFiltroAvanzado_CheckedChanged);
            // 
            // cboCriterio
            // 
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(184, 79);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(156, 30);
            this.cboCriterio.TabIndex = 8;
            // 
            // gbxFiltroAvanzado
            // 
            this.gbxFiltroAvanzado.Controls.Add(this.lblCriterio);
            this.gbxFiltroAvanzado.Controls.Add(this.lblCampo);
            this.gbxFiltroAvanzado.Controls.Add(this.rdbNombre);
            this.gbxFiltroAvanzado.Controls.Add(this.rdbPrecio);
            this.gbxFiltroAvanzado.Controls.Add(this.rdbDescripcion);
            this.gbxFiltroAvanzado.Controls.Add(this.cboCriterio);
            this.gbxFiltroAvanzado.Location = new System.Drawing.Point(466, 10);
            this.gbxFiltroAvanzado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxFiltroAvanzado.Name = "gbxFiltroAvanzado";
            this.gbxFiltroAvanzado.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxFiltroAvanzado.Size = new System.Drawing.Size(401, 173);
            this.gbxFiltroAvanzado.TabIndex = 11;
            this.gbxFiltroAvanzado.TabStop = false;
            this.gbxFiltroAvanzado.Text = "Filtro Avanzado";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampo.Location = new System.Drawing.Point(19, 42);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(81, 27);
            this.lblCampo.TabIndex = 9;
            this.lblCampo.Text = "Campo";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriterio.Location = new System.Drawing.Point(179, 43);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(86, 27);
            this.lblCriterio.TabIndex = 10;
            this.lblCriterio.Text = "Criterio";
            // 
            // frmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 571);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.pbxImagenArticulo);
            this.Controls.Add(this.gbxFiltroAvanzado);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.chbFiltroAvanzado);
            this.Controls.Add(this.btnBuscar);
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
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.CheckBox chbFiltroAvanzado;
        private System.Windows.Forms.GroupBox gbxFiltroAvanzado;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblCampo;
    }
}

