
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
    public partial class MainCompras : Form
    {
        private static MainCompras instance;
        ControlLogacell control;
       
        public MainCompras()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            try
            {
                actualizarTabla(control.obtenerComprasTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
}

        public static MainCompras getInstance()
        {
                if (instance == null)
                {
                    instance = new MainCompras();
                }
                return instance;
        }


        private void form_ClosedClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTabla(control.obtenerComprasTable());
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
                dataGridView1.Columns[0].Width = 90;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 140;
                dataGridView1.Columns[4].Width = 140;
                dataGridView1.Columns[5].Width = 140;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            limpiarBusqueda.Visible = true;
            if (txtBuscar.Text == "")
                limpiarBusqueda.Visible = false;
            try
            {
                actualizarTabla(control.obtenerComprasTable(txtBuscar.Text));
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
                String idVenta = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //DetalleDeVenta dv = new DetalleDeVenta(control.consultarVenta(idVenta));
                //dv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormCompra fv = new FormCompra();
            fv.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
            fv.Show();
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarTabla(control.obtenerComprasTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiarBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtBuscar.Text = "";
            limpiarBusqueda.Visible = false;
            try
            {
                actualizarTabla(control.obtenerComprasTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
