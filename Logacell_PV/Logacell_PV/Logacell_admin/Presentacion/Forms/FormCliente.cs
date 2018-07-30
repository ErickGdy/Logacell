using Logacell_Admin.Control;
using Logacell_Admin.DataObject;
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
    public partial class FormCliente : Form
    {
        ControlLogacell_Admin control;
        bool modificacion = false;
        public FormCliente(Cliente cliente) { 
            InitializeComponent();
            control = new ControlLogacell_Admin();
            if(cliente != null)
            {
                modificacion = true;
                txtNombre.Text = cliente.nombre;
                txtDireccion.Text = cliente.direcion;
                txtTelefono.Text = cliente.telefono;
                txtCorreo.Text = cliente.correo;
                txtObservaciones.Text = cliente.observaciones;
                checkCredito.Checked = cliente.is_credito;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Cliente c = new Cliente();
                c.nombre = txtNombre.Text;
                c.direcion = txtDireccion.Text;
                c.telefono = txtTelefono.Text;
                c.correo = txtCorreo.Text;
                c.observaciones = txtObservaciones.Text;
                c.is_credito = checkCredito.Checked;
                try
                {
                    if (modificacion)
                    {
                        if (control.actualizarCliente(c))
                        {
                            MessageBox.Show("Datos actualizados exitosamente!");
                            Close();
                            Dispose();
                        }
                        else
                            MessageBox.Show("Error al guardar datos, verifique los campos y vuelva a intentarlo");
                    }
                    else
                    {
                        if (control.agregarCliente(c))
                        {
                            MessageBox.Show("Datos guardados exitosamente!");
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
            if (txtCorreo.Text != "" && txtDireccion.Text != "" && txtNombre.Text != "" && txtObservaciones.Text != "" && txtTelefono.Text != "")
                return true;
            return false;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
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

    }
}
