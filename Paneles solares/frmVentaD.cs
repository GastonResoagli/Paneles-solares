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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Venta oVenta = new CN_Venta().ObtenerVenta(txtbusqueda.Text);

            if (oVenta.idVenta != 0)
            {
                // Datos generales de la venta
                txtnumerodocumento.Text = oVenta.DocumentoCliente;
                txtfecha.Text = oVenta.FechaRegistro;
                txttipodocumento.Text = oVenta.TipoDocumento;
                txtusuario.Text = oVenta.oUsuario.NombreCompleto;
                txtdoccliente.Text = oVenta.DocumentoCliente;
                txtnombrecliente.Text = oVenta.NombreCliente;

                // Limpiar y cargar el detalle de productos
                dgvdata.Rows.Clear();
                foreach (Venta_Detalle dv in oVenta.oVenta_Detalle)
                {
                    dgvdata.Rows.Add(new object[]
                    {
                dv.oProducto.Nombre,
                dv.PrecioVenta.ToString("0.00"),
                dv.Cantidad,
                dv.SubTotal.ToString("0.00")
                    });
                }

                // Mostrar montos totales formateados
                txtmontototal.Text = oVenta.MontoTotal.ToString("0.00");
                txtmontopago.Text = oVenta.MontoPago.ToString("0.00");
                txtmontocambio.Text = oVenta.MontoCambio.ToString("0.00");
            }
            else
            {
                MessageBox.Show("No se encontró ninguna venta con ese número de documento.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.plantilla.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);


            Texto_Html = Texto_Html.Replace("@doccliente", txtdoccliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", txtmontopago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", txtmontocambio.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    // Documento A4 con márgenes
                    using (var pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25))
                    {
                        var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // Intentar obtener y dibujar el logo
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
        

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            // Limpiar campos de información general
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdoccliente.Text = "";
            txtnombrecliente.Text = "";

            // Limpiar la tabla de detalle
            dgvdata.Rows.Clear();

            // Reiniciar totales
            txtmontototal.Text = "0.00";
            txtmontopago.Text = "0.00";
            txtmontocambio.Text = "0.00";
        }
    }
}
