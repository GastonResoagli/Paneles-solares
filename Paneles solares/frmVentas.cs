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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
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
                    .Where(p => p.Codigo == txtCodigoproducto.Text && p.Estado == true)
                    .FirstOrDefault();

                if (oProducto != null)
                {
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
                    txtidproducto.Text = "0";
                    txtProducto.Text = "";
                    txtPrecio.Text = "";
                    txtStock.Text = "";
                    txtcantidad.Value = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;

            // Verificar si se seleccionó un producto
            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Validar formato del precio
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }

            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(txtcantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verificar si el producto ya existe en el DataGridView
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }
            if (!producto_existe)
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
        private void calculartotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
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

        private void dvgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /*
                        if (e.RowIndex < 0)
                            return;

                        if (e.ColumnIndex == 5)
                        {
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                            var w = Properties.Resources.delete25.Width;
                            var h = Properties.Resources.delete25.Height;
                            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                            e.Graphics.DrawImage(Properties.Resources.delete25, new Rectangle(x, y, w, h));
                            e.Handled = true;
                        } */
        }

        private void dvgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    dgvdata.Rows.RemoveAt(index);
                    calculartotal();
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
    }
}
