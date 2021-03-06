﻿namespace Logacell
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
            this.menuTablaClietes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limiteDeCréditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abonoACréditoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.lblTotalClientes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnActualizarTabla = new System.Windows.Forms.Button();
            this.menuTablaClietes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMenus
            // 
            this.pnMenus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(157)))));
            this.pnMenus.Location = new System.Drawing.Point(-2, 0);
            this.pnMenus.Name = "pnMenus";
            this.pnMenus.Size = new System.Drawing.Size(190, 508);
            this.pnMenus.TabIndex = 0;
            // 
            // menuTablaClietes
            // 
            this.menuTablaClietes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTablaClietes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem,
            this.modificaToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.créditoToolStripMenuItem});
            this.menuTablaClietes.Name = "menuTabla";
            this.menuTablaClietes.Size = new System.Drawing.Size(153, 122);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem.Image")));
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Visible = false;
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
            // créditoToolStripMenuItem
            // 
            this.créditoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limiteDeCréditoToolStripMenuItem,
            this.abonoACréditoToolStripMenuItem1});
            this.créditoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("créditoToolStripMenuItem.Image")));
            this.créditoToolStripMenuItem.Name = "créditoToolStripMenuItem";
            this.créditoToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.créditoToolStripMenuItem.Text = "Crédito";
            // 
            // limiteDeCréditoToolStripMenuItem
            // 
            this.limiteDeCréditoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("limiteDeCréditoToolStripMenuItem.Image")));
            this.limiteDeCréditoToolStripMenuItem.Name = "limiteDeCréditoToolStripMenuItem";
            this.limiteDeCréditoToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.limiteDeCréditoToolStripMenuItem.Text = "Limite de crédito";
            this.limiteDeCréditoToolStripMenuItem.Click += new System.EventHandler(this.limiteDeCréditoToolStripMenuItem_Click);
            // 
            // abonoACréditoToolStripMenuItem1
            // 
            this.abonoACréditoToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("abonoACréditoToolStripMenuItem1.Image")));
            this.abonoACréditoToolStripMenuItem1.Name = "abonoACréditoToolStripMenuItem1";
            this.abonoACréditoToolStripMenuItem1.Size = new System.Drawing.Size(194, 24);
            this.abonoACréditoToolStripMenuItem1.Text = "Abono a Crédito";
            this.abonoACréditoToolStripMenuItem1.Click += new System.EventHandler(this.abonoACréditoToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(745, 47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCliente.Image")));
            this.btnAgregarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCliente.Location = new System.Drawing.Point(824, 11);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(160, 31);
            this.btnAgregarCliente.TabIndex = 37;
            this.btnAgregarCliente.Text = "Agregar Nuevo";
            this.btnAgregarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscarCliente.Location = new System.Drawing.Point(775, 47);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(218, 26);
            this.txtBuscarCliente.TabIndex = 38;
            this.txtBuscarCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarCliente_KeyUp);
            // 
            // lblTotalClientes
            // 
            this.lblTotalClientes.AutoSize = true;
            this.lblTotalClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClientes.Location = new System.Drawing.Point(346, 474);
            this.lblTotalClientes.Name = "lblTotalClientes";
            this.lblTotalClientes.Size = new System.Drawing.Size(18, 20);
            this.lblTotalClientes.TabIndex = 36;
            this.lblTotalClientes.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(212, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Total de Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(269, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 39);
            this.label2.TabIndex = 34;
            this.label2.Text = "Clientes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.menuTablaClietes;
            this.dataGridView1.Location = new System.Drawing.Point(209, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(785, 384);
            this.dataGridView1.TabIndex = 33;
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // btnActualizarTabla
            // 
            this.btnActualizarTabla.AutoSize = true;
            this.btnActualizarTabla.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarTabla.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarTabla.FlatAppearance.BorderSize = 0;
            this.btnActualizarTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarTabla.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarTabla.Image")));
            this.btnActualizarTabla.Location = new System.Drawing.Point(213, 47);
            this.btnActualizarTabla.Name = "btnActualizarTabla";
            this.btnActualizarTabla.Size = new System.Drawing.Size(30, 30);
            this.btnActualizarTabla.TabIndex = 48;
            this.btnActualizarTabla.UseVisualStyleBackColor = false;
            this.btnActualizarTabla.Click += new System.EventHandler(this.btnActualizarTabla_Click);
            // 
            // MainCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 580);
            this.ControlBox = false;
            this.Controls.Add(this.btnActualizarTabla);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.txtBuscarCliente);
            this.Controls.Add(this.lblTotalClientes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnMenus);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainCliente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.SizeChanged += new System.EventHandler(this.MainCliente_SizeChanged);
            this.menuTablaClietes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnMenus;
        private System.Windows.Forms.ContextMenuStrip menuTablaClietes;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Label lblTotalClientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnActualizarTabla;
        private System.Windows.Forms.ToolStripMenuItem créditoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limiteDeCréditoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abonoACréditoToolStripMenuItem1;
    }
}