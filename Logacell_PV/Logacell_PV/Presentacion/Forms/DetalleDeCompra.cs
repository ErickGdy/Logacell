
using Logacell.Control;
using Logacell.DataObject;
using Logacell.Presentacion;
using Logacell_PV.DataObject;
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
    public partial class DetalleDeCompra : Form
    {
        private static DetalleDeCompra instance;
        ControlLogacell control;
       
        public DetalleDeCompra(Compra compra)
        {
            InitializeComponent();

            control = ControlLogacell.getInstance(); ;
            actualizarTabla(control.obtenerDetalleComprasTable(compra.id));
            lblFolio.Text = compra.id;
            lblFecha.Text = compra.fecha.ToString();
            lblTotal.Text = compra.total.ToString();
            try
            {
                lblPV.Text = control.consultarPuntoVenta(compra.idPV.ToString()).nombre;
                lblVendedor.Text = control.consultarEmpleado(compra.Empleado).nombre;
            }
            catch (Exception ex)
            {

            }

        }

        public static DetalleDeCompra getInstance(Compra sc)
        {
                if (instance == null)
                {
                    instance = new DetalleDeCompra(sc);
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
                dataGridView1.Columns[0].Width = 240;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns[3].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns[3].Width = 100;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



       

      
    }
}
