
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
    public partial class DetalleDeVenta : Form
    {
        private static DetalleDeVenta instance;
        ControlLogacell control;
       
        public DetalleDeVenta(Venta dv)
        {
            InitializeComponent();

            control = ControlLogacell.getInstance(); ;
            actualizarTabla(control.obtenerDetalleVentasTable(dv.id));
            lblFolio.Text = dv.id;
            lblFecha.Text = dv.fecha.ToString();
            lblTotal.Text = dv.total.ToString();
            lblPV.Text = control.consultarPuntoVenta(dv.puntoVenta.ToString()).nombre;
            lblVendedor.Text = control.consultarEmpleado(dv.vendedor).nombre;

        }

        public static DetalleDeVenta getInstance(Venta sc)
        {
                if (instance == null)
                {
                    instance = new DetalleDeVenta(sc);
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
                dataGridView1.Columns[1].Width = 243;
                dataGridView1.Columns[2].Width = 65;
                dataGridView1.Columns[3].Width = 65;
                dataGridView1.Columns[4].Width = 65;
                dataGridView1.Columns[5].Width = 65;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



       

      
    }
}
