namespace CoffeeSoftCafe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            btnIngrear = new Button();
            btnVerClave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Bisque;
            pictureBox1.Image = Properties.Resources.pae2;
            pictureBox1.Location = new Point(226, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label1.Location = new Point(248, 155);
            label1.Name = "label1";
            label1.Size = new Size(151, 19);
            label1.TabIndex = 1;
            label1.Text = "Sistema de Gestion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label2.Location = new Point(225, 186);
            label2.Name = "label2";
            label2.Size = new Size(95, 19);
            label2.TabIndex = 2;
            label2.Text = "👤 Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label3.Location = new Point(225, 256);
            label3.Name = "label3";
            label3.Size = new Size(120, 19);
            label3.TabIndex = 3;
            label3.Text = "🔒 Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            txtUsuario.Location = new Point(226, 224);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ingrese su usuario";
            txtUsuario.Size = new Size(213, 27);
            txtUsuario.TabIndex = 4;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            txtClave.Location = new Point(226, 291);
            txtClave.Name = "txtClave";
            txtClave.PlaceholderText = "Ingrese su contraseña";
            txtClave.Size = new Size(213, 27);
            txtClave.TabIndex = 5;
            // 
            // btnIngrear
            // 
            btnIngrear.BackColor = Color.SandyBrown;
            btnIngrear.FlatStyle = FlatStyle.Flat;
            btnIngrear.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            btnIngrear.Location = new Point(248, 334);
            btnIngrear.Name = "btnIngrear";
            btnIngrear.Size = new Size(141, 29);
            btnIngrear.TabIndex = 6;
            btnIngrear.Text = "INGRESAR ☕";
            btnIngrear.UseVisualStyleBackColor = false;
            btnIngrear.Click += btnIngrear_Click;
            // 
            // btnVerClave
            // 
            btnVerClave.Location = new Point(454, 291);
            btnVerClave.Name = "btnVerClave";
            btnVerClave.Size = new Size(42, 27);
            btnVerClave.TabIndex = 7;
            btnVerClave.Text = "👁";
            btnVerClave.UseVisualStyleBackColor = true;
            btnVerClave.Click += btnVerClave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(679, 384);
            Controls.Add(btnVerClave);
            Controls.Add(btnIngrear);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormLogin";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;

        private TextBox txtUsuario;
        private TextBox txtClave;

        private Button btnIngrear;
        private Button btnVerClave;
    }
}
