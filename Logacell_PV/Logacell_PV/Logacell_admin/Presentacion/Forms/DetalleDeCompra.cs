
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
    public partial class DetalleDeCompra : Form
    {
        private static DetalleDeCompra instance;
        ControlLogacell_Admin control;
       
        public DetalleDeCompra(Compra dv)
        {
            InitializeComponent();

            control = ControlLogacell_Admin.getInstance(); ;
            actualizarTabla(control.obtenerDetalleComprasTable(dv.id.ToString()));
            lblFolio.Text = dv.id.ToString();
            lblFecha.Text = dv.fecha.ToString();
            lblTotal.Text = dv.total.ToString();
            lblPV.Text = control.consultarPuntoVenta(dv.idPV.ToString()).nombre;
            lblVendedor.Text = control.consultarEmpleado(dv.Empleado).nombre;

        }

        public static DetalleDeCompra getInstance(Compra sc)
        {
            if (instance == null)
            {
                instance = new DetalleDeCompra (sc);
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
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 243;
                dataGridView1.Columns[2].Width = 100;
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
