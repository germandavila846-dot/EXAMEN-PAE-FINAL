using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using CapaDatos;

namespace CoffeeSoftCafe
{
    public partial class FrmDashboard : Form
    {
        private Usuario usuarioActual;


        public FrmDashboard(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;

            ConfigurarBotones();

            lblUsuario.Text = usuarioActual.NombreCompleto;

            timer1.Start();
        }

        private void ConfigurarBotones()
        {
            Button[] botones =
            {
                btnDashboard,
                btnProductos,
                btnClientes,
                btnFacturacion,
                btnHistorial,
                btnReportes,
                btnSalir
            };

            foreach (Button btn in botones)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                btn.BackColor = Color.FromArgb(92, 58, 33);
                btn.ForeColor = Color.White;

                btn.Font = new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

                btn.Cursor = Cursors.Hand;
            }
        }

        private void lblUsuario_Click_1(object sender, EventArgs e)
        {
            lblUsuario.Text = usuarioActual.NombreCompleto;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString(
                "dddd dd 'de' MMMM 'de' yyyy",
                new CultureInfo("es-ES"));

            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos fp = new FormProductos();
            fp.FormClosed += (s, args) => this.Show(); // ← al cerrar Productos, regresa el Dashboard
            this.Hide();   // oculta el Dashboard
            fp.Show();     // muestra Productos
        }



        private void btnSalir_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show("¡Gracias por usar CoffeeSoft Café! ☕", "Hasta Luego",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Exit();

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes fp = new FormClientes();
            fp.FormClosed += (s, args) => this.Show(); // ← al cerrar Clientes, regresa el Dashboard
            this.Hide();   // oculta el Dashboard
            fp.Show();     // muestra Clientes
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            FormFacturacion ff = new FormFacturacion();
            ff.FormClosed += (s, args) => this.Show(); // ← al cerrar Facturación, regresa el Dashboard
            this.Hide();   // oculta el Dashboard
            ff.Show();     // muestra Facturación
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial ff = new FormHistorial();
            ff.FormClosed += (s, args) => this.Show(); // ← al cerrar Historial, regresa el Dashboard
            this.Hide();   // oculta el Dashboard
            ff.Show();     // muestra Historial

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                CD_Reportes cd = new CapaDatos.CD_Reportes();
                DataTable dt = cd.ResumenDashboard();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    string resumen =
                        $"📊  RESUMEN DEL SISTEMA\n" +
                        $"{"─────────────────────────────────────────"}\n\n" +
                        $"📦  Productos registrados : {row["TotalProductos"]}\n" +
                        $"👤  Clientes registrados  : {row["TotalClientes"]}\n\n" +
                        $"🧾  Facturas de hoy       : {row["FacturasHoy"]}\n" +
                        $"💰  Ventas de hoy         : C$ {Convert.ToDecimal(row["VentasHoy"]):N2}\n\n" +
                        $"📅  Ventas del mes        : C$ {Convert.ToDecimal(row["VentasMes"]):N2}\n";

                    MessageBox.Show(
                        resumen,
                        "Dashboard — CoffeeSoft Café",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar resumen:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormReportes ff = new FormReportes();
            ff.FormClosed += (s, args) => this.Show(); // ← al cerrar Reportes, regresa el Dashboard
            this.Hide();   // oculta el Dashboard
            ff.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

