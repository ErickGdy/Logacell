
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
       
        public DetalleSolicitudServicios(string id)
        {
            InitializeComponent();

            control = ControlLogacell.getInstance(); ;
            actualizarTabla(control.obtenerDetalleServiciosClientesTable(id));
        }

        public static DetalleSolicitudServicios getInstance(string id)
        {
                if (instance == null)
                {
                    instance = new DetalleSolicitudServicios(id);
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
                // actualiza el valor de la etiqueta donde se muestra el total de productos
            }catch(Exception e)
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
