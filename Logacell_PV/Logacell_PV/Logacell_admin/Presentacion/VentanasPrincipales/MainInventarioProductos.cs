
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
    public partial class MainInventarioProductos : Form
    {
        private static MainInventarioProductos instance;
        ControlLogacell_Admin control;
        public MainInventarioProductos()
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            try
            {
                actualizarTablaProductos(control.obtenerProductosTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static MainInventarioProductos getInstance()
        {
                if (instance == null)
                {
                    instance = new MainInventarioProductos();
                }
                return instance;
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
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                lblTotalProductos.Text = dataGridViewProductos.RowCount.ToString();
                dataGridViewProductos.Columns[0].Width = 50;
                dataGridViewProductos.Columns[1].Width = 145;
                dataGridViewProductos.Columns[2].Width = 185;
                dataGridViewProductos.Columns[3].Width = 130;
                dataGridViewProductos.Columns[4].Width = 140;
                dataGridViewProductos.Columns[5].Width = 110;
                //dataGridViewProductos.Columns[6].Width = 50;
                //dataGridViewProductos.Columns[6].DefaultCellStyle.NullValue = "0";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormProducto fp = new FormProducto(null,0);
            fp.FormClosed += new FormClosedEventHandler(form_Closed);
            fp.Show();
        }
        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTablaProductos(control.obtenerProductosTable(txtBuscarProducto.Text));
        }

        private void menuEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridViewProductos.CurrentRow.Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("¿Desea eliminar el Producto?", "Eliminar Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (control.eliminarProducto(id))
                    {
                        MessageBox.Show("Producto Eliminado");
                        actualizarTablaProductos(control.obtenerProductosTable());
                    }
                    else MessageBox.Show("Error al eliminar producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridViewProductos.CurrentRow.Cells[0].Value.ToString();
                Producto producto = control.consultarProducto(id);
                FormProducto fp = new FormProducto(producto,0);
                fp.FormClosed += new FormClosedEventHandler(form_Closed);
                fp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuConsultarProducto_Click(object sender, EventArgs e)
        {
            consultarProducto();
        }

        private void limpiarBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            limpiarBusqueda.Visible = false;
            txtBuscarProducto.Text = "";
            try
            {
                actualizarTablaProductos(control.obtenerProductosTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBuscarProducto_KeyUp_1(object sender, KeyEventArgs e)
        {
            limpiarBusqueda.Visible = true;
            if (txtBuscarProducto.Text == "")
                limpiarBusqueda.Visible = false;
            try
            {
                actualizarTablaProductos(control.obtenerProductosTable(txtBuscarProducto.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            consultarProducto();
        }

        private void consultarProducto()
        {
            switch (dataGridViewProductos.CurrentRow.Cells[1].Value.ToString())
            {
                case "Protector":
                    imgAccesorio.Visible=false;
                    imgCristal.Visible = false;
                    imgProtector.Visible = true;
                    break;
                case "Cristal":
                    imgAccesorio.Visible = false;
                    imgCristal.Visible = true;
                    imgProtector.Visible = false;
                    break;
                case "Accesorio":
                    imgAccesorio.Visible = true;
                    imgCristal.Visible = false;
                    imgProtector.Visible = false;
                    break;
            }
            lblID.Text = dataGridViewProductos.CurrentRow.Cells[0].Value.ToString();
            lblCategoria.Text = dataGridViewProductos.CurrentRow.Cells[1].Value.ToString();
            lblNombre.Text = dataGridViewProductos.CurrentRow.Cells[2].Value.ToString();
            lblMarca.Text = dataGridViewProductos.CurrentRow.Cells[3].Value.ToString();
            lblModelo.Text = dataGridViewProductos.CurrentRow.Cells[4].Value.ToString();
            lblPrecio.Text = dataGridViewProductos.CurrentRow.Cells[5].Value.ToString();
            //lblStock.Text = dataGridViewProductos.CurrentRow.Cells[6].Value.ToString();
        }

        private void MainInventarioProductos_SizeChanged(object sender, EventArgs e)
        {
            panelDetalles.Height = this.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizarTablaProductos(control.obtenerProductosTable(txtBuscarProducto.Text));
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.id = Convert.ToInt32(dataGridViewProductos.CurrentRow.Cells[0].Value.ToString());
            p.categoria = dataGridViewProductos.CurrentRow.Cells[1].Value.ToString();
            p.nombre = dataGridViewProductos.CurrentRow.Cells[2].Value.ToString();
            p.marca = dataGridViewProductos.CurrentRow.Cells[3].Value.ToString();
            p.modelo = dataGridViewProductos.CurrentRow.Cells[4].Value.ToString();
            StockEnPV spv = new StockEnPV(p);
            spv.Show();
        }

        private void mínMáxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dataGridViewProductos.CurrentRow.Cells[0].Value.ToString();
                Producto producto = control.consultarProducto(id);
                ProductosMinMax fp = new ProductosMinMax(producto);
                fp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
