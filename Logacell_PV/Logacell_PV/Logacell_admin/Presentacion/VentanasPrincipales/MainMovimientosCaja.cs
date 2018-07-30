
using Logacell_Admin.Control;
using Logacell_Admin.DataObject;
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

namespace Logacell_Admin
{
    public partial class MainMovimientosCaja : Form
    {
        private static MainMovimientosCaja instance;
        ControlLogacell_Admin control;
        int pv;
       
        public MainMovimientosCaja(int pv)
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            this.pv = pv;
            
            try
            {
                actualizarTabla(control.obtenerMovimientosTable(pv));
                lblPV.Text = control.consultarPuntoVenta(pv.ToString()).nombre;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static MainMovimientosCaja getInstance(int pv)
        {
                if (instance == null)
                {
                    instance = new MainMovimientosCaja(pv);
                }
                return instance;
        }



        private void form_ClosedClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTabla(control.obtenerMovimientosTable(pv));
        }

        public void actualizarTabla(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewMovimientos.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                lblTotalMovimientos.Text = dataGridViewMovimientos.RowCount.ToString();
                dataGridViewMovimientos.Columns[0].Width = 50;
                dataGridViewMovimientos.Columns[1].Width = 70;
                dataGridViewMovimientos.Columns[2].Width = 130;
                dataGridViewMovimientos.Columns[3].Width = 60;
                dataGridViewMovimientos.Columns[4].Width = 200;
                dataGridViewMovimientos.Columns[5].Visible = false; 
                dataGridViewMovimientos.Columns[6].Width = 125;

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
                actualizarTabla(control.obtenerMovimientosTable(txtBuscarMovimiento.Text, pv));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String id  = dataGridViewMovimientos.CurrentRow.Cells[0].Value.ToString();
            //MessageBox.Show("aqui se mostraran los datos relevantes del cliente: "+telefono);
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            actualizarTabla(control.obtenerMovimientosTable(txtBuscarMovimiento.Text,pv));
        }

    }
}
