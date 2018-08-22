
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
    public partial class MainPuntoVenta : Form
    {
        private static MainPuntoVenta instance;
        ControlLogacell_Admin control;
       
        public MainPuntoVenta()
        {
            InitializeComponent();
            control = new ControlLogacell_Admin();
            try
            {
                actualizarTabla(control.obtenerPuntoVentasTable());
                actualizarTablaCajas(control.obtenerCajasTable());
                actualizarTablaCortes(control.obtenerCortesTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
}

        public static MainPuntoVenta getInstance()
        {
                if (instance == null)
                {
                    instance = new MainPuntoVenta();
                }
                return instance;
        }


        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTabla(control.obtenerPuntoVentasTable());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormPuntoVenta form = new FormPuntoVenta(null);
            form.FormClosed += new FormClosedEventHandler(form_Closed);
            form.Show();
        }
        private void form_ClosedClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTabla(control.obtenerPuntoVentasTable());
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
                dataGridView1.Columns[0].Width = 65;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 185;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 140;
                dataGridView1.Columns[5].Width = 100;
                lblTotal.Text = dataGridView1.RowCount.ToString();
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
                actualizarTabla(control.obtenerPuntoVentasTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String id  = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            MessageBox.Show("aqui se mostraran los datos relevantes del punto de venta: "+id);
        }

        private void modificaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                PuntoVenta pv = control.consultarPuntoVenta(id);
                FormPuntoVenta form = new FormPuntoVenta(pv);
                form.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
                form.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eliminarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("¿Desea eliminar el Punto de venta?", "Eliminar Punto de Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (control.eliminarPuntoVenta(id))
                    {
                        MessageBox.Show("Punto de venta Eliminado");
                        actualizarTabla(control.obtenerPuntoVentasTable());
                    }
                    else MessageBox.Show("Error al eliminar punto de venta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void txtBuscarCaja_KeyUp(object sender, KeyEventArgs e)
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

        private void consultarCajaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                String idCaja = dataGridViewCaja.CurrentRow.Cells[0].Value.ToString();
                MainMovimientosCaja mvc = new MainMovimientosCaja(Convert.ToInt32(idCaja));
                mvc.Show();
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

        private void btnActualizarPV_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarTabla(control.obtenerPuntoVentasTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizarTablaCortes_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarTablaCortes(control.obtenerCortesTable(txtBuscarCortes.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtBuscarCortes.Text = "";
            linkLabel1.Visible = false;
            try
            {
                actualizarTablaCortes(control.obtenerCortesTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void actualizarTablaCortes(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewCortes.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                lblTotalCortes.Text = dataGridViewCortes.RowCount.ToString();
                dataGridViewCortes.Columns[0].Width = 50;
                dataGridViewCortes.Columns[1].Width = 130;
                dataGridViewCortes.Columns[2].Width = 140;
                dataGridViewCortes.Columns[3].Width = 70;
                dataGridViewCortes.Columns[4].Width = 140;
                dataGridViewCortes.Columns[5].Width = 140;
                dataGridViewCortes.Columns[5].ValueType = typeof(DateTime);
                dataGridViewCortes.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                dataGridViewCortes.Columns[6].Width = 140;
                dataGridViewCortes.Columns[6].ValueType = typeof(DateTime);
                dataGridViewCortes.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void txtBuscarCortes_KeyUp(object sender, KeyEventArgs e)
        {
            linkLabel1.Visible = true;
            if (txtBuscarCortes.Text == "")
                linkLabel1.Visible = false;
            try
            {
                actualizarTablaCortes(control.obtenerCortesTable(txtBuscarCortes.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                String puntoVenta = "";
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridViewCortes.CurrentRow.Cells[1].Value.ToString() == dataGridView1.Rows[i].Cells[1].Value.ToString())
                    {
                        puntoVenta = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        break;
                    }
                }
                String fechaInicio = dataGridViewCortes.CurrentRow.Cells[5].Value.ToString();
                String fechaFin = dataGridViewCortes.CurrentRow.Cells[6].Value.ToString();
                FormCorteCaja mvc = new FormCorteCaja(Convert.ToInt32(puntoVenta),fechaInicio,fechaFin, dataGridViewCortes.CurrentRow.Cells[0].Value.ToString());
                mvc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
