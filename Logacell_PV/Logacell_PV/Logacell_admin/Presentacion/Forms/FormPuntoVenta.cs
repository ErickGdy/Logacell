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
    public partial class FormPuntoVenta : Form
    {
        ControlLogacell_Admin control;
        bool modificacion = false;
        public FormPuntoVenta(PuntoVenta pv)
        {
            InitializeComponent();
            control = new ControlLogacell_Admin();
            if (pv != null)
            {
                modificacion = true;
                txtID.Text = pv.id.ToString();
                txtNombre.Text = pv.nombre;
                txtDireccion.Text = pv.direcion;
                txtTelefono.Text = pv.telefono;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                PuntoVenta c = new PuntoVenta();
                c.nombre = txtNombre.Text;
                c.direcion = txtDireccion.Text;
                c.telefono = txtTelefono.Text;
                try
                {
                    if (modificacion)
                    {
                        c.id = Convert.ToInt32(txtID.Text);
                        if (control.actualizarPuntoVenta(c))
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
                        if (control.agregarPuntoVentas(c))
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


        //--------Metodos de control de form------------//
        private bool validarCampos()
        {
            if (txtDireccion.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "")
                return true;
            return false;
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
    }
}
