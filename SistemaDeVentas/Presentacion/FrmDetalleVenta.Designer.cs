namespace SistemaDeVentas.Presentacion
{
    partial class FrmDetalleVenta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDatosNoEncontrados = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtProductoId = new System.Windows.Forms.TextBox();
            this.txtProductoDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVentaId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDatosNoEncontrados);
            this.groupBox1.Controls.Add(this.dgvVentas);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(547, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(703, 518);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Venta";
            // 
            // lblDatosNoEncontrados
            // 
            this.lblDatosNoEncontrados.AutoSize = true;
            this.lblDatosNoEncontrados.Location = new System.Drawing.Point(224, 217);
            this.lblDatosNoEncontrados.Name = "lblDatosNoEncontrados";
            this.lblDatosNoEncontrados.Size = new System.Drawing.Size(196, 18);
            this.lblDatosNoEncontrados.TabIndex = 3;
            this.lblDatosNoEncontrados.Text = "No se encontraron datos";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dgvVentas.Location = new System.Drawing.Point(5, 30);
            this.dgvVentas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 24;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(677, 366);
            this.dgvVentas.TabIndex = 0;
            this.dgvVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentas_CellContentClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Width = 125;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitar.Location = new System.Drawing.Point(17, 414);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(181, 39);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.Text = "Quitar Producto";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtProductoId);
            this.groupBox3.Controls.Add(this.txtProductoDescripcion);
            this.groupBox3.Controls.Add(this.txtPrecioUnitario);
            this.groupBox3.Controls.Add(this.txtCantidad);
            this.groupBox3.Controls.Add(this.cmbTipoDoc);
            this.groupBox3.Controls.Add(this.txtFecha);
            this.groupBox3.Controls.Add(this.btnBuscarProducto);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Controls.Add(this.txtNumeroDocumento);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtClienteNombre);
            this.groupBox3.Controls.Add(this.txtStock);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtClienteId);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtVentaId);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(15, 33);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(508, 518);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Ventas";
            // 
            // txtProductoId
            // 
            this.txtProductoId.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProductoId.Location = new System.Drawing.Point(151, 258);
            this.txtProductoId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProductoId.Name = "txtProductoId";
            this.txtProductoId.Size = new System.Drawing.Size(44, 24);
            this.txtProductoId.TabIndex = 12;
            // 
            // txtProductoDescripcion
            // 
            this.txtProductoDescripcion.Location = new System.Drawing.Point(203, 258);
            this.txtProductoDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductoDescripcion.Name = "txtProductoDescripcion";
            this.txtProductoDescripcion.Size = new System.Drawing.Size(180, 24);
            this.txtProductoDescripcion.TabIndex = 11;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(151, 356);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(81, 24);
            this.txtPrecioUnitario.TabIndex = 9;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(151, 309);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(83, 24);
            this.txtCantidad.TabIndex = 8;
            this.txtCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.Enabled = false;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Items.AddRange(new object[] {
            "Boleta",
            "Factura"});
            this.cmbTipoDoc.Location = new System.Drawing.Point(151, 159);
            this.cmbTipoDoc.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(232, 26);
            this.cmbTipoDoc.TabIndex = 7;
            this.cmbTipoDoc.Text = "Factura";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(151, 111);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(232, 24);
            this.txtFecha.TabIndex = 6;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscarProducto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscarProducto.Location = new System.Drawing.Point(405, 256);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(63, 28);
            this.btnBuscarProducto.TabIndex = 3;
            this.btnBuscarProducto.Text = "...";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(340, 414);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(159, 62);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Agregar Producto";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Enabled = false;
            this.txtNumeroDocumento.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumeroDocumento.Location = new System.Drawing.Point(151, 207);
            this.txtNumeroDocumento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(232, 24);
            this.txtNumeroDocumento.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Numero Doc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tipo doc";
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Enabled = false;
            this.txtClienteNombre.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtClienteNombre.Location = new System.Drawing.Point(203, 70);
            this.txtClienteNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(181, 24);
            this.txtClienteNombre.TabIndex = 1;
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtStock.Location = new System.Drawing.Point(315, 309);
            this.txtStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(71, 24);
            this.txtStock.TabIndex = 1;
            this.txtStock.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Fecha";
            // 
            // txtClienteId
            // 
            this.txtClienteId.Enabled = false;
            this.txtClienteId.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtClienteId.Location = new System.Drawing.Point(151, 70);
            this.txtClienteId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.Size = new System.Drawing.Size(45, 24);
            this.txtClienteId.TabIndex = 1;
            this.txtClienteId.TextChanged += new System.EventHandler(this.txtClienteId_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 356);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "Precio Unitario";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(253, 311);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 18);
            this.label15.TabIndex = 0;
            this.label15.Text = "Stock";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Cantidad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Producto";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Cliente";
            // 
            // txtVentaId
            // 
            this.txtVentaId.Enabled = false;
            this.txtVentaId.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtVentaId.Location = new System.Drawing.Point(153, 30);
            this.txtVentaId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVentaId.Name = "txtVentaId";
            this.txtVentaId.Size = new System.Drawing.Size(232, 24);
            this.txtVentaId.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "Venta Id";
            // 
            // FrmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1264, 578);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento De Detalle de Ventas";
            this.Load += new System.EventHandler(this.FrmDetalleVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDatosNoEncontrados;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.NumericUpDown txtCantidad;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClienteId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVentaId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtProductoDescripcion;
        private System.Windows.Forms.TextBox txtProductoId;
    }
}