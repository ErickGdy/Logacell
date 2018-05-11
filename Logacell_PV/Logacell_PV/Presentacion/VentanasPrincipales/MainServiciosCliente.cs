
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
    public partial class MainServiciosCliente : Form
    {
        private static MainServiciosCliente instance;
        ControlLogacell control;
       
        public MainServiciosCliente()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
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
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
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
            sc.total = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            sc.anticipo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            sc.pendiente = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            DetalleSolicitudServicios dt = new DetalleSolicitudServicios(sc);
            dt.Show();
        }

        private void modificaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                ServicioCliente serCli = control.consultarServicioCliente(id);
                //FormServicio fc = new FormCliente(serCli);
                //fc.FormClosed += new FormClosedEventHandler(form_Closed);
                //fc.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eliminarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("¿Desea cancelar el servicio?", "Cancelar servicio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (control.actualizarEstadoServicioCliente(id, "Cancelado"))
                    {
                        MessageBox.Show("Servicio Cancelado");
                        actualizarTabla(control.obtenerServiciosClientesTable());
                    }
                    else MessageBox.Show("Error al cancelar servicio");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormServicioCliente fm = new FormServicioCliente();
            fm.FormClosed += new FormClosedEventHandler(form_Closed);
            fm.Show();
        }

        private void esperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (control.actualizarEstadoServicioCliente(id, "Espera"))
                {
                    MessageBox.Show("Servicio actualizado");
                    actualizarTabla(control.obtenerServiciosClientesTable());
                }
                else MessageBox.Show("Error al actualizar estado de servicio");
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
                    MessageBox.Show("Servicio actualizado");
                    actualizarTabla(control.obtenerServiciosClientesTable());
                }
                else MessageBox.Show("Error al actualizar estado de servicio");
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
                if (control.actualizarEstadoServicioCliente(id, "Terminado"))
                {
                    MessageBox.Show("Servicio actualizado");
                    actualizarTabla(control.obtenerServiciosClientesTable());
                }
                else MessageBox.Show("Error al actualizar estado de servicio");
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
                    MessageBox.Show("Servicio actualizado");
                    actualizarTabla(control.obtenerServiciosClientesTable());
                }
                else MessageBox.Show("Error al actualizar estado de servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainServiciosCliente_SizeChanged(object sender, EventArgs e)
        {
            pnMenus.Height = this.Height;
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            actualizarTabla(control.obtenerServiciosClientesTable());
        }
    }
}
