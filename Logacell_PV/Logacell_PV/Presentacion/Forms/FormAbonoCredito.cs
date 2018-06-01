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

namespace Logacell.Presentacion
{
    public partial class FormAbonoCredito : Form
    {
        ControlLogacell control;
        bool modificacion = false;
        string idCliente = "";
        public FormAbonoCredito(CreditoCliente credito) { 
            InitializeComponent();
            control = new ControlLogacell();
            if(credito != null)
            {
                modificacion = true;
                lblCliente.Text = control.consultarCliente(credito.cliente).nombre;
                txtLimiteCredito.Text = credito.limiteCredito.ToString();
                txtPendiente.Text = credito.pendiente.ToString();
                txtDeuda.Text = credito.deuda.ToString();
                txtAbono.Maximum = credito.deuda;
                txtAbono.Value = credito.deuda;
                idCliente = credito.cliente;
            }
            cmbFormaPago.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                CreditoCliente c = new CreditoCliente();
                c.limiteCredito = Convert.ToInt32(txtLimiteCredito.Text);
                c.pendiente = Convert.ToInt32(txtPendiente.Text);
                c.deuda = Convert.ToInt32(txtPendiente.Text);
                c.cliente = idCliente;
                AbonoCredito a = new AbonoCredito();
                a.abono = Convert.ToInt32(txtAbono.Text);
                a.cliente = idCliente;
                a.empleado = ControlLogacell.currentUser.empleado;
                try
                {
                    if (control.actualizarCreditoCliente(c))
                    {
                        if (control.agregarAbonoCredito(a,cmbFormaPago.SelectedItem.ToString()))
                        {
                            MessageBox.Show("Datos guardados exitosamente!");
                        }else
                        {
                            MessageBox.Show("Ocurio un error al registrar pago");
                        }
                        Close();
                        Dispose();
                    }
                    else
                        MessageBox.Show("Error al guardar datos, verifique los campos y vuelva a intentarlo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("No dejar campos vacios");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private bool validarCampos()
        {
            if (txtLimiteCredito.Text != "" && txtAbono.Text != "" && txtPendiente.Text != "" && txtDeuda.Text != "")
                return true;
            return false;
        }

        private void onlyNumbers(object sender, KeyPressEventArgs e)
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

        private void nonSpaces(object sender, KeyPressEventArgs e)
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

        private void calcularPendiente(object sender, EventArgs e)
        {
            if (txtAbono.Text != "")
                txtPendiente.Text = (Convert.ToInt32(txtDeuda.Text) - Convert.ToInt32(txtAbono.Value)).ToString();
            if (txtAbono.Value <= Convert.ToInt32(txtDeuda.Text) && txtAbono.Value != 0)
                btnAceptar.Enabled = true;
            else
                btnAceptar.Enabled = false;
            if (txtPago.Value >= txtAbono.Value)
            {
                txtCambio.Text = (txtPago.Value - txtAbono.Value).ToString();
                btnAceptar.Enabled = true;
            }
            else
                btnAceptar.Enabled = false;

            }
        private void txtPago_ValueChanged(object sender, EventArgs e)
        {
            if(txtPago.Value >= txtAbono.Value)
            {
                txtCambio.Text = (txtPago.Value - txtAbono.Value).ToString();
                btnAceptar.Enabled = true;
            }
            else
                btnAceptar.Enabled = false;
        }

        private void txtAbono_KeyUp(object sender, KeyEventArgs e)
        {
            calcularPendiente(null, null);
        }

        private void txtPago_KeyUp(object sender, KeyEventArgs e)
        {
            txtPago_ValueChanged(null,null);
        }
        
    }
}
