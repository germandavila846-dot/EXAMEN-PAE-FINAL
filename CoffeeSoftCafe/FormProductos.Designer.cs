namespace CoffeeSoftCafe
{
    partial class FormProductos
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
            txtPrecio = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cboCategoria = new ComboBox();
            cboTipoCafe = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            label7 = new Label();
            dgvProductos = new DataGridView();
            btnRegresar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(167, 51);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(125, 27);
            txtCodigo.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(167, 105);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(167, 149);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(125, 27);
            txtPrecio.TabIndex = 2;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(268, 275);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(315, 27);
            textBox4.TabIndex = 3;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(209, 9);
            label1.Name = "label1";
            label1.Size = new Size(351, 28);
            label1.TabIndex = 4;
            label1.Text = "☕ GESTIÓN DE PRODUCTOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 54);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 5;
            label2.Text = "Código:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 108);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 6;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 152);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 7;
            label4.Text = "Precio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(335, 54);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 8;
            label5.Text = "Categoría:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(335, 108);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 9;
            label6.Text = "Tipo de Café:";
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(428, 51);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(151, 28);
            cboCategoria.TabIndex = 10;
            cboCategoria.SelectedIndexChanged += cboCategoria_SelectedIndexChanged;
            // 
            // cboTipoCafe
            // 
            cboTipoCafe.FormattingEnabled = true;
            cboTipoCafe.Location = new Point(438, 105);
            cboTipoCafe.Name = "cboTipoCafe";
            cboTipoCafe.Size = new Size(151, 28);
            cboTipoCafe.TabIndex = 11;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(111, 197);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(92, 53);
            btnNuevo.TabIndex = 12;
            btnNuevo.Text = "➕ Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(223, 197);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(92, 53);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(335, 197);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(92, 53);
            btnEditar.TabIndex = 14;
            btnEditar.Text = "✏ Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(450, 197);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(92, 53);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "🗑 Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(562, 197);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(92, 53);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "\U0001f9f9 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(209, 278);
            label7.Name = "label7";
            label7.Size = new Size(55, 20);
            label7.TabIndex = 17;
            label7.Text = "Buscar:";
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(91, 325);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(576, 188);
            dgvProductos.TabIndex = 19;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.FromArgb(101, 67, 33);
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(635, 38);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(125, 90);
            btnRegresar.TabIndex = 20;
            btnRegresar.Text = "⬅ Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(800, 525);
            Controls.Add(btnRegresar);
            Controls.Add(dgvProductos);
            Controls.Add(label7);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(cboTipoCafe);
            Controls.Add(cboCategoria);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Name = "FormProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Productos - CoffeeSoftCafe";
            Load += FormProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cboCategoria;
        private ComboBox cboTipoCafe;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label label7;
        private DataGridView dgvProductos;
        private Button btnRegresar;
    }
}