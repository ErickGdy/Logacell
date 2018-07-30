using Logacell;
using Logacell.Control;

namespace Logacell_Admin
{
    partial class MainForm
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
            instance = null;
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnMenus = new System.Windows.Forms.Panel();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnFinanzas = new System.Windows.Forms.Button();
            this.btnTerminales = new System.Windows.Forms.Button();
            this.btnProgresoServicios = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnAdministracion = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnMenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(157)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nToolStripMenuItem,
            this.usuarioToolStripMenuItem,
            this.inicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 40);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nToolStripMenuItem
            // 
            this.nToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.nToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nToolStripMenuItem.Image")));
            this.nToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nToolStripMenuItem.Name = "nToolStripMenuItem";
            this.nToolStripMenuItem.Size = new System.Drawing.Size(171, 36);
            this.nToolStripMenuItem.Text = "Notificaciones";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.usuarioToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usuarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usuarioToolStripMenuItem.Image")));
            this.usuarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(118, 36);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.inicioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inicioToolStripMenuItem.Image")));
            this.inicioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(98, 36);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // pnMenus
            // 
            this.pnMenus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(167)))));
            this.pnMenus.Controls.Add(this.btnCompras);
            this.pnMenus.Controls.Add(this.btnServicios);
            this.pnMenus.Controls.Add(this.imgLogo);
            this.pnMenus.Controls.Add(this.btnVentas);
            this.pnMenus.Controls.Add(this.btnFinanzas);
            this.pnMenus.Controls.Add(this.btnTerminales);
            this.pnMenus.Controls.Add(this.btnProgresoServicios);
            this.pnMenus.Controls.Add(this.btnProductos);
            this.pnMenus.Controls.Add(this.btnAdministracion);
            this.pnMenus.Controls.Add(this.btnClientes);
            this.pnMenus.Controls.Add(this.btnEmpleados);
            this.pnMenus.Location = new System.Drawing.Point(0, 43);
            this.pnMenus.Name = "pnMenus";
            this.pnMenus.Size = new System.Drawing.Size(190, 638);
            this.pnMenus.TabIndex = 17;
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.White;
            this.btnCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnCompras.Location = new System.Drawing.Point(4, 288);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(183, 56);
            this.btnCompras.TabIndex = 11;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.BackColor = System.Drawing.Color.Transparent;
            this.btnServicios.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnServicios.BackgroundImage")));
            this.btnServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnServicios.Location = new System.Drawing.Point(4, 59);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(183, 56);
            this.btnServicios.TabIndex = 10;
            this.btnServicios.Text = "Servicios";
            this.btnServicios.UseVisualStyleBackColor = false;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.Location = new System.Drawing.Point(4, 581);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(186, 56);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogo.TabIndex = 9;
            this.imgLogo.TabStop = false;
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.White;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnVentas.Location = new System.Drawing.Point(3, 230);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(183, 56);
            this.btnVentas.TabIndex = 8;
            this.btnVentas.Tag = "";
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnFinanzas
            // 
            this.btnFinanzas.BackColor = System.Drawing.Color.White;
            this.btnFinanzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnFinanzas.Location = new System.Drawing.Point(4, 461);
            this.btnFinanzas.Name = "btnFinanzas";
            this.btnFinanzas.Size = new System.Drawing.Size(183, 56);
            this.btnFinanzas.TabIndex = 7;
            this.btnFinanzas.Text = "Finanzas";
            this.btnFinanzas.UseVisualStyleBackColor = false;
            this.btnFinanzas.Click += new System.EventHandler(this.btnFinanzas_Click);
            // 
            // btnTerminales
            // 
            this.btnTerminales.BackColor = System.Drawing.Color.White;
            this.btnTerminales.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnTerminales.Location = new System.Drawing.Point(4, 345);
            this.btnTerminales.Name = "btnTerminales";
            this.btnTerminales.Size = new System.Drawing.Size(183, 56);
            this.btnTerminales.TabIndex = 4;
            this.btnTerminales.Text = "Puntos de Venta";
            this.btnTerminales.UseVisualStyleBackColor = false;
            this.btnTerminales.Click += new System.EventHandler(this.btnTerminales_Click);
            // 
            // btnProgresoServicios
            // 
            this.btnProgresoServicios.BackColor = System.Drawing.Color.White;
            this.btnProgresoServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgresoServicios.Location = new System.Drawing.Point(4, 173);
            this.btnProgresoServicios.Name = "btnProgresoServicios";
            this.btnProgresoServicios.Size = new System.Drawing.Size(183, 56);
            this.btnProgresoServicios.TabIndex = 3;
            this.btnProgresoServicios.Text = "Progreso de Servicios";
            this.btnProgresoServicios.UseVisualStyleBackColor = false;
            this.btnProgresoServicios.Click += new System.EventHandler(this.btnProgresoServicios_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.Transparent;
            this.btnProductos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProductos.BackgroundImage")));
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnProductos.Location = new System.Drawing.Point(4, 3);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(183, 56);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnAdministracion
            // 
            this.btnAdministracion.BackColor = System.Drawing.Color.White;
            this.btnAdministracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnAdministracion.Location = new System.Drawing.Point(4, 519);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(183, 56);
            this.btnAdministracion.TabIndex = 5;
            this.btnAdministracion.Text = "Administración";
            this.btnAdministracion.UseVisualStyleBackColor = false;
            this.btnAdministracion.Click += new System.EventHandler(this.btnAdministracion_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.White;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnClientes.Location = new System.Drawing.Point(4, 116);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(183, 56);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.Color.White;
            this.btnEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnEmpleados.Location = new System.Drawing.Point(4, 403);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(183, 56);
            this.btnEmpleados.TabIndex = 6;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = false;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(60)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnMenus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnMenus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.Panel pnMenus;
        private System.Windows.Forms.Button btnFinanzas;
        private System.Windows.Forms.Button btnTerminales;
        private System.Windows.Forms.Button btnProgresoServicios;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnAdministracion;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnCompras;
    }
}



