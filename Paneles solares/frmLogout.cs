using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paneles_solares
{
    public partial class frmLogout : Form
    {
        public frmLogout()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // Crear un FolderBrowserDialog para seleccionar la carpeta de destino
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccione la carpeta donde guardar el backup";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaDestino = folderDialog.SelectedPath;

                    // Validar que la ruta exista
                    if (!Directory.Exists(rutaDestino))
                    {
                        MessageBox.Show("La ruta seleccionada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Mostrar cursor de espera
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        string mensaje = string.Empty;
                        bool resultado = new CN_Backup().GenerarBackup(rutaDestino, out mensaje);

                        // Restaurar cursor
                        this.Cursor = Cursors.Default;

                        if (resultado)
                        {
                            MessageBox.Show(mensaje, "Backup Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Restaurar cursor en caso de error
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cerrar todos los formularios abiertos excepto el principal
                Application.Restart();
            }
        }
    }
}
