namespace Paneles_solares
{
    partial class frmReportes
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
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbuscarreporte = new FontAwesome.Sharp.IconButton();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfechafin = new System.Windows.Forms.DateTimePicker();
            this.txtfechainicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.cbobusqueda2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnexportar = new System.Windows.Forms.Button();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(862, 58);
            this.label11.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 51;
            this.label1.Text = "Reporte Ventas";
            // 
            // btnbuscarreporte
            // 
            this.btnbuscarreporte.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnbuscarreporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarreporte.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscarreporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarreporte.ForeColor = System.Drawing.Color.White;
            this.btnbuscarreporte.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnbuscarreporte.IconColor = System.Drawing.Color.Black;
            this.btnbuscarreporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarreporte.IconSize = 20;
            this.btnbuscarreporte.Location = new System.Drawing.Point(772, 35);
            this.btnbuscarreporte.Margin = new System.Windows.Forms.Padding(2);
            this.btnbuscarreporte.Name = "btnbuscarreporte";
            this.btnbuscarreporte.Size = new System.Drawing.Size(37, 23);
            this.btnbuscarreporte.TabIndex = 58;
            this.btnbuscarreporte.UseVisualStyleBackColor = false;
            this.btnbuscarreporte.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(608, 37);
            this.cbobusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(134, 21);
            this.cbobusqueda.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(513, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 56;
            this.label3.Text = "Buscar por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 59;
            this.label2.Text = "Fecha inicio: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 60;
            this.label4.Text = "Fecha Fin: ";
            // 
            // txtfechafin
            // 
            this.txtfechafin.CustomFormat = "dd/mm/yyyy";
            this.txtfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechafin.Location = new System.Drawing.Point(293, 42);
            this.txtfechafin.Margin = new System.Windows.Forms.Padding(2);
            this.txtfechafin.Name = "txtfechafin";
            this.txtfechafin.Size = new System.Drawing.Size(86, 20);
            this.txtfechafin.TabIndex = 61;
            // 
            // txtfechainicio
            // 
            this.txtfechainicio.CustomFormat = "dd/mm/yyyy";
            this.txtfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechainicio.Location = new System.Drawing.Point(98, 42);
            this.txtfechainicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtfechainicio.Name = "txtfechainicio";
            this.txtfechainicio.Size = new System.Drawing.Size(86, 20);
            this.txtfechainicio.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(862, 428);
            this.label5.TabIndex = 63;
            // 
            // btnlimpiarbuscador
            // 
            this.btnlimpiarbuscador.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.ForeColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Bomb;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 20;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(743, 95);
            this.btnlimpiarbuscador.Margin = new System.Windows.Forms.Padding(2);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(51, 28);
            this.btnlimpiarbuscador.TabIndex = 69;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 20;
            this.iconButton1.Location = new System.Drawing.Point(673, 96);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(51, 28);
            this.iconButton1.TabIndex = 68;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Location = new System.Drawing.Point(506, 100);
            this.txtbusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(134, 20);
            this.txtbusqueda.TabIndex = 67;
            // 
            // cbobusqueda2
            // 
            this.cbobusqueda2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda2.FormattingEnabled = true;
            this.cbobusqueda2.Location = new System.Drawing.Point(328, 98);
            this.cbobusqueda2.Margin = new System.Windows.Forms.Padding(2);
            this.cbobusqueda2.Name = "cbobusqueda2";
            this.cbobusqueda2.Size = new System.Drawing.Size(134, 21);
            this.cbobusqueda2.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(236, 98);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 65;
            this.label6.Text = "Buscar por:";
            // 
            // btnexportar
            // 
            this.btnexportar.Location = new System.Drawing.Point(11, 89);
            this.btnexportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(112, 24);
            this.btnexportar.TabIndex = 70;
            this.btnexportar.Text = "Descargar Excel";
            this.btnexportar.UseVisualStyleBackColor = true;
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.AllowUserToDeleteRows = false;
            this.dgvdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeight = 29;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUsuario,
            this.DNI,
            this.NombreCompleto,
            this.Correo,
            this.Clave,
            this.idRol,
            this.Rol,
            this.Estado,
            this.EstadoValor,
            this.PrevioVenta,
            this.Cantidad,
            this.SubTotal});
            this.dgvdata.Location = new System.Drawing.Point(21, 133);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(831, 376);
            this.dgvdata.TabIndex = 71;
            // 
            // idUsuario
            // 
            this.idUsuario.HeaderText = "Fecha Registro";
            this.idUsuario.MinimumWidth = 6;
            this.idUsuario.Name = "idUsuario";
            // 
            // DNI
            // 
            this.DNI.FillWeight = 99.72386F;
            this.DNI.HeaderText = "Tipo Documento";
            this.DNI.MinimumWidth = 6;
            this.DNI.Name = "DNI";
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.FillWeight = 152.2842F;
            this.NombreCompleto.HeaderText = "Numero Documento";
            this.NombreCompleto.MinimumWidth = 6;
            this.NombreCompleto.Name = "NombreCompleto";
            // 
            // Correo
            // 
            this.Correo.FillWeight = 99.72386F;
            this.Correo.HeaderText = "Monto Total";
            this.Correo.MinimumWidth = 6;
            this.Correo.Name = "Correo";
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Usuario Registro";
            this.Clave.MinimumWidth = 6;
            this.Clave.Name = "Clave";
            // 
            // idRol
            // 
            this.idRol.HeaderText = "Codigo Producto";
            this.idRol.MinimumWidth = 6;
            this.idRol.Name = "idRol";
            // 
            // Rol
            // 
            this.Rol.FillWeight = 99.72386F;
            this.Rol.HeaderText = "Nombre Producto";
            this.Rol.MinimumWidth = 6;
            this.Rol.Name = "Rol";
            // 
            // Estado
            // 
            this.Estado.FillWeight = 99.72386F;
            this.Estado.HeaderText = "Categoria";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "Precio Compra";
            this.EstadoValor.MinimumWidth = 6;
            this.EstadoValor.Name = "EstadoValor";
            // 
            // PrevioVenta
            // 
            this.PrevioVenta.HeaderText = "PrecioVenta";
            this.PrevioVenta.MinimumWidth = 6;
            this.PrevioVenta.Name = "PrevioVenta";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.MinimumWidth = 6;
            this.SubTotal.Name = "SubTotal";
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 521);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.btnexportar);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cbobusqueda2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtfechainicio);
            this.Controls.Add(this.txtfechafin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnbuscarreporte);
            this.Controls.Add(this.cbobusqueda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnbuscarreporte;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtfechafin;
        private System.Windows.Forms.DateTimePicker txtfechainicio;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.ComboBox cbobusqueda2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnexportar;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}