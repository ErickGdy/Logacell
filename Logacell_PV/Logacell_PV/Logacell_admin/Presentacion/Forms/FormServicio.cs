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
    public partial class FormServicio : Form
    {
        ControlLogacell_Admin control;
        bool modificacion = false;
        public FormServicio(Servicio s)
        {
            InitializeComponent();
            control = new ControlLogacell_Admin();
            if (s != null)
            {
                modificacion = true;
                txtID.Text = s.id.ToString();
                txtNombre.Text = s.nombre;
                txtCosto.Text = s.costo;
                txtDescripcion.Text = s.descripcion;
                txtDuración.Text = s.duracion;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try {
                if (validarCampos())
                {
                    Servicio s = new Servicio();
                    s.nombre = txtNombre.Text;
                    s.costo = txtCosto.Text;
                    s.descripcion = txtDescripcion.Text;
                    s.duracion = txtDuración.Text;
                    if (modificacion)
                    {
                        s.id = Convert.ToInt32(txtID.Text);
                        if (control.actualizarServicio(s))
                        {
                            MessageBox.Show("Datos actualizados exitosamente");
                            Close();
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Error al actualizar Servicio");
                    }
                    else
                    {
                        if (control.agregarServicios(s))
                        {
                            MessageBox.Show("Servicio agregado exitosamente");
                            Close();
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Error: verifique los campos y vuelva a intentarlo");
                    }
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
            if (txtDescripcion.Text != "" && txtDuración.Text != "" && txtNombre.Text != "" && txtCosto.Text != "")
                return true;
            return false;
        }
    }
}
