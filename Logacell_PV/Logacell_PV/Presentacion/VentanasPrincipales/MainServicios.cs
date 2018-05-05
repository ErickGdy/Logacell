
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
    public partial class MainServicios : Form
    {
        private static MainServicios instance;
        ControlLogacell control;
        public MainServicios()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            try
            {
                actualizarTablaServicios(control.obtenerServiciosTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static MainServicios getInstance()
        {
                if (instance == null)
                {
                    instance = new MainServicios();
                }
                return instance;
        }

        private void actualizarTablaServicios(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewServicios.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de servicios
                lblTotalServicios.Text = dataGridViewServicios.RowCount.ToString();
                dataGridViewServicios.Columns[0].Width = 65;
                dataGridViewServicios.Columns[1].Width = 150;
                dataGridViewServicios.Columns[2].Width = 275;
                dataGridViewServicios.Columns[3].Width = 100;
                dataGridViewServicios.Columns[4].Width = 170;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


        private void btnAgregarServicios_Click(object sender, EventArgs e)
        {
            FormServicio fs = new FormServicio(null);
            fs.FormClosed += new FormClosedEventHandler(form_ClosedServicios);
            fs.Show();
        }
        private void form_ClosedServicios(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTablaServicios(control.obtenerServiciosTable());
        }
        private void menuConsultarServicio_Click(object sender, EventArgs e)
        {
            consultarServicio();
        }

        private void menuModificarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridViewServicios.CurrentRow.Cells[0].Value.ToString();
                Servicio servicio = control.consultarServicio(id);
                FormServicio fs = new FormServicio(servicio);
                fs.FormClosed += new FormClosedEventHandler(form_ClosedServicios);
                fs.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuEliminarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridViewServicios.CurrentRow.Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("¿Desea eliminar el Servicio?", "Eliminar Servicio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (control.eliminarServicio(id))
                    {
                        MessageBox.Show("Servicio Eliminado");
                        actualizarTablaServicios(control.obtenerServiciosTable());
                    }
                    else MessageBox.Show("Error al eliminar servicio");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarServicio()
        {
            lblID.Text = dataGridViewServicios.CurrentRow.Cells[0].Value.ToString();
            lblNombre.Text = dataGridViewServicios.CurrentRow.Cells[1].Value.ToString();
            lblDescripcion.Text = dataGridViewServicios.CurrentRow.Cells[2].Value.ToString();
            lblPrecio.Text = dataGridViewServicios.CurrentRow.Cells[3].Value.ToString();
            lblDuracion.Text = dataGridViewServicios.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridViewServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            consultarServicio();
        }

        private void txtBuscarServicio_KeyUp(object sender, KeyEventArgs e)
        {
            limpiarBusqueda.Visible = true;
            if (txtBuscarServicio.Text == "")
                limpiarBusqueda.Visible = false;
            actualizarTablaServicios(control.obtenerServiciosTable(txtBuscarServicio.Text));
        }

        private void MainServicios_SizeChanged(object sender, EventArgs e)
        {
            panelDetalles.Height = this.Height;
        }

        private void limpiarBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            limpiarBusqueda.Visible = false;
            txtBuscarServicio.Text = "";
            try
            {
                actualizarTablaServicios(control.obtenerServiciosTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }
    }
}
