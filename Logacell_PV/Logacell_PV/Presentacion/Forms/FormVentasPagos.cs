using Logacell.Control;
using Logacell.DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell_PV.Presentacion.Forms
{
    public partial class FormVentasPagos : Form
    {
        Venta venta;
        public FormVentasPagos(Venta sale)
        {
            InitializeComponent();
            this.venta = sale;
            lblFecha.Text = DateTime.Now.ToShortDateString();
            txtFolio.Text = venta.id.ToString();
            lblTotal.Text = venta.total.ToString("F2");
            lblRestante.Text= venta.total.ToString("F2");
            lblCambio.Text = "0";
            txtCantidad.Value = Convert.ToDecimal(venta.total);
            cmbFormaPago.SelectedIndex = 0;
            txtCantidad.Maximum = Convert.ToDecimal(lblRestante.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int found = -1; 
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if(dataGridView1.Rows[i].Cells[1].Value.ToString() == cmbFormaPago.SelectedItem.ToString())
                {
                    found = i;
                }
            }
            if(found>=0)
                dataGridView1.Rows[found].Cells[0].Value = Convert.ToDecimal(dataGridView1.Rows[found].Cells[0].Value.ToString()) + txtCantidad.Value;
            else
                dataGridView1.Rows.Insert(dataGridView1.RowCount, txtPago.Value, cmbFormaPago.SelectedItem.ToString());
            lblRestante.Text = (Convert.ToDecimal(lblRestante.Text) - (txtCantidad.Value)).ToString("F2");
            cmbFormaPago.SelectedIndex = 0;
            double totalEnPagos = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                totalEnPagos += Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }
            if (totalEnPagos - Convert.ToDouble(lblTotal.Text) <= 0)
                lblCambio.Text = "0";
            else
                lblCambio.Text = (totalEnPagos - Convert.ToDouble(lblTotal.Text)).ToString();

        }

        private void txtNum_ValueChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Value != 0 && txtPago.Value != 0 && txtCantidad.Value <= txtPago.Value)
                btnAgregar.Enabled = true;
            else
                btnAgregar.Enabled = false;
        }

        private void lblRestante_TextChanged(object sender, EventArgs e)
        {
            txtCantidad.Maximum = Convert.ToDecimal(lblRestante.Text);
            txtCantidad.Value = Convert.ToDecimal(lblRestante.Text);
            if (lblRestante.Text == "0.00")
            {
                btnAceptar.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAceptar.Enabled = false;
                btnAgregar.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pagos> pagos = new List<Pagos>();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    Pagos pago = new Pagos();
                    pago.folio = txtFolio.Text;
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "Efectivo")
                        pago.pago = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value.ToString()) - Convert.ToDouble(lblCambio.Text);
                    else
                        pago.pago = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    pago.formaPago = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    pagos.Add(pago);
                }
                venta.pagos = pagos;
                if (ControlLogacell.getInstance().agregarVenta(venta))
                {
                    MessageBox.Show("Venta agregada exitosamente");
                    Dispose();
                }else
                {
                    MessageBox.Show("Error al agregar venta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
