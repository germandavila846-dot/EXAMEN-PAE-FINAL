namespace CoffeeSoftCafe
{
    partial class FormReportes
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
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            cboTipoReporte = new ComboBox();
            btnGenerar = new Button();
            btnExportarPDF = new Button();
            btnExportarExcel = new Button();
            btnRegresar = new Button();
            dgvReporte = new DataGridView();
            lblResumen = new Label();
            lblTotalFacturas = new Label();
            lblTotalIngresos = new Label();
            lblTotalIVA = new Label();
            lblTotalFacturasVal = new Label();
            lblTotalIngresosVal = new Label();
            lblTotalIVAVal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();

            // ── label1 Título ────────────────────────────────────
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 13.8F, FontStyle.Bold);
            label1.Location = new Point(230, 15);
            label1.Name = "label1";
            label1.Text = "📊 REPORTES";

            // ── label2 Tipo Reporte ──────────────────────────────
            label2.AutoSize = true;
            label2.Location = new Point(30, 65);
            label2.Name = "label2";
            label2.Text = "Tipo de Reporte:";

            // ── label3 Desde ─────────────────────────────────────
            label3.AutoSize = true;
            label3.Location = new Point(370, 65);
            label3.Name = "label3";
            label3.Text = "Desde:";

            // ── label4 Hasta ─────────────────────────────────────
            label4.AutoSize = true;
            label4.Location = new Point(560, 65);
            label4.Name = "label4";
            label4.Text = "Hasta:";

            // ── cboTipoReporte ───────────────────────────────────
            cboTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoReporte.FormattingEnabled = true;
            cboTipoReporte.Location = new Point(160, 62);
            cboTipoReporte.Name = "cboTipoReporte";
            cboTipoReporte.Size = new Size(190, 28);
            cboTipoReporte.Items.AddRange(new string[]
            {
                "Ventas por Fecha",
                "Productos Más Vendidos",
                "Ingresos por Método de Pago"
            });
            cboTipoReporte.SelectedIndex = 0;

            // ── dtpDesde ─────────────────────────────────────────
            dtpDesde.Location = new Point(420, 62);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(130, 27);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);

            // ── dtpHasta ─────────────────────────────────────────
            dtpHasta.Location = new Point(610, 62);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(130, 27);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Value = DateTime.Now;

            // ── btnGenerar ───────────────────────────────────────
            btnGenerar.Location = new Point(755, 60);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(110, 32);
            btnGenerar.Text = "📊 Generar";
            btnGenerar.BackColor = Color.FromArgb(101, 67, 33);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += new EventHandler(this.btnGenerar_Click);

            // ── dgvReporte ───────────────────────────────────────
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.ReadOnly = true;
            dgvReporte.Location = new Point(30, 110);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(835, 300);
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ── lblResumen ───────────────────────────────────────
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResumen.Location = new Point(30, 425);
            lblResumen.Name = "lblResumen";
            lblResumen.Text = "📋 Resumen del período:";
            lblResumen.ForeColor = Color.FromArgb(101, 67, 33);

            // ── lblTotalFacturas ─────────────────────────────────
            lblTotalFacturas.AutoSize = true;
            lblTotalFacturas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalFacturas.Location = new Point(30, 460);
            lblTotalFacturas.Text = "Total Facturas:";

            lblTotalFacturasVal.AutoSize = true;
            lblTotalFacturasVal.Font = new Font("Segoe UI", 10F);
            lblTotalFacturasVal.Location = new Point(180, 460);
            lblTotalFacturasVal.Name = "lblTotalFacturasVal";
            lblTotalFacturasVal.Text = "0";
            lblTotalFacturasVal.ForeColor = Color.FromArgb(101, 67, 33);

            // ── lblTotalIVA ──────────────────────────────────────
            lblTotalIVA.AutoSize = true;
            lblTotalIVA.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalIVA.Location = new Point(350, 460);
            lblTotalIVA.Text = "Total IVA:";

            lblTotalIVAVal.AutoSize = true;
            lblTotalIVAVal.Font = new Font("Segoe UI", 10F);
            lblTotalIVAVal.Location = new Point(460, 460);
            lblTotalIVAVal.Name = "lblTotalIVAVal";
            lblTotalIVAVal.Text = "C$ 0.00";
            lblTotalIVAVal.ForeColor = Color.FromArgb(101, 67, 33);

            // ── lblTotalIngresos ─────────────────────────────────
            lblTotalIngresos.AutoSize = true;
            lblTotalIngresos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalIngresos.Location = new Point(600, 455);
            lblTotalIngresos.Text = "TOTAL INGRESOS:";

            lblTotalIngresosVal.AutoSize = true;
            lblTotalIngresosVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalIngresosVal.Location = new Point(600, 480);
            lblTotalIngresosVal.Name = "lblTotalIngresosVal";
            lblTotalIngresosVal.Text = "C$ 0.00";
            lblTotalIngresosVal.ForeColor = Color.FromArgb(101, 67, 33);

            // ── btnExportarPDF ───────────────────────────────────
            btnExportarPDF.Location = new Point(30, 520);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(150, 35);
            btnExportarPDF.Text = "📄 Exportar PDF";
            btnExportarPDF.BackColor = Color.FromArgb(180, 50, 50);
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.FlatStyle = FlatStyle.Flat;
            btnExportarPDF.FlatAppearance.BorderSize = 0;
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += new EventHandler(this.btnExportarPDF_Click);

            // ── btnExportarExcel ─────────────────────────────────
            btnExportarExcel.Location = new Point(195, 520);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(160, 35);
            btnExportarExcel.Text = "📗 Exportar Excel";
            btnExportarExcel.BackColor = Color.FromArgb(40, 120, 70);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.FlatAppearance.BorderSize = 0;
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += new EventHandler(this.btnExportarExcel_Click);

            // ── btnRegresar ──────────────────────────────────────
            btnRegresar.Location = new Point(370, 520);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(130, 35);
            btnRegresar.Text = "⬅ Regresar";
            btnRegresar.BackColor = Color.FromArgb(101, 67, 33);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += new EventHandler(this.btnRegresar_Click);

            // ── FormReportes ─────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(900, 580);
            Controls.Add(lblTotalIngresosVal);
            Controls.Add(lblTotalIngresos);
            Controls.Add(lblTotalIVAVal);
            Controls.Add(lblTotalIVA);
            Controls.Add(lblTotalFacturasVal);
            Controls.Add(lblTotalFacturas);
            Controls.Add(lblResumen);
            Controls.Add(btnRegresar);
            Controls.Add(btnExportarExcel);
            Controls.Add(btnExportarPDF);
            Controls.Add(dgvReporte);
            Controls.Add(btnGenerar);
            Controls.Add(dtpHasta);
            Controls.Add(label4);
            Controls.Add(dtpDesde);
            Controls.Add(label3);
            Controls.Add(cboTipoReporte);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormReportes";
            Text = "Reportes - CoffeeSoftCafe";
            this.Load += new EventHandler(this.FormReportes_Load);
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblResumen;
        private Label lblTotalFacturas;
        private Label lblTotalIngresos;
        private Label lblTotalIVA;
        private Label lblTotalFacturasVal;
        private Label lblTotalIngresosVal;
        private Label lblTotalIVAVal;
        private ComboBox cboTipoReporte;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnGenerar;
        private Button btnExportarPDF;
        private Button btnExportarExcel;
        private Button btnRegresar;
        private DataGridView dgvReporte;
    }
}