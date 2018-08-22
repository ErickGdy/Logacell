using Logacell_Admin.Control;
using Logacell_Admin.DataObject;
using Logacell_Admin;
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
using Logacell.Control;

namespace Logacell_Admin
{
    public partial class MainForm : Form
    {
        public static MainForm instance;
        Usuario user;
        ControlLogacell_Admin control;
        public MainForm(string empleado)
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            control.setCurrentUser(empleado);
            usuarioToolStripMenuItem.Text = empleado;
            try
            {
                if (control.consultarEmpleado(empleado).puesto != "Administrador")
                {
                    btnServicios.Visible = false;
                    btnClientes.Visible = false;
                    btnProgresoServicios.Visible = false;
                    btnVentas.Visible = false;
                    btnCompras.Visible = false;
                    btnTerminales.Visible = false;
                    btnEmpleados.Visible = false;
                    btnFinanzas.Visible = false;
                    btnAdministracion.Visible = false;

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static MainForm getInstance(string empleado)
        {
            if (instance == null)
            {
                instance = new MainForm(empleado);
            }
            return instance;
        }


        private void btnInventario_Click(object sender, EventArgs e)
        {
            minimizeForms();

            inhabilitarBoton("Inventario");
            MainInventarioProductos form = MainInventarioProductos.getInstance();
            configurarForm(form);

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            minimizeForms();

            inhabilitarBoton("Cliente");
            MainCliente mc = MainCliente.getInstance();
            configurarForm(mc);
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inhabilitarBoton("");
            closeForms();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Empleado");

            MainEmpleado me = MainEmpleado.getInstance();
            configurarForm(me);
        }


        private void btnTerminales_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Terminal");
            MainPuntoVenta mpv = MainPuntoVenta.getInstance();
            configurarForm(mpv);
        }

        private void btnProgresoServicios_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Progreso");

            MainServiciosCliente form = MainServiciosCliente.getInstance();
            configurarForm(form);
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Administracion");
            MainAdministracion form = MainAdministracion.getInstance();
            configurarForm(form);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Venta");

            MainVentas form = MainVentas.getInstance();
            configurarForm(form);
        }
        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            minimizeForms();

            inhabilitarBoton("Finanzas");
            MainFinanzas form = MainFinanzas.getInstance();
            configurarForm(form);
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
            form.Show();
        }


    

        private void inhabilitarBoton(String boton)
        {
            btnProductos.Enabled = true;
            btnClientes.Enabled = true;
            btnAdministracion.Enabled = true;
            btnEmpleados.Enabled = true;
            btnTerminales.Enabled = true;
            btnFinanzas.Enabled = true;
            btnVentas.Enabled = true;
            btnServicios.Enabled = true;
            btnCompras.Enabled = true;
            btnProgresoServicios.Enabled = true;
            btnTraspasos.Enabled = true;
            switch (boton)
            {
                case "Inventario":
                    btnProductos.Enabled = false;
                    break;
                case "Servicios":
                    btnServicios.Enabled = false;
                    break;
                case "Cliente":
                    btnClientes.Enabled = false;
                    break;
                case "Administracion":
                    btnAdministracion.Enabled = false;
                    break;
                case "Empleado":
                    btnEmpleados.Enabled = false;
                    break;
                case "Finanzas":
                    btnFinanzas.Enabled = false;
                    break;
                case "Terminal":
                    btnTerminales.Enabled = false;
                    break;
                case "Venta":
                    btnVentas.Enabled = false;
                    break;
                case "Progreso":
                    btnProgresoServicios.Enabled = false;
                    break;
                case "Compras":
                    btnCompras.Enabled = false;
                    break;
                case "Traspasos":
                    btnTraspasos.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            minimizeForms();

            inhabilitarBoton("Servicios");
            MainServicios form = MainServicios.getInstance();
            configurarForm(form);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            minimizeForms();

            inhabilitarBoton("Compras");
            MainCompras form = MainCompras.getInstance();
            configurarForm(form);
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            pnMenus.Height = this.Height;
            imgLogo.Location = new System.Drawing.Point(4, this.Height - 145);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            minimizeForms();
            inhabilitarBoton("Traspasos");
            MainTraspasos form = MainTraspasos.getInstance();
            configurarForm(form);
        }
    }
}
