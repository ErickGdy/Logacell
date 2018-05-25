
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
    public partial class MainMovimientosCaja : Form
    {
        private static MainMovimientosCaja instance;
        ControlLogacell control;
       
        public MainMovimientosCaja()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            try
            {
                actualizarTabla(control.obtenerMovimientosTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static MainMovimientosCaja getInstance()
        {
                if (instance == null)
                {
                    instance = new MainMovimientosCaja();
                }
                return instance;
        }


        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormEgreso form = new FormEgreso(null);
            form.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
            form.Show();
        }
        private void form_ClosedClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTabla(control.obtenerMovimientosTable());
        }

        public void actualizarTabla(MySqlDataAdapter data)
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
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].Width = 60;
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[5].Width = 125;
                dataGridView1.Columns[6].Width = 125;

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
                actualizarTabla(control.obtenerMovimientosTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String id  = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //MessageBox.Show("aqui se mostraran los datos relevantes del cliente: "+telefono);
        }

        private void modificaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                FormEgreso fc = new FormEgreso(control.consultarIngresosEgreso(id));
                fc.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
                fc.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainCliente_SizeChanged(object sender, EventArgs e)
        {
            pnMenus.Height = this.Height;
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            actualizarTabla(control.obtenerMovimientosTable(txtBuscar.Text));
        }

    }
}
