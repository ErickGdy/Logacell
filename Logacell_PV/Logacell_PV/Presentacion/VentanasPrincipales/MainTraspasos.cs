
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
    public partial class MainTraspasos : Form
    {
        private static MainTraspasos instance;
        ControlLogacell control;
       
        public MainTraspasos()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            try
            {
                actualizarTablaOrigen(control.obtenerTraspasosPVOrigenTable());
                actualizarTablaDestino(control.obtenerTraspasosPVDestinoTable());
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


        private void form_ClosedClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTablaOrigen(control.obtenerTraspasosPVOrigenTable());
            actualizarTablaDestino(control.obtenerTraspasosPVDestinoTable());
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
                actualizarTablaOrigen(control.obtenerTraspasosPVOrigenTable(txtBuscar.Text));
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
                if (dataGridViewDestino.CurrentRow.Cells[5].Value.ToString() != "Recibido")
                {
                    String id = dataGridViewDestino.CurrentRow.Cells[0].Value.ToString();
                    FormTraspasos dv = new FormTraspasos(control.consultarTraspaso(id));
                    dv.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
                    dv.Show();
                }
                else
                    MessageBox.Show("El traspaso ya ha sido recibido");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormTraspasos dv = new FormTraspasos(null);
            dv.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
            dv.Show();
        }

        private void btnActualizarTablaOrigen_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarTablaOrigen(control.obtenerTraspasosPVOrigenTable(txtBuscar.Text));
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
                actualizarTablaOrigen(control.obtenerTraspasosPVOrigenTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void actualizarTablaDestino(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewDestino.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                dataGridViewDestino.Columns[0].Width = 50;
                dataGridViewDestino.Columns[1].Width = 120;
                dataGridViewDestino.Columns[2].Width = 120;
                dataGridViewDestino.Columns[3].Width = 80;
                dataGridViewDestino.Columns[4].Width = 150;
                dataGridViewDestino.Columns[5].Width = 80;
                dataGridViewDestino.Columns[6].Width = 160;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtBuscarDestino_KeyUp(object sender, KeyEventArgs e)
        {
            LimpiarBusquedaDestino.Visible = true;
            if (txtBuscarDestino.Text == "")
                LimpiarBusquedaDestino.Visible = false;
            try
            {
                actualizarTablaDestino(control.obtenerTraspasosPVDestinoTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnActualizarTablaDestino_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarTablaDestino(control.obtenerTraspasosPVDestinoTable(txtBuscarDestino.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiarBusquedaDestino_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtBuscarDestino.Text = "";
            LimpiarBusquedaDestino.Visible = false;
            try
            {
                actualizarTablaDestino(control.obtenerTraspasosPVDestinoTable());
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

        private void dataGridViewDestino_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridViewDestino.CurrentRow.Cells[0].Value.ToString();
            lblCategoria.Text = dataGridViewDestino.CurrentRow.Cells[1].Value.ToString();
            lblNombre.Text = dataGridViewDestino.CurrentRow.Cells[2].Value.ToString();
            lblMarca.Text = dataGridViewDestino.CurrentRow.Cells[3].Value.ToString();
            lblModelo.Text = dataGridViewDestino.CurrentRow.Cells[4].Value.ToString();
            lblPrecio.Text = dataGridViewDestino.CurrentRow.Cells[5].Value.ToString();
            lblStock.Text = dataGridViewDestino.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
