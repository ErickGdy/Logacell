﻿using Logacell.Control;
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
    public partial class FormVenta : Form
    {
        ControlLogacell control;
        List<Producto> productos;
        List<Producto> productosVendidos;
        FormVentaDescuentoDialog fd;
        public FormVenta()
        {
            InitializeComponent();
            control = new ControlLogacell();
            lblFecha.Text = DateTime.Now.ToShortDateString();
            productos = new List<Producto>();              
            try
            {
                txtFolio.Text = control.folioVenta();
                productos = control.obtenerProductosByPV();
                this.dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
                this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
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
                    List<DetalleVenta> detalles = new List<DetalleVenta>();
                    DetalleVenta detalle;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        detalle = new DetalleVenta();
                        detalle.folio = txtFolio.Text;
                        detalle.total=Convert.ToDouble(row.Cells[5].Value.ToString());
                        if(row.Cells[4].Value.ToString()!="Agregar")
                            detalle.descuento =Convert.ToDouble(Decimal.Round(Convert.ToDecimal(row.Cells[5].Value.ToString()) * (Convert.ToDecimal(row.Cells[4].Value.ToString())/100)));
                        else
                            detalle.descuento = 0;
                        detalle.idProducto = Convert.ToInt32(row.Cells[0].Value.ToString());
                        detalle.cantidadProducto = Convert.ToInt32(row.Cells[3].Value.ToString());
                        detalles.Add(detalle);
                    }
                    Venta venta = new Venta();
                    venta.id = txtFolio.Text;
                    venta.productos = detalles;
                    venta.total = Convert.ToDouble(txtTotal.Text);
                    FormVentasPagos fv = new FormVentasPagos(venta);
                    fv.FormClosed += new FormClosedEventHandler(form_ClosedThis);
                    fv.ShowDialog();
        
            }
                else
                    MessageBox.Show("No dejar campos vacios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void form_ClosedThis(object sender, FormClosedEventArgs e)
        {
            Close();
            Dispose();
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
            if (txtSubTotal.Text != "" && txtSubTotal.Text != "0")
                return true;
            return false;
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productos.RemoveAt(dataGridView1.CurrentRow.Index);
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            actualizarTotal();
        }
        private void actualizarTotal()
        {
            try
            {
                decimal descuentos = 0;
                decimal cont = 0;
                decimal total = 0;
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    cont += Convert.ToDecimal(row.Cells[5].Value.ToString())* Convert.ToDecimal(row.Cells[3].Value.ToString());
                    if(row.Cells[4].Value.ToString()!="Agregar")
                        descuentos += Decimal.Round(Convert.ToDecimal(Convert.ToDecimal(row.Cells[5].Value.ToString()) * (Convert.ToDecimal(row.Cells[4].Value.ToString())/100)) * Convert.ToDecimal(row.Cells[3].Value.ToString()));
                }
                total = cont - descuentos;
                txtSubTotal.Text = cont.ToString("F2");
                txtTotal.Text = total.ToString("F2");
                txtDescuento.Text = descuentos.ToString("F2");
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
                Producto prod = null;
                foreach (Producto p in productos)
                {
                    if (p.id.ToString() == id)
                    {
                        prod = p;
                        break;
                    }
                }
                dataGridView1.Rows.Insert(dataGridView1.RowCount, prod.id, prod.nombre, prod.cantidad, 1, "Agregar", prod.precio);
            }catch(Exception ex)
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
                if (p.id.ToString().IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0 || p.nombre.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0 || p.modelo.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0 || p.marca.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
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
        private void dataGridView1_CellValidating(object sender,DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3) // 1 should be your column index
            {
                decimal i;
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                }
                if (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value) < Convert.ToDecimal(e.FormattedValue))
                {
                    e.Cancel = true;
                    MessageBox.Show("La cantidad no puede exceder el stock");
                }
            }
            if (e.ColumnIndex != 3 && e.ColumnIndex != 4)
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != e.FormattedValue.ToString())
                    e.Cancel = true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                fd = new FormVentaDescuentoDialog();
                fd.FormClosed += new FormClosedEventHandler(form_ClosedClientes);
                fd.ShowDialog();
            }
            if (e.ColumnIndex == 3)
            {
                actualizarTotal();
            }
        }
        private void form_ClosedClientes(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            if(fd.discount()>0)
                dataGridView1.CurrentRow.Cells[4].Value= fd.discount();
            if (fd.discount() == 0)
                dataGridView1.CurrentRow.Cells[4].Value = "Agregar";
            actualizarTotal();
        }
    }
}
