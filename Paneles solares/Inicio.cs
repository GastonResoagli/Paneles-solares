using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;


using CapaEntidad;
using CapaNegocio;

namespace Paneles_solares
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form FormularioActivo = null;
        public Inicio(Usuario objusuario)
        {
            usuarioActual = objusuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = new CN_Permiso().Listar(usuarioActual.idUsuario);

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button boton)
                {
                    bool encontrado = listaPermisos.Any(p => p.NombreMenu == boton.Name);
                    if (!encontrado)
                    {
                        boton.Visible = false;
                    }
                }
            }


            lblusuario.Text = usuarioActual.NombreCompleto;
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {

        }

        /*
        private void abrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }

            if (menu != null)  // Evita error cuando es un Button
            {
                menu.BackColor = Color.Silver;
                menuActivo = menu;
            }

            menu.BackColor = Color.Silver;
            menuActivo = menu; 

            if(FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        } */

        private void abrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }

            if (menu != null)
            {
                menu.BackColor = Color.Silver;
                menuActivo = menu;
            }

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            if (contenedor != null)
                contenedor.Controls.Add(formulario);
            else
                this.Controls.Add(formulario);

            formulario.Show();
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            abrirFormulario(null, new frmUsuarios());
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            abrirFormulario(null, new frmProductos());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            abrirFormulario(null, new frmClientes());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            abrirFormulario(null, new frmVentas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            abrirFormulario(null, new frmReportes());
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            abrirFormulario(null, new frmConfig());
        }
    }
}