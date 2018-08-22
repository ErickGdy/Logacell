namespace Logacell_Admin
{
    partial class MainPuntoVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPuntoVenta));
            this.pnMenus = new System.Windows.Forms.Panel();
            this.menuTabla = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnActualizarPV = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.limpiarBusqueda = new System.Windows.Forms.LinkLabel();
            this.btnActualizarTablaCaja = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBuscarCaja = new System.Windows.Forms.TextBox();
            this.lblTotalCaja = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewCaja = new System.Windows.Forms.DataGridView();
            this.menuTablaCaja = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.consultarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnActualizarTablaCortes = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtBuscarCortes = new System.Windows.Forms.TextBox();
            this.lblTotalCortes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewCortes = new System.Windows.Forms.DataGridView();
            this.menuTablaCortes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.consultarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaja)).BeginInit();
            this.menuTablaCaja.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCortes)).BeginInit();
            this.menuTablaCortes.SuspendLayout();
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
            // menuTabla
            // 
            this.menuTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTabla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem,
            this.modificaToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menuTabla.Name = "menuTabla";
            this.menuTabla.Size = new System.Drawing.Size(147, 76);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem.Image")));
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click_1);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificaToolStripMenuItem.Image")));
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.modificaToolStripMenuItem.Text = "Modificar";
            this.modificaToolStripMenuItem.Click += new System.EventHandler(this.modificaToolStripMenuItem_Click_1);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(556, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(635, 12);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(160, 31);
            this.btnAgregar.TabIndex = 43;
            this.btnAgregar.Text = "Agregar Nuevo";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscar.Location = new System.Drawing.Point(586, 48);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(218, 26);
            this.txtBuscar.TabIndex = 44;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(64, 473);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(18, 20);
            this.lblTotal.TabIndex = 42;
            this.lblTotal.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(21, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(51, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 39);
            this.label2.TabIndex = 40;
            this.label2.Text = "Puntos de Venta";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.menuTabla;
            this.dataGridView1.Location = new System.Drawing.Point(19, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(785, 384);
            this.dataGridView1.TabIndex = 33;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(194, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 592);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnActualizarPV);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btnAgregar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtBuscar);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(872, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Puntos de Venta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnActualizarPV
            // 
            this.btnActualizarPV.AutoSize = true;
            this.btnActualizarPV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarPV.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarPV.FlatAppearance.BorderSize = 0;
            this.btnActualizarPV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarPV.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarPV.Image")));
            this.btnActualizarPV.Location = new System.Drawing.Point(25, 48);
            this.btnActualizarPV.Name = "btnActualizarPV";
            this.btnActualizarPV.Size = new System.Drawing.Size(30, 30);
            this.btnActualizarPV.TabIndex = 56;
            this.btnActualizarPV.UseVisualStyleBackColor = false;
            this.btnActualizarPV.Click += new System.EventHandler(this.btnActualizarPV_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.limpiarBusqueda);
            this.tabPage2.Controls.Add(this.btnActualizarTablaCaja);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.txtBuscarCaja);
            this.tabPage2.Controls.Add(this.lblTotalCaja);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dataGridViewCaja);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(872, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cajas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // limpiarBusqueda
            // 
            this.limpiarBusqueda.AutoSize = true;
            this.limpiarBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarBusqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.limpiarBusqueda.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.limpiarBusqueda.LinkColor = System.Drawing.Color.Gray;
            this.limpiarBusqueda.Location = new System.Drawing.Point(783, 50);
            this.limpiarBusqueda.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.limpiarBusqueda.Name = "limpiarBusqueda";
            this.limpiarBusqueda.Size = new System.Drawing.Size(21, 20);
            this.limpiarBusqueda.TabIndex = 56;
            this.limpiarBusqueda.TabStop = true;
            this.limpiarBusqueda.Text = "X";
            this.limpiarBusqueda.Visible = false;
            this.limpiarBusqueda.VisitedLinkColor = System.Drawing.Color.Black;
            this.limpiarBusqueda.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.limpiarBusquedaCaja_LinkClicked);
            // 
            // btnActualizarTablaCaja
            // 
            this.btnActualizarTablaCaja.AutoSize = true;
            this.btnActualizarTablaCaja.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarTablaCaja.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarTablaCaja.FlatAppearance.BorderSize = 0;
            this.btnActualizarTablaCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarTablaCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarTablaCaja.Image")));
            this.btnActualizarTablaCaja.Location = new System.Drawing.Point(19, 46);
            this.btnActualizarTablaCaja.Name = "btnActualizarTablaCaja";
            this.btnActualizarTablaCaja.Size = new System.Drawing.Size(30, 30);
            this.btnActualizarTablaCaja.TabIndex = 55;
            this.btnActualizarTablaCaja.UseVisualStyleBackColor = false;
            this.btnActualizarTablaCaja.Click += new System.EventHandler(this.btnactualizarTablaCajas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(557, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // txtBuscarCaja
            // 
            this.txtBuscarCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscarCaja.Location = new System.Drawing.Point(587, 47);
            this.txtBuscarCaja.Name = "txtBuscarCaja";
            this.txtBuscarCaja.Size = new System.Drawing.Size(218, 26);
            this.txtBuscarCaja.TabIndex = 53;
            this.txtBuscarCaja.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarCaja_KeyUp);
            // 
            // lblTotalCaja
            // 
            this.lblTotalCaja.AutoSize = true;
            this.lblTotalCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCaja.Location = new System.Drawing.Point(133, 473);
            this.lblTotalCaja.Name = "lblTotalCaja";
            this.lblTotalCaja.Size = new System.Drawing.Size(18, 20);
            this.lblTotalCaja.TabIndex = 52;
            this.lblTotalCaja.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(21, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "Total de cajas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label4.Location = new System.Drawing.Point(83, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 39);
            this.label4.TabIndex = 50;
            this.label4.Text = "Cajas";
            // 
            // dataGridViewCaja
            // 
            this.dataGridViewCaja.AllowUserToAddRows = false;
            this.dataGridViewCaja.AllowUserToDeleteRows = false;
            this.dataGridViewCaja.AllowUserToOrderColumns = true;
            this.dataGridViewCaja.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCaja.ContextMenuStrip = this.menuTablaCaja;
            this.dataGridViewCaja.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewCaja.Name = "dataGridViewCaja";
            this.dataGridViewCaja.ReadOnly = true;
            this.dataGridViewCaja.RowHeadersVisible = false;
            this.dataGridViewCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCaja.Size = new System.Drawing.Size(785, 384);
            this.dataGridViewCaja.TabIndex = 49;
            // 
            // menuTablaCaja
            // 
            this.menuTablaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTablaCaja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarCajaToolStripMenuItem});
            this.menuTablaCaja.Name = "menuTabla";
            this.menuTablaCaja.Size = new System.Drawing.Size(239, 28);
            // 
            // consultarCajaToolStripMenuItem
            // 
            this.consultarCajaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarCajaToolStripMenuItem.Image")));
            this.consultarCajaToolStripMenuItem.Name = "consultarCajaToolStripMenuItem";
            this.consultarCajaToolStripMenuItem.Size = new System.Drawing.Size(238, 24);
            this.consultarCajaToolStripMenuItem.Tag = "Mostrar Detalle De Venta";
            this.consultarCajaToolStripMenuItem.Text = "Consultar Movimientos";
            this.consultarCajaToolStripMenuItem.Click += new System.EventHandler(this.consultarCajaToolStripMenuItem_Click_1);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.btnActualizarTablaCortes);
            this.tabPage3.Controls.Add(this.pictureBox3);
            this.tabPage3.Controls.Add(this.txtBuscarCortes);
            this.tabPage3.Controls.Add(this.lblTotalCortes);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dataGridViewCortes);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(872, 566);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cortes De Caja";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.Location = new System.Drawing.Point(781, 50);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(21, 20);
            this.linkLabel1.TabIndex = 57;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "X";
            this.linkLabel1.Visible = false;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnActualizarTablaCortes
            // 
            this.btnActualizarTablaCortes.AutoSize = true;
            this.btnActualizarTablaCortes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarTablaCortes.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarTablaCortes.FlatAppearance.BorderSize = 0;
            this.btnActualizarTablaCortes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarTablaCortes.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarTablaCortes.Image")));
            this.btnActualizarTablaCortes.Location = new System.Drawing.Point(19, 46);
            this.btnActualizarTablaCortes.Name = "btnActualizarTablaCortes";
            this.btnActualizarTablaCortes.Size = new System.Drawing.Size(30, 30);
            this.btnActualizarTablaCortes.TabIndex = 55;
            this.btnActualizarTablaCortes.UseVisualStyleBackColor = false;
            this.btnActualizarTablaCortes.Click += new System.EventHandler(this.btnActualizarTablaCortes_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(557, 47);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 54;
            this.pictureBox3.TabStop = false;
            // 
            // txtBuscarCortes
            // 
            this.txtBuscarCortes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscarCortes.Location = new System.Drawing.Point(587, 47);
            this.txtBuscarCortes.Name = "txtBuscarCortes";
            this.txtBuscarCortes.Size = new System.Drawing.Size(218, 26);
            this.txtBuscarCortes.TabIndex = 53;
            this.txtBuscarCortes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarCortes_KeyUp);
            // 
            // lblTotalCortes
            // 
            this.lblTotalCortes.AutoSize = true;
            this.lblTotalCortes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCortes.Location = new System.Drawing.Point(193, 473);
            this.lblTotalCortes.Name = "lblTotalCortes";
            this.lblTotalCortes.Size = new System.Drawing.Size(18, 20);
            this.lblTotalCortes.TabIndex = 52;
            this.lblTotalCortes.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(21, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Total de cortes de caja:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label6.Location = new System.Drawing.Point(76, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 39);
            this.label6.TabIndex = 50;
            this.label6.Text = "Cortes De Caja";
            // 
            // dataGridViewCortes
            // 
            this.dataGridViewCortes.AllowUserToAddRows = false;
            this.dataGridViewCortes.AllowUserToDeleteRows = false;
            this.dataGridViewCortes.AllowUserToOrderColumns = true;
            this.dataGridViewCortes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewCortes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCortes.ContextMenuStrip = this.menuTablaCortes;
            this.dataGridViewCortes.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewCortes.Name = "dataGridViewCortes";
            this.dataGridViewCortes.ReadOnly = true;
            this.dataGridViewCortes.RowHeadersVisible = false;
            this.dataGridViewCortes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCortes.Size = new System.Drawing.Size(834, 384);
            this.dataGridViewCortes.TabIndex = 49;
            // 
            // menuTablaCortes
            // 
            this.menuTablaCortes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem1});
            this.menuTablaCortes.Name = "menuTablaCortes";
            this.menuTablaCortes.Size = new System.Drawing.Size(153, 50);
            // 
            // consultarToolStripMenuItem1
            // 
            this.consultarToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.consultarToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem1.Image")));
            this.consultarToolStripMenuItem1.Name = "consultarToolStripMenuItem1";
            this.consultarToolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
            this.consultarToolStripMenuItem1.Text = "Consultar";
            this.consultarToolStripMenuItem1.Click += new System.EventHandler(this.consultarToolStripMenuItem1_Click);
            // 
            // MainPuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1206, 600);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnMenus);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPuntoVenta";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.menuTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaja)).EndInit();
            this.menuTablaCaja.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCortes)).EndInit();
            this.menuTablaCortes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenus;
        private System.Windows.Forms.ContextMenuStrip menuTabla;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel limpiarBusqueda;
        private System.Windows.Forms.Button btnActualizarTablaCaja;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBuscarCaja;
        private System.Windows.Forms.Label lblTotalCaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewCaja;
        private System.Windows.Forms.ContextMenuStrip menuTablaCaja;
        private System.Windows.Forms.ToolStripMenuItem consultarCajaToolStripMenuItem;
        private System.Windows.Forms.Button btnActualizarPV;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnActualizarTablaCortes;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtBuscarCortes;
        private System.Windows.Forms.Label lblTotalCortes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewCortes;
        private System.Windows.Forms.ContextMenuStrip menuTablaCortes;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem1;
    }
}