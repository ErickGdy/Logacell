using Logacell.Control;
using Logacell.DataObject;
using Logacell_PV.DataObject;
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
    public partial class FormEgreso : Form
    {
        ControlLogacell control;
        bool modificacion = false;
        public FormEgreso(IngresoEgreso pago)
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            cmbTipo.SelectedIndex = 0;
            if (pago!=null)
            {
                modificacion = true;
                txtID.Text = pago.id.ToString();
                txtCantidad.Value = Convert.ToDecimal(pago.pago);
                txtCantidad.ReadOnly = true;
                dateTimePicker1.Value = pago.fecha;
                cmbTipo.SelectedItem = pago.tipo;
                txtConcepto.Text = pago.concepto;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                agregarMovimiento();
                    
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool validarCampos()
        {
            if (txtCantidad.Text != "0" && txtConcepto.Text != "")
                return true;
            return false;
        }

        private bool agregarMovimiento()
        {
            if (validarCampos())
            {
                IngresoEgreso p = new IngresoEgreso();
                p.pago = Convert.ToDouble(txtCantidad.Value);
                p.fecha = dateTimePicker1.Value;
                p.concepto = txtConcepto.Text;
                if (modificacion)
                {
                    p.id = Convert.ToInt32(txtID.Text);
                    if (control.actualizarIngresoEgreso(p, cmbTipo.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Datos guardados exitosamente");
                        Close();
                        Dispose();
                    }
                    else
                        MessageBox.Show("Error al actualizar movimiento de caja");
                }
                else
                {
                    if (control.agregarIngresoEgreso(p, cmbTipo.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Datos guardados exitosamente");
                        Close();
                        Dispose();
                    }
                    else
                        MessageBox.Show("Error al agregar movimiento de caja");
                }
            }
            else
                MessageBox.Show("No dejar campos vacios");
            return false;
        }
    }
}
