namespace CoffeeSoftCafe
{
    partial class FormHistorial
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
            txtBuscarCliente = new TextBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            btnRegresar = new Button();
            dgvFacturas = new DataGridView();
            dgvDetalle = new DataGridView();
            lblDetalleTitulo = new Label();
            lblSubtotal = new Label();
            lblIVA = new Label();
            lblTotal = new Label();
            lblSubtotalVal = new Label();
            lblIVAVal = new Label();
            lblTotalVal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label1.Location = new Point(220, 15);
            label1.Name = "label1";
            label1.Size = new Size(347, 28);
            label1.TabIndex = 18;
            label1.Text = "📋 HISTORIAL DE FACTURAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 65);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 17;
            label2.Text = "🔍 Buscar cliente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 65);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 15;
            label3.Text = "Desde:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(520, 65);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 13;
            label4.Text = "Hasta:";
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(160, 62);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.PlaceholderText = "Nombre del cliente...";
            txtBuscarCliente.Size = new Size(150, 27);
            txtBuscarCliente.TabIndex = 16;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(380, 62);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(130, 27);
            dtpDesde.TabIndex = 14;
            dtpDesde.Value = new DateTime(2026, 5, 18, 15, 23, 13, 103);
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(570, 62);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(130, 27);
            dtpHasta.TabIndex = 12;
            dtpHasta.Value = new DateTime(2026, 6, 18, 15, 23, 13, 104);
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(101, 67, 33);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(715, 60);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 32);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(715, 95);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 32);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "\U0001f9f9 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.FromArgb(101, 67, 33);
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(30, 605);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(130, 35);
            btnRegresar.TabIndex = 9;
            btnRegresar.Text = "⬅ Regresar";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.ColumnHeadersHeight = 29;
            dgvFacturas.Location = new Point(30, 141);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersWidth = 51;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(785, 164);
            dgvFacturas.TabIndex = 8;
            dgvFacturas.CellClick += dgvFacturas_CellClick;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeight = 29;
            dgvDetalle.Location = new Point(30, 345);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(785, 180);
            dgvDetalle.TabIndex = 7;
            // 
            // lblDetalleTitulo
            // 
            lblDetalleTitulo.AutoSize = true;
            lblDetalleTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetalleTitulo.ForeColor = Color.FromArgb(101, 67, 33);
            lblDetalleTitulo.Location = new Point(30, 318);
            lblDetalleTitulo.Name = "lblDetalleTitulo";
            lblDetalleTitulo.Size = new Size(312, 23);
            lblDetalleTitulo.TabIndex = 6;
            lblDetalleTitulo.Text = "📄 Detalle de la factura seleccionada:";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubtotal.Location = new Point(500, 538);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(84, 23);
            lblSubtotal.TabIndex = 5;
            lblSubtotal.Text = "Subtotal:";
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIVA.Location = new Point(500, 568);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(94, 23);
            lblIVA.TabIndex = 3;
            lblIVA.Text = "IVA (15%):";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(500, 600);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 28);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "TOTAL:";
            // 
            // lblSubtotalVal
            // 
            lblSubtotalVal.AutoSize = true;
            lblSubtotalVal.Font = new Font("Segoe UI", 10F);
            lblSubtotalVal.ForeColor = Color.FromArgb(101, 67, 33);
            lblSubtotalVal.Location = new Point(620, 538);
            lblSubtotalVal.Name = "lblSubtotalVal";
            lblSubtotalVal.Size = new Size(66, 23);
            lblSubtotalVal.TabIndex = 4;
            lblSubtotalVal.Text = "C$ 0.00";
            // 
            // lblIVAVal
            // 
            lblIVAVal.AutoSize = true;
            lblIVAVal.Font = new Font("Segoe UI", 10F);
            lblIVAVal.ForeColor = Color.FromArgb(101, 67, 33);
            lblIVAVal.Location = new Point(620, 568);
            lblIVAVal.Name = "lblIVAVal";
            lblIVAVal.Size = new Size(66, 23);
            lblIVAVal.TabIndex = 2;
            lblIVAVal.Text = "C$ 0.00";
            // 
            // lblTotalVal
            // 
            lblTotalVal.AutoSize = true;
            lblTotalVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalVal.ForeColor = Color.FromArgb(101, 67, 33);
            lblTotalVal.Location = new Point(620, 600);
            lblTotalVal.Name = "lblTotalVal";
            lblTotalVal.Size = new Size(83, 28);
            lblTotalVal.TabIndex = 0;
            lblTotalVal.Text = "C$ 0.00";
            // 
            // FormHistorial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(850, 660);
            Controls.Add(lblTotalVal);
            Controls.Add(lblTotal);
            Controls.Add(lblIVAVal);
            Controls.Add(lblIVA);
            Controls.Add(lblSubtotalVal);
            Controls.Add(lblSubtotal);
            Controls.Add(lblDetalleTitulo);
            Controls.Add(dgvDetalle);
            Controls.Add(dgvFacturas);
            Controls.Add(btnRegresar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(dtpHasta);
            Controls.Add(label4);
            Controls.Add(dtpDesde);
            Controls.Add(label3);
            Controls.Add(txtBuscarCliente);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormHistorial";
            Text = "Historial de Facturas - CoffeeSoftCafe";
            Load += FormHistorial_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblDetalleTitulo;
        private Label lblSubtotal;
        private Label lblIVA;
        private Label lblTotal;
        private Label lblSubtotalVal;
        private Label lblIVAVal;
        private Label lblTotalVal;
        private TextBox txtBuscarCliente;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private Button btnLimpiar;
        private Button btnRegresar;
        private DataGridView dgvFacturas;
        private DataGridView dgvDetalle;
    }
}