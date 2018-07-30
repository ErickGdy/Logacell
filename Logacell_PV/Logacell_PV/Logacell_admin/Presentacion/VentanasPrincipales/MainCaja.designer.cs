namespace Logacell_Admin
{
    partial class MainCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCaja));
            this.pnMenus = new System.Windows.Forms.Panel();
            this.menuTablaCaja = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.consultarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtBuscarCaja = new System.Windows.Forms.TextBox();
            this.lblTotalCaja = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewCaja = new System.Windows.Forms.DataGridView();
            this.btnActualizarTablaCaja = new System.Windows.Forms.Button();
            this.limpiarBusqueda = new System.Windows.Forms.LinkLabel();
            this.menuTablaCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaja)).BeginInit();
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
            // menuTablaCaja
            // 
            this.menuTablaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTablaCaja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarCajaToolStripMenuItem});
            this.menuTablaCaja.Name = "menuTabla";
            this.menuTablaCaja.Size = new System.Drawing.Size(147, 28);
            // 
            // consultarCajaToolStripMenuItem
            // 
            this.consultarCajaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarCajaToolStripMenuItem.Image")));
            this.consultarCajaToolStripMenuItem.Name = "consultarCajaToolStripMenuItem";
            this.consultarCajaToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.consultarCajaToolStripMenuItem.Tag = "Mostrar Detalle De Venta";
            this.consultarCajaToolStripMenuItem.Text = "Consultar";
            this.consultarCajaToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(747, 47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // txtBuscarCaja
            // 
            this.txtBuscarCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscarCaja.Location = new System.Drawing.Point(777, 47);
            this.txtBuscarCaja.Name = "txtBuscarCaja";
            this.txtBuscarCaja.Size = new System.Drawing.Size(218, 26);
            this.txtBuscarCaja.TabIndex = 44;
            this.txtBuscarCaja.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // lblTotalCaja
            // 
            this.lblTotalCaja.AutoSize = true;
            this.lblTotalCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCaja.Location = new System.Drawing.Point(323, 473);
            this.lblTotalCaja.Name = "lblTotalCaja";
            this.lblTotalCaja.Size = new System.Drawing.Size(18, 20);
            this.lblTotalCaja.TabIndex = 42;
            this.lblTotalCaja.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(211, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Total de cajas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(273, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 39);
            this.label2.TabIndex = 40;
            this.label2.Text = "Cajas";
            // 
            // dataGridViewCaja
            // 
            this.dataGridViewCaja.AllowUserToAddRows = false;
            this.dataGridViewCaja.AllowUserToDeleteRows = false;
            this.dataGridViewCaja.AllowUserToOrderColumns = true;
            this.dataGridViewCaja.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCaja.ContextMenuStrip = this.menuTablaCaja;
            this.dataGridViewCaja.Location = new System.Drawing.Point(209, 79);
            this.dataGridViewCaja.Name = "dataGridViewCaja";
            this.dataGridViewCaja.ReadOnly = true;
            this.dataGridViewCaja.RowHeadersVisible = false;
            this.dataGridViewCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCaja.Size = new System.Drawing.Size(785, 384);
            this.dataGridViewCaja.TabIndex = 33;
            // 
            // btnActualizarTablaCaja
            // 
            this.btnActualizarTablaCaja.AutoSize = true;
            this.btnActualizarTablaCaja.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarTablaCaja.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarTablaCaja.FlatAppearance.BorderSize = 0;
            this.btnActualizarTablaCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarTablaCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarTablaCaja.Image")));
            this.btnActualizarTablaCaja.Location = new System.Drawing.Point(209, 46);
            this.btnActualizarTablaCaja.Name = "btnActualizarTablaCaja";
            this.btnActualizarTablaCaja.Size = new System.Drawing.Size(30, 30);
            this.btnActualizarTablaCaja.TabIndex = 47;
            this.btnActualizarTablaCaja.UseVisualStyleBackColor = false;
            this.btnActualizarTablaCaja.Click += new System.EventHandler(this.btnactualizarTablaCajas_Click);
            // 
            // limpiarBusqueda
            // 
            this.limpiarBusqueda.AutoSize = true;
            this.limpiarBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarBusqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.limpiarBusqueda.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.limpiarBusqueda.LinkColor = System.Drawing.Color.Gray;
            this.limpiarBusqueda.Location = new System.Drawing.Point(973, 50);
            this.limpiarBusqueda.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.limpiarBusqueda.Name = "limpiarBusqueda";
            this.limpiarBusqueda.Size = new System.Drawing.Size(21, 20);
            this.limpiarBusqueda.TabIndex = 48;
            this.limpiarBusqueda.TabStop = true;
            this.limpiarBusqueda.Text = "X";
            this.limpiarBusqueda.Visible = false;
            this.limpiarBusqueda.VisitedLinkColor = System.Drawing.Color.Black;
            this.limpiarBusqueda.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.limpiarBusquedaCaja_LinkClicked);
            // 
            // MainCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 580);
            this.ControlBox = false;
            this.Controls.Add(this.limpiarBusqueda);
            this.Controls.Add(this.btnActualizarTablaCaja);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtBuscarCaja);
            this.Controls.Add(this.lblTotalCaja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewCaja);
            this.Controls.Add(this.pnMenus);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainCaja";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.menuTablaCaja.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnMenus;
        private System.Windows.Forms.ContextMenuStrip menuTablaCaja;
        private System.Windows.Forms.ToolStripMenuItem consultarCajaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBuscarCaja;
        private System.Windows.Forms.Label lblTotalCaja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewCaja;
        private System.Windows.Forms.Button btnActualizarTablaCaja;
        private System.Windows.Forms.LinkLabel limpiarBusqueda;
    }
}