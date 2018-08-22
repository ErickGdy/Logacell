

using Logacell_Admin.Control;
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
    public partial class MainTraspasos : Form
    {
        private static MainTraspasos instance;
        ControlLogacell_Admin control;
       
        public MainTraspasos()
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            try
            {
                actualizarTablaOrigen(control.obtenerTraspasosTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
}

        public static MainTraspasos getInstance()
        {
                if (instance == null)
                {
                    instance = new MainTraspasos();
                }
                return instance;
        }


        public void actualizarTablaOrigen(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewOrigen.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                dataGridViewOrigen.Columns[0].Width = 50;
                dataGridViewOrigen.Columns[1].Width = 120;
                dataGridViewOrigen.Columns[2].Width = 120;
                dataGridViewOrigen.Columns[3].Width = 80;
                dataGridViewOrigen.Columns[4].Width = 150;
                dataGridViewOrigen.Columns[5].Width = 80;
                dataGridViewOrigen.Columns[6].Width = 160;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtBuscarOrigen_KeyUp(object sender, KeyEventArgs e)
        {
            limpiarBusqueda.Visible = true;
            if (txtBuscar.Text == "")
                limpiarBusqueda.Visible = false;
            try
            {
                actualizarTablaOrigen(control.obtenerTraspasosTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnActualizarTablaOrigen_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarTablaOrigen(control.obtenerTraspasosTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiarBusquedaOrigen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtBuscar.Text = "";
            limpiarBusqueda.Visible = false;
            try
            {
                actualizarTablaOrigen(control.obtenerTraspasosTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      




        private void dataGridViewOrigen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridViewOrigen.CurrentRow.Cells[0].Value.ToString();
            lblCategoria.Text = dataGridViewOrigen.CurrentRow.Cells[1].Value.ToString();
            lblNombre.Text = dataGridViewOrigen.CurrentRow.Cells[2].Value.ToString();
            lblMarca.Text = dataGridViewOrigen.CurrentRow.Cells[3].Value.ToString();
            lblModelo.Text = dataGridViewOrigen.CurrentRow.Cells[4].Value.ToString();
            lblPrecio.Text = dataGridViewOrigen.CurrentRow.Cells[5].Value.ToString();
            lblStock.Text = dataGridViewOrigen.CurrentRow.Cells[6].Value.ToString();
        }

        private void MainTraspasos_SizeChanged(object sender, EventArgs e)
        {
            panelDetalles.Height = this.Height;
        }
    }
}
