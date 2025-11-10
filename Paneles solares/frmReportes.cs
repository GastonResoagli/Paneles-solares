using CapaEntidad;
using CapaNegocio;
using Paneles_solares.Utilidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Paneles_solares
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        // Cuando se abre el formulario
        private void frmReportes_Load(object sender, EventArgs e)
        {
            // Carga el combo para filtrar por tipo de documento
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "", Texto = "Todos" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            // Carga el combo con las columnas de la tabla (para buscar por)
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                cbobusqueda2.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cbobusqueda2.DisplayMember = "Texto";
            cbobusqueda2.ValueMember = "Valor";
            cbobusqueda2.SelectedIndex = 0;

            // Ajusta el tamaño de las columnas
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Buscar ventas por rango de fechas
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Obtiene las ventas desde la base de datos
            List<ReporteVenta> lista = new CN_Reporte().Venta(
                txtfechainicio.Value.ToString("dd/MM/yyyy"),
                txtfechafin.Value.ToString("dd/MM/yyyy")
            );

            // Filtra por tipo de documento
            string tipoDocumentoFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            dgvdata.Rows.Clear();

            // Carga los datos en la tabla
            foreach (ReporteVenta rv in lista)
            {
                if (string.IsNullOrEmpty(tipoDocumentoFiltro) || rv.TipoDocumento == tipoDocumentoFiltro)
                {
                    dgvdata.Rows.Add(new object[] {
                    rv.FechaRegistro,
                    rv.TipoDocumento,
                    rv.NumeroDocumento,
                    rv.DocumentoCliente,
                    rv.NombreCliente,
                    rv.MontoTotal,
                    rv.UsuarioRegistro,
                    rv.CodigoProducto,
                    rv.NombreProducto,
                    rv.Categoria,
                    rv.PrecioVenta,
                    rv.Cantidad,
                    rv.SubTotal
                });
                }
            }
        }

        // Buscar dentro de la tabla (filtro por texto)
        private void iconButton1_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda2.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Muestra solo las filas que coincidan con el texto
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        // Limpia el texto del buscador y muestra todas las filas
        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        // Exportar reporte a Excel
        private void btnexportar_Click(object sender, EventArgs e)
        {
            // Si no hay datos, muestra mensaje
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Crea una tabla en memoria
            DataTable dt = new DataTable();

            // Crea las columnas del archivo
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                dt.Columns.Add(columna.HeaderText, typeof(string));
            }

            // Carga las filas visibles en la tabla
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Visible)
                {
                    List<string> fila = new List<string>();

                    foreach (DataGridViewCell celda in row.Cells)
                    {
                        fila.Add(celda.Value != null ? celda.Value.ToString() : "");
                    }

                    dt.Rows.Add(fila.ToArray());
                }
            }

            // Selecciona dónde guardar el archivo
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files | *.xlsx";

            // Genera el archivo Excel
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook wb = new XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Informe");
                    hoja.ColumnsUsed().AdjustToContents();
                    wb.SaveAs(savefile.FileName);
                    MessageBox.Show("Reporte generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar reporte: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}

        /* private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {

                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[] {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString()
                        });
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
        */


