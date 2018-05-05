namespace Logacell
{
    partial class MainCliente
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
            instance = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCliente));
            this.pnMenus = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.lblTotalClientes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNumByPag = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuTablaClietes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBuscarFrecuente = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.comenuTablaFrecuentes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.consultarFrecuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarFrecuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarFrecuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAgregarClienteF = new System.Windows.Forms.Button();
            this.lblTotalFrecuentes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLastPageF = new System.Windows.Forms.Button();
            this.btnNextPageF = new System.Windows.Forms.Button();
            this.btnFirstPageF = new System.Windows.Forms.Button();
            this.btnPrevPageF = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbNumByPageF = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuTablaClietes.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.comenuTablaFrecuentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMenus
            // 
            this.pnMenus.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnMenus.Location = new System.Drawing.Point(-2, 0);
            this.pnMenus.Name = "pnMenus";
            this.pnMenus.Size = new System.Drawing.Size(190, 508);
            this.pnMenus.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(192, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(894, 568);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.btnAgregarCliente);
            this.tabPage1.Controls.Add(this.txtBuscarCliente);
            this.tabPage1.Controls.Add(this.lblTotalClientes);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnLastPage);
            this.tabPage1.Controls.Add(this.btnNextPage);
            this.tabPage1.Controls.Add(this.btnFirstPage);
            this.tabPage1.Controls.Add(this.btnPrevPage);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbNumByPag);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(886, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Todos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(581, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCliente.Image")));
            this.btnAgregarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCliente.Location = new System.Drawing.Point(660, 47);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(160, 31);
            this.btnAgregarCliente.TabIndex = 22;
            this.btnAgregarCliente.Text = "Agregar Nuevo";
            this.btnAgregarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscarCliente.Location = new System.Drawing.Point(611, 83);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(218, 26);
            this.txtBuscarCliente.TabIndex = 31;
            this.txtBuscarCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarCliente_KeyUp);
            // 
            // lblTotalClientes
            // 
            this.lblTotalClientes.AutoSize = true;
            this.lblTotalClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClientes.Location = new System.Drawing.Point(180, 508);
            this.lblTotalClientes.Name = "lblTotalClientes";
            this.lblTotalClientes.Size = new System.Drawing.Size(18, 20);
            this.lblTotalClientes.TabIndex = 21;
            this.lblTotalClientes.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(46, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Total de Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(37, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 39);
            this.label2.TabIndex = 19;
            this.label2.Text = "Clientes";
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(786, 505);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(34, 23);
            this.btnLastPage.TabIndex = 18;
            this.btnLastPage.Text = ">>";
            this.btnLastPage.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(762, 505);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(26, 23);
            this.btnNextPage.TabIndex = 17;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(706, 505);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(34, 23);
            this.btnFirstPage.TabIndex = 16;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(738, 505);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(26, 23);
            this.btnPrevPage.TabIndex = 15;
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(113, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Por página";
            // 
            // cmbNumByPag
            // 
            this.cmbNumByPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumByPag.FormattingEnabled = true;
            this.cmbNumByPag.Items.AddRange(new object[] {
            "25",
            "50",
            "100",
            "TODOS"});
            this.cmbNumByPag.Location = new System.Drawing.Point(44, 87);
            this.cmbNumByPag.Name = "cmbNumByPag";
            this.cmbNumByPag.Size = new System.Drawing.Size(63, 21);
            this.cmbNumByPag.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.menuTablaClietes;
            this.dataGridView1.Location = new System.Drawing.Point(44, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(785, 384);
            this.dataGridView1.TabIndex = 12;
            // 
            // menuTablaClietes
            // 
            this.menuTablaClietes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTablaClietes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem,
            this.modificaToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menuTablaClietes.Name = "menuTabla";
            this.menuTablaClietes.Size = new System.Drawing.Size(153, 98);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem.Image")));
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click_1);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificaToolStripMenuItem.Image")));
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.modificaToolStripMenuItem.Text = "Modificar";
            this.modificaToolStripMenuItem.Click += new System.EventHandler(this.modificaToolStripMenuItem_Click_1);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.txtBuscarFrecuente);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.btnAgregarClienteF);
            this.tabPage2.Controls.Add(this.lblTotalFrecuentes);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnLastPageF);
            this.tabPage2.Controls.Add(this.btnNextPageF);
            this.tabPage2.Controls.Add(this.btnFirstPageF);
            this.tabPage2.Controls.Add(this.btnPrevPageF);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cmbNumByPageF);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(886, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Frecuentes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(581, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // txtBuscarFrecuente
            // 
            this.txtBuscarFrecuente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscarFrecuente.Location = new System.Drawing.Point(611, 83);
            this.txtBuscarFrecuente.Name = "txtBuscarFrecuente";
            this.txtBuscarFrecuente.Size = new System.Drawing.Size(218, 26);
            this.txtBuscarFrecuente.TabIndex = 35;
            this.txtBuscarFrecuente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarFrecuente_KeyUp);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.comenuTablaFrecuentes;
            this.dataGridView2.Location = new System.Drawing.Point(44, 115);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(785, 384);
            this.dataGridView2.TabIndex = 34;
            // 
            // comenuTablaFrecuentes
            // 
            this.comenuTablaFrecuentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comenuTablaFrecuentes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarFrecuenteToolStripMenuItem,
            this.modificarFrecuenteToolStripMenuItem,
            this.eliminarFrecuenteToolStripMenuItem});
            this.comenuTablaFrecuentes.Name = "menuTabla";
            this.comenuTablaFrecuentes.Size = new System.Drawing.Size(147, 76);
            // 
            // consultarFrecuenteToolStripMenuItem
            // 
            this.consultarFrecuenteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarFrecuenteToolStripMenuItem.Image")));
            this.consultarFrecuenteToolStripMenuItem.Name = "consultarFrecuenteToolStripMenuItem";
            this.consultarFrecuenteToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.consultarFrecuenteToolStripMenuItem.Text = "Consultar";
            this.consultarFrecuenteToolStripMenuItem.Click += new System.EventHandler(this.consultarFrecuenteToolStripMenuItem_Click);
            // 
            // modificarFrecuenteToolStripMenuItem
            // 
            this.modificarFrecuenteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarFrecuenteToolStripMenuItem.Image")));
            this.modificarFrecuenteToolStripMenuItem.Name = "modificarFrecuenteToolStripMenuItem";
            this.modificarFrecuenteToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.modificarFrecuenteToolStripMenuItem.Text = "Modificar";
            this.modificarFrecuenteToolStripMenuItem.Click += new System.EventHandler(this.modificarFrecuenteToolStripMenuItem_Click);
            // 
            // eliminarFrecuenteToolStripMenuItem
            // 
            this.eliminarFrecuenteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarFrecuenteToolStripMenuItem.Image")));
            this.eliminarFrecuenteToolStripMenuItem.Name = "eliminarFrecuenteToolStripMenuItem";
            this.eliminarFrecuenteToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.eliminarFrecuenteToolStripMenuItem.Text = "Eliminar";
            this.eliminarFrecuenteToolStripMenuItem.Click += new System.EventHandler(this.eliminarFrecuenteToolStripMenuItem_Click);
            // 
            // btnAgregarClienteF
            // 
            this.btnAgregarClienteF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarClienteF.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarClienteF.Image")));
            this.btnAgregarClienteF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarClienteF.Location = new System.Drawing.Point(660, 47);
            this.btnAgregarClienteF.Name = "btnAgregarClienteF";
            this.btnAgregarClienteF.Size = new System.Drawing.Size(160, 31);
            this.btnAgregarClienteF.TabIndex = 33;
            this.btnAgregarClienteF.Text = "Agregar Nuevo";
            this.btnAgregarClienteF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarClienteF.UseVisualStyleBackColor = true;
            this.btnAgregarClienteF.Click += new System.EventHandler(this.btnAgregarClienteF_Click);
            // 
            // lblTotalFrecuentes
            // 
            this.lblTotalFrecuentes.AutoSize = true;
            this.lblTotalFrecuentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFrecuentes.Location = new System.Drawing.Point(180, 508);
            this.lblTotalFrecuentes.Name = "lblTotalFrecuentes";
            this.lblTotalFrecuentes.Size = new System.Drawing.Size(18, 20);
            this.lblTotalFrecuentes.TabIndex = 32;
            this.lblTotalFrecuentes.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(46, 508);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Total de Clientes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label6.Location = new System.Drawing.Point(37, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(320, 39);
            this.label6.TabIndex = 30;
            this.label6.Text = "Clientes Frecuentes";
            // 
            // btnLastPageF
            // 
            this.btnLastPageF.Location = new System.Drawing.Point(786, 505);
            this.btnLastPageF.Name = "btnLastPageF";
            this.btnLastPageF.Size = new System.Drawing.Size(34, 23);
            this.btnLastPageF.TabIndex = 29;
            this.btnLastPageF.Text = ">>";
            this.btnLastPageF.UseVisualStyleBackColor = true;
            // 
            // btnNextPageF
            // 
            this.btnNextPageF.Location = new System.Drawing.Point(762, 505);
            this.btnNextPageF.Name = "btnNextPageF";
            this.btnNextPageF.Size = new System.Drawing.Size(26, 23);
            this.btnNextPageF.TabIndex = 28;
            this.btnNextPageF.Text = ">";
            this.btnNextPageF.UseVisualStyleBackColor = true;
            // 
            // btnFirstPageF
            // 
            this.btnFirstPageF.Location = new System.Drawing.Point(706, 505);
            this.btnFirstPageF.Name = "btnFirstPageF";
            this.btnFirstPageF.Size = new System.Drawing.Size(34, 23);
            this.btnFirstPageF.TabIndex = 27;
            this.btnFirstPageF.Text = "<<";
            this.btnFirstPageF.UseVisualStyleBackColor = true;
            // 
            // btnPrevPageF
            // 
            this.btnPrevPageF.Location = new System.Drawing.Point(738, 505);
            this.btnPrevPageF.Name = "btnPrevPageF";
            this.btnPrevPageF.Size = new System.Drawing.Size(26, 23);
            this.btnPrevPageF.TabIndex = 26;
            this.btnPrevPageF.Text = "<";
            this.btnPrevPageF.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(113, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Por página";
            // 
            // cmbNumByPageF
            // 
            this.cmbNumByPageF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumByPageF.FormattingEnabled = true;
            this.cmbNumByPageF.Items.AddRange(new object[] {
            "25",
            "50",
            "100",
            "TODOS"});
            this.cmbNumByPageF.Location = new System.Drawing.Point(44, 87);
            this.cmbNumByPageF.Name = "cmbNumByPageF";
            this.cmbNumByPageF.Size = new System.Drawing.Size(63, 21);
            this.cmbNumByPageF.TabIndex = 24;
            // 
            // MainCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 580);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnMenus);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainCliente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuTablaClietes.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.comenuTablaFrecuentes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Label lblTotalClientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNumByPag;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAgregarClienteF;
        private System.Windows.Forms.Label lblTotalFrecuentes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLastPageF;
        private System.Windows.Forms.Button btnNextPageF;
        private System.Windows.Forms.Button btnFirstPageF;
        private System.Windows.Forms.Button btnPrevPageF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbNumByPageF;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBuscarFrecuente;
        private System.Windows.Forms.ContextMenuStrip menuTablaClietes;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip comenuTablaFrecuentes;
        private System.Windows.Forms.ToolStripMenuItem consultarFrecuenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarFrecuenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarFrecuenteToolStripMenuItem;
    }
}