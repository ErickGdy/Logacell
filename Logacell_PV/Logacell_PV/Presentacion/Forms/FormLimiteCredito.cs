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
    public partial class FormLimiteCredito : Form
    {
        ControlLogacell control;
        bool modificacion = false;
        string idCliente = "";
        public FormLimiteCredito(CreditoCliente credito) { 
            InitializeComponent();
            control = new ControlLogacell();
            lblCliente.Text = control.consultarCliente(credito.cliente).nombre;
            txtLimiteCredito.Text = credito.limiteCredito.ToString();
            txtDeuda.Text = credito.deuda.ToString();
            txtNuevo.Value = credito.limiteCredito;
            idCliente = credito.cliente;
            if (control.consultarCreditoCliente(idCliente)!= null)
            {
                modificacion = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                CreditoCliente c = new CreditoCliente();
                c.limiteCredito = Convert.ToInt32(txtNuevo.Value);
                c.pendiente = Convert.ToInt32(txtDeuda.Text);
                c.deuda = Convert.ToInt32(txtDeuda.Text);
                c.cliente = idCliente;
                try
                {
                    if (modificacion)
                    {
                        if (control.actualizarCreditoCliente(c))
                        {
                            MessageBox.Show("Limite de crédito actualizado exitosamente!");
                            Close();
                            Dispose();
                        }
                        else
                            MessageBox.Show("Error al guardar datos, verifique los campos y vuelva a intentarlo");
                    }else
                    {
                        if (control.agregarCreditoClientes(c))
                        {
                            MessageBox.Show("Limite de crédito actualizado exitosamente!");
                            Close();
                            Dispose();
                        }
                        else
                            MessageBox.Show("Error al guardar datos, verifique los campos y vuelva a intentarlo");
                    }
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
            if (txtLimiteCredito.Text != "" && txtNuevo.Text != "" && txtDeuda.Text != "")
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

        private void btnCancelarCredito_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea cancelar crédito?", "Cancelar credito cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                CreditoCliente c = new CreditoCliente();
                c.limiteCredito = 0;
                c.pendiente = Convert.ToInt32(txtDeuda.Text);
                c.deuda = Convert.ToInt32(txtDeuda.Text);
                c.cliente = idCliente;
                try
                {
                    if (control.cancelarCreditoCliente(c))
                    {
                        MessageBox.Show("Crédito cancelado exitosamente!");
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
        }
      
    }
}
