namespace Logacell_Admin
{
    partial class MainMovimientosCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMovimientosCaja));
            this.menuTablaClietes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtBuscarMovimiento = new System.Windows.Forms.TextBox();
            this.lblTotalMovimientos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dataGridViewMovimientos = new System.Windows.Forms.DataGridView();
            this.btnActualizarTablaMovimientos = new System.Windows.Forms.Button();
            this.lblPV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuTablaClietes
            // 
            this.menuTablaClietes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTablaClietes.Name = "menuTabla";
            this.menuTablaClietes.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(418, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // txtBuscarMovimiento
            // 
            this.txtBuscarMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscarMovimiento.Location = new System.Drawing.Point(448, 71);
            this.txtBuscarMovimiento.Name = "txtBuscarMovimiento";
            this.txtBuscarMovimiento.Size = new System.Drawing.Size(218, 26);
            this.txtBuscarMovimiento.TabIndex = 38;
            this.txtBuscarMovimiento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarCliente_KeyUp);
            // 
            // lblTotalMovimientos
            // 
            this.lblTotalMovimientos.AutoSize = true;
            this.lblTotalMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMovimientos.ForeColor = System.Drawing.Color.White;
            this.lblTotalMovimientos.Location = new System.Drawing.Point(174, 498);
            this.lblTotalMovimientos.Name = "lblTotalMovimientos";
            this.lblTotalMovimientos.Size = new System.Drawing.Size(18, 20);
            this.lblTotalMovimientos.TabIndex = 36;
            this.lblTotalMovimientos.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Total de Movimientos:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(336, 39);
            this.lblTitulo.TabIndex = 34;
            this.lblTitulo.Text = "Movimientos de caja:";
            // 
            // dataGridViewMovimientos
            // 
            this.dataGridViewMovimientos.AllowUserToAddRows = false;
            this.dataGridViewMovimientos.AllowUserToDeleteRows = false;
            this.dataGridViewMovimientos.AllowUserToOrderColumns = true;
            this.dataGridViewMovimientos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovimientos.ContextMenuStrip = this.menuTablaClietes;
            this.dataGridViewMovimientos.Location = new System.Drawing.Point(12, 104);
            this.dataGridViewMovimientos.Name = "dataGridViewMovimientos";
            this.dataGridViewMovimientos.ReadOnly = true;
            this.dataGridViewMovimientos.RowHeadersVisible = false;
            this.dataGridViewMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMovimientos.Size = new System.Drawing.Size(654, 384);
            this.dataGridViewMovimientos.TabIndex = 33;
            // 
            // btnActualizarTablaMovimientos
            // 
            this.btnActualizarTablaMovimientos.AutoSize = true;
            this.btnActualizarTablaMovimientos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarTablaMovimientos.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarTablaMovimientos.FlatAppearance.BorderSize = 0;
            this.btnActualizarTablaMovimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarTablaMovimientos.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarTablaMovimientos.Image")));
            this.btnActualizarTablaMovimientos.Location = new System.Drawing.Point(16, 71);
            this.btnActualizarTablaMovimientos.Name = "btnActualizarTablaMovimientos";
            this.btnActualizarTablaMovimientos.Size = new System.Drawing.Size(30, 30);
            this.btnActualizarTablaMovimientos.TabIndex = 48;
            this.btnActualizarTablaMovimientos.UseVisualStyleBackColor = false;
            this.btnActualizarTablaMovimientos.Click += new System.EventHandler(this.btnActualizarTabla_Click);
            // 
            // lblPV
            // 
            this.lblPV.AutoSize = true;
            this.lblPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblPV.ForeColor = System.Drawing.Color.White;
            this.lblPV.Location = new System.Drawing.Point(342, 21);
            this.lblPV.Name = "lblPV";
            this.lblPV.Size = new System.Drawing.Size(26, 39);
            this.lblPV.TabIndex = 49;
            this.lblPV.Text = " ";
            // 
            // MainMovimientosCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(678, 525);
            this.Controls.Add(this.lblPV);
            this.Controls.Add(this.btnActualizarTablaMovimientos);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtBuscarMovimiento);
            this.Controls.Add(this.lblTotalMovimientos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dataGridViewMovimientos);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMovimientosCaja";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos de caja";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip menuTablaClietes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBuscarMovimiento;
        private System.Windows.Forms.Label lblTotalMovimientos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataGridViewMovimientos;
        private System.Windows.Forms.Button btnActualizarTablaMovimientos;
        private System.Windows.Forms.Label lblPV;
    }
}