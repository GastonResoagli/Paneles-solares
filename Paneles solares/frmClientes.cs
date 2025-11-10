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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        // Cuando se abre el formulario
        private void frmClientes_Load(object sender, EventArgs e)
        {
            // Carga opciones de estado (Activo / No Activo)
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            // Carga las columnas del DataGridView para usar en el buscador
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

            // Muestra todos los clientes guardados
            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                "",
                item.idCliente,
                item.DNI,
                item.Nombre,
                item.Correo,
                item.Telefono,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "No Activo"
            });
            }
        }

        // Botón Guardar (agregar o editar cliente)
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // -------- VALIDACIONES --------

            // DNI obligatorio
            if (string.IsNullOrWhiteSpace(txtdni.Text))
            {
                MessageBox.Show("Debe ingresar el DNI del cliente");
                txtdni.Focus();
                return;
            }

            // DNI solo números
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtdni.Text, @"^\d+$"))
            {
                MessageBox.Show("El DNI debe contener solo números");
                txtdni.Focus();
                return;
            }

            // DNI con 7 u 8 dígitos
            if (txtdni.Text.Length < 7 || txtdni.Text.Length > 8)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos");
                txtdni.Focus();
                return;
            }

            // DNI duplicado
            bool dniExiste = new CN_Cliente().Listar().Any(c =>
                c.DNI == txtdni.Text && c.idCliente != Convert.ToInt32(txtid.Text));

            if (dniExiste)
            {
                MessageBox.Show("Ya existe un cliente con ese DNI");
                txtdni.Focus();
                return;
            }

            // Nombre obligatorio
            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del cliente");
                txtnombre.Focus();
                return;
            }

            // Nombre solo letras
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtnombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre debe contener solo letras");
                txtnombre.Focus();
                return;
            }

            // Correo válido (si se ingresó)
            if (!string.IsNullOrWhiteSpace(txtcorreo.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtcorreo.Text,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("El formato del correo electrónico no es válido");
                    txtcorreo.Focus();
                    return;
                }
            }

            // Teléfono válido (si se ingresó)
            if (!string.IsNullOrWhiteSpace(txttelefono.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txttelefono.Text, @"^[\d\s\-\+\(\)]+$"))
                {
                    MessageBox.Show("El teléfono solo puede contener números y signos comunes (+, -, (), espacio)");
                    txttelefono.Focus();
                    return;
                }
            }

            // -------- CREAR OBJETO CLIENTE --------
            Cliente obj = new Cliente()
            {
                idCliente = Convert.ToInt32(txtid.Text),
                DNI = txtdni.Text.Trim(),
                Nombre = txtnombre.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            // -------- NUEVO CLIENTE --------
            if (obj.idCliente == 0)
            {
                int idgenerado = new CN_Cliente().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    // Agrega nuevo cliente al DataGridView
                    dgvdata.Rows.Add(new object[] {
                    "",
                    idgenerado,
                    txtdni.Text,
                    txtnombre.Text,
                    txtcorreo.Text,
                    txttelefono.Text,
                    ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboestado.SelectedItem).Texto.ToString()
                });
                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            // -------- EDITAR CLIENTE --------
            else
            {
                bool resultado = new CN_Cliente().Editar(obj, out mensaje);

                if (resultado)
                {
                    // Actualiza la fila seleccionada
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idCliente"].Value = txtid.Text;
                    row.Cells["DNI"].Value = txtdni.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;
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
            txtdni.Text = "";
            txtnombre.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cboestado.SelectedIndex = 0;
            txtdni.Select();
        }

        // Dibuja el ícono del botón seleccionar en la grilla
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

        // Cargar datos del cliente seleccionado
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["idCliente"].Value.ToString();
                    txtdni.Text = dgvdata.Rows[indice].Cells["DNI"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value.ToString();

                    // Selecciona el estado correcto en el combo
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if ((oc.Texto == dgvdata.Rows[indice].Cells["EstadoValor"].Value.ToString()))
                        {
                            cboestado.SelectedIndex = cboestado.Items.IndexOf(oc);
                            break;
                        }
                    }
                }
            }
        }

        // Botón eliminar cliente
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente obj = new Cliente() { idCliente = Convert.ToInt32(txtid.Text) };

                    // Elimina el cliente
                    bool respuesta = new CN_Cliente().Eliminar(obj, out mensaje);
                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        // Buscar cliente
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

        // Limpiar campo de búsqueda
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
