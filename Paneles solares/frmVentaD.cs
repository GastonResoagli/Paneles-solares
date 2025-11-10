using CapaEntidad;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paneles_solares
{
    public partial class frmVentaD : Form
    {
        public frmVentaD()
        {
            InitializeComponent();
        }

        // Buscar venta por número de documento
        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Busca la venta en la base de datos
            Venta oVenta = new CN_Venta().ObtenerVenta(txtbusqueda.Text);

            // Si existe la venta
            if (oVenta.idVenta != 0)
            {
                // Muestra los datos principales de la venta
                txtnumerodocumento.Text = oVenta.NumeroDocumento.ToString();
                txtfecha.Text = oVenta.FechaRegistro;
                txttipodocumento.Text = oVenta.TipoDocumento;
                txtusuario.Text = oVenta.oUsuario.NombreCompleto;
                txtdoccliente.Text = oVenta.DocumentoCliente;
                txtnombrecliente.Text = oVenta.NombreCliente;

                // Limpia la tabla y carga los productos vendidos
                dgvdata.Rows.Clear();
                foreach (Venta_Detalle dv in oVenta.oVenta_Detalle)
                {
                    dgvdata.Rows.Add(new object[]
                    {
                    "",
                    dv.oProducto.Nombre,
                    dv.PrecioVenta.ToString("0.00"),
                    dv.Cantidad,
                    dv.SubTotal.ToString("0.00"),
                    ""
                    });
                }

                // Muestra los totales
                txtmontototal.Text = oVenta.MontoTotal.ToString("0.00");
                txtmontopago.Text = oVenta.MontoPago.ToString("0.00");
                txtmontocambio.Text = oVenta.MontoCambio.ToString("0.00");
            }
            else
            {
                // Si no encuentra la venta, muestra mensaje
                MessageBox.Show("No se encontró ninguna venta con ese número de documento.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Generar PDF de la venta
        private void iconButton2_Click(object sender, EventArgs e)
        {
            // Si no hay datos cargados
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Carga la plantilla HTML
            string Texto_Html = Properties.Resources.plantilla.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            // Ruta del logo de la empresa
            string rutaLogo = Path.Combine(Application.StartupPath, @"..\..\Resources\logo.png");
            rutaLogo = Path.GetFullPath(rutaLogo);
            Texto_Html = Texto_Html.Replace("./logo.png", rutaLogo);

            // Reemplaza los datos en la plantilla
            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);
            Texto_Html = Texto_Html.Replace("@doccliente", txtdoccliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            // Crea las filas con los productos
            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioVenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", txtmontopago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", txtmontocambio.Text);

            // Guardar como PDF
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    // Crea el documento PDF
                    using (var pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25))
                    {
                        var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // Agrega el logo si existe
                        bool obtenido;
                        byte[] logoBytes = new CN_Negocio().ObtenerLogo(out obtenido);

                        if (obtenido && logoBytes != null && logoBytes.Length > 0)
                        {
                            var img = iTextSharp.text.Image.GetInstance(logoBytes);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                            pdfDoc.Add(img);
                        }

                        // Convierte el HTML en PDF
                        using (StringReader sr = new StringReader(Texto_Html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                        MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // Limpiar los datos del formulario
        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            // Limpia los campos
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdoccliente.Text = "";
            txtnombrecliente.Text = "";

            // Limpia la tabla
            dgvdata.Rows.Clear();

            // Reinicia los totales
            txtmontototal.Text = "0.00";
            txtmontopago.Text = "0.00";
            txtmontocambio.Text = "0.00";
        }
    }
}