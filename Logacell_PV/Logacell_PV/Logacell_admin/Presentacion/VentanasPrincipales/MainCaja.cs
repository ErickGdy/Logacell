
using Logacell_Admin.Control;
using Logacell_Admin.DataObject;
using Logacell_Admin;
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
    public partial class MainCaja : Form
    {
        private static MainCaja instance;
        ControlLogacell_Admin control;
       
        public MainCaja()
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            try
            {
                actualizarTablaCajas(control.obtenerCajasTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
}

        public static MainCaja getInstance()
        {
                if (instance == null)
                {
                    instance = new MainCaja();
                }
                return instance;
        }


        public void actualizarTablaCajas(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewCaja.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                lblTotalCaja.Text = dataGridViewCaja.RowCount.ToString();
                dataGridViewCaja.Columns[0].Width = 90;
                dataGridViewCaja.Columns[1].Width = 170;
                dataGridViewCaja.Columns[2].Width = 100;
                dataGridViewCaja.Columns[3].Width = 100;
                dataGridViewCaja.Columns[4].Width = 140;
                dataGridViewCaja.Columns[5].Width = 160;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            limpiarBusqueda.Visible = true;
            if (txtBuscarCaja.Text == "")
                limpiarBusqueda.Visible = false;
            try
            {
                actualizarTablaCajas(control.obtenerCajasTable(txtBuscarCaja.Text));
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
                String idCaja = dataGridViewCaja.CurrentRow.Cells[0].Value.ToString();
                //DetalleDeCompra dv = new DetalleDeCompra(control.consultarCompra(idCompra));
                //dv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnactualizarTablaCajas_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarTablaCajas(control.obtenerCajasTable(txtBuscarCaja.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiarBusquedaCaja_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtBuscarCaja.Text = "";
            limpiarBusqueda.Visible = false;
            try
            {
                actualizarTablaCajas(control.obtenerCajasTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
