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
    public partial class frmReportesAnaliticos : Form
    {
        public frmReportesAnaliticos()
        {
            InitializeComponent();
        }

        // Cuando se abre el formulario
        private void frmReportesAnaliticos_Load(object sender, EventArgs e)
        {
            // Pone fechas por defecto (último mes)
            dtpFechaInicio1.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin1.Value = DateTime.Now;

            dtpFechaInicio2.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin2.Value = DateTime.Now;

            dtpFechaInicio3.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin3.Value = DateTime.Now;

            // Configura las tablas
            ConfigurarDataGridVendedores();
            ConfigurarDataGridProductos();
            ConfigurarDataGridClientes();
        }

        
        // CONFIGURAR LAS TABLAS
        

        private void ConfigurarDataGridVendedores()
        {
            // Crea las columnas de la tabla de vendedores
            dgvVendedores.Columns.Clear();
            dgvVendedores.Columns.Add("DNI", "DNI");
            dgvVendedores.Columns.Add("Vendedor", "Vendedor");
            dgvVendedores.Columns.Add("Rol", "Rol");
            dgvVendedores.Columns.Add("CantidadVentas", "Cantidad Ventas");
            dgvVendedores.Columns.Add("MontoTotalVendido", "Monto Total Vendido");
            dgvVendedores.Columns.Add("PromedioVenta", "Promedio por Venta");
            dgvVendedores.Columns.Add("VentaMaxima", "Venta Máxima");
            dgvVendedores.Columns.Add("VentaMinima", "Venta Mínima");

            dgvVendedores.AllowUserToAddRows = false;
            dgvVendedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigurarDataGridProductos()
        {
            // Crea las columnas de la tabla de productos
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add("Categoria", "Categoría");
            dgvProductos.Columns.Add("CodigoProducto", "Código");
            dgvProductos.Columns.Add("NombreProducto", "Producto");
            dgvProductos.Columns.Add("VecesVendido", "Veces Vendido");
            dgvProductos.Columns.Add("CantidadTotalVendida", "Cantidad Total");
            dgvProductos.Columns.Add("MontoTotalGenerado", "Monto Total");
            dgvProductos.Columns.Add("PrecioPromedioVenta", "Precio Promedio");
            dgvProductos.Columns.Add("StockActual", "Stock Actual");

            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigurarDataGridClientes()
        {
            // Crea las columnas de la tabla de clientes
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("DocumentoCliente", "DNI");
            dgvClientes.Columns.Add("NombreCliente", "Cliente");
            dgvClientes.Columns.Add("CorreoCliente", "Correo");
            dgvClientes.Columns.Add("TelefonoCliente", "Teléfono");
            dgvClientes.Columns.Add("CantidadCompras", "Cantidad Compras");
            dgvClientes.Columns.Add("MontoTotalComprado", "Monto Total");
            dgvClientes.Columns.Add("PromedioCompra", "Promedio Compra");
            dgvClientes.Columns.Add("CompraMaxima", "Compra Máxima");
            dgvClientes.Columns.Add("CompraMinima", "Compra Mínima");
            dgvClientes.Columns.Add("UltimaCompra", "Última Compra");

            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

       
        // REPORTE DE VENDEDORES
       

        private void btnBuscarVendedores_Click(object sender, EventArgs e)
        {
            // Obtiene lista de vendedores con más ventas
            List<ReporteVendedor> lista = new CN_Reporte().VendedoresMayoresVentas(
                dtpFechaInicio1.Value.ToString("dd/MM/yyyy"),
                dtpFechaFin1.Value.ToString("dd/MM/yyyy")
            );

            // Limpia la tabla
            dgvVendedores.Rows.Clear();

            // Agrega los vendedores a la tabla
            foreach (ReporteVendedor rv in lista)
            {
                dgvVendedores.Rows.Add(new object[] {
                rv.DNI,
                rv.Vendedor,
                rv.Rol,
                rv.CantidadVentas,
                Convert.ToDecimal(rv.MontoTotalVendido).ToString("N2"),
                Convert.ToDecimal(rv.PromedioVenta).ToString("N2"),
                Convert.ToDecimal(rv.VentaMaxima).ToString("N2"),
                Convert.ToDecimal(rv.VentaMinima).ToString("N2")
            });
            }

            // Calcula totales
            decimal totalVendido = lista.Sum(v => Convert.ToDecimal(v.MontoTotalVendido));
            int totalVentas = lista.Sum(v => Convert.ToInt32(v.CantidadVentas));

            lblTotalVendedores.Text = $"Total Vendedores: {lista.Count} | Total Ventas: {totalVentas} | Monto Total: ${totalVendido:N2}";
        }

        private void btnExportarVendedores_Click(object sender, EventArgs e)
        {
            // Exporta el reporte a Excel
            ExportarAExcel(dgvVendedores, "ReporteVendedores");
        }

       
        // REPORTE DE PRODUCTOS
        

        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            // Obtiene los productos más vendidos
            List<ReporteProducto> lista = new CN_Reporte().ProductosMasVendidos(
                dtpFechaInicio2.Value.ToString("dd/MM/yyyy"),
                dtpFechaFin2.Value.ToString("dd/MM/yyyy")
            );

            dgvProductos.Rows.Clear();

            // Agrega los productos al DataGridView
            foreach (ReporteProducto rp in lista)
            {
                dgvProductos.Rows.Add(new object[] {
                rp.Categoria,
                rp.CodigoProducto,
                rp.NombreProducto,
                rp.VecesVendido,
                rp.CantidadTotalVendida,
                Convert.ToDecimal(rp.MontoTotalGenerado).ToString("N2"),
                Convert.ToDecimal(rp.PrecioPromedioVenta).ToString("N2"),
                rp.StockActual
            });
            }

            // Calcula totales
            decimal totalGenerado = lista.Sum(p => Convert.ToDecimal(p.MontoTotalGenerado));
            int totalCantidad = lista.Sum(p => Convert.ToInt32(p.CantidadTotalVendida));

            lblTotalProductos.Text = $"Total Productos: {lista.Count} | Cantidad Vendida: {totalCantidad} | Monto Total: ${totalGenerado:N2}";
        }

        private void btnExportarProductos_Click(object sender, EventArgs e)
        {
            // Exporta a Excel
            ExportarAExcel(dgvProductos, "ReporteProductos");
        }

        
        // REPORTE DE CLIENTES
        

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            // Obtiene los clientes con más compras
            List<ReporteCliente> lista = new CN_Reporte().ClientesMayorCompra(
                dtpFechaInicio3.Value.ToString("dd/MM/yyyy"),
                dtpFechaFin3.Value.ToString("dd/MM/yyyy")
            );

            dgvClientes.Rows.Clear();

            // Agrega los clientes a la tabla
            foreach (ReporteCliente rc in lista)
            {
                dgvClientes.Rows.Add(new object[] {
                rc.DocumentoCliente,
                rc.NombreCliente,
                rc.CorreoCliente,
                rc.TelefonoCliente,
                rc.CantidadCompras,
                Convert.ToDecimal(rc.MontoTotalComprado).ToString("N2"),
                Convert.ToDecimal(rc.PromedioCompra).ToString("N2"),
                Convert.ToDecimal(rc.CompraMaxima).ToString("N2"),
                Convert.ToDecimal(rc.CompraMinima).ToString("N2"),
                rc.UltimaCompra
            });
            }

            // Calcula totales
            decimal totalComprado = lista.Sum(c => Convert.ToDecimal(c.MontoTotalComprado));
            int totalCompras = lista.Sum(c => Convert.ToInt32(c.CantidadCompras));

            lblTotalClientes.Text = $"Total Clientes: {lista.Count} | Total Compras: {totalCompras} | Monto Total: ${totalComprado:N2}";
        }

        private void btnExportarClientes_Click(object sender, EventArgs e)
        {
            // Exporta el reporte de clientes a Excel
            ExportarAExcel(dgvClientes, "ReporteClientes");
        }

        
        // MÉTODO COMÚN: EXPORTAR A EXCEL
        
        private void ExportarAExcel(DataGridView dgv, string nombreReporte)
        {
            // Si no hay datos, avisa
            if (dgv.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Crea una tabla en memoria
            DataTable dt = new DataTable();

            // Crea columnas
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                dt.Columns.Add(columna.HeaderText, typeof(string));
            }

            // Carga los datos visibles
            foreach (DataGridViewRow row in dgv.Rows)
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

            // Guarda el archivo Excel
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}_{1}.xlsx", nombreReporte, DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files | *.xlsx";

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