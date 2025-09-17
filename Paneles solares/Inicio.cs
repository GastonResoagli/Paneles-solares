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
    public partial class inicio : Form
    {
        //colores fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        //user
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form FormularioActivo = null;
        public inicio(Usuario objusuario)
        {

            usuarioActual = objusuario;
            InitializeComponent();
            random = new Random();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = new CN_Permiso().Listar(usuarioActual.idUsuario);

            foreach (Control ctrl in panelMenu.Controls)
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

        private void abrirFormulario(object sender, Form formulario)
        {

            ActivateButton(sender);

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
        //colores de los botones

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisabledButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DisabledButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            abrirFormulario(sender, new frmUsuarios());
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            
            abrirFormulario(sender, new frmProductos());
           
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
          
            abrirFormulario(sender, new frmClientes());
            
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
           
            abrirFormulario(sender, new frmVentas());
           
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
          
            abrirFormulario(sender, new frmReportes());
           
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {

            abrirFormulario(sender, new frmConfig());
            
        }


       
       
    }
}