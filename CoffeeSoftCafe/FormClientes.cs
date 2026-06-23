using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CoffeeSoftCafe
{
    public partial class FormClientes : Form
    {
        // ═══════════════════════════════════════════════════════════
        //  ESTADO INTERNO
        // ═══════════════════════════════════════════════════════════
        private DataTable dtClientes = new DataTable();
        private bool modoEdicion = false;
        private int idClienteSeleccionado = -1;
        private CD_Conexion cn = new CD_Conexion();

        // ═══════════════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ═══════════════════════════════════════════════════════════
        public FormClientes()
        {
            InitializeComponent();
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGA DEL FORMULARIO
        // ═══════════════════════════════════════════════════════════
        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarGrid();
            EstadoInicial();
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGAR GRID DESDE SQL
        // ═══════════════════════════════════════════════════════════
        private void CargarGrid()
        {
            try
            {
                dtClientes = cn.EjecutarConsulta(@"
                    SELECT
                        IdCliente       AS ID,
                        NombreCompleto  AS Nombre,
                        Direccion       AS Dirección,
                        Telefono        AS Teléfono
                    FROM Clientes
                    ORDER BY IdCliente");

                dgvClientes.DataSource = dtClientes;

                if (dgvClientes.Columns["ID"] != null)
                    dgvClientes.Columns["ID"].Visible = false;

                EstiloGrid();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar clientes:\n{ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  ESTILOS DEL GRID
        // ═══════════════════════════════════════════════════════════
        private void EstiloGrid()
        {
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(101, 67, 33);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 140, 80);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 225);
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ═══════════════════════════════════════════════════════════
        //  GENERAR ID AUTOMÁTICO
        // ═══════════════════════════════════════════════════════════
        private void GenerarId()
        {
            try
            {
                object res = cn.EjecutarEscalar(
                    "SELECT ISNULL(MAX(IdCliente), 0) + 1 FROM Clientes");
                txtCodigo.Text = $"CLI{Convert.ToInt32(res):D3}";
            }
            catch
            {
                txtCodigo.Text = "CLI001";
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  BOTONES CRUD
        // ═══════════════════════════════════════════════════════════

        // ── Nuevo ────────────────────────────────────────────────
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            idClienteSeleccionado = -1;
            LimpiarCampos();
            HabilitarCampos(true);
            GenerarId();
            txtNombre.Focus();
            ActualizarEstadoBotones("nuevo");
        }

        // ── Guardar ──────────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                if (modoEdicion && idClienteSeleccionado > 0)
                {
                    // ── UPDATE ───────────────────────────────────
                    cn.EjecutarNonQuery(@"
                        UPDATE Clientes SET
                            NombreCompleto = @nombre,
                            Direccion      = @direccion,
                            Telefono       = @telefono
                        WHERE IdCliente = @id",
                        new Dictionary<string, object>
                        {
                            { "@nombre",    txtNombre.Text.Trim()    },
                            { "@direccion", txtDireccion.Text.Trim() },
                            { "@telefono",  txtTelefono.Text.Trim()  },
                            { "@id",        idClienteSeleccionado    }
                        });

                    MostrarMensaje("Cliente actualizado correctamente. ✏️",
                        "Actualizado", MessageBoxIcon.Information);
                }
                else
                {
                    // ── INSERT ───────────────────────────────────
                    cn.EjecutarNonQuery(@"
                        INSERT INTO Clientes
                            (NombreCompleto, Direccion, Telefono)
                        VALUES
                            (@nombre, @direccion, @telefono)",
                        new Dictionary<string, object>
                        {
                            { "@nombre",    txtNombre.Text.Trim()    },
                            { "@direccion", txtDireccion.Text.Trim() },
                            { "@telefono",  txtTelefono.Text.Trim()  }
                        });

                    MostrarMensaje("Cliente guardado correctamente. ✅",
                        "Guardado", MessageBoxIcon.Information);
                }

                CargarGrid();
                LimpiarCampos();
                HabilitarCampos(false);
                ActualizarEstadoBotones("inicial");
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al guardar:\n{ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        // ── Editar ───────────────────────────────────────────────
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado <= 0)
            {
                MostrarMensaje("Selecciona un cliente para editar.",
                    "Aviso", MessageBoxIcon.Warning);
                return;
            }
            modoEdicion = true;
            HabilitarCampos(true);
            txtCodigo.Enabled = false;
            ActualizarEstadoBotones("edicion");
        }

        // ── Eliminar ─────────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado <= 0)
            {
                MostrarMensaje("Selecciona un cliente para eliminar.",
                    "Aviso", MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Estás seguro de eliminar a '{txtNombre.Text}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    cn.EjecutarNonQuery(
                        "DELETE FROM Clientes WHERE IdCliente = @id",
                        new Dictionary<string, object>
                        {
                            { "@id", idClienteSeleccionado }
                        });

                    MostrarMensaje("Cliente eliminado correctamente. 🗑️",
                        "Eliminado", MessageBoxIcon.Information);
                    CargarGrid();
                    LimpiarCampos();
                    ActualizarEstadoBotones("inicial");
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Error al eliminar:\n{ex.Message}",
                        "Error", MessageBoxIcon.Error);
                }
            }
        }

        // ── Limpiar ──────────────────────────────────────────────
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            idClienteSeleccionado = -1;
            LimpiarCampos();
            HabilitarCampos(false);
            ActualizarEstadoBotones("inicial");
        }

        // ── Regresar ─────────────────────────────────────────────
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ═══════════════════════════════════════════════════════════
        //  CLICK EN FILA DEL GRID
        // ═══════════════════════════════════════════════════════════
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
            idClienteSeleccionado = Convert.ToInt32(row.Cells["ID"].Value);
            txtCodigo.Text = $"CLI{idClienteSeleccionado:D3}";
            txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
            txtDireccion.Text = row.Cells["Dirección"].Value?.ToString();
            txtTelefono.Text = row.Cells["Teléfono"].Value?.ToString();

            ActualizarEstadoBotones("seleccion");
        }

        // ═══════════════════════════════════════════════════════════
        //  BÚSQUEDA EN TIEMPO REAL
        // ═══════════════════════════════════════════════════════════
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscar.Text.Trim().Replace("'", "''");
                dtClientes.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                    ? ""
                    : $"Nombre LIKE '%{filtro}%' OR Teléfono LIKE '%{filtro}%'";
            }
            catch
            {
                dtClientes.DefaultView.RowFilter = "";
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  VALIDACIÓN TELÉFONO — solo números
        // ═══════════════════════════════════════════════════════════
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        // ═══════════════════════════════════════════════════════════
        //  HELPERS
        // ═══════════════════════════════════════════════════════════
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarMensaje("Ingresa el nombre del cliente.",
                    "Validación", MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MostrarMensaje("Ingresa el teléfono del cliente.",
                    "Validación", MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            if (txtTelefono.Text.Length < 8)
            {
                MostrarMensaje("El teléfono debe tener al menos 8 dígitos.",
                    "Validación", MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtBuscar.Text = string.Empty;
            idClienteSeleccionado = -1;
            modoEdicion = false;
            if (dtClientes != null)
                dtClientes.DefaultView.RowFilter = string.Empty;
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtCodigo.Enabled = false;
            Color fondo = habilitar ? Color.White : Color.FromArgb(245, 245, 245);
            txtNombre.BackColor = fondo;
            txtDireccion.BackColor = fondo;
            txtTelefono.BackColor = fondo;
            txtCodigo.BackColor = Color.FromArgb(230, 230, 230);
        }

        private void EstadoInicial()
        {
            HabilitarCampos(false);
            ActualizarEstadoBotones("inicial");
        }

        private void ActualizarEstadoBotones(string modo)
        {
            switch (modo)
            {
                case "inicial":
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnLimpiar.Enabled = false;
                    break;
                case "nuevo":
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnLimpiar.Enabled = true;
                    break;
                case "seleccion":
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnLimpiar.Enabled = true;
                    break;
                case "edicion":
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnLimpiar.Enabled = true;
                    break;
            }
        }

        private void MostrarMensaje(string texto, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, icono);
        }
    }
}