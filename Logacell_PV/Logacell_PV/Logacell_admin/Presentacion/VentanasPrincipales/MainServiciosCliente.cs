
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
    public partial class MainServiciosCliente : Form
    {
        private static MainServiciosCliente instance;
        ControlLogacell_Admin control;
       
        public MainServiciosCliente()
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            try
            {
                actualizarTabla(control.obtenerServiciosClientesTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
}

        public static MainServiciosCliente getInstance()
        {
                if (instance == null)
                {
                    instance = new MainServiciosCliente();
                }

                return instance;
        }


        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTabla(control.obtenerServiciosClientesTable());
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
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 210;
                dataGridView1.Columns[2].Width = 85;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 80;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SolicitudServicio sc = new SolicitudServicio();
            sc.Folio  = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            sc.nombreCliente = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            sc.telefonoCliente = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            sc.total = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            sc.anticipo = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            sc.pendiente = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            DetalleSolicitudServicios dt = new DetalleSolicitudServicios(sc);
            dt.FormClosed += new FormClosedEventHandler(form_Closed);
            dt.ShowDialog();
        }


        private void MainServiciosCliente_SizeChanged(object sender, EventArgs e)
        {
            pnMenus.Height = this.Height;
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("¿Desea cancelar el servicio?", "Cancelar servicio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (control.cancelarServicioCliente(control.consultarServicioCliente(id)))
                    {
                        MessageBox.Show("Servicio Cancelado");
                                    actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
                    }
                    else MessageBox.Show("Error al cancelar servicio");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void esperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (control.actualizarEstadoServicioCliente(id, "Espera"))
                {
                    MessageBox.Show("Estado actualizado");
                                actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
                }
                else MessageBox.Show("Error al actualizar estado servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void enProgresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (control.actualizarEstadoServicioCliente(id, "En Progreso"))
                {
                    MessageBox.Show("Estado actualizado");
                    actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
                }
                else MessageBox.Show("Error al actualizar estado servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void terminadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (control.actualizarEstadoServicioCliente(id, "Terminado Sin Éxito"))
                {
                    MessageBox.Show("Estado actualizado");
                                actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
                }
                else MessageBox.Show("Error al actualizar estado servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void entregadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (control.actualizarEstadoServicioCliente(id, "Entregado"))
                {
                    MessageBox.Show("Estado actualizado");
                                actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
                }
                else MessageBox.Show("Error al actualizar estado servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void terminadoConÉxitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (control.actualizarEstadoServicioCliente(id, "Terminado Con Éxito"))
                {
                    MessageBox.Show("Estado actualizado");
                                actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
                }
                else MessageBox.Show("Error al actualizar estado servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sinAutorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (control.actualizarEstadoServicioCliente(id, "Sin Autorizar"))
                {
                    MessageBox.Show("Estado actualizado");
                                actualizarTabla(control.obtenerServiciosClientesTable(txtBuscar.Text));
                }
                else MessageBox.Show("Error al actualizar estado servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
