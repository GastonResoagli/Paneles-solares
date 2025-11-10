using CapaEntidad;
using CapaNegocio;
using Paneles_solares.Modal;
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
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }


        private void frmVentas_Load(object sender, EventArgs e)
        {
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";

            txtpagocon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";

            dgvdata.AllowUserToAddRows = false; 
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtDocumentocliente.Text = modal._Cliente.DNI;
                    nombreCliente.Text = modal._Cliente.Nombre;
                    txtCodigoproducto.Select();
                }
                else
                {
                    txtDocumentocliente.Select();
                }
            }
        }

        private void txtDocumentocliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Cliente oCliente = new CN_Cliente()
                    .Listar()
                    .Where(c => c.DNI == txtDocumentocliente.Text && c.Estado == true)
                    .FirstOrDefault();

                if (oCliente != null)
                {
                    txtDocumentocliente.BackColor = Color.Honeydew;
                    nombreCliente.Text = oCliente.Nombre;
                    txtCodigoproducto.Select();
                }
                else
                {
                    txtDocumentocliente.BackColor = Color.MistyRose;
                    nombreCliente.Text = "";
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // ❗ Validación de baja lógica
                    if (!modal._Producto.Estado)
                    {
                        MessageBox.Show("El producto está INACTIVO (baja lógica) y no puede venderse.",
                                        "Producto inactivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarProducto();
                        txtCodigoproducto.Select();
                        return;
                    }

                    txtidproducto.Text = modal._Producto.idProducto.ToString();
                    txtCodigoproducto.Text = modal._Producto.Codigo;
                    txtProducto.Text = modal._Producto.Nombre;
                    txtPrecio.Text = modal._Producto.PrecioVenta.ToString("0.00");
                    txtStock.Text = modal._Producto.Stock.ToString();
                    txtcantidad.Select();
                }
                else
                {
                    txtCodigoproducto.Select();
                }
            }
        }

        private void txtCodigoproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto()
                    .Listar()
                    .FirstOrDefault(p => p.Codigo == txtCodigoproducto.Text);

                if (oProducto != null)
                {
                    if (!oProducto.Estado)
                    {
                        txtCodigoproducto.BackColor = Color.MistyRose;
                        MessageBox.Show("El producto está INACTIVO (baja lógica) y no puede venderse.",
                                        "Producto inactivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarProducto();
                        return;
                    }

                    txtCodigoproducto.BackColor = Color.Honeydew;
                    txtidproducto.Text = oProducto.idProducto.ToString();
                    txtProducto.Text = oProducto.Nombre;
                    txtPrecio.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtStock.Text = oProducto.Stock.ToString();
                    txtcantidad.Select();
                }
                else
                {
                    txtCodigoproducto.BackColor = Color.MistyRose;
                    LimpiarProducto();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // ❗ Revalidar estado contra la base por si cambió
            int idProd = Convert.ToInt32(txtidproducto.Text);
            var prod = new CN_Producto().Listar().FirstOrDefault(p => p.idProducto == idProd);
            if (prod == null || !prod.Estado)
            {
                MessageBox.Show("El producto está INACTIVO (baja lógica) y no puede venderse.",
                                "Producto inactivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }

            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(txtcantidad.Value))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["idProducto"].Value != null && fila.Cells["idProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }
            if (!producto_existe)
            {
                string mensaje = string.Empty;
                bool respuesta = new CN_Venta().RestarStock(
                    Convert.ToInt32(txtidproducto.Text),
                    Convert.ToInt32(txtcantidad.Value)
                );

                if (respuesta)
                {
                    dgvdata.Rows.Add(new object[]
                    {
                txtidproducto.Text,
                txtProducto.Text,
                precio.ToString("0.00"),
                txtcantidad.Value.ToString(),
                (txtcantidad.Value * precio).ToString("0.00")
                    });
                    calculartotal();
                    LimpiarProducto();
                    txtCodigoproducto.Select();
                }
            }

        }
       private void calculartotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells["SubTotal"].Value != null)
                        total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }
            }
            txttotalpagar.Text = total.ToString("0.00");
        }

        private void LimpiarProducto()
        {
            txtidproducto.Text = "0";
            txtCodigoproducto.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtcantidad.Value = 1;
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
                        if (e.RowIndex < 0)
                            return;

                        if (e.ColumnIndex == 5)
                        {
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                            var w = Properties.Resources.gg2.Width;
                            var h = Properties.Resources.gg2.Height;
                            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                            e.Graphics.DrawImage(Properties.Resources.gg2, new Rectangle(x, y, w, h));
                            e.Handled = true;
                        } 
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    bool respuesta = new CN_Venta().SumarStock(
                       Convert.ToInt32(dgvdata.Rows[index].Cells["idProducto"].Value.ToString()),
                       Convert.ToInt32(dgvdata.Rows[index].Cells["Cantidad"].Value.ToString()));

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(index);
                        calculartotal();
                    }

                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, un punto decimal y teclas de control (como Backspace)
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false; // Se permite
            }
            else
            {
                if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    // No permitir que empiece con punto
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false; // Se permite el punto o teclas de control
                    }
                    else
                    {
                        e.Handled = true; // Bloquea cualquier otro carácter
                    }
                }
            }
        }

        private void txtpagocon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, un punto decimal y teclas de control (como Backspace)
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false; // Se permite
            }
            else
            {
                if (txtpagocon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    // No permitir que empiece con punto
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false; // Se permite el punto o teclas de control
                    }
                    else
                    {
                        e.Handled = true; // Bloquea cualquier otro carácter
                    }
                }
            }
        }

        private void calcularcambio()
        {
            if(txttotalpagar.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            decimal pagocon = 0;
            decimal total = Convert.ToDecimal(txttotalpagar.Text);

            if(txtpagocon.Text.Trim() == "")
            {
                txtpagocon.Text = "0";
            }

            if(decimal.TryParse(txtpagocon.Text.Trim(), out pagocon))
            {
                if(pagocon < total)
                {
                    txtcambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagocon - total;
                    txtcambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtpagocon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                calcularcambio();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtDocumentocliente.Text == "")
            {
                MessageBox.Show("Ingrese el documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDocumentocliente.Focus();
                return;
            }

          if(nombreCliente.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nombreCliente.Focus();
                return;
            }

          if(dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Ingrese los productos a la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; 
            }


            DataTable detalle_venta = new DataTable();
            
            detalle_venta.Columns.Add("idProducto", typeof(string));
            detalle_venta.Columns.Add("Precioventa", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal", typeof(decimal));


            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                detalle_venta.Rows.Add(
                    new object[]
                    {
                        row.Cells["idProducto"].Value.ToString(),
                        row.Cells["PrecioVenta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["SubTotal"].Value.ToString(),
                    }
                    );
            }

            int idcorrelativo = new CN_Venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);
            calcularcambio();


            Venta oVenta = new Venta()
            {
                oUsuario = new Usuario() { idUsuario = _Usuario.idUsuario },

                oCliente = new Cliente()
                {
                    idCliente = 1,
                    DNI = txtDocumentocliente.Text,
                    Nombre = nombreCliente.Text
                },

                TipoDocumento = ((OpcionCombo)cbotipodocumento.SelectedItem).Texto,
                NumeroDocumento = Convert.ToInt32(numeroDocumento),
                DocumentoCliente = txtDocumentocliente.Text,
                NombreCliente = nombreCliente.Text,
                MontoPago = Convert.ToDecimal(txtpagocon.Text),
                MontoCambio = Convert.ToDecimal(txtcambio.Text),
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oVenta, detalle_venta, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Número de venta generada:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numeroDocumento);
                }

                // Limpiar los campos del formulario
                txtDocumentocliente.Text = "";
                nombreCliente.Text = "";
                dgvdata.Rows.Clear();
                calculartotal();
                txtpagocon.Text = "";
                txtcambio.Text = "";
            } else
            {  MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
    }
}
