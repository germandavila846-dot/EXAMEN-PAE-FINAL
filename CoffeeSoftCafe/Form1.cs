using CapaEntidades;
using CapaDatos;
using System.Drawing.Drawing2D;

namespace CoffeeSoftCafe
{
    public partial class Form1 : Form
    {
        // ── Colores corporativos ──────────────────────────────────
        private readonly Color CafeOscuro = ColorTranslator.FromHtml("#3E2010");
        private readonly Color CafeMedio = ColorTranslator.FromHtml("#6B3A1F");
        private readonly Color CafeClaro = ColorTranslator.FromHtml("#C49A6C");
        private readonly Color CremaSuave = ColorTranslator.FromHtml("#FDF6EC");
        private readonly Color CremaBg = ColorTranslator.FromHtml("#F5E6D0");
        private readonly Color TextoOscuro = ColorTranslator.FromHtml("#2C1A0E");

        public Form1()
        {
            InitializeComponent();
            ConfigurarVentana();
            ConfigurarEstilos();
        }

        // ═══════════════════════════════════════════════════════════
        //  CONFIGURACIÓN INICIAL
        // ═══════════════════════════════════════════════════════════
        private void ConfigurarVentana()
        {
            this.Text = "CoffeeSoft Café — Iniciar Sesión";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = CremaBg;
            this.Font = new Font("Segoe UI", 9.5f);

            // Enter en usuario → salta a contraseña
            txtUsuario.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    txtClave.Focus();
                }
            };

            // Enter en contraseña → dispara login
            txtClave.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnIngrear.PerformClick();
                }
            };

         
        }

        private void ConfigurarEstilos()
        {
            // Password por defecto
            txtClave.UseSystemPasswordChar = true;
            btnVerClave.Text = "👁";

            // Estilo campos de texto
            EstilarTextBox(txtUsuario);
            EstilarTextBox(txtClave);

            // Botón principal
            EstilarBotonPrincipal(btnIngrear);

            // Botón ver clave — pequeño y discreto
            btnVerClave.FlatStyle = FlatStyle.Flat;
            btnVerClave.FlatAppearance.BorderSize = 0;
            btnVerClave.BackColor = Color.Transparent;
            btnVerClave.ForeColor = CafeMedio;
            btnVerClave.Cursor = Cursors.Hand;
            btnVerClave.Font = new Font("Segoe UI", 11f);

            // Placeholder manual
            ConfigurarPlaceholder(txtUsuario, "Usuario");
            ConfigurarPlaceholder(txtClave, "Contraseña");
        }

        // ═══════════════════════════════════════════════════════════
        //  HELPERS DE ESTILO
        // ═══════════════════════════════════════════════════════════
        private void EstilarTextBox(TextBox tb)
        {
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.BackColor = Color.White;
            tb.ForeColor = TextoOscuro;
            tb.Font = new Font("Segoe UI", 10.5f);
            tb.Height = 32;

            tb.Enter += (s, e) => { tb.BackColor = ColorTranslator.FromHtml("#FFFBF5"); };
            tb.Leave += (s, e) => { tb.BackColor = Color.White; };
        }

        private void EstilarBotonPrincipal(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = CafeMedio;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 40;

            btn.MouseEnter += (s, e) => btn.BackColor = CafeOscuro;
            btn.MouseLeave += (s, e) => btn.BackColor = CafeMedio;
        }

        // ── Placeholder visual (sin librerías externas) ───────────
        private void ConfigurarPlaceholder(TextBox tb, string placeholder)
        {
            bool esClave = tb.UseSystemPasswordChar;

            tb.Tag = placeholder;
            tb.ForeColor = Color.Gray;
            tb.Text = placeholder;
            if (esClave) tb.UseSystemPasswordChar = false;

            tb.Enter += (s, e) =>
            {
                if (tb.Text == placeholder)
                {
                    tb.Text = "";
                    tb.ForeColor = TextoOscuro;
                    if (esClave) tb.UseSystemPasswordChar = true;
                }
            };

            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    if (esClave) tb.UseSystemPasswordChar = false;
                    tb.Text = placeholder;
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        // ── Obtener texto limpio (sin placeholder) ────────────────
        private string ObtenerTexto(TextBox tb)
        {
            string placeholder = tb.Tag?.ToString() ?? "";
            return tb.Text == placeholder ? "" : tb.Text.Trim();
        }

        // ═══════════════════════════════════════════════════════════
        //  PINTADO PERSONALIZADO (línea inferior en campos)
        // ═══════════════════════════════════════════════════════════
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Línea decorativa superior (banda café)
            using var brush = new SolidBrush(CafeMedio);
            e.Graphics.FillRectangle(brush, 0, 0, this.Width, 6);
        }

        // ═══════════════════════════════════════════════════════════
        //  EVENTOS
        // ═══════════════════════════════════════════════════════════
        private void Form1_Load(object sender, EventArgs e)
        {
            // Foco inicial correcto (evita que el placeholder desaparezca solo)
            this.ActiveControl = null;
            txtUsuario.Select();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void btnVerClave_Click(object sender, EventArgs e)
        {
            // Solo aplica si no es placeholder
            if (ObtenerTexto(txtClave) != "")
            {
                txtClave.UseSystemPasswordChar = !txtClave.UseSystemPasswordChar;
                btnVerClave.Text = txtClave.UseSystemPasswordChar ? "👁" : "🙈";
            }
            txtClave.Focus();
        }

        private void btnIngrear_Click(object sender, EventArgs e)
        {
            string usuario = ObtenerTexto(txtUsuario);
            string clave = ObtenerTexto(txtClave);

            // Validaciones
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MostrarAlerta("👤 Debe ingresar un nombre de usuario.", txtUsuario);
                return;
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                MostrarAlerta("🔒 Debe ingresar una contraseña.", txtClave);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            btnIngrear.Enabled = false;
            btnIngrear.Text = "⏳ Verificando...";

            try
            {
                CD_Login login = new CD_Login();
                Usuario usuarioObj = login.ValidarUsuario(usuario, clave);

                if (usuarioObj != null)
                {
                    MessageBox.Show(
                        $"☕ ¡Bienvenido a CoffeeSoft Café!\n\n" +
                        $"👤 Usuario: {usuarioObj.NombreCompleto}\n\n" +
                        $"✅ Inicio de sesión exitoso.",
                        "Acceso Concedido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    FrmDashboard dashboard = new FrmDashboard(usuarioObj);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "❌ Acceso denegado.\n\n" +
                        "El usuario o la contraseña ingresados son incorrectos.\n\n" +
                        "🔑 Verifique sus credenciales e intente nuevamente.",
                        "Error de Autenticación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    LimpiarClave();
                    txtClave.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "⚠️ No fue posible establecer conexión con la base de datos.\n\n" +
                    "📡 Verifique que el servidor SQL esté en ejecución e inténtelo nuevamente.",
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnIngrear.Enabled = true;
                btnIngrear.Text = "Ingresar";
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  HELPERS
        // ═══════════════════════════════════════════════════════════
        private void MostrarAlerta(string mensaje, TextBox campoFoco)
        {
            MessageBox.Show(mensaje, "CoffeeSoft Café",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            campoFoco.Focus();
            if (campoFoco == txtClave) LimpiarClave();
        }

        private void LimpiarClave()
        {
            txtClave.UseSystemPasswordChar = true;
            txtClave.Clear();
            txtClave.ForeColor = TextoOscuro;
            btnVerClave.Text = "👁";
            txtClave.Focus();
        }
    }
}