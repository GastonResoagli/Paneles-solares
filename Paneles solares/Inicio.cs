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
        //colores fields para hacerlo random
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

        //se ejecuta cuando carga el formulario principal
        private void Inicio_Load(object sender, EventArgs e)
        {
            //obtener la lista de permisos desde la capa negocio 
            List<Permiso> listaPermisos = new CN_Permiso().Listar(usuarioActual.idUsuario);

            //recorre los controles dentro del panel del menu 
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is Button boton)
                {
                    //verifica si el boton tiene permiso asociado en la lista de permiso
                    bool encontrado = listaPermisos.Any(p => p.NombreMenu == boton.Name);
                    if (!encontrado)
                    {
                        //si no esta lo oculta
                        boton.Visible = false;
                    }
                }
            }

            //usuario que inicio sesion 
            lblusuario.Text = usuarioActual.NombreCompleto;
        }

      //abre el formulario hijo dentro del contenedor principal 
        private void abrirFormulario(object sender, Form formulario)
        {
            //activa el boton seleccionado 
            ActivateButton(sender);

            //si hay un formulario abierto lo cierra 
            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }


            //pone el nuevo fomulario como activo
            FormularioActivo = formulario;
            formulario.TopLevel = false;  //evita que sea independiente
            formulario.FormBorderStyle = FormBorderStyle.None; //saca los bordes
            formulario.Dock = DockStyle.Fill; // ocupa el contenededor entero
            formulario.BackColor = Color.SteelBlue; //color de fondo

            //agrega al contenedor si existe o al formulario principal 
            if (contenedor != null)
                contenedor.Controls.Add(formulario);
            else
                this.Controls.Add(formulario);

            formulario.Show();
        }

        //colores de los botones

        private Color SelectThemeColor()
        {
            /*
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);*/

            string color = "#78CFE9";
            return ColorTranslator.FromHtml(color);
        }
        //cambia un boton al ser seleccionado 
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

        //Restaura el estilo visual de los botones cuando no estan activos 
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


        //metodos para abrir los formularios hijos
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



       
       
    }
}