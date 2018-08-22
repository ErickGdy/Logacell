
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
    public partial class StockEnPV : Form
    {
        private static StockEnPV instance;
        ControlLogacell control;
       
        public StockEnPV(Producto p)
        {
            InitializeComponent();
            control = ControlLogacell.getInstance(); ;
            lblID.Text = p.id.ToString();
            lblCategoria.Text = p.categoria;
            lblNombre.Text = p.nombre;
            lblMarca.Text = p.marca;
            lblModelo.Text = p.modelo;
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
                foreach (PuntoVenta pv in control.obtenerPuntoVentas())
                {
                    int x = control.obtenerStockProducto(lblID.Text, pv.id);
                    if (x < 0)
                        dataGridView1.Rows.Insert(dataGridView1.RowCount, pv.nombre, 0);
                    else
                        dataGridView1.Rows.Insert(dataGridView1.RowCount, pv.nombre, x);
                }
                dataGridView1.Columns[0].Width = 195;
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[1].DefaultCellStyle.NullValue = 0;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


    }
}
