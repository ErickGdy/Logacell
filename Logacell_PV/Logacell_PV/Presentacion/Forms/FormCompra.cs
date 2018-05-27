using Logacell.Control;
using Logacell.DataObject;
using Logacell_PV.Presentacion.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell.Presentacion
{
    public partial class FormCompra : Form
    {
        ControlLogacell control;
        List<Producto> productos;
        List<Producto> productosComprados;
        public FormCompra()
        {
            InitializeComponent();
            control = new ControlLogacell();
            lblFecha.Text = DateTime.Now.ToShortDateString();
            productos = new List<Producto>();
            productosComprados = new List<Producto>();
            try
            {
                this.dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
                this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
                productos = control.obtenerProductos();
            }
            catch (Exception ex)
            {

            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    Producto prod = new Producto();
                    productosComprados.Clear();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        prod.id = Convert.ToInt32(row.Cells[0].Value.ToString());
                        prod.cantidad = Convert.ToInt32(row.Cells[3].Value.ToString());
                        prod.precio = row.Cells[4].Value.ToString();
                        productosComprados.Add(prod);
                    }
                    if (control.agregarCompra(productosComprados, txtTotal.Text))
                    {
                        MessageBox.Show("Compra guardada exitosamente");
                        Close();
                        Dispose();
                    }
                    else MessageBox.Show("Error al guardar compra");
                }
                else
                    MessageBox.Show("No dejar campos vacios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void onlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            };
        }
        private void noSpaces_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private bool validarCampos()
        {
            if (txtTotal.Text != "" && txtTotal.Text != "0")
                return true;
            return false;
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
        private void actualizarTotal()
        {
            try
            {
                decimal total = 0;
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    total += Convert.ToDecimal(row.Cells[3].Value.ToString()) * Convert.ToDecimal(row.Cells[4].Value.ToString());
                }
                txtTotal.Text = total.ToString("F2");
            }
            catch (Exception ex)
            {

            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string id;
                id = txtProducto.Text.Substring(0, txtProducto.Text.IndexOf(" -"));
                Producto prod = new Producto();
                foreach (Producto p in productos)
                {
                    if (p.id.ToString() == id)
                    {
                        prod = p;
                        break;
                    }
                }
                dataGridView1.Rows.Insert(dataGridView1.RowCount, prod.id, prod.nombre, control.obtenerStockProducto(prod.id.ToString()), 1, prod.precio, prod.precio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar producto, seleccione un producto válido");
            }
            limpiarForm();
            actualizarTotal();
        }
        private void limpiarForm()
        {
            txtProducto.Text = "";
        }
        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int i;
                if (txtProducto.Text.Length > 2 || int.TryParse(Convert.ToString(txtProducto.Text), out i))
                {
                    comboBox1.Items.Clear();
                    string[] aux = obtenerArregloProductos(txtProducto.Text);
                    comboBox1.Items.AddRange(aux);
                    //comboBox1.DroppedDown = true;
                }
                else
                {
                    comboBox1.DroppedDown = false;
                    comboBox1.Items.Clear();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar))
            {
                txtProducto.Focus();
            }
        }
        private string[] obtenerArregloProductos(string text)
        {
            List<string> aux = new List<string>();
            foreach (Producto p in productos)
            {
                if(p.id.ToString().IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0 || p.nombre.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0 || p.modelo.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0 || p.marca.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    aux.Add(p.id.ToString()+" - "+p.nombre+ " "+p.marca+" "+p.modelo);
                }
            }
            return aux.ToArray();
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem!=null)
                txtProducto.Text = comboBox1.SelectedItem.ToString();
        }
        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(txtProducto.Text.Length>1)
            if (e.KeyValue == 40) {
                SendKeys.Send("{TAB}");
                SendKeys.Send("{DOWN}");
                e.Handled = true;
            }
        }
        private void FormVenta_Load(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_CellValidating(object sender,DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4) // 1 should be your column index
            {
                decimal i;
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                }
                else
                {
                    if(e.ColumnIndex == 4) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).ToString("F2");
                }
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != e.FormattedValue.ToString())
                e.Cancel = true;
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            if (dataGridView1.CurrentCell.ColumnIndex == 3 || dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                if (e.ColumnIndex == 4) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).ToString("F2");
                decimal cantidad = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                decimal precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                decimal total = cantidad * precio;
                dataGridView1.CurrentRow.Cells[5].Value = total.ToString("F2");
                actualizarTotal();
            }
        }

    }
}
