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
            //trae todos los usuarios de la base de datos
            List<Usuario> Test = new CN_Usuario().Listar();

            //busca ek usuario que coincide con las credenciales ingresadas
            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.DNI == txtDocumento.Text && u.Clave == txtClave.Text).FirstOrDefault();

            //si encuntra el usuario valido

            if(ousuario != null)
            {

                //abre el fomulario principal
               inicio form = new inicio(ousuario);


                form.Show(); //muestra el formulario principal
                this.Hide(); //oculta el login

                form.FormClosing += frm_clossing;
            }
            else
            {
                //cuando cierre el formulario principal volver al login
                MessageBox.Show("no se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
