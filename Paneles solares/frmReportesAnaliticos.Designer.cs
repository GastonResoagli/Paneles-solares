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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVendedores = new System.Windows.Forms.TabPage();
            this.panelVendedores = new System.Windows.Forms.Panel();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.panelTotalesVendedores = new System.Windows.Forms.Panel();
            this.lblTotalVendedores = new System.Windows.Forms.Label();
            this.panelFiltrosVendedores = new System.Windows.Forms.Panel();
            this.btnExportarVendedores = new System.Windows.Forms.Button();
            this.btnBuscarVendedores = new System.Windows.Forms.Button();
            this.dtpFechaFin1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.panelTotalesProductos = new System.Windows.Forms.Panel();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.panelFiltrosProductos = new System.Windows.Forms.Panel();
            this.btnExportarProductos = new System.Windows.Forms.Button();
            this.btnBuscarProductos = new System.Windows.Forms.Button();
            this.dtpFechaFin2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabClientes = new System.Windows.Forms.TabPage();
            this.panelClientes = new System.Windows.Forms.Panel();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.panelTotalesClientes = new System.Windows.Forms.Panel();
            this.lblTotalClientes = new System.Windows.Forms.Label();
            this.panelFiltrosClientes = new System.Windows.Forms.Panel();
            this.btnExportarClientes = new System.Windows.Forms.Button();
            this.btnBuscarClientes = new System.Windows.Forms.Button();
            this.dtpFechaFin3 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio3 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabVendedores.SuspendLayout();
            this.panelVendedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.panelTotalesVendedores.SuspendLayout();
            this.panelFiltrosVendedores.SuspendLayout();
            this.tabProductos.SuspendLayout();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panelTotalesProductos.SuspendLayout();
            this.panelFiltrosProductos.SuspendLayout();
            this.tabClientes.SuspendLayout();
            this.panelClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.panelTotalesClientes.SuspendLayout();
            this.panelFiltrosClientes.SuspendLayout();
            this.SuspendLayout();
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 26);
            this.label7.TabIndex = 1;
            this.label7.Text = "Reportes Analíticos";
            //
            // tabControl1
            //
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabVendedores);
            this.tabControl1.Controls.Add(this.tabProductos);
            this.tabControl1.Controls.Add(this.tabClientes);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(20, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(970, 565);
            this.tabControl1.TabIndex = 0;
            //
            // tabVendedores
            //
            this.tabVendedores.BackColor = System.Drawing.Color.White;
            this.tabVendedores.Controls.Add(this.panelVendedores);
            this.tabVendedores.Controls.Add(this.panelTotalesVendedores);
            this.tabVendedores.Controls.Add(this.panelFiltrosVendedores);
            this.tabVendedores.Location = new System.Drawing.Point(4, 25);
            this.tabVendedores.Name = "tabVendedores";
            this.tabVendedores.Padding = new System.Windows.Forms.Padding(3);
            this.tabVendedores.Size = new System.Drawing.Size(962, 536);
            this.tabVendedores.TabIndex = 0;
            this.tabVendedores.Text = "Vendedores con Mayores Ventas";
            //
            // panelVendedores
            //
            this.panelVendedores.Controls.Add(this.dgvVendedores);
            this.panelVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVendedores.Location = new System.Drawing.Point(3, 63);
            this.panelVendedores.Name = "panelVendedores";
            this.panelVendedores.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.panelVendedores.Size = new System.Drawing.Size(956, 425);
            this.panelVendedores.TabIndex = 2;
            //
            // dgvVendedores
            //
            this.dgvVendedores.AllowUserToAddRows = false;
            this.dgvVendedores.AllowUserToDeleteRows = false;
            this.dgvVendedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendedores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedores.EnableHeadersVisualStyles = false;
            this.dgvVendedores.Location = new System.Drawing.Point(10, 10);
            this.dgvVendedores.MultiSelect = false;
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.RowHeadersWidth = 51;
            this.dgvVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedores.Size = new System.Drawing.Size(936, 410);
            this.dgvVendedores.TabIndex = 4;
            //
            // panelTotalesVendedores
            //
            this.panelTotalesVendedores.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTotalesVendedores.Controls.Add(this.lblTotalVendedores);
            this.panelTotalesVendedores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTotalesVendedores.Location = new System.Drawing.Point(3, 488);
            this.panelTotalesVendedores.Name = "panelTotalesVendedores";
            this.panelTotalesVendedores.Padding = new System.Windows.Forms.Padding(10);
            this.panelTotalesVendedores.Size = new System.Drawing.Size(956, 45);
            this.panelTotalesVendedores.TabIndex = 1;
            //
            // lblTotalVendedores
            //
            this.lblTotalVendedores.AutoSize = true;
            this.lblTotalVendedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVendedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalVendedores.Location = new System.Drawing.Point(13, 13);
            this.lblTotalVendedores.Name = "lblTotalVendedores";
            this.lblTotalVendedores.Size = new System.Drawing.Size(166, 17);
            this.lblTotalVendedores.TabIndex = 7;
            this.lblTotalVendedores.Text = "Total Vendedores: 0";
            //
            // panelFiltrosVendedores
            //
            this.panelFiltrosVendedores.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltrosVendedores.Controls.Add(this.btnExportarVendedores);
            this.panelFiltrosVendedores.Controls.Add(this.btnBuscarVendedores);
            this.panelFiltrosVendedores.Controls.Add(this.dtpFechaFin1);
            this.panelFiltrosVendedores.Controls.Add(this.dtpFechaInicio1);
            this.panelFiltrosVendedores.Controls.Add(this.label2);
            this.panelFiltrosVendedores.Controls.Add(this.label1);
            this.panelFiltrosVendedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltrosVendedores.Location = new System.Drawing.Point(3, 3);
            this.panelFiltrosVendedores.Name = "panelFiltrosVendedores";
            this.panelFiltrosVendedores.Padding = new System.Windows.Forms.Padding(10);
            this.panelFiltrosVendedores.Size = new System.Drawing.Size(956, 60);
            this.panelFiltrosVendedores.TabIndex = 0;
            //
            // btnExportarVendedores
            //
            this.btnExportarVendedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarVendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnExportarVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarVendedores.ForeColor = System.Drawing.Color.White;
            this.btnExportarVendedores.Location = new System.Drawing.Point(806, 18);
            this.btnExportarVendedores.Name = "btnExportarVendedores";
            this.btnExportarVendedores.Size = new System.Drawing.Size(130, 28);
            this.btnExportarVendedores.TabIndex = 6;
            this.btnExportarVendedores.Text = "Exportar a Excel";
            this.btnExportarVendedores.UseVisualStyleBackColor = false;
            this.btnExportarVendedores.Click += new System.EventHandler(this.btnExportarVendedores_Click);
            //
            // btnBuscarVendedores
            //
            this.btnBuscarVendedores.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarVendedores.ForeColor = System.Drawing.Color.White;
            this.btnBuscarVendedores.Location = new System.Drawing.Point(470, 18);
            this.btnBuscarVendedores.Name = "btnBuscarVendedores";
            this.btnBuscarVendedores.Size = new System.Drawing.Size(90, 28);
            this.btnBuscarVendedores.TabIndex = 5;
            this.btnBuscarVendedores.Text = "Buscar";
            this.btnBuscarVendedores.UseVisualStyleBackColor = false;
            this.btnBuscarVendedores.Click += new System.EventHandler(this.btnBuscarVendedores_Click);
            //
            // dtpFechaFin1
            //
            this.dtpFechaFin1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin1.Location = new System.Drawing.Point(310, 21);
            this.dtpFechaFin1.Name = "dtpFechaFin1";
            this.dtpFechaFin1.Size = new System.Drawing.Size(140, 22);
            this.dtpFechaFin1.TabIndex = 3;
            //
            // dtpFechaInicio1
            //
            this.dtpFechaInicio1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio1.Location = new System.Drawing.Point(100, 21);
            this.dtpFechaInicio1.Name = "dtpFechaInicio1";
            this.dtpFechaInicio1.Size = new System.Drawing.Size(140, 22);
            this.dtpFechaInicio1.TabIndex = 2;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio:";
            //
            // tabProductos
            //
            this.tabProductos.BackColor = System.Drawing.Color.White;
            this.tabProductos.Controls.Add(this.panelProductos);
            this.tabProductos.Controls.Add(this.panelTotalesProductos);
            this.tabProductos.Controls.Add(this.panelFiltrosProductos);
            this.tabProductos.Location = new System.Drawing.Point(4, 25);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(962, 536);
            this.tabProductos.TabIndex = 1;
            this.tabProductos.Text = "Productos Más Vendidos";
            //
            // panelProductos
            //
            this.panelProductos.Controls.Add(this.dgvProductos);
            this.panelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductos.Location = new System.Drawing.Point(3, 63);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.panelProductos.Size = new System.Drawing.Size(956, 425);
            this.panelProductos.TabIndex = 5;
            //
            // dgvProductos
            //
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(10, 10);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(936, 410);
            this.dgvProductos.TabIndex = 12;
            //
            // panelTotalesProductos
            //
            this.panelTotalesProductos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTotalesProductos.Controls.Add(this.lblTotalProductos);
            this.panelTotalesProductos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTotalesProductos.Location = new System.Drawing.Point(3, 488);
            this.panelTotalesProductos.Name = "panelTotalesProductos";
            this.panelTotalesProductos.Padding = new System.Windows.Forms.Padding(10);
            this.panelTotalesProductos.Size = new System.Drawing.Size(956, 45);
            this.panelTotalesProductos.TabIndex = 4;
            //
            // lblTotalProductos
            //
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalProductos.Location = new System.Drawing.Point(13, 13);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(155, 17);
            this.lblTotalProductos.TabIndex = 15;
            this.lblTotalProductos.Text = "Total Productos: 0";
            //
            // panelFiltrosProductos
            //
            this.panelFiltrosProductos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltrosProductos.Controls.Add(this.btnExportarProductos);
            this.panelFiltrosProductos.Controls.Add(this.btnBuscarProductos);
            this.panelFiltrosProductos.Controls.Add(this.dtpFechaFin2);
            this.panelFiltrosProductos.Controls.Add(this.dtpFechaInicio2);
            this.panelFiltrosProductos.Controls.Add(this.label3);
            this.panelFiltrosProductos.Controls.Add(this.label4);
            this.panelFiltrosProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltrosProductos.Location = new System.Drawing.Point(3, 3);
            this.panelFiltrosProductos.Name = "panelFiltrosProductos";
            this.panelFiltrosProductos.Padding = new System.Windows.Forms.Padding(10);
            this.panelFiltrosProductos.Size = new System.Drawing.Size(956, 60);
            this.panelFiltrosProductos.TabIndex = 3;
            //
            // btnExportarProductos
            //
            this.btnExportarProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnExportarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarProductos.ForeColor = System.Drawing.Color.White;
            this.btnExportarProductos.Location = new System.Drawing.Point(806, 18);
            this.btnExportarProductos.Name = "btnExportarProductos";
            this.btnExportarProductos.Size = new System.Drawing.Size(130, 28);
            this.btnExportarProductos.TabIndex = 14;
            this.btnExportarProductos.Text = "Exportar a Excel";
            this.btnExportarProductos.UseVisualStyleBackColor = false;
            this.btnExportarProductos.Click += new System.EventHandler(this.btnExportarProductos_Click);
            //
            // btnBuscarProductos
            //
            this.btnBuscarProductos.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProductos.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProductos.Location = new System.Drawing.Point(470, 18);
            this.btnBuscarProductos.Name = "btnBuscarProductos";
            this.btnBuscarProductos.Size = new System.Drawing.Size(90, 28);
            this.btnBuscarProductos.TabIndex = 13;
            this.btnBuscarProductos.Text = "Buscar";
            this.btnBuscarProductos.UseVisualStyleBackColor = false;
            this.btnBuscarProductos.Click += new System.EventHandler(this.btnBuscarProductos_Click);
            //
            // dtpFechaFin2
            //
            this.dtpFechaFin2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin2.Location = new System.Drawing.Point(310, 21);
            this.dtpFechaFin2.Name = "dtpFechaFin2";
            this.dtpFechaFin2.Size = new System.Drawing.Size(140, 22);
            this.dtpFechaFin2.TabIndex = 11;
            //
            // dtpFechaInicio2
            //
            this.dtpFechaInicio2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio2.Location = new System.Drawing.Point(100, 21);
            this.dtpFechaInicio2.Name = "dtpFechaInicio2";
            this.dtpFechaInicio2.Size = new System.Drawing.Size(140, 22);
            this.dtpFechaInicio2.TabIndex = 10;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(257, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hasta:";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Inicio:";
            //
            // tabClientes
            //
            this.tabClientes.BackColor = System.Drawing.Color.White;
            this.tabClientes.Controls.Add(this.panelClientes);
            this.tabClientes.Controls.Add(this.panelTotalesClientes);
            this.tabClientes.Controls.Add(this.panelFiltrosClientes);
            this.tabClientes.Location = new System.Drawing.Point(4, 25);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.Size = new System.Drawing.Size(962, 536);
            this.tabClientes.TabIndex = 2;
            this.tabClientes.Text = "Clientes con Mayor Compra";
            //
            // panelClientes
            //
            this.panelClientes.Controls.Add(this.dgvClientes);
            this.panelClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClientes.Location = new System.Drawing.Point(0, 60);
            this.panelClientes.Name = "panelClientes";
            this.panelClientes.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.panelClientes.Size = new System.Drawing.Size(962, 431);
            this.panelClientes.TabIndex = 8;
            //
            // dgvClientes
            //
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.EnableHeadersVisualStyles = false;
            this.dgvClientes.Location = new System.Drawing.Point(10, 10);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(942, 416);
            this.dgvClientes.TabIndex = 20;
            //
            // panelTotalesClientes
            //
            this.panelTotalesClientes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTotalesClientes.Controls.Add(this.lblTotalClientes);
            this.panelTotalesClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTotalesClientes.Location = new System.Drawing.Point(0, 491);
            this.panelTotalesClientes.Name = "panelTotalesClientes";
            this.panelTotalesClientes.Padding = new System.Windows.Forms.Padding(10);
            this.panelTotalesClientes.Size = new System.Drawing.Size(962, 45);
            this.panelTotalesClientes.TabIndex = 7;
            //
            // lblTotalClientes
            //
            this.lblTotalClientes.AutoSize = true;
            this.lblTotalClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalClientes.Location = new System.Drawing.Point(13, 13);
            this.lblTotalClientes.Name = "lblTotalClientes";
            this.lblTotalClientes.Size = new System.Drawing.Size(138, 17);
            this.lblTotalClientes.TabIndex = 23;
            this.lblTotalClientes.Text = "Total Clientes: 0";
            //
            // panelFiltrosClientes
            //
            this.panelFiltrosClientes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltrosClientes.Controls.Add(this.btnExportarClientes);
            this.panelFiltrosClientes.Controls.Add(this.btnBuscarClientes);
            this.panelFiltrosClientes.Controls.Add(this.dtpFechaFin3);
            this.panelFiltrosClientes.Controls.Add(this.dtpFechaInicio3);
            this.panelFiltrosClientes.Controls.Add(this.label5);
            this.panelFiltrosClientes.Controls.Add(this.label6);
            this.panelFiltrosClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltrosClientes.Location = new System.Drawing.Point(0, 0);
            this.panelFiltrosClientes.Name = "panelFiltrosClientes";
            this.panelFiltrosClientes.Padding = new System.Windows.Forms.Padding(10);
            this.panelFiltrosClientes.Size = new System.Drawing.Size(962, 60);
            this.panelFiltrosClientes.TabIndex = 6;
            //
            // btnExportarClientes
            //
            this.btnExportarClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnExportarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarClientes.ForeColor = System.Drawing.Color.White;
            this.btnExportarClientes.Location = new System.Drawing.Point(812, 18);
            this.btnExportarClientes.Name = "btnExportarClientes";
            this.btnExportarClientes.Size = new System.Drawing.Size(130, 28);
            this.btnExportarClientes.TabIndex = 22;
            this.btnExportarClientes.Text = "Exportar a Excel";
            this.btnExportarClientes.UseVisualStyleBackColor = false;
            this.btnExportarClientes.Click += new System.EventHandler(this.btnExportarClientes_Click);
            //
            // btnBuscarClientes
            //
            this.btnBuscarClientes.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarClientes.ForeColor = System.Drawing.Color.White;
            this.btnBuscarClientes.Location = new System.Drawing.Point(470, 18);
            this.btnBuscarClientes.Name = "btnBuscarClientes";
            this.btnBuscarClientes.Size = new System.Drawing.Size(90, 28);
            this.btnBuscarClientes.TabIndex = 21;
            this.btnBuscarClientes.Text = "Buscar";
            this.btnBuscarClientes.UseVisualStyleBackColor = false;
            this.btnBuscarClientes.Click += new System.EventHandler(this.btnBuscarClientes_Click);
            //
            // dtpFechaFin3
            //
            this.dtpFechaFin3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin3.Location = new System.Drawing.Point(310, 21);
            this.dtpFechaFin3.Name = "dtpFechaFin3";
            this.dtpFechaFin3.Size = new System.Drawing.Size(140, 22);
            this.dtpFechaFin3.TabIndex = 19;
            //
            // dtpFechaInicio3
            //
            this.dtpFechaInicio3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio3.Location = new System.Drawing.Point(100, 21);
            this.dtpFechaInicio3.Name = "dtpFechaInicio3";
            this.dtpFechaInicio3.Size = new System.Drawing.Size(140, 22);
            this.dtpFechaInicio3.TabIndex = 18;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(257, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Hasta:";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Fecha Inicio:";
            //
            // frmReportesAnaliticos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1013, 632);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmReportesAnaliticos";
            this.Text = "Reportes Analíticos";
            this.Load += new System.EventHandler(this.frmReportesAnaliticos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabVendedores.ResumeLayout(false);
            this.panelVendedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.panelTotalesVendedores.ResumeLayout(false);
            this.panelTotalesVendedores.PerformLayout();
            this.panelFiltrosVendedores.ResumeLayout(false);
            this.panelFiltrosVendedores.PerformLayout();
            this.tabProductos.ResumeLayout(false);
            this.panelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panelTotalesProductos.ResumeLayout(false);
            this.panelTotalesProductos.PerformLayout();
            this.panelFiltrosProductos.ResumeLayout(false);
            this.panelFiltrosProductos.PerformLayout();
            this.tabClientes.ResumeLayout(false);
            this.panelClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.panelTotalesClientes.ResumeLayout(false);
            this.panelTotalesClientes.PerformLayout();
            this.panelFiltrosClientes.ResumeLayout(false);
            this.panelFiltrosClientes.PerformLayout();
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
        private System.Windows.Forms.Panel panelFiltrosVendedores;
        private System.Windows.Forms.Panel panelTotalesVendedores;
        private System.Windows.Forms.Panel panelVendedores;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.Panel panelTotalesProductos;
        private System.Windows.Forms.Panel panelFiltrosProductos;
        private System.Windows.Forms.Panel panelClientes;
        private System.Windows.Forms.Panel panelTotalesClientes;
        private System.Windows.Forms.Panel panelFiltrosClientes;
    }
}
