namespace Paneles_solares
{
    partial class frmReportesAnaliticos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVendedores = new System.Windows.Forms.TabPage();
            this.lblTotalVendedores = new System.Windows.Forms.Label();
            this.btnExportarVendedores = new System.Windows.Forms.Button();
            this.btnBuscarVendedores = new System.Windows.Forms.Button();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.dtpFechaFin1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.btnExportarProductos = new System.Windows.Forms.Button();
            this.btnBuscarProductos = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dtpFechaFin2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabClientes = new System.Windows.Forms.TabPage();
            this.lblTotalClientes = new System.Windows.Forms.Label();
            this.btnExportarClientes = new System.Windows.Forms.Button();
            this.btnBuscarClientes = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.dtpFechaFin3 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio3 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabVendedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.tabProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tabClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabVendedores);
            this.tabControl1.Controls.Add(this.tabProductos);
            this.tabControl1.Controls.Add(this.tabClientes);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1260, 600);
            this.tabControl1.TabIndex = 0;
            //
            // tabVendedores
            //
            this.tabVendedores.BackColor = System.Drawing.Color.White;
            this.tabVendedores.Controls.Add(this.lblTotalVendedores);
            this.tabVendedores.Controls.Add(this.btnExportarVendedores);
            this.tabVendedores.Controls.Add(this.btnBuscarVendedores);
            this.tabVendedores.Controls.Add(this.dgvVendedores);
            this.tabVendedores.Controls.Add(this.dtpFechaFin1);
            this.tabVendedores.Controls.Add(this.dtpFechaInicio1);
            this.tabVendedores.Controls.Add(this.label2);
            this.tabVendedores.Controls.Add(this.label1);
            this.tabVendedores.Location = new System.Drawing.Point(4, 24);
            this.tabVendedores.Name = "tabVendedores";
            this.tabVendedores.Padding = new System.Windows.Forms.Padding(3);
            this.tabVendedores.Size = new System.Drawing.Size(1252, 572);
            this.tabVendedores.TabIndex = 0;
            this.tabVendedores.Text = "Vendedores con Mayores Ventas";
            //
            // lblTotalVendedores
            //
            this.lblTotalVendedores.AutoSize = true;
            this.lblTotalVendedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVendedores.Location = new System.Drawing.Point(20, 540);
            this.lblTotalVendedores.Name = "lblTotalVendedores";
            this.lblTotalVendedores.Size = new System.Drawing.Size(200, 15);
            this.lblTotalVendedores.TabIndex = 7;
            this.lblTotalVendedores.Text = "Total Vendedores: 0";
            //
            // btnExportarVendedores
            //
            this.btnExportarVendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExportarVendedores.ForeColor = System.Drawing.Color.White;
            this.btnExportarVendedores.Location = new System.Drawing.Point(1090, 20);
            this.btnExportarVendedores.Name = "btnExportarVendedores";
            this.btnExportarVendedores.Size = new System.Drawing.Size(140, 30);
            this.btnExportarVendedores.TabIndex = 6;
            this.btnExportarVendedores.Text = "Exportar a Excel";
            this.btnExportarVendedores.UseVisualStyleBackColor = false;
            this.btnExportarVendedores.Click += new System.EventHandler(this.btnExportarVendedores_Click);
            //
            // btnBuscarVendedores
            //
            this.btnBuscarVendedores.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarVendedores.ForeColor = System.Drawing.Color.White;
            this.btnBuscarVendedores.Location = new System.Drawing.Point(500, 20);
            this.btnBuscarVendedores.Name = "btnBuscarVendedores";
            this.btnBuscarVendedores.Size = new System.Drawing.Size(100, 30);
            this.btnBuscarVendedores.TabIndex = 5;
            this.btnBuscarVendedores.Text = "Buscar";
            this.btnBuscarVendedores.UseVisualStyleBackColor = false;
            this.btnBuscarVendedores.Click += new System.EventHandler(this.btnBuscarVendedores_Click);
            //
            // dgvVendedores
            //
            this.dgvVendedores.AllowUserToAddRows = false;
            this.dgvVendedores.AllowUserToDeleteRows = false;
            this.dgvVendedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Location = new System.Drawing.Point(20, 70);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.Size = new System.Drawing.Size(1210, 450);
            this.dgvVendedores.TabIndex = 4;
            //
            // dtpFechaFin1
            //
            this.dtpFechaFin1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin1.Location = new System.Drawing.Point(330, 25);
            this.dtpFechaFin1.Name = "dtpFechaFin1";
            this.dtpFechaFin1.Size = new System.Drawing.Size(150, 21);
            this.dtpFechaFin1.TabIndex = 3;
            //
            // dtpFechaInicio1
            //
            this.dtpFechaInicio1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio1.Location = new System.Drawing.Point(110, 25);
            this.dtpFechaInicio1.Name = "dtpFechaInicio1";
            this.dtpFechaInicio1.Size = new System.Drawing.Size(150, 21);
            this.dtpFechaInicio1.TabIndex = 2;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio:";
            //
            // tabProductos
            //
            this.tabProductos.BackColor = System.Drawing.Color.White;
            this.tabProductos.Controls.Add(this.lblTotalProductos);
            this.tabProductos.Controls.Add(this.btnExportarProductos);
            this.tabProductos.Controls.Add(this.btnBuscarProductos);
            this.tabProductos.Controls.Add(this.dgvProductos);
            this.tabProductos.Controls.Add(this.dtpFechaFin2);
            this.tabProductos.Controls.Add(this.dtpFechaInicio2);
            this.tabProductos.Controls.Add(this.label3);
            this.tabProductos.Controls.Add(this.label4);
            this.tabProductos.Location = new System.Drawing.Point(4, 24);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(1252, 572);
            this.tabProductos.TabIndex = 1;
            this.tabProductos.Text = "Productos Más Vendidos";
            //
            // lblTotalProductos
            //
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.Location = new System.Drawing.Point(20, 540);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(200, 15);
            this.lblTotalProductos.TabIndex = 15;
            this.lblTotalProductos.Text = "Total Productos: 0";
            //
            // btnExportarProductos
            //
            this.btnExportarProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExportarProductos.ForeColor = System.Drawing.Color.White;
            this.btnExportarProductos.Location = new System.Drawing.Point(1090, 20);
            this.btnExportarProductos.Name = "btnExportarProductos";
            this.btnExportarProductos.Size = new System.Drawing.Size(140, 30);
            this.btnExportarProductos.TabIndex = 14;
            this.btnExportarProductos.Text = "Exportar a Excel";
            this.btnExportarProductos.UseVisualStyleBackColor = false;
            this.btnExportarProductos.Click += new System.EventHandler(this.btnExportarProductos_Click);
            //
            // btnBuscarProductos
            //
            this.btnBuscarProductos.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarProductos.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProductos.Location = new System.Drawing.Point(500, 20);
            this.btnBuscarProductos.Name = "btnBuscarProductos";
            this.btnBuscarProductos.Size = new System.Drawing.Size(100, 30);
            this.btnBuscarProductos.TabIndex = 13;
            this.btnBuscarProductos.Text = "Buscar";
            this.btnBuscarProductos.UseVisualStyleBackColor = false;
            this.btnBuscarProductos.Click += new System.EventHandler(this.btnBuscarProductos_Click);
            //
            // dgvProductos
            //
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(20, 70);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(1210, 450);
            this.dgvProductos.TabIndex = 12;
            //
            // dtpFechaFin2
            //
            this.dtpFechaFin2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin2.Location = new System.Drawing.Point(330, 25);
            this.dtpFechaFin2.Name = "dtpFechaFin2";
            this.dtpFechaFin2.Size = new System.Drawing.Size(150, 21);
            this.dtpFechaFin2.TabIndex = 11;
            //
            // dtpFechaInicio2
            //
            this.dtpFechaInicio2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio2.Location = new System.Drawing.Point(110, 25);
            this.dtpFechaInicio2.Name = "dtpFechaInicio2";
            this.dtpFechaInicio2.Size = new System.Drawing.Size(150, 21);
            this.dtpFechaInicio2.TabIndex = 10;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hasta:";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Inicio:";
            //
            // tabClientes
            //
            this.tabClientes.BackColor = System.Drawing.Color.White;
            this.tabClientes.Controls.Add(this.lblTotalClientes);
            this.tabClientes.Controls.Add(this.btnExportarClientes);
            this.tabClientes.Controls.Add(this.btnBuscarClientes);
            this.tabClientes.Controls.Add(this.dgvClientes);
            this.tabClientes.Controls.Add(this.dtpFechaFin3);
            this.tabClientes.Controls.Add(this.dtpFechaInicio3);
            this.tabClientes.Controls.Add(this.label5);
            this.tabClientes.Controls.Add(this.label6);
            this.tabClientes.Location = new System.Drawing.Point(4, 24);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.Size = new System.Drawing.Size(1252, 572);
            this.tabClientes.TabIndex = 2;
            this.tabClientes.Text = "Clientes con Mayor Compra";
            //
            // lblTotalClientes
            //
            this.lblTotalClientes.AutoSize = true;
            this.lblTotalClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClientes.Location = new System.Drawing.Point(20, 540);
            this.lblTotalClientes.Name = "lblTotalClientes";
            this.lblTotalClientes.Size = new System.Drawing.Size(200, 15);
            this.lblTotalClientes.TabIndex = 23;
            this.lblTotalClientes.Text = "Total Clientes: 0";
            //
            // btnExportarClientes
            //
            this.btnExportarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExportarClientes.ForeColor = System.Drawing.Color.White;
            this.btnExportarClientes.Location = new System.Drawing.Point(1090, 20);
            this.btnExportarClientes.Name = "btnExportarClientes";
            this.btnExportarClientes.Size = new System.Drawing.Size(140, 30);
            this.btnExportarClientes.TabIndex = 22;
            this.btnExportarClientes.Text = "Exportar a Excel";
            this.btnExportarClientes.UseVisualStyleBackColor = false;
            this.btnExportarClientes.Click += new System.EventHandler(this.btnExportarClientes_Click);
            //
            // btnBuscarClientes
            //
            this.btnBuscarClientes.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarClientes.ForeColor = System.Drawing.Color.White;
            this.btnBuscarClientes.Location = new System.Drawing.Point(500, 20);
            this.btnBuscarClientes.Name = "btnBuscarClientes";
            this.btnBuscarClientes.Size = new System.Drawing.Size(100, 30);
            this.btnBuscarClientes.TabIndex = 21;
            this.btnBuscarClientes.Text = "Buscar";
            this.btnBuscarClientes.UseVisualStyleBackColor = false;
            this.btnBuscarClientes.Click += new System.EventHandler(this.btnBuscarClientes_Click);
            //
            // dgvClientes
            //
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(20, 70);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.Size = new System.Drawing.Size(1210, 450);
            this.dgvClientes.TabIndex = 20;
            //
            // dtpFechaFin3
            //
            this.dtpFechaFin3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin3.Location = new System.Drawing.Point(330, 25);
            this.dtpFechaFin3.Name = "dtpFechaFin3";
            this.dtpFechaFin3.Size = new System.Drawing.Size(150, 21);
            this.dtpFechaFin3.TabIndex = 19;
            //
            // dtpFechaInicio3
            //
            this.dtpFechaInicio3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio3.Location = new System.Drawing.Point(110, 25);
            this.dtpFechaInicio3.Name = "dtpFechaInicio3";
            this.dtpFechaInicio3.Size = new System.Drawing.Size(150, 21);
            this.dtpFechaInicio3.TabIndex = 18;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Hasta:";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Fecha Inicio:";
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "Reportes Analíticos";
            //
            // frmReportesAnaliticos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 672);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportesAnaliticos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes Analíticos - Tablas Cruzadas";
            this.Load += new System.EventHandler(this.frmReportesAnaliticos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabVendedores.ResumeLayout(false);
            this.tabVendedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.tabProductos.ResumeLayout(false);
            this.tabProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tabClientes.ResumeLayout(false);
            this.tabClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVendedores;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.TabPage tabClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio1;
        private System.Windows.Forms.DateTimePicker dtpFechaFin1;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private System.Windows.Forms.Button btnBuscarVendedores;
        private System.Windows.Forms.Button btnExportarVendedores;
        private System.Windows.Forms.Label lblTotalVendedores;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Button btnExportarProductos;
        private System.Windows.Forms.Button btnBuscarProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DateTimePicker dtpFechaFin2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalClientes;
        private System.Windows.Forms.Button btnExportarClientes;
        private System.Windows.Forms.Button btnBuscarClientes;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DateTimePicker dtpFechaFin3;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
