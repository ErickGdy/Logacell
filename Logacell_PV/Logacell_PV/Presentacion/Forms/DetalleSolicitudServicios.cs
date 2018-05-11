
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
    public partial class DetalleSolicitudServicios : Form
    {
        private static DetalleSolicitudServicios instance;
        ControlLogacell control;
       
        public DetalleSolicitudServicios(SolicitudServicio sc)
        {
            InitializeComponent();

            control = ControlLogacell.getInstance(); ;
            actualizarTabla(control.obtenerDetalleServiciosClientesTable(sc.Folio));
            lblFolio.Text = sc.Folio;
            lblNombre.Text = sc.nombreCliente;
            lblTelefono.Text = sc.telefonoCliente;
            lblTotal.Text = sc.total;
            lblPendiente.Text = sc.pendiente;
            lblPego.Text = sc.anticipo;
        }

        public static DetalleSolicitudServicios getInstance(SolicitudServicio sc)
        {
                if (instance == null)
                {
                    instance = new DetalleSolicitudServicios(sc);
                }
                return instance;
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
                dataGridView1.Columns[0].Width = 250;
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].Width = 75;
                dataGridView1.Columns[4].Width = 45;
                dataGridView1.Columns[5].Width = 45;
                dataGridView1.Columns[6].Width = 50;
                dataGridView1.Columns[7].Width = 47;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            //actualizarTabla(control.obtenerXTable(txtBuscar.Text));
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
                        actualizarTabla(control.obtenerClientesTable());
                    }
                    else MessageBox.Show("Error al eliminar cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void esperaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enProgresoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void terminadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void entregadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
