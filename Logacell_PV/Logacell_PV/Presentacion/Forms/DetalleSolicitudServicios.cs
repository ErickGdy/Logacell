
using Logacell.Control;
using Logacell.DataObject;
using Logacell.Presentacion;
using Logacell_PV.Presentacion.Forms;
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
    public partial class DetalleSolicitudServicios : Form
    {
        private static DetalleSolicitudServicios instance;
        ControlLogacell control;
        SolicitudServicio solicitud;
       
        public DetalleSolicitudServicios(SolicitudServicio sc)
        {
            InitializeComponent();
            solicitud = sc;
            control = ControlLogacell.getInstance(); ;
            actualizarTabla(control.obtenerDetalleServiciosClientesTable(sc.Folio));
            lblFolio.Text = sc.Folio;
            lblNombre.Text = sc.nombreCliente;
            lblTelefono.Text = sc.telefonoCliente;
            lblTotal.Text = sc.total;
            lblPendiente.Text = sc.pendiente;
            lblPego.Text = sc.anticipo;
        }

        public static DetalleSolicitudServicios getInstance(SolicitudServicio sc)
        {
                if (instance == null)
                {
                    instance = new DetalleSolicitudServicios(sc);
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
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 190;
                dataGridView1.Columns[1].HeaderText = "Descripción";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Contraseña";
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[4].HeaderText = "Patrón";
                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[5].Width = 40;
                dataGridView1.Columns[6].Width = 40;
                dataGridView1.Columns[7].Width = 50;
                dataGridView1.Columns[8].Width = 40;
                dataGridView1.Columns[9].Width = 110;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
                        actualizarTabla(control.obtenerDetalleServiciosClientesTable(lblFolio.Text));
                        actualizarDatos();
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
                    actualizarTabla(control.obtenerDetalleServiciosClientesTable(lblFolio.Text));
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
                    actualizarTabla(control.obtenerDetalleServiciosClientesTable(lblFolio.Text));
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
                    actualizarTabla(control.obtenerDetalleServiciosClientesTable(lblFolio.Text));
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
                    actualizarTabla(control.obtenerDetalleServiciosClientesTable(lblFolio.Text));
                }
                else MessageBox.Show("Error al actualizar estado servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void actualizarDatos()
        {
            try
            {
                SolicitudServicio sc = control.consultarSolicitudServicio(lblFolio.Text);
                lblNombre.Text = sc.nombreCliente;
                lblTelefono.Text = sc.telefonoCliente;
                lblTotal.Text = sc.total;
                lblPendiente.Text = sc.pendiente;
                lblPego.Text = sc.anticipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar datos del servicios");
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
                    actualizarTabla(control.obtenerDetalleServiciosClientesTable(lblFolio.Text));
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
                    actualizarTabla(control.obtenerDetalleServiciosClientesTable(lblFolio.Text));
                }
                else MessageBox.Show("Error al actualizar estado servicio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modificarCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormServicioClienteCotizacion fcm = new FormServicioClienteCotizacion(dataGridView1.CurrentRow.Cells[0].Value.ToString(),lblFolio.Text);
            fcm.FormClosed += new FormClosedEventHandler(form_Closed);
            fcm.Show();
        }
        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                actualizarTabla(control.obtenerDetalleServiciosClientesTable(lblFolio.Text));
                SolicitudServicio sc = control.consultarSolicitudServicio(lblFolio.Text);
                lblTotal.Text = sc.total;
                lblPendiente.Text = sc.pendiente;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   }
}
