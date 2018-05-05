using Logacell.Control;
using Logacell.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell
{
    public partial class Main : Form
    {
        public static Main instance;
        public Main()
        {
            InitializeComponent();
            usuarioToolStripMenuItem.Text = ControlLogacell.currentUser.usuario;
            this.Text = ControlLogacell.idPV.nombre;
        }
        public static Main getInstance(string usuario)
        {
            if (instance == null)
            {
                instance = new Main();
            }
            return instance;
        }


        private void btnClientes_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Cliente");
            MainCliente mc = MainCliente.getInstance();
            configurarForm(mc);
            mc.Show();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inhabilitarBoton("");
            closeForms();
        }

        private void listaDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Servicios");
            MainServicios form = MainServicios.getInstance();
            configurarForm(form);
            form.Show();
        }

        private void btnProgresoServicios_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Progreso");
            MainServiciosCliente form = MainServiciosCliente.getInstance();
            configurarForm(form);
            form.Show();
        }


        private void btnVenta_Click(object sender, EventArgs e)
        {
            inhabilitarBoton("Venta");
            minimizeForms();
            MainVentas form = MainVentas.getInstance();
            configurarForm(form);
            form.Show();
        }

        private void listaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("InvProductos");
            MainInventarioProductos form = MainInventarioProductos.getInstance();
            configurarForm(form);
            form.Show();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void corteDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //---------METODOS DE CONTROL------------------//
        private void closeForms()
        {
            foreach (Form aux in MdiChildren)
            {
                aux.Dispose();
            }
        }
        private void minimizeForms()
        {
            foreach (Form aux in MdiChildren)
            {
                aux.Hide();
            }
            inhabilitarBoton("");

        }
        private void configurarForm(Form form)
        {
            form.MdiParent = this;
            form.Size = new Size(this.Size.Width - 20, this.Size.Height - 85);
        }


        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginCambiarContrasena lc = new LoginCambiarContrasena();
            lc.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void inhabilitarBoton(String boton)
        {
            switch (boton)
            {
                case "InvProductos":
                    //prod.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            foreach (Form aux in MdiChildren)
            {
                configurarForm(aux);
            }
            footer.Width = this.Width - 15;
            footer.Location = new Point(0, this.Height - 105);
            pictureBox1.Location = new Point((this.Width/2)-105, 7);
        }


    }
}
