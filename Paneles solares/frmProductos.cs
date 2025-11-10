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

namespace Paneles_solares
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        // Al cargar el formulario
        private void frmProductos_Load(object sender, EventArgs e)
        {
            // Carga opciones del combo ESTADO
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            // Carga las categorías desde la base de datos
            List<Categoria> listacategoria = new CN_Categoria().Listar();
            foreach (Categoria item in listacategoria)
            {
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.idCategoria, Texto = item.Descripcion });
            }
            cbocategoria.DisplayMember = "Texto";
            cbocategoria.ValueMember = "Valor";

            // Carga las columnas para la búsqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            // Muestra todos los productos de la base de datos
            List<Producto> lista = new CN_Producto().Listar();
            foreach (Producto item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                "",
                item.idProducto,
                item.Codigo,
                item.Nombre,
                item.Descripcion,
                item.oCategoria.idCategoria,
                item.oCategoria.Descripcion,
                item.Stock,
                "",
                item.PrecioVenta,
                item.Estado == true ? "Activo" : "No Activo",
                item.Estado == true ? 1 : 0
            });
            }
        }

        // Botón Guardar (Registrar o Editar producto)
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            int stock;
            decimal precioVenta;

            // Validaciones simples
            if (!int.TryParse(txtstock.Text, out stock))
            {
                MessageBox.Show("Stock inválido"); return;
            }
            if (!decimal.TryParse(txtprecioventa.Text, out precioVenta))
            {
                MessageBox.Show("Precio de venta inválido"); return;
            }

            // Crea un objeto Producto con los datos del formulario
            Producto obj = new Producto()
            {
                idProducto = Convert.ToInt32(txtid.Text),
                Codigo = txtcodigo.Text,
                Nombre = txtnombre.Text,
                Descripcion = txtdescripcion.Text,
                oCategoria = new Categoria() { idCategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor) },
                Stock = stock,
                PrecioVenta = precioVenta,
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            // Si es nuevo producto
            if (obj.idProducto == 0)
            {
                int IdGenerado = new CN_Producto().Registrar(obj, out mensaje);

                if (IdGenerado != 0)
                {
                    // Agrega el nuevo producto al DataGridView
                    dgvdata.Rows.Add(new object[] {
                    "",
                    IdGenerado,
                    txtcodigo.Text,
                    txtnombre.Text,
                    txtdescripcion.Text,
                    ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString(),
                    txtstock.Text,
                    "",
                    txtprecioventa.Text,
                    ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
                    ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                });
                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                // Si se está editando un producto existente
                bool resultado = new CN_Producto().Editar(obj, out mensaje);

                if (resultado)
                {
                    // Actualiza los datos en la grilla
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idProducto"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["idCategoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString();
                    row.Cells["Stock"].Value = txtstock.Text;
                    row.Cells["PrecioVenta"].Value = txtprecioventa.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();
                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        // Limpia los campos del formulario
        private void limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            txtstock.Clear();
            txtprecioventa.Clear();
            cbocategoria.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;
        }

        // Dibuja el icono en la primera columna (botón seleccionar)
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.gg.Width;
                var h = Properties.Resources.gg.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - w) / 2;

                e.Graphics.DrawImage(Properties.Resources.gg, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        // Cargar los datos del producto seleccionado en los campos
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    // Carga los datos en los campos
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["idProducto"].Value.ToString();
                    txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txtstock.Text = dgvdata.Rows[indice].Cells["Stock"].Value.ToString();
                    txtprecioventa.Text = dgvdata.Rows[indice].Cells["PrecioVenta"].Value.ToString();

                    // Selecciona la categoría correcta en el combo
                    foreach (OpcionCombo oc in cbocategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["idCategoria"].Value))
                        {
                            cbocategoria.SelectedIndex = cbocategoria.Items.IndexOf(oc);
                            break;
                        }
                    }

                    // Selecciona el estado correcto en el combo
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            cboestado.SelectedIndex = cboestado.Items.IndexOf(oc);
                            break;
                        }
                    }
                }
            }
        }

        // Botón eliminar producto
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto obj = new Producto()
                    {
                        idProducto = Convert.ToInt32(txtid.Text)
                    };

                    // Elimina el producto
                    bool respuesta = new CN_Producto().Eliminar(obj, out mensaje);
                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(dgvdata.CurrentRow.Index);
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        // Buscar producto en la tabla
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        // Limpia el campo de búsqueda
        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        // Botón limpiar formulario
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}