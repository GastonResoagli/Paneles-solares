using System.Windows.Forms;

namespace Paneles_solares
{
    partial class inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.Logut = new System.Windows.Forms.Button();
            this.btnReportesAnaliticos = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.lblusuario = new System.Windows.Forms.Label();
            this.btnVentasD = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.contenedor = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(75)))));
            this.panelMenu.Controls.Add(this.Logut);
            this.panelMenu.Controls.Add(this.btnReportesAnaliticos);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.lblusuario);
            this.panelMenu.Controls.Add(this.btnVentasD);
            this.panelMenu.Controls.Add(this.btnVentas);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnClientes);
            this.panelMenu.Controls.Add(this.btnProductos);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(225, 718);
            this.panelMenu.TabIndex = 0;
            // 
            // Logut
            // 
            this.Logut.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logut.FlatAppearance.BorderSize = 0;
            this.Logut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logut.ForeColor = System.Drawing.Color.Gainsboro;
            this.Logut.Image = global::Paneles_solares.Properties.Resources.WhatsApp_Image_2025_11_03_at_14_33_59;
            this.Logut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Logut.Location = new System.Drawing.Point(0, 553);
            this.Logut.Name = "Logut";
            this.Logut.Size = new System.Drawing.Size(225, 93);
            this.Logut.TabIndex = 12;
            this.Logut.Text = "Logout";
            this.Logut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Logut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Logut.UseVisualStyleBackColor = true;
            this.Logut.Click += new System.EventHandler(this.btnReportesAnaliticos_Click);
            // 
            // btnReportesAnaliticos
            // 
            this.btnReportesAnaliticos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportesAnaliticos.FlatAppearance.BorderSize = 0;
            this.btnReportesAnaliticos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportesAnaliticos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportesAnaliticos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReportesAnaliticos.Image = global::Paneles_solares.Properties.Resources.grafico_de_barras;
            this.btnReportesAnaliticos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportesAnaliticos.Location = new System.Drawing.Point(0, 474);
            this.btnReportesAnaliticos.Name = "btnReportesAnaliticos";
            this.btnReportesAnaliticos.Size = new System.Drawing.Size(225, 79);
            this.btnReportesAnaliticos.TabIndex = 11;
            this.btnReportesAnaliticos.Text = "Reportes Analíticos";
            this.btnReportesAnaliticos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportesAnaliticos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportesAnaliticos.UseVisualStyleBackColor = true;
            this.btnReportesAnaliticos.Click += new System.EventHandler(this.Logut_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReportes.Image = global::Paneles_solares.Properties.Resources.grafico_de_barras;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(0, 395);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(225, 79);
            this.btnReportes.TabIndex = 10;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click_1);
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.ForeColor = System.Drawing.SystemColors.Control;
            this.lblusuario.Location = new System.Drawing.Point(76, 674);
            this.lblusuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(51, 13);
            this.lblusuario.TabIndex = 8;
            this.lblusuario.Text = "lblusuario";
            this.lblusuario.Click += new System.EventHandler(this.lblusuario_Click);
            // 
            // btnVentasD
            // 
            this.btnVentasD.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentasD.FlatAppearance.BorderSize = 0;
            this.btnVentasD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasD.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVentasD.Image = global::Paneles_solares.Properties.Resources.WhatsApp_Image_2025_11_03_at_14_34_00;
            this.btnVentasD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentasD.Location = new System.Drawing.Point(0, 316);
            this.btnVentasD.Name = "btnVentasD";
            this.btnVentasD.Size = new System.Drawing.Size(225, 79);
            this.btnVentasD.TabIndex = 5;
            this.btnVentasD.Text = "Ventas Detales";
            this.btnVentasD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentasD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVentasD.UseVisualStyleBackColor = true;
            this.btnVentasD.Click += new System.EventHandler(this.btnVentasD_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVentas.Image = global::Paneles_solares.Properties.Resources.carrito_de_compras;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 237);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(225, 79);
            this.btnVentas.TabIndex = 4;
            this.btnVentas.Text = " Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUsuarios.Image = global::Paneles_solares.Properties.Resources.avatar;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 158);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(225, 79);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click_1);
            // 
            // btnClientes
            // 
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClientes.Image = global::Paneles_solares.Properties.Resources.agregar_usuario;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 79);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(225, 79);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProductos.Image = global::Paneles_solares.Properties.Resources.panel_solar;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 0);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(225, 79);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click_1);
            // 
            // panelLogo
            // 
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(150, 81);
            this.panelLogo.TabIndex = 9;
            // 
            // contenedor
            // 
            this.contenedor.BackgroundImage = global::Paneles_solares.Properties.Resources.logo2;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(225, 0);
            this.contenedor.Margin = new System.Windows.Forms.Padding(2);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1013, 718);
            this.contenedor.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Paneles_solares.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(-44, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 86);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 718);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.panelMenu);
            this.Name = "inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnVentasD;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblusuario;
        private readonly PaintEventHandler panelLogo_Paint;
        private Panel contenedor;
        private Button btnReportesAnaliticos;
        private Button btnReportes;
        private Button Logut;
    }
}

