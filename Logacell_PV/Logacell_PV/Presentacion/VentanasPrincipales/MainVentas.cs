
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
    public partial class MainVentas : Form
    {
        private static MainVentas instance;
        ControlLogacell control;
       
        public MainVentas()
        {
            InitializeComponent();
            cmbNumByPag.SelectedIndex = 0;
            control = ControlLogacell.getInstance();
            try
            {
                actualizarTabla(control.obtenerVentasTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
}

        public static MainVentas getInstance()
        {
                if (instance == null)
                {
                    instance = new MainVentas();
                }
                return instance;
        }

        private void form_ClosedFrecuente(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTabla(control.obtenerVentasTable());
        }

        private void form_ClosedClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTabla(control.obtenerVentasTable());
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
                lblTotal.Text = dataGridView1.RowCount.ToString();
                dataGridView1.Columns[0].Width = 85;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 160;
                dataGridView1.Columns[4].Width = 160;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                actualizarTabla(control.obtenerVentasTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                String idVenta = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                MessageBox.Show("aqui se mostraran los datos relevantes de la venta: " + idVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
