using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paneles_solares.Utilidad;
using CapaEntidad;
using CapaNegocio;

namespace Paneles_solares
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        //evento para insertar y editar usuarios
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // Validar que la contraseña no esté vacia y tenga mas de 4 caracteres
            if (string.IsNullOrWhiteSpace(txtclave.Text) || txtclave.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtclave.Focus();
                return;
            }

            // Validar que coincidan las contraseñas
            if (txtclave.Text != txtconfclave.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtconfclave.Focus();
                return;
            }

            // Validar otros campos obligatorios
            if (string.IsNullOrWhiteSpace(txtdocumento.Text) ||
                string.IsNullOrWhiteSpace(txtnombrecompleto.Text) ||
                string.IsNullOrWhiteSpace(txtcorreo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Armar el objeto usuario
            Usuario objusuario = new Usuario()
            {
                idUsuario = Convert.ToInt32(txtid.Text),
                DNI = txtdocumento.Text,
                NombreCompleto = txtnombrecompleto.Text,
                Correo = txtcorreo.Text,
                Clave = txtclave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            // 5. Insertar o editar segun corresponda
            if (objusuario.idUsuario == 0)
            {
                int IdUsuarioGenerado = new CN_Usuario().Registrar(objusuario, out mensaje);

                if (IdUsuarioGenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {
                "", IdUsuarioGenerado, txtdocumento.Text, txtnombrecompleto.Text, txtcorreo.Text, txtclave.Text,
                ((OpcionCombo)cborol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cborol.SelectedItem).Texto.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
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
                bool resultado = new CN_Usuario().Editar(objusuario, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idUsuario"].Value = txtid.Text;
                    row.Cells["DNI"].Value = txtdocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtnombrecompleto.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Clave"].Value = txtclave.Text;
                    row.Cells["idRol"].Value = ((OpcionCombo)cborol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cborol.SelectedItem).Texto.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();

                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }
        
        
        //limpia los campos del formulario
                private void limpiar()
                {
                    txtindice.Text = "-1";
                    txtid.Text = "";
                    txtdocumento.Text = "";
                    txtnombrecompleto.Text = "";
                    txtcorreo.Text = "";
                    txtclave.Text = "";
                    txtconfclave.Text = "";
                    cborol.SelectedIndex = 0;
                    cboestado.SelectedIndex = 0;
                }

       

        //evento para cargar el formulario
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // Se cargan las opciones de ESTADO
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            // Se cargan los roles desde la capa de negocio
            List<Rol> listaRol = new CN_Rol().Listar();
            foreach (Rol item in listaRol) {
                cborol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion});
            }
            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            cborol.SelectedIndex = 0;

            // Se cargan las columnas disponibles para busqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns) {
            if(columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
              }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;


            //mostrar todos los usuarios de la DB
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvdata.Rows.Add(new object[] { "", item.idUsuario,item.DNI,item.NombreCompleto, item.Correo, item.Clave,
                    item.oRol.IdRol,
                    item.oRol.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"
            });
            }

        }

        //dibuja un icono en el datagrid
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if(e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.gg.Width;
                var h = Properties.Resources.gg.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - w) / 2;

                e.Graphics.DrawImage(Properties.Resources.gg, new Rectangle(x,y,w,h));
                e.Handled = true;
            }
        }
        //evento para la columna seleccionar del datagrid
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if(indice >= 0)
                {
                    // Se cargan los valores de la fila seleccionada en los campos de edicion
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["idUsuario"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["DNI"].Value.ToString();
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtconfclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    // Selecciona el rol correcto en el combo
                    foreach (OpcionCombo oc in cborol.Items)
                    {
                        if (Convert.ToInt32 (oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["idRol"].Value))
                        {
                            int indice_combo = cborol.Items.IndexOf(oc);
                            cborol.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    // Selecciona el estado correcto en el combo
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["Estado"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }


                }
            }
        }
        //evento para eliminar usuario
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtid.Text) != 0)
            {
                if(MessageBox.Show("¿Desea eliminar el usuario?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {
                        idUsuario = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Usuario().Eliminar(objusuario, out mensaje);
                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(dgvdata.CurrentRow.Index); //sin txtindice
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        //boton buscar en el datagrid
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
        //limpia el buscador del datagrid
        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
        //limpia los campos del formulario
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtdocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtcorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            // Permitir control (ej. borrar, tab, enter)
            if (char.IsControl(c))
            {
                e.Handled = false;
                return;
            }

            // Permitir letras, números y caracteres especiales tipicos del correo
            if (char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // Bloquea todo lo demas
            }
        }
    }
}
