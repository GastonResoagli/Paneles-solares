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

        // Constructor: recibe el usuario que inició sesión
        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        // carga el formulario
        private void frmVentas_Load(object sender, EventArgs e)
        {
            // Carga los tipos de documento (boleta o factura)
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            // Inicializa campos
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";
            txtpagocon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";

            // No permite agregar filas manualmente
            dgvdata.AllowUserToAddRows = false;
        }

        // Buscar cliente
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Carga los datos del cliente 
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

        // Buscar cliente
        private void txtDocumentocliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                // Busca el cliente en la base de datos
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

        // Buscar producto
        private void iconButton1_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Verifica que el producto esté activo
                    if (!modal._Producto.Estado)
                    {
                        MessageBox.Show("El producto está inactivo", "Producto inactivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarProducto();
                        txtCodigoproducto.Select();
                        return;
                    }

                    // Carga los datos del producto
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

        // Buscar producto por codigo
        private void txtCodigoproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                // Busca el producto por código
                Producto oProducto = new CN_Producto()
                    .Listar()
                    .FirstOrDefault(p => p.Codigo == txtCodigoproducto.Text);

                if (oProducto != null)
                {
                    if (!oProducto.Estado)
                    {
                        txtCodigoproducto.BackColor = Color.MistyRose;
                        MessageBox.Show("El producto está inactivo", "Producto inactivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        // Agregar producto al detalle
        private void button1_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verifica que el producto siga activo
            int idProd = Convert.ToInt32(txtidproducto.Text);
            var prod = new CN_Producto().Listar().FirstOrDefault(p => p.idProducto == idProd);
            if (prod == null || !prod.Estado)
            {
                MessageBox.Show("El producto está inactivo", "Producto inactivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verifica que el precio sea correcto
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }

            // Verifica stock
            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(txtcantidad.Value))
            {
                MessageBox.Show("Cantidad mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verifica si el producto ya está en la lista
            DataGridViewRow filaExistente = null;
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["idProducto"].Value != null && fila.Cells["idProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    filaExistente = fila;
                    break;
                }
            }

            if (producto_existe)
            {
                // Si ya está, suma la cantidad
                int cantidadActual = Convert.ToInt32(filaExistente.Cells["Cantidad"].Value);
                int nuevaCantidad = cantidadActual + Convert.ToInt32(txtcantidad.Value);

                // Verifica que no pase el stock
                if (nuevaCantidad > Convert.ToInt32(txtStock.Text) + cantidadActual)
                {
                    MessageBox.Show("Cantidad total supera stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Resta stock en la base
                bool respuesta = new CN_Venta().RestarStock(
                    Convert.ToInt32(txtidproducto.Text),
                    Convert.ToInt32(txtcantidad.Value)
                );

                if (respuesta)
                {
                    filaExistente.Cells["Cantidad"].Value = nuevaCantidad.ToString();
                    filaExistente.Cells["SubTotal"].Value = (nuevaCantidad * precio).ToString("0.00");
                    calculartotal();
                    LimpiarProducto();
                    txtCodigoproducto.Select();
                }
            }
            else
            {
                // Si no está, lo agrega nuevo
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

        // Calcula el total a pagar
        private void calculartotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["SubTotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            txttotalpagar.Text = total.ToString("0.00");
        }

        // Limpia los campos del producto
        private void LimpiarProducto()
        {
            txtidproducto.Text = "0";
            txtCodigoproducto.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtcantidad.Value = 1;
        }

        // Dibuja el ícono del botón eliminar en la grilla
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

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

        // Eliminar producto del detalle
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    // Devuelve el stock y borra la fila
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

        // Solo permite números y punto en el campo precio
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) e.Handled = false;
            else if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".") e.Handled = true;
            else if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".") e.Handled = false;
            else e.Handled = true;
        }

        // Solo permite números y punto en el campo Paga con
        private void txtpagocon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) e.Handled = false;
            else if (txtpagocon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".") e.Handled = true;
            else if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".") e.Handled = false;
            else e.Handled = true;
        }

        // Calcula el cambio
        private void calcularcambio()
        {
            if (txttotalpagar.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagocon = 0;
            decimal total = Convert.ToDecimal(txttotalpagar.Text);

            if (txtpagocon.Text.Trim() == "") txtpagocon.Text = "0";

            if (decimal.TryParse(txtpagocon.Text.Trim(), out pagocon))
            {
                if (pagocon < total) txtcambio.Text = "0.00";
                else txtcambio.Text = (pagocon - total).ToString("0.00");
            }
        }

        // Calcula el cambio al presionar Enter
        private void txtpagocon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularcambio();
            }
        }


        // Evento del botón "Guardar venta"
        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica que se haya ingresado el documento del cliente
            if (txtDocumentocliente.Text == "")
            {
                MessageBox.Show("Ingrese el documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDocumentocliente.Focus();
                return;
            }

            // Verifica que se haya ingresado el nombre del cliente
            if (nombreCliente.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nombreCliente.Focus();
                return;
            }

            // Verifica que haya productos cargados en la venta
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Ingrese los productos a la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Crea una tabla para guardar el detalle de los productos vendidos
            DataTable detalle_venta = new DataTable();
            detalle_venta.Columns.Add("idProducto", typeof(string));
            detalle_venta.Columns.Add("Precioventa", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal", typeof(decimal));

            // Agrega los productos del DataGridView a la tabla
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

            // Obtiene el número de venta correlativo (automático)
            int idcorrelativo = new CN_Venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);
            calcularcambio(); // Calcula el vuelto

            // Crea el objeto venta con todos los datos
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
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text),
                FechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            };

            // Guarda la venta en la base de datos
            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oVenta, detalle_venta, out mensaje);

            // Si se guardó correctamente
            if (respuesta)
            {
                // Muestra el número de venta y pregunta si se quiere copiar
                var result = MessageBox.Show("Número de venta generada:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?",
                    "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numeroDocumento);
                }

                // Limpia los campos del formulario
                txtDocumentocliente.Text = "";
                nombreCliente.Text = "";
                dgvdata.Rows.Clear();
                calculartotal();
                txtpagocon.Text = "";
                txtcambio.Text = "";
            }
            else
            {
                // Si hubo un error, muestra el mensaje
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
