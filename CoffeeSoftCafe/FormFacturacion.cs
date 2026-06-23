using CapaDatos;
using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CoffeeSoftCafe
{
    public partial class FormFacturacion : Form
    {
        // ═══════════════════════════════════════════════════════════
        //  ESTADO INTERNO
        // ═══════════════════════════════════════════════════════════
        private CD_Facturacion cdFactura = new CD_Facturacion();
        private CN_Facturacion cnFactura = new CN_Facturacion();
        private DataTable dtDetalle = new DataTable();

        // ═══════════════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ═══════════════════════════════════════════════════════════
        public FormFacturacion()
        {
            InitializeComponent();
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGA DEL FORMULARIO
        // ═══════════════════════════════════════════════════════════
        private void FormFacturacion_Load(object sender, EventArgs e)
        {
            InicializarTablaDetalle();
            CargarCombos();
            NuevaFactura();
        }

        // ═══════════════════════════════════════════════════════════
        //  INICIALIZAR TABLA DETALLE EN MEMORIA
        // ═══════════════════════════════════════════════════════════
        private void InicializarTablaDetalle()
        {
            dtDetalle.Columns.Add("IdProducto", typeof(int));
            dtDetalle.Columns.Add("Código", typeof(string));
            dtDetalle.Columns.Add("Producto", typeof(string));
            dtDetalle.Columns.Add("Cantidad", typeof(int));
            dtDetalle.Columns.Add("Precio", typeof(decimal));
            dtDetalle.Columns.Add("Subtotal", typeof(decimal));
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGAR COMBOS DESDE SQL
        // ═══════════════════════════════════════════════════════════
        private void CargarCombos()
        {
            try
            {
                // ── Clientes ─────────────────────────────────────
                DataTable dtClientes = cdFactura.ObtenerClientes();
                cboCliente.DataSource = dtClientes;
                cboCliente.DisplayMember = "NombreCompleto";
                cboCliente.ValueMember = "IdCliente";
                cboCliente.SelectedIndex = -1;

                // ── Métodos de pago ───────────────────────────────
                DataTable dtMetodos = cdFactura.ObtenerMetodosPago();
                cboMetodoPago.DataSource = dtMetodos;
                cboMetodoPago.DisplayMember = "NombreMetodo";
                cboMetodoPago.ValueMember = "IdMetodoPago";
                cboMetodoPago.SelectedIndex = -1;

                // ── Productos ─────────────────────────────────────
                DataTable dtProductos = cdFactura.ObtenerProductos();
                cboProducto.DataSource = dtProductos;
                cboProducto.DisplayMember = "NombreProducto";
                cboProducto.ValueMember = "IdProducto";
                cboProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar datos:\n{ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  NUEVA FACTURA — resetea todo
        // ═══════════════════════════════════════════════════════════
        private void NuevaFactura()
        {
            // Número de factura automático
            txtNumFactura.Text = GenerarNumFactura();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Limpiar combos
            cboCliente.SelectedIndex = -1;
            cboMetodoPago.SelectedIndex = -1;
            cboProducto.SelectedIndex = -1;
            txtCantidad.Text = "1";

            // Limpiar tabla detalle
            dtDetalle.Rows.Clear();
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = dtDetalle;

            // Ocultar columna IdProducto
            if (dgvDetalle.Columns["IdProducto"] != null)
                dgvDetalle.Columns["IdProducto"].Visible = false;

            EstiloGrid();
            ActualizarTotales();
        }

        // ── Generar número de factura ────────────────────────────
        private string GenerarNumFactura()
        {
            try
            {
                object res = cdFactura.ObtenerProximoNumFactura();
                int num = Convert.ToInt32(res ?? 1);
                return $"FAC{num:D5}";
            }
            catch
            {
                return $"FAC{DateTime.Now.Ticks % 100000:D5}";
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  AL CAMBIAR PRODUCTO — muestra precio
        // ═══════════════════════════════════════════════════════════
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem is DataRowView drv)
            {
                decimal precio = Convert.ToDecimal(drv["PrecioUnitario"]);
                // Mostrar precio en el label de referencia
                label6.Text = $"Producto:  C$ {precio:N2}";
            }
            else
            {
                label6.Text = "Producto:";
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  AGREGAR PRODUCTO AL DETALLE
        // ═══════════════════════════════════════════════════════════
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // ── Validar selección ────────────────────────────────
            if (cboProducto.SelectedIndex == -1)
            {
                MostrarMensaje("Selecciona un producto.", "Aviso", MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MostrarMensaje("Ingresa una cantidad válida.", "Aviso", MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            DataRowView drv = cboProducto.SelectedItem as DataRowView;
            int idProducto = Convert.ToInt32(drv["IdProducto"]);
            string codigo = drv["CodigoProducto"].ToString();
            string nombre = drv["NombreProducto"].ToString();
            decimal precio = Convert.ToDecimal(drv["PrecioUnitario"]);

            // ── Verificar si el producto ya está en la lista ─────
            foreach (DataRow row in dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["IdProducto"]) == idProducto)
                {
                    // Sumar cantidad si ya existe
                    row["Cantidad"] = Convert.ToInt32(row["Cantidad"]) + cantidad;
                    row["Subtotal"] = Convert.ToDecimal(row["Precio"])
                                    * Convert.ToInt32(row["Cantidad"]);
                    ActualizarTotales();
                    txtCantidad.Text = "1";
                    cboProducto.SelectedIndex = -1;
                    label6.Text = "Producto:";
                    return;
                }
            }

            // ── Agregar nueva línea ──────────────────────────────
            dtDetalle.Rows.Add(
                idProducto,
                codigo,
                nombre,
                cantidad,
                precio,
                precio * cantidad
            );

            ActualizarTotales();
            txtCantidad.Text = "1";
            cboProducto.SelectedIndex = -1;
            label6.Text = "Producto:";
        }

        // ═══════════════════════════════════════════════════════════
        //  QUITAR LÍNEA DEL DETALLE
        // ═══════════════════════════════════════════════════════════
        private void btnQuitarLinea_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null || dgvDetalle.CurrentRow.Index < 0)
            {
                MostrarMensaje("Selecciona una línea para quitar.", "Aviso", MessageBoxIcon.Warning);
                return;
            }

            dtDetalle.Rows[dgvDetalle.CurrentRow.Index].Delete();
            ActualizarTotales();
        }

        // ═══════════════════════════════════════════════════════════
        //  CALCULAR Y MOSTRAR TOTALES
        //  (el cálculo en sí ya NO vive aquí, se lo pedimos a la
        //  capa de negocio CN_Facturacion)
        // ═══════════════════════════════════════════════════════════
        private void ActualizarTotales()
        {
            var (subtotal, iva, total) = cnFactura.CalcularTotales(dtDetalle);

            lblSubtotalVal.Text = $"C$ {subtotal:N2}";
            lblIVAVal.Text = $"C$ {iva:N2}";
            lblTotalVal.Text = $"C$ {total:N2}";
        }

        // ═══════════════════════════════════════════════════════════
        //  GUARDAR FACTURA
        // ═══════════════════════════════════════════════════════════
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // ── Validaciones ─────────────────────────────────────
            if (cboCliente.SelectedIndex == -1)
            {
                MostrarMensaje("Selecciona un cliente.", "Validación", MessageBoxIcon.Warning);
                return;
            }

            if (cboMetodoPago.SelectedIndex == -1)
            {
                MostrarMensaje("Selecciona un método de pago.", "Validación", MessageBoxIcon.Warning);
                return;
            }

            if (dtDetalle.Rows.Count == 0)
            {
                MostrarMensaje("Agrega al menos un producto.", "Validación", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ── Pedir los totales a la capa de negocio ────────
                var (subtotal, iva, total) = cnFactura.CalcularTotales(dtDetalle);

                Factura factura = new Factura
                {
                    IdCliente = Convert.ToInt32(
                        (cboCliente.SelectedItem as DataRowView)["IdCliente"]),
                    IdMetodoPago = Convert.ToInt32(
                        (cboMetodoPago.SelectedItem as DataRowView)["IdMetodoPago"]),
                    Subtotal = subtotal,
                    IVA = iva,
                    Total = total,
                    Detalles = new List<DetalleFactura>()
                };

                // ── Armar detalles ────────────────────────────────
                foreach (DataRow row in dtDetalle.Rows)
                {
                    factura.Detalles.Add(new DetalleFactura
                    {
                        IdProducto = Convert.ToInt32(row["IdProducto"]),
                        Cantidad = Convert.ToInt32(row["Cantidad"]),
                        PrecioUnitario = Convert.ToDecimal(row["Precio"]),
                        SubtotalLinea = Convert.ToDecimal(row["Subtotal"])
                    });
                }

                // ── Guardar en SQL ────────────────────────────────
                int idFactura = cdFactura.GuardarFactura(factura);

                MessageBox.Show(
                    $"✅ Factura {txtNumFactura.Text} guardada correctamente.\n\n" +
                    $"Cliente : {(cboCliente.SelectedItem as DataRowView)["NombreCompleto"]}\n" +
                    $"Subtotal: C$ {subtotal:N2}\n" +
                    $"IVA     : C$ {iva:N2}\n" +
                    $"Total   : C$ {total:N2}",
                    "Factura Guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                NuevaFactura(); // Resetea para una nueva
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al guardar factura:\n{ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  NUEVA FACTURA (botón)
        // ═══════════════════════════════════════════════════════════
        private void btnNueva_Click(object sender, EventArgs e)
        {
            if (dtDetalle.Rows.Count > 0)
            {
                var confirm = MessageBox.Show(
                    "¿Deseas iniciar una nueva factura?\nSe perderán los datos actuales.",
                    "Nueva Factura",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                    NuevaFactura();
            }
            else
            {
                NuevaFactura();
            }
        }

        // ── Regresar ─────────────────────────────────────────────
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ═══════════════════════════════════════════════════════════
        //  VALIDACIÓN CANTIDAD — solo números
        // ═══════════════════════════════════════════════════════════
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        // ═══════════════════════════════════════════════════════════
        //  ESTILOS DEL GRID
        // ═══════════════════════════════════════════════════════════
        private void EstiloGrid()
        {
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(101, 67, 33);
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvDetalle.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 140, 80);
            dgvDetalle.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 225);
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ═══════════════════════════════════════════════════════════
        //  HELPER MENSAJES
        // ═══════════════════════════════════════════════════════════
        private void MostrarMensaje(string texto, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, icono);
        }


    }
}
