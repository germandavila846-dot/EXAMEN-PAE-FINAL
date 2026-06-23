using CapaDatos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CoffeeSoftCafe
{
    public partial class FormHistorial : Form
    {
        // ═══════════════════════════════════════════════════════════
        //  ESTADO INTERNO
        // ═══════════════════════════════════════════════════════════
        private CD_Facturacion cdFactura = new CD_Facturacion();
        private DataTable dtFacturas = new DataTable();

        // ═══════════════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ═══════════════════════════════════════════════════════════
        public FormHistorial()
        {
            InitializeComponent();
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGA DEL FORMULARIO
        // ═══════════════════════════════════════════════════════════
        private void FormHistorial_Load(object sender, EventArgs e)
        {
            CargarHistorial();
            LimpiarDetalle();
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGAR HISTORIAL COMPLETO
        // ═══════════════════════════════════════════════════════════
        private void CargarHistorial()
        {
            try
            {
                dtFacturas = cdFactura.ObtenerHistorial();
                dgvFacturas.DataSource = dtFacturas;

                // Ocultar IdFactura del grid
                if (dgvFacturas.Columns["N° Factura"] != null)
                    dgvFacturas.Columns["N° Factura"].Width = 90;

                EstiloGrid(dgvFacturas);
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar historial:\n{ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  BUSCAR CON FILTROS
        // ═══════════════════════════════════════════════════════════
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string cliente = txtBuscarCliente.Text.Trim();
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

                // ✅ Consulta real a SQL con filtros
                dtFacturas = cdFactura.ObtenerHistorialFiltrado(
                                            cliente, desde, hasta);
                dgvFacturas.DataSource = dtFacturas;
                EstiloGrid(dgvFacturas);

                int total = dtFacturas.Rows.Count;
                lblDetalleTitulo.Text = total > 0
                    ? $"📄 {total} factura(s) encontrada(s) — selecciona una para ver el detalle:"
                    : "📄 No se encontraron facturas con esos filtros.";

                LimpiarDetalle();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al buscar:\n{ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  LIMPIAR FILTROS
        // ═══════════════════════════════════════════════════════════
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Text = string.Empty;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            dtFacturas.DefaultView.RowFilter = string.Empty;
            lblDetalleTitulo.Text = "📄 Detalle de la factura seleccionada:";
            LimpiarDetalle();
        }

        // ═══════════════════════════════════════════════════════════
        //  CLICK EN FILA — carga detalle de la factura
        // ═══════════════════════════════════════════════════════════
        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvFacturas.Rows[e.RowIndex];
                int idFact = Convert.ToInt32(row.Cells["N° Factura"].Value);
                string cliente = row.Cells["Cliente"].Value?.ToString();
                decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                decimal iva = Convert.ToDecimal(row.Cells["IVA"].Value);
                decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                // ── Cargar detalle ────────────────────────────────
                DataTable dtDet = cdFactura.ObtenerDetalle(idFact);
                dgvDetalle.DataSource = dtDet;
                EstiloGrid(dgvDetalle);

                // ── Mostrar totales ───────────────────────────────
                lblSubtotalVal.Text = $"C$ {subtotal:N2}";
                lblIVAVal.Text = $"C$ {iva:N2}";
                lblTotalVal.Text = $"C$ {total:N2}";
                lblDetalleTitulo.Text = $"📄 Detalle — Factura #{idFact:D5} | Cliente: {cliente}";
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar detalle:\n{ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        // ── Regresar ─────────────────────────────────────────────
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ═══════════════════════════════════════════════════════════
        //  HELPERS
        // ═══════════════════════════════════════════════════════════
        private void LimpiarDetalle()
        {
            dgvDetalle.DataSource = null;
            lblSubtotalVal.Text = "C$ 0.00";
            lblIVAVal.Text = "C$ 0.00";
            lblTotalVal.Text = "C$ 0.00";
            lblDetalleTitulo.Text = "📄 Detalle de la factura seleccionada:";
        }

        private void EstiloGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(101, 67, 33);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 140, 80);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 225);
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void MostrarMensaje(string texto, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, icono);
        }
    }
}