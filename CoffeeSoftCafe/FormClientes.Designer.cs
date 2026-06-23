namespace CoffeeSoftCafe
{
    partial class FormClientes
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
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtBuscar = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblBuscar = new Label();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnRegresar = new Button();
            dgvClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // txtCodigo
            // 
            txtCodigo.BackColor = Color.FromArgb(230, 230, 230);
            txtCodigo.Enabled = false;
            txtCodigo.Location = new Point(180, 72);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(180, 27);
            txtCodigo.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(180, 117);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(180, 27);
            txtNombre.TabIndex = 7;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(180, 162);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(180, 27);
            txtDireccion.TabIndex = 8;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(500, 72);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 27);
            txtTelefono.TabIndex = 9;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(180, 227);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(250, 27);
            txtBuscar.TabIndex = 10;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(200, 20);
            label1.Name = "label1";
            label1.Size = new Size(317, 28);
            label1.TabIndex = 0;
            label1.Text = "👤 GESTIÓN DE CLIENTES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 75);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 1;
            label2.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 120);
            label3.Name = "label3";
            label3.Size = new Size(137, 20);
            label3.TabIndex = 2;
            label3.Text = "Nombre Completo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 165);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 3;
            label4.Text = "Dirección:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(400, 75);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 4;
            label5.Text = "Teléfono:";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(50, 230);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(80, 20);
            lblBuscar.TabIndex = 5;
            lblBuscar.Text = "🔍 Buscar:";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(50, 275);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "➕ Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(165, 275);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(280, 275);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "✏ Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(395, 275);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "🗑 Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(510, 275);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 35);
            btnLimpiar.TabIndex = 15;
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
            btnRegresar.Location = new Point(620, 275);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(110, 35);
            btnRegresar.TabIndex = 16;
            btnRegresar.Text = "⬅ Regresar";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeight = 29;
            dgvClientes.Location = new Point(50, 330);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(700, 230);
            dgvClientes.TabIndex = 17;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(800, 590);
            Controls.Add(dgvClientes);
            Controls.Add(btnRegresar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Clientes - CoffeeSoftCafe";
            Load += FormClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtBuscar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblBuscar;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnRegresar;
        private DataGridView dgvClientes;
    }
}