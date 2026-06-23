using CapaDatos;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

using PdfFont = iTextSharp.text.Font;
using PdfDoc = iTextSharp.text.Document;
using WinFont = System.Drawing.Font;
using WinColor = System.Drawing.Color;

namespace CoffeeSoftCafe
{
    public partial class FormReportes : Form
    {
        private CD_Reportes cdReportes = new CD_Reportes();
        private DataTable dtReporte = new DataTable();
        private string tipoActual = "";

       
        private readonly string rutaLogo =
            Path.Combine(Application.StartupPath, "logo.png");

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            btnExportarPDF.Enabled = false;
            btnExportarExcel.Enabled = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

                if (desde > hasta)
                {
                    MostrarMensaje("La fecha Desde no puede ser mayor que Hasta.",
                        "Validación", MessageBoxIcon.Warning);
                    return;
                }

                tipoActual = cboTipoReporte.SelectedItem.ToString();

                switch (tipoActual)
                {
                    case "Ventas por Fecha":
                        dtReporte = cdReportes.VentasPorFecha(desde, hasta);
                        break;
                    case "Productos Más Vendidos":
                        dtReporte = cdReportes.ProductosMasVendidos(desde, hasta);
                        break;
                    case "Ingresos por Método de Pago":
                        dtReporte = cdReportes.IngresosPorMetodoPago(desde, hasta);
                        break;
                }

                dgvReporte.DataSource = dtReporte;
                EstiloGrid();
                CargarResumen(desde, hasta);

                bool hayDatos = dtReporte.Rows.Count > 0;
                btnExportarPDF.Enabled = hayDatos;
                btnExportarExcel.Enabled = hayDatos;

                if (!hayDatos)
                    MostrarMensaje("No hay datos para el período seleccionado.",
                        "Sin resultados", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al generar reporte:\n{ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        private void CargarResumen(DateTime desde, DateTime hasta)
        {
            try
            {
                DataTable dtRes = cdReportes.ResumenGeneral(desde, hasta);
                if (dtRes.Rows.Count > 0)
                {
                    DataRow row = dtRes.Rows[0];
                    lblTotalFacturasVal.Text = row["Total Facturas"].ToString();
                    lblTotalIVAVal.Text = $"C$ {Convert.ToDecimal(row["Total IVA"]):N2}";
                    lblTotalIngresosVal.Text = $"C$ {Convert.ToDecimal(row["Total General"]):N2}";
                }
            }
            catch { }
        }

        // ═══════════════════════════════════════════════════════════
        //  EXPORTAR PDF  — con logo
        // ═══════════════════════════════════════════════════════════
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF|*.pdf",
                    FileName = $"Reporte_{tipoActual.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    PdfDoc doc = new PdfDoc(PageSize.LETTER, 25, 25, 30, 25);
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    PdfFont fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, new BaseColor(101, 67, 33));
                    PdfFont fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY);
                    PdfFont fuenteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
                    PdfFont fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
                    PdfFont fuenteResumen = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, new BaseColor(101, 67, 33));

                    // ── Encabezado con logo ───────────────────────
                    PdfPTable encabezado = new PdfPTable(2) { WidthPercentage = 100 };
                    encabezado.SetWidths(new float[] { 1f, 4f });

                    // Celda logo
                    if (File.Exists(rutaLogo))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                        logo.ScaleToFit(80f, 80f);
                        PdfPCell celdaLogo = new PdfPCell(logo)
                        {
                            Border = PdfPCell.NO_BORDER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 4
                        };
                        encabezado.AddCell(celdaLogo);
                    }
                    else
                    {
                        encabezado.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });
                    }

                    // Celda textos
                    PdfPCell celdaTextos = new PdfPCell { Border = PdfPCell.NO_BORDER, VerticalAlignment = Element.ALIGN_MIDDLE, Padding = 4 };
                    celdaTextos.AddElement(new Paragraph("CoffeeSoft Café", fuenteTitulo));
                    celdaTextos.AddElement(new Paragraph($"Reporte: {tipoActual}", fuenteSubtitulo));
                    celdaTextos.AddElement(new Paragraph($"Período  : {dtpDesde.Value:dd/MM/yyyy} al {dtpHasta.Value:dd/MM/yyyy}", fuenteSubtitulo));
                    celdaTextos.AddElement(new Paragraph($"Generado : {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteSubtitulo));
                    encabezado.AddCell(celdaTextos);
                    doc.Add(encabezado);

                    // Línea separadora
                    PdfPTable linea = new PdfPTable(1) { WidthPercentage = 100 };
                    linea.AddCell(new PdfPCell(new Phrase(" "))
                    {
                        BorderWidthTop = 0,
                        BorderWidthLeft = 0,
                        BorderWidthRight = 0,
                        BorderWidthBottom = 1.5f,
                        BorderColorBottom = new BaseColor(101, 67, 33),
                        Padding = 4
                    });
                    doc.Add(linea);
                    doc.Add(Chunk.NEWLINE);

                    // ── Tabla de datos ────────────────────────────
                    PdfPTable tabla = new PdfPTable(dtReporte.Columns.Count) { WidthPercentage = 100 };

                    foreach (DataColumn col in dtReporte.Columns)
                    {
                        tabla.AddCell(new PdfPCell(new Phrase(col.ColumnName, fuenteHeader))
                        {
                            BackgroundColor = new BaseColor(101, 67, 33),
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 6
                        });
                    }

                    bool par = false;
                    foreach (DataRow row in dtReporte.Rows)
                    {
                        BaseColor fondo = par ? new BaseColor(255, 240, 225) : BaseColor.WHITE;
                        foreach (var item in row.ItemArray)
                        {
                            tabla.AddCell(new PdfPCell(new Phrase(item?.ToString() ?? "", fuenteCelda))
                            {
                                BackgroundColor = fondo,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            });
                        }
                        par = !par;
                    }

                    doc.Add(tabla);

                    // ── Resumen al pie ────────────────────────────
                    doc.Add(Chunk.NEWLINE);
                    doc.Add(new Paragraph(
                        $"Total Facturas : {lblTotalFacturasVal.Text}   " +
                        $"Total IVA      : {lblTotalIVAVal.Text}   " +
                        $"Total Ingresos : {lblTotalIngresosVal.Text}",
                        fuenteResumen));

                    doc.Close();
                }

                MostrarMensaje("PDF exportado correctamente. ✅", "Exportado", MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al exportar PDF:\n{ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  EXPORTAR EXCEL  — con logo
        // ═══════════════════════════════════════════════════════════
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel|*.xlsx",
                    FileName = $"Reporte_{tipoActual.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (XLWorkbook wb = new XLWorkbook())
                {
                    IXLWorksheet ws = wb.Worksheets.Add(tipoActual);

                    // ── Logo en Excel ─────────────────────────────
                    int colTexto = 1;
                    if (File.Exists(rutaLogo))
                    {
                        ws.AddPicture(rutaLogo).MoveTo(ws.Cell(1, 1)).WithSize(90, 90);
                        colTexto = 2;
                        ws.Column(1).Width = 14;
                    }

                    // ── Textos encabezado ─────────────────────────
                    var cTitulo = ws.Cell(1, colTexto);
                    cTitulo.Value = "CoffeeSoft Café";
                    cTitulo.Style.Font.Bold = true;
                    cTitulo.Style.Font.FontSize = 16;
                    cTitulo.Style.Font.FontColor = XLColor.FromArgb(101, 67, 33);

                    ws.Cell(2, colTexto).Value = $"Reporte: {tipoActual}";
                    ws.Cell(3, colTexto).Value = $"Período: {dtpDesde.Value:dd/MM/yyyy} al {dtpHasta.Value:dd/MM/yyyy}";
                    ws.Cell(4, colTexto).Value = $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}";

                    // ── Encabezados de columnas ───────────────────
                    int fila = 6;
                    for (int c = 0; c < dtReporte.Columns.Count; c++)
                    {
                        var cell = ws.Cell(fila, c + 1);
                        cell.Value = dtReporte.Columns[c].ColumnName;
                        cell.Style.Font.Bold = true;
                        cell.Style.Font.FontColor = XLColor.White;
                        cell.Style.Fill.BackgroundColor = XLColor.FromArgb(101, 67, 33);
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }

                    // ── Filas de datos ────────────────────────────
                    fila++;
                    bool par = false;
                    foreach (DataRow row in dtReporte.Rows)
                    {
                        for (int c = 0; c < dtReporte.Columns.Count; c++)
                        {
                            var cell = ws.Cell(fila, c + 1);
                            cell.Value = row[c]?.ToString() ?? "";
                            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            if (par) cell.Style.Fill.BackgroundColor = XLColor.FromArgb(255, 240, 225);
                        }
                        fila++;
                        par = !par;
                    }

                    // ── Resumen ───────────────────────────────────
                    fila++;
                    foreach (var (texto, offset) in new (string, int)[]
                    {
                        ($"Total Facturas : {lblTotalFacturasVal.Text}", 0),
                        ($"Total IVA      : {lblTotalIVAVal.Text}",      1),
                        ($"Total Ingresos : {lblTotalIngresosVal.Text}", 2)
                    })
                    {
                        var cell = ws.Cell(fila + offset, 1);
                        cell.Value = texto;
                        cell.Style.Font.Bold = true;
                        cell.Style.Font.FontColor = XLColor.FromArgb(101, 67, 33);
                    }

                    ws.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                }

                MostrarMensaje("Excel exportado correctamente. ✅", "Exportado", MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al exportar Excel:\n{ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstiloGrid()
        {
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.ColumnHeadersDefaultCellStyle.BackColor = WinColor.FromArgb(101, 67, 33);
            dgvReporte.ColumnHeadersDefaultCellStyle.ForeColor = WinColor.White;
            dgvReporte.ColumnHeadersDefaultCellStyle.Font = new WinFont("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvReporte.DefaultCellStyle.SelectionBackColor = WinColor.FromArgb(210, 140, 80);
            dgvReporte.DefaultCellStyle.SelectionForeColor = WinColor.White;
            dgvReporte.AlternatingRowsDefaultCellStyle.BackColor = WinColor.FromArgb(255, 240, 225);
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void MostrarMensaje(string texto, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, icono);
        }
    }
}