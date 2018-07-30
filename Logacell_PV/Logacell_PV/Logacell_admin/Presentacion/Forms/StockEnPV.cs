
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
    public partial class StockEnPV : Form
    {
        private static StockEnPV instance;
        ControlLogacell_Admin control;
        Producto producto;
        List<PuntoVenta> puntosDeVenta;
       
        public StockEnPV(Producto p)
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance(); ;
            lblID.Text = p.id.ToString();
            lblCategoria.Text = p.categoria;
            lblNombre.Text = p.nombre;
            lblMarca.Text = p.marca;
            lblModelo.Text = p.modelo;
            producto = p;
            puntosDeVenta = control.obtenerPuntoVentas();
            actualizarTabla();

        }

        public static StockEnPV getInstance(Producto p)
        {
                if (instance == null)
                {
                    instance = new StockEnPV(p);
                }
                return instance;
        }


        public void actualizarTabla()
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (PuntoVenta pv in puntosDeVenta)
                {
                    int x = control.obtenerStockProducto(producto.id.ToString(), pv.id);
                    if (x <0)
                        dataGridView1.Rows.Insert(dataGridView1.RowCount, pv.nombre, 0);
                    else
                        dataGridView1.Rows.Insert(dataGridView1.RowCount, pv.nombre, x);
                }
                dataGridView1.Columns[0].Width = 195;
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[1].DefaultCellStyle.NullValue = 0;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

       

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String telefono  = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            MessageBox.Show("aqui se mostraran los datos relevantes del cliente: "+telefono);
        }

        private void modificarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockModificarPV st = new StockModificarPV(producto,puntosDeVenta.ElementAt(dataGridView1.CurrentRow.Index));
            st.ShowDialog();
            actualizarTabla();
        }
    }
}
