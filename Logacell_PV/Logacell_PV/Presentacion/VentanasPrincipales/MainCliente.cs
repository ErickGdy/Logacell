
using Logacell.Control;
using Logacell.DataObject;
using Logacell.Presentacion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell
{
    public partial class MainCliente : Form
    {
        private static MainCliente instance;
        ControlLogacell control;
       
        public MainCliente()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            try
            {
                actualizarTablaClientes(control.obtenerClientesTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static MainCliente getInstance()
        {
                if (instance == null)
                {
                    instance = new MainCliente();
                }
                return instance;
        }


        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormCliente form = new FormCliente(null);
            form.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
            form.Show();
        }
        private void form_ClosedClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTablaClientes(control.obtenerClientesTable());
        }

        public void actualizarTablaClientes(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridView1.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                lblTotalClientes.Text = dataGridView1.RowCount.ToString();
                dataGridView1.Columns[0].Width = 160;
                dataGridView1.Columns[1].Width = 170;
                dataGridView1.Columns[1].HeaderText = "Dirección";
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[2].HeaderText = "Teléfono";
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[5].HeaderText = "Crédito";

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void txtBuscarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                actualizarTablaClientes(control.obtenerClientesTable(txtBuscarCliente.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String telefono  = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            MessageBox.Show("aqui se mostraran los datos relevantes del cliente: "+telefono);
        }

        private void modificaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String telefono = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            try
            {
                Cliente cliente = control.consultarCliente(telefono);
                FormCliente fc = new FormCliente(cliente);
                fc.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
                fc.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eliminarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                String telefono = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("¿Desea eliminar el Cliente?", "Eliminar Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (control.eliminarCliente(telefono))
                    {
                        MessageBox.Show("Cliente Eliminado");
                        actualizarTablaClientes(control.obtenerClientesTable());
                    }
                    else MessageBox.Show("Error al eliminar cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainCliente_SizeChanged(object sender, EventArgs e)
        {
            pnMenus.Height = this.Height;
        }

        private void abonoACréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String telefono = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            try
            {
                CreditoCliente c = control.consultarCreditoCliente(telefono);
                if (c != null)
                {
                    FormAbonoCredito fc = new FormAbonoCredito(c);
                    fc.Show();
                }
                else
                    MessageBox.Show("Error al obtener datos de credito del cliente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            actualizarTablaClientes(control.obtenerClientesTable(txtBuscarCliente.Text));
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "True")
                {
                    abonoACréditoToolStripMenuItem.Visible = true;
                }else
                    abonoACréditoToolStripMenuItem.Visible = false;
            }
        }
    }
}
