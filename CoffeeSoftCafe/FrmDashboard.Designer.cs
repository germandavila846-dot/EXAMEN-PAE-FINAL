namespace CoffeeSoftCafe
{
    partial class FrmDashboard
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            lblHora = new Label();
            lblFecha = new Label();
            btnSalir = new Button();
            btnReportes = new Button();
            btnHistorial = new Button();
            btnFacturacion = new Button();
            btnClientes = new Button();
            btnProductos = new Button();
            btnDashboard = new Button();
            lblUsuario = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox2 = new PictureBox();
            label2 = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(92, 58, 33);
            panel1.Controls.Add(lblHora);
            panel1.Controls.Add(lblFecha);
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnReportes);
            panel1.Controls.Add(btnHistorial);
            panel1.Controls.Add(btnFacturacion);
            panel1.Controls.Add(btnClientes);
            panel1.Controls.Add(btnProductos);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 700);
            panel1.TabIndex = 0;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.ForeColor = Color.White;
            lblHora.Location = new Point(20, 520);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(128, 20);
            lblHora.TabIndex = 11;
            lblHora.Text = "Hora: 08:45:30 PM";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(15, 491);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(130, 20);
            lblFecha.TabIndex = 10;
            lblFecha.Text = "Fecha: 15/06/2026\n";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.PeachPuff;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(20, 560);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(180, 40);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "🚪 Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.PeachPuff;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Location = new Point(20, 370);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(180, 40);
            btnReportes.TabIndex = 1;
            btnReportes.Text = "📊 Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.PeachPuff;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.Location = new Point(20, 320);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(180, 40);
            btnHistorial.TabIndex = 2;
            btnHistorial.Text = "📋 Historial";
            btnHistorial.UseVisualStyleBackColor = false;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnFacturacion
            // 
            btnFacturacion.BackColor = Color.PeachPuff;
            btnFacturacion.FlatStyle = FlatStyle.Flat;
            btnFacturacion.Location = new Point(20, 270);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Size = new Size(180, 40);
            btnFacturacion.TabIndex = 3;
            btnFacturacion.Text = "\U0001f9fe Facturación";
            btnFacturacion.UseVisualStyleBackColor = false;
            btnFacturacion.Click += btnFacturacion_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.PeachPuff;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Location = new Point(20, 220);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(180, 40);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "👥 Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.PeachPuff;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Location = new Point(20, 170);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(180, 40);
            btnProductos.TabIndex = 5;
            btnProductos.Text = "📦 Productos";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.PeachPuff;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Location = new Point(20, 120);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(180, 40);
            btnDashboard.TabIndex = 6;
            btnDashboard.Text = "🏠 Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(20, 458);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(104, 20);
            lblUsuario.TabIndex = 7;
            lblUsuario.Text = "Administrador";
            lblUsuario.Click += lblUsuario_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 428);
            label1.Name = "label1";
            label1.Size = new Size(99, 23);
            label1.TabIndex = 8;
            label1.Text = "👤 Usuario";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pae2;
            pictureBox1.Location = new Point(45, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._5a40b63d_e528_4a19_867c_71a6aba1f698;
            pictureBox2.Location = new Point(276, 141);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(560, 370);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.SandyBrown;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Rockwell", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(334, 45);
            label2.Name = "label2";
            label2.Size = new Size(406, 42);
            label2.TabIndex = 12;
            label2.Text = "Bienvenido a CoffeeSoft";
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(897, 700);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Name = "FrmDashboard";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CoffeeSoft Café - Dashboard";
            Load += FrmDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label lblUsuario;

        private Button btnDashboard;
        private Button btnProductos;
        private Button btnClientes;
        private Button btnFacturacion;
        private Button btnHistorial;
        private Button btnReportes;
        private Button btnSalir;
        private Label lblHora;
        private Label lblFecha;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox2;
        private Label label2;
        private System.Windows.Forms.Timer timer2;
    }
}