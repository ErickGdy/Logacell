
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
    public partial class StockEnPV : Form
    {
        private static StockEnPV instance;
        ControlLogacell control;
       
        public StockEnPV(Producto p)
        {
            InitializeComponent();
            control = ControlLogacell.getInstance(); ;
            actualizarTabla(control.obtenerStockProductoPV(p.id.ToString()));
            lblID.Text = p.id.ToString();
            lblCategoria.Text = p.categoria;
            lblNombre.Text = p.nombre;
            lblMarca.Text = p.marca;
            lblModelo.Text = p.modelo;
        }

        public static StockEnPV getInstance(Producto p)
        {
                if (instance == null)
                {
                    instance = new StockEnPV(p);
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
                dataGridView1.Columns[0].Width = 195;
                dataGridView1.Columns[1].Width = 50;
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
