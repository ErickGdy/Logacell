
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
    public partial class MainFinanzas : Form
    {
        private static MainFinanzas instance;
        ControlLogacell_Admin control;
        public MainFinanzas()
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            try
            {
                List<PuntoVenta> list = control.obtenerPuntoVentas();
                string[] pvs = new string[list.Count + 1];
                pvs[0] = "Todos";
                for (int i = 0; i < list.Count; i++)
                {
                    pvs[i + 1] = list.ElementAt(i).nombre;
                }
                checkedListBox1.Items.AddRange(pvs);
                checkedListBox1.SetItemChecked(0, true);
                List<int> items = new List<int>();
                items.Add(0);
                actualizarDatos(datePickerDesde.Value, datePickerHasta.Value, items);
                actualizarTablas(datePickerDesde.Value, datePickerHasta.Value, items);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void actualizarTablas(DateTime fechaInicio, DateTime fechaFin, List<int> puntosVenta)
        {
            try
            {
                actualizarTablaServicios(control.datosTablaFinanzasServicios(fechaInicio, fechaFin, puntosVenta));
                actualizarTablaProductos(control.datosTablaFinanzasProductos(fechaInicio, fechaFin, puntosVenta));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void actualizarDatos(DateTime fechaInicio, DateTime fechaFin, List<int> puntosVenta)
        {
            try
            {
                List<double> datos = control.datosFinanzas(fechaInicio, fechaFin, puntosVenta);
                //Ventas
                lblVentasEfectivo.Text = datos.ElementAt(0).ToString("C2");
                lblVentasTarjetaCredito.Text = datos.ElementAt(1).ToString("C2");
                lblTotalVentas.Text = datos.ElementAt(2).ToString("C2");
                //Servicios
                lblEfectivoServicios.Text = datos.ElementAt(3).ToString("C2");
                lblTarjetaServicios.Text = datos.ElementAt(4).ToString("C2");
                lblTotalServicios.Text = datos.ElementAt(5).ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static MainFinanzas getInstance()
        {
            if (instance == null)
            {
                instance = new MainFinanzas();
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
                dataGridViewServicios.Columns[0].Width = 150;
                dataGridViewServicios.Columns[1].Width = 250;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void actualizarTablaProductos(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewProductos.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de servicios
                dataGridViewProductos.Columns[0].Width = 220;
                dataGridViewProductos.Columns[1].Width = 65;
                dataGridViewProductos.Columns[2].Width = 65;
                dataGridViewProductos.Columns[3].Width = 80;
                dataGridViewProductos.Columns[3].HeaderText = "Cantidad";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> items = new List<int>();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i)&& i == 0)
                    {
                        items.Add(0);
                        break;
                    }
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        items.Add(i);
                    }

                }
                actualizarDatos(datePickerDesde.Value, datePickerHasta.Value, items);
                actualizarTablas(datePickerDesde.Value, datePickerHasta.Value, items);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                for (int i = 1; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
            if (e.Index != 0 && e.NewValue == CheckState.Checked)
            {
                checkedListBox1.SetItemChecked(0, false);
            }
        }
    }
}
