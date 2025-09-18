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

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            List<Usuario> Test = new CN_Usuario().Listar();


            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.DNI == txtDocumento.Text && u.Clave == txtClave.Text).FirstOrDefault();

            //

            if(ousuario != null)
            {
               inicio form = new inicio(ousuario);


                form.Show();
                this.Hide();

                form.FormClosing += frm_clossing;
            }
            else
            {
                MessageBox.Show("no se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        
        }

        private void frm_clossing(object sender, FormClosingEventArgs e)
        {

            txtDocumento.Text = "";
            txtClave.Text = "";

            this.Show();
        }

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
    }
}
