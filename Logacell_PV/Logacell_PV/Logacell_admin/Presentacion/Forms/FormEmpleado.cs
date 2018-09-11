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
    public partial class FormEmpleado : Form
    {
        ControlLogacell_Admin control;
        bool modificacion = false;
        Empleado c = new Empleado();
        public FormEmpleado(Empleado empleado, Usuario usuario)
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            if(empleado != null)
            {
                c = empleado;
                modificacion = true;
                txtCorreo.Text = empleado.correo;
                txtDireccion.Text = empleado.direcion;
                txtNombre.Text = empleado.nombre;
                txtPuesto.SelectedItem = empleado.puesto;
                txtTelefono.Text = empleado.telefono;
            }
            if (usuario != null)
            {
                checkAcceso.Checked = usuario.estado;
                txtUsuario.Text = usuario.usuario;
                txtContrasena.Text = usuario.contraseña;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                c.nombre = txtNombre.Text;
                c.direcion = txtDireccion.Text;
                c.telefono = txtTelefono.Text;
                c.correo = txtCorreo.Text;
                c.puesto = txtPuesto.SelectedItem.ToString();
                Usuario u = null;
                if (checkAcceso.Checked == true)
                {
                    u = new Usuario();
                    u.usuario = txtUsuario.Text;
                    u.contraseña = txtContrasena.Text;
                    u.estado = checkAcceso.Checked;
                }
                try
                {
                    if (modificacion)
                    {
                        if (control.actualizarEmpleado(c, txtUsuario.Text,txtContrasena.Text, checkAcceso.Checked))
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
                        if (control.agregarEmpleados(c, u))
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
            if (txtCorreo.Text != "" && txtDireccion.Text != "" && txtNombre.Text != ""  && txtTelefono.Text != "")
                if (checkAcceso.Checked)
                {
                    if (txtUsuario.Text != "" && txtContrasena.Text != "")
                        return true;
                    else
                        return false;
                }else
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

        private void checkAcceso_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAcceso.Checked)
                panelUsuario.Enabled = true;
            else
                panelUsuario.Enabled = false;
        }
    }
}
