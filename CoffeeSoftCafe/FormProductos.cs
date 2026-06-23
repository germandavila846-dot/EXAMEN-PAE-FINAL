using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;




namespace CoffeeSoftCafe
{
    public partial class FormProductos : Form
    {
        // ═══════════════════════════════════════════════════════════
        //  ESTADO INTERNO
        // ═══════════════════════════════════════════════════════════
        private DataTable dtProductos = new DataTable();
        private bool modoEdicion = false;
        private int idProductoSeleccionado = -1;
        private CD_Conexion cn = new CD_Conexion();

        // ═══════════════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ═══════════════════════════════════════════════════════════
        public FormProductos()
        {
            InitializeComponent();
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGA DEL FORMULARIO
        // ═══════════════════════════════════════════════════════════
        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrid();
            EstadoInicial();
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGAR COMBOS DESDE SQL
        // ═══════════════════════════════════════════════════════════
        private void CargarCombos()
        {
            try
            {
                // ── Categorías ───────────────────────────────────
                DataTable dtCateg = cn.EjecutarConsulta("SELECT IdCategoria, NombreCategoria FROM Categorias ORDER BY IdCategoria");

                cboCategoria.DataSource = dtCateg;
                cboCategoria.DisplayMember = "NombreCategoria";
                cboCategoria.ValueMember = "IdCategoria";
                cboCategoria.SelectedIndex = -1;


                // ── Tipos de Café ─────────────────────────────────
                DataTable dtTipo = cn.EjecutarConsulta("SELECT IdTipoCafe, NombreTipo FROM TiposCafe ORDER BY IdTipoCafe");

                // Fila vacía para productos sin tipo de café
                DataRow filaVacia = dtTipo.NewRow();
                filaVacia["IdTipoCafe"] = DBNull.Value;
                filaVacia["NombreTipo"] = "N/A";
                dtTipo.Rows.InsertAt(filaVacia, 0);

                cboTipoCafe.DataSource = dtTipo;
                cboTipoCafe.DisplayMember = "NombreTipo";
                cboTipoCafe.ValueMember = "IdTipoCafe";
                cboTipoCafe.SelectedIndex = -1;
                cboTipoCafe.Enabled = false; 


                // CD_Conexion helper closes connections internally
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  CARGAR GRID DESDE SQL
        // ═══════════════════════════════════════════════════════════
        private void CargarGrid()
        {
            try
            {
                string query = @"
                    SELECT 
                        p.IdProducto,
                        p.CodigoProducto  AS Código,
                        p.NombreProducto  AS Nombre,
                        p.PrecioUnitario  AS Precio,
                        c.NombreCategoria AS Categoría,
                        ISNULL(t.NombreTipo, 'N/A') AS [Tipo Café]
                    FROM Productos p
                    INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
                    LEFT  JOIN TiposCafe  t ON p.IdTipoCafe  = t.IdTipoCafe
                    ORDER BY p.CodigoProducto";

                dtProductos = cn.EjecutarConsulta(query);
                dgvProductos.DataSource = dtProductos;
                if (dgvProductos.Columns["IdProducto"] != null)
                    dgvProductos.Columns["IdProducto"].Visible = false;

                EstiloGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  ESTILOS DEL GRID
        // ═══════════════════════════════════════════════════════════
        private void EstiloGrid()
        {
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(101, 67, 33);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 140, 80);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 225);
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ═══════════════════════════════════════════════════════════
        //  GENERAR CÓDIGO AUTOMÁTICO
        // ═══════════════════════════════════════════════════════════
        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!modoEdicion)
                GenerarCodigo();

            string cat = (cboCategoria.SelectedItem as DataRowView)?["NombreCategoria"].ToString() ?? "";
            bool esBebida = cat == "Bebidas Calientes" || cat == "Bebidas Frias";
            cboTipoCafe.Enabled = esBebida;
            // verificar que tenga items antes de asignar índice
            if (!esBebida && cboTipoCafe.Items.Count > 0)
                cboTipoCafe.SelectedIndex = 0;
            else if (!esBebida)
                cboTipoCafe.SelectedIndex = -1;


        }

        private void GenerarCodigo()
        {
            if (cboCategoria.SelectedIndex == -1 || cboCategoria.SelectedItem == null) return;

            string categoria = (cboCategoria.SelectedItem as DataRowView)?["NombreCategoria"].ToString() ?? "";

            string prefijo = categoria switch
            {
                "Bebidas Calientes" => "BC",
                "Bebidas Frias" => "BF",
                "Panaderia" => "PAN",
                "Reposteria" => "REP",
                "Postres" => "POS",
                _ => "PRD"
            };

            try
            {
                object res = cn.EjecutarEscalar("SELECT COUNT(*) FROM Productos WHERE CodigoProducto LIKE @prefijo", new System.Collections.Generic.Dictionary<string, object> { { "@prefijo", prefijo + "%" } });
                int count = Convert.ToInt32(res ?? 0);
                txtCodigo.Text = $"{prefijo}{(count + 1):D3}";
            }
            catch
            {
                txtCodigo.Text = $"{prefijo}001";
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  BOTONES CRUD
        // ═══════════════════════════════════════════════════════════
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            idProductoSeleccionado = -1;
            LimpiarCampos();
            HabilitarCampos(true);
            cboCategoria.Focus();
            ActualizarEstadoBotones("nuevo");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                int idCateg = Convert.ToInt32((cboCategoria.SelectedItem as DataRowView)["IdCategoria"]);
                object idTipoCafe = DBNull.Value;

                if (cboTipoCafe.SelectedItem is DataRowView drvTipo && drvTipo["IdTipoCafe"] != DBNull.Value)
                    idTipoCafe = Convert.ToInt32(drvTipo["IdTipoCafe"]);

                if (modoEdicion && idProductoSeleccionado > 0)
                {
                    string sql = @"
                        UPDATE Productos SET
                            NombreProducto = @nombre,
                            PrecioUnitario = @precio,
                            IdCategoria    = @idCateg,
                            IdTipoCafe     = @idTipo
                        WHERE IdProducto = @id";

                    var parametros = new System.Collections.Generic.Dictionary<string, object>
                    {
                        { "@nombre", txtNombre.Text.Trim() },
                        { "@precio", decimal.Parse(txtPrecio.Text.Trim()) },
                        { "@idCateg", idCateg },
                        { "@idTipo", idTipoCafe },
                        { "@id", idProductoSeleccionado }
                    };

                    cn.EjecutarNonQuery(sql, parametros);
                    MostrarMensaje("Producto actualizado correctamente. ✏️", "Actualizado", MessageBoxIcon.Information);
                }
                else
                {
                    string sql = @"
                        INSERT INTO Productos
                            (CodigoProducto, NombreProducto, PrecioUnitario, IdCategoria, IdTipoCafe)
                        VALUES
                            (@codigo, @nombre, @precio, @idCateg, @idTipo)";

                    var parametros = new System.Collections.Generic.Dictionary<string, object>
                    {
                        { "@codigo", txtCodigo.Text.Trim() },
                        { "@nombre", txtNombre.Text.Trim() },
                        { "@precio", decimal.Parse(txtPrecio.Text.Trim()) },
                        { "@idCateg", idCateg },
                        { "@idTipo", idTipoCafe }
                    };

                    cn.EjecutarNonQuery(sql, parametros);
                    MostrarMensaje("Producto guardado correctamente. ✅", "Guardado", MessageBoxIcon.Information);
                }
                CargarGrid();
                LimpiarCampos();
                HabilitarCampos(false);
                ActualizarEstadoBotones("inicial");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado <= 0)
            {
                MostrarMensaje("Selecciona un producto de la tabla para editar.", "Aviso", MessageBoxIcon.Warning);
                return;
            }
            modoEdicion = true;
            HabilitarCampos(true);
            txtCodigo.Enabled = false;
            ActualizarEstadoBotones("edicion");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado <= 0)
            {
                MostrarMensaje("Selecciona un producto para eliminar.", "Aviso", MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Estás seguro de eliminar '{txtNombre.Text}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM Productos WHERE IdProducto = @id";
                    cn.EjecutarNonQuery(sql, new System.Collections.Generic.Dictionary<string, object> { { "@id", idProductoSeleccionado } });

                    MostrarMensaje("Producto eliminado. 🗑️", "Eliminado", MessageBoxIcon.Information);
                    CargarGrid();
                    LimpiarCampos();
                    ActualizarEstadoBotones("inicial");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            idProductoSeleccionado = -1;
            LimpiarCampos();
            HabilitarCampos(false);
            ActualizarEstadoBotones("inicial");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Connection is managed internally by CD_Conexion helper methods; no explicit close required here.
            this.Close();
        }

        // ═══════════════════════════════════════════════════════════
        //  CLICK EN FILA DEL GRID
        // ═══════════════════════════════════════════════════════════
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
            idProductoSeleccionado = Convert.ToInt32(row.Cells["IdProducto"].Value);
            txtCodigo.Text = row.Cells["Código"].Value?.ToString();
            txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
            txtPrecio.Text = row.Cells["Precio"].Value?.ToString();

            // Seleccionar categoría
            foreach (DataRowView item in cboCategoria.Items)
            {
                if (item["NombreCategoria"].ToString() == row.Cells["Categoría"].Value?.ToString())
                { cboCategoria.SelectedItem = item; break; }
            }

            // Seleccionar tipo café
            foreach (DataRowView item in cboTipoCafe.Items)
            {
                if (item["NombreTipo"].ToString() == row.Cells["Tipo Café"].Value?.ToString())
                { cboTipoCafe.SelectedItem = item; break; }
            }

            ActualizarEstadoBotones("seleccion");
        }

        // ═══════════════════════════════════════════════════════════
        //  BÚSQUEDA EN TIEMPO REAL
        // ═══════════════════════════════════════════════════════════
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = textBox4.Text.Trim().Replace("'", "''");

                if (string.IsNullOrEmpty(filtro))
                    dtProductos.DefaultView.RowFilter = "";
                else
                    dtProductos.DefaultView.RowFilter =
                        $"Nombre LIKE '%{filtro}%' OR Código LIKE '%{filtro}%'";
            }
            catch
            {
                dtProductos.DefaultView.RowFilter = "";
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  VALIDACIÓN PRECIO
        // ═══════════════════════════════════════════════════════════
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
            if (e.KeyChar == '.' && txtPrecio.Text.Contains('.'))
                e.Handled = true;
        }

        // ═══════════════════════════════════════════════════════════
        //  HELPERS
        // ═══════════════════════════════════════════════════════════
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            { MostrarMensaje("Selecciona una categoría para generar el código.", "Validación", MessageBoxIcon.Warning); return false; }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MostrarMensaje("Ingresa el nombre del producto.", "Validación", MessageBoxIcon.Warning); txtNombre.Focus(); return false; }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            { MostrarMensaje("Ingresa un precio válido mayor a 0.", "Validación", MessageBoxIcon.Warning); txtPrecio.Focus(); return false; }

            if (cboCategoria.SelectedIndex == -1)
            { MostrarMensaje("Selecciona una categoría.", "Validación", MessageBoxIcon.Warning); return false; }

            return true;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            textBox4.Text = string.Empty;
            cboCategoria.SelectedIndex = -1;
            cboTipoCafe.SelectedIndex = -1;
            cboTipoCafe.Enabled = false;
            idProductoSeleccionado = -1;
            modoEdicion = false;
            if (dtProductos != null)
                dtProductos.DefaultView.RowFilter = string.Empty;
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            cboCategoria.Enabled = habilitar;
            txtCodigo.Enabled = false;
            Color fondo = habilitar ? Color.White : Color.FromArgb(245, 245, 245);
            txtNombre.BackColor = fondo;
            txtPrecio.BackColor = fondo;
            txtCodigo.BackColor = Color.FromArgb(230, 230, 230);
        }

        private void EstadoInicial()
        {
            HabilitarCampos(false);
            cboTipoCafe.Enabled = false;
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