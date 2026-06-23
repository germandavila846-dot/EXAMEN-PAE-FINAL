namespace CoffeeSoftCafe
{
    partial class FormFacturacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblSubtotal = new Label();
            lblIVA = new Label();
            lblTotal = new Label();
            lblSubtotalVal = new Label();
            lblIVAVal = new Label();
            lblTotalVal = new Label();
            cboCliente = new ComboBox();
            cboProducto = new ComboBox();
            cboMetodoPago = new ComboBox();
            txtCantidad = new TextBox();
            txtNumFactura = new TextBox();
            txtFecha = new TextBox();
            btnAgregar = new Button();
            btnQuitarLinea = new Button();
            btnGuardar = new Button();
            btnNueva = new Button();
            btnRegresar = new Button();
            dgvDetalle = new DataGridView();
            lblCantidad = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label1.Location = new Point(220, 15);
            label1.Name = "label1";
            label1.Size = new Size(224, 28);
            label1.TabIndex = 24;
            label1.Text = "\U0001f9fe FACTURACIÓN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 65);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 23;
            label2.Text = "N° Factura:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 105);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 21;
            label3.Text = "Fecha:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(350, 65);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 19;
            label4.Text = "Cliente:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(350, 105);
            label5.Name = "label5";
            label5.Size = new Size(123, 20);
            label5.TabIndex = 17;
            label5.Text = "Método de Pago:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(67, 142);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 15;
            label6.Text = "Producto:";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubtotal.Location = new Point(500, 415);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(84, 23);
            lblSubtotal.TabIndex = 6;
            lblSubtotal.Text = "Subtotal:";
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIVA.Location = new Point(500, 448);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(94, 23);
            lblIVA.TabIndex = 4;
            lblIVA.Text = "IVA (15%):";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(500, 485);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 28);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "TOTAL:";
            // 
            // lblSubtotalVal
            // 
            lblSubtotalVal.AutoSize = true;
            lblSubtotalVal.Font = new Font("Segoe UI", 10F);
            lblSubtotalVal.ForeColor = Color.FromArgb(101, 67, 33);
            lblSubtotalVal.Location = new Point(610, 415);
            lblSubtotalVal.Name = "lblSubtotalVal";
            lblSubtotalVal.Size = new Size(66, 23);
            lblSubtotalVal.TabIndex = 5;
            lblSubtotalVal.Text = "C$ 0.00";
            // 
            // lblIVAVal
            // 
            lblIVAVal.AutoSize = true;
            lblIVAVal.Font = new Font("Segoe UI", 10F);
            lblIVAVal.ForeColor = Color.FromArgb(101, 67, 33);
            lblIVAVal.Location = new Point(610, 448);
            lblIVAVal.Name = "lblIVAVal";
            lblIVAVal.Size = new Size(66, 23);
            lblIVAVal.TabIndex = 3;
            lblIVAVal.Text = "C$ 0.00";
            // 
            // lblTotalVal
            // 
            lblTotalVal.AutoSize = true;
            lblTotalVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalVal.ForeColor = Color.FromArgb(101, 67, 33);
            lblTotalVal.Location = new Point(610, 485);
            lblTotalVal.Name = "lblTotalVal";
            lblTotalVal.Size = new Size(83, 28);
            lblTotalVal.TabIndex = 1;
            lblTotalVal.Text = "C$ 0.00";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(470, 62);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(280, 28);
            cboCliente.TabIndex = 18;
            // 
            // cboProducto
            // 
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProducto.FormattingEnabled = true;
            cboProducto.Location = new Point(118, 166);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(300, 28);
            cboProducto.TabIndex = 14;
            cboProducto.SelectedIndexChanged += cboProducto_SelectedIndexChanged;
            // 
            // cboMetodoPago
            // 
            cboMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetodoPago.FormattingEnabled = true;
            cboMetodoPago.Location = new Point(470, 102);
            cboMetodoPago.Name = "cboMetodoPago";
            cboMetodoPago.Size = new Size(280, 28);
            cboMetodoPago.TabIndex = 16;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(549, 152);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(60, 27);
            txtCantidad.TabIndex = 13;
            txtCantidad.Text = "1";
            txtCantidad.KeyPress += txtCantidad_KeyPress;
            // 
            // txtNumFactura
            // 
            txtNumFactura.BackColor = Color.FromArgb(230, 230, 230);
            txtNumFactura.Enabled = false;
            txtNumFactura.Location = new Point(130, 62);
            txtNumFactura.Name = "txtNumFactura";
            txtNumFactura.Size = new Size(150, 27);
            txtNumFactura.TabIndex = 22;
            // 
            // txtFecha
            // 
            txtFecha.BackColor = Color.FromArgb(230, 230, 230);
            txtFecha.Enabled = false;
            txtFecha.Location = new Point(130, 102);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(150, 27);
            txtFecha.TabIndex = 20;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(626, 152);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 32);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnQuitarLinea
            // 
            btnQuitarLinea.Location = new Point(30, 415);
            btnQuitarLinea.Name = "btnQuitarLinea";
            btnQuitarLinea.Size = new Size(130, 32);
            btnQuitarLinea.TabIndex = 10;
            btnQuitarLinea.Text = "🗑 Quitar línea";
            btnQuitarLinea.UseVisualStyleBackColor = true;
            btnQuitarLinea.Click += btnQuitarLinea_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(101, 67, 33);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 520);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 35);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNueva
            // 
            btnNueva.Location = new Point(175, 520);
            btnNueva.Name = "btnNueva";
            btnNueva.Size = new Size(130, 35);
            btnNueva.TabIndex = 8;
            btnNueva.Text = "\U0001f9fe Nueva";
            btnNueva.UseVisualStyleBackColor = true;
            btnNueva.Click += btnNueva_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.FromArgb(150, 100, 50);
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(320, 520);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(130, 35);
            btnRegresar.TabIndex = 7;
            btnRegresar.Text = "⬅ Regresar";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeight = 29;
            dgvDetalle.Location = new Point(30, 212);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(730, 188);
            dgvDetalle.TabIndex = 11;
           // dgvDetalle.CellContentClick += dgvDetalle_CellContentClick;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(469, 155);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(72, 20);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad:";
            // 
            // FormFacturacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(800, 580);
            Controls.Add(lblCantidad);
            Controls.Add(lblTotalVal);
            Controls.Add(lblTotal);
            Controls.Add(lblIVAVal);
            Controls.Add(lblIVA);
            Controls.Add(lblSubtotalVal);
            Controls.Add(lblSubtotal);
            Controls.Add(btnRegresar);
            Controls.Add(btnNueva);
            Controls.Add(btnGuardar);
            Controls.Add(btnQuitarLinea);
            Controls.Add(dgvDetalle);
            Controls.Add(btnAgregar);
            Controls.Add(txtCantidad);
            Controls.Add(cboProducto);
            Controls.Add(label6);
            Controls.Add(cboMetodoPago);
            Controls.Add(label5);
            Controls.Add(cboCliente);
            Controls.Add(label4);
            Controls.Add(txtFecha);
            Controls.Add(label3);
            Controls.Add(txtNumFactura);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormFacturacion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Facturación - CoffeeSoftCafe";
            Load += FormFacturacion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblSubtotal;
        private Label lblIVA;
        private Label lblTotal;
        private Label lblSubtotalVal;
        private Label lblIVAVal;
        private Label lblTotalVal;
        private ComboBox cboCliente;
        private ComboBox cboProducto;
        private ComboBox cboMetodoPago;
        private TextBox txtCantidad;
        private TextBox txtNumFactura;
        private TextBox txtFecha;
        private Button btnAgregar;
        private Button btnQuitarLinea;
        private Button btnGuardar;
        private Button btnNueva;
        private Button btnRegresar;
        private DataGridView dgvDetalle;
        private Label lblCantidad;
    }
}