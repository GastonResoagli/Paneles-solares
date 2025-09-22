using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace Paneles_solares
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //evento boton ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
        
            // Validar que los campos no esten vacios
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Por favor ingrese su documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor ingrese su clave", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            // Validar condiciones personalizadas
            // Por ejemplo: que el documento tenga al menos 7 dígitos
            if (txtDocumento.Text.Length < 7)
            {
                MessageBox.Show("El documento debe tener al menos 7 números", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            // Que la clave tenga al menos 4 caracteres
            if (txtClave.Text.Length < 4)
            {
                MessageBox.Show("La clave debe tener al menos 4 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            // Si paso las validaciones, recién ahi consulta la base de datos
            Usuario ousuario = new CN_Usuario().Listar()
                                .Where(u => u.DNI == txtDocumento.Text && u.Clave == txtClave.Text)
                                .FirstOrDefault();

            if (ousuario != null)
            {
                inicio form = new inicio(ousuario);

                form.Show();
                this.Hide();

                form.FormClosing += frm_clossing;
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrectos", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        

        //evento que se ejecuta cuando se cierra el formulario principal
        private void frm_clossing(object sender, FormClosingEventArgs e)
        {

            txtDocumento.Text = "";
            txtClave.Text = "";

            this.Show();
        }

        //evento boton cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
