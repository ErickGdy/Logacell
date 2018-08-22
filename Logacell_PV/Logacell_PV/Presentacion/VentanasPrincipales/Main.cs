using Logacell.Control;
using Logacell.DataObject;
using Logacell.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            ControlLogacell.getInstance().escribirDoc();
            ControlLogacell.getInstance().setCaja();
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
            MainCliente mc = MainCliente.getInstance();
            configurarForm(mc);
            mc.Show();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForms();
        }

        private void listaDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeForms();
            MainServicios form = MainServicios.getInstance();
            configurarForm(form);
            form.Show();
        }

        private void btnProgresoServicios_Click(object sender, EventArgs e)
        {
            minimizeForms();
            MainServiciosCliente form = MainServiciosCliente.getInstance();
            configurarForm(form);
            form.Show();
        }


        private void btnVenta_Click(object sender, EventArgs e)
        {
            minimizeForms();
            MainVentas form = MainVentas.getInstance();
            configurarForm(form);
            form.Show();
        }

        private void listaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeForms();
            MainInventarioProductos form = MainInventarioProductos.getInstance();
            configurarForm(form);
            form.Show();
        }


        private void corteDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ControlLogacell.getInstance().consultarCaja().estado == "Abierta")
            {
                FormCorteCaja fc = new FormCorteCaja();
            }
            else
                MessageBox.Show("Error!: Debe abrir la caja primero");

            
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

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void nuevoServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormServicioCliente fm = new FormServicioCliente();
            fm.FormClosed += new FormClosedEventHandler(form_ClosedServiciosClientes);
            fm.Show();
        }
        private void form_ClosedServiciosClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            MainServiciosCliente.getInstance().Dispose();
            btnProgresoServicios_Click(null, null);
        }

        private void nuevaVentaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormVenta fv = new FormVenta();
            fv.FormClosed += new FormClosedEventHandler(form_CloseVentas);
            fv.Show();
        }
        private void form_CloseVentas(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            MainVentas.getInstance().Dispose();
            btnVenta_Click(null, null);
        }

        private void nuevaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {

           FormCompra fv = new FormCompra();
           fv.FormClosed += new FormClosedEventHandler(form_FormCompra);
           fv.Show();
        }
        private void form_FormCompra(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            MainCompras.getInstance().Dispose();
            listaDeComprasToolStripMenuItem_Click(null, null);
        }

        private void egresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeForms();
            MainMovimientosCaja mv = MainMovimientosCaja.getInstance();
            configurarForm(mv);
            mv.Show();
        }

        private void listaDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeForms();
            MainCompras mc = MainCompras.getInstance();
            configurarForm(mc);
            mc.Show();
        }

        private void nuevoIngresoEgresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEgreso fv = new FormEgreso(null);
            fv.FormClosed += new FormClosedEventHandler(form_CloseIngreso);
            fv.Show();
        }
        private void form_CloseIngreso(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            MainMovimientosCaja.getInstance().Dispose();
            egresoToolStripMenuItem_Click(null, null);
        }

        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ControlLogacell.caja.estado != "Abierta")
            {
                AbrirCaja ac = new AbrirCaja();
            }
            else
                MessageBox.Show("La caja se encuentra abierta");

        }

        private void toolStripMenuAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado emp = ControlLogacell.getInstance().consultarEmpleado(ControlLogacell.currentUser.empleado);
                if (emp.puesto == "Administrador" || emp.puesto == "Encargado de envios")
                {
                    Logacell_Admin.MainForm main = Logacell_Admin.MainForm.getInstance(emp.correo);
                    main.Show();
                }
                else
                {
                    Logacell_Admin.Login log = new Logacell_Admin.Login();
                    log.Show();
                }
            }
            catch (Exception ex) { }
        }

        private void trapasosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeForms();
            MainTraspasos mc = MainTraspasos.getInstance();
            configurarForm(mc);
            mc.Show();
        }
    }
}
