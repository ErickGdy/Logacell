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
    public partial class FormServicioCliente : Form
    {
        ControlLogacell control;
        public FormServicioCliente()
        {
            InitializeComponent();
            control = new ControlLogacell();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try {
                if (validarCampos())
                {
                    ServicioCliente s = new ServicioCliente();
                    if (control.agregarServiciosClientes(s))
                    {
                        MessageBox.Show("Datos guardados exitosamente");
                        Close();
                        this.Dispose();
                    }
                    else
                        MessageBox.Show("Error: verifique los campos y vuelva a intentarlo");
                }
                else
                    MessageBox.Show("No dejar campos vacios");
            }catch(Exception ex){
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
            if (txtTelefono.Text != "" && txtNombre.Text != "" && txtTotal.Text!="" && txtTotal.Text != "0")
                return true;
            return false;
        }

        private void txtAnticipo_KeyUp(object sender, KeyEventArgs e)
        {
            actualizarTotal();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            
            actualizarTotal();
        }

        private void actualizarTotal()
        {
            try
            {
                txtPendiente.Text = (Convert.ToInt32(txtTotal.Text) - Convert.ToInt32(txtAnticipo.Text)).ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtAnticipo_TextChanged(object sender, EventArgs e)
        {
            actualizarTotal();
        }

        private void txtAnticipo_Leave(object sender, EventArgs e)
        {
            if (txtAnticipo.Text == "")
                txtAnticipo.Text = "0";
        }
    }
}
