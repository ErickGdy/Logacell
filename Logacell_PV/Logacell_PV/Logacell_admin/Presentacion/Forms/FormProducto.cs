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
    public partial class FormProducto : Form
    {
        ControlLogacell_Admin control;
        bool modificacion = false;
        int pv;
        public FormProducto(Producto p, int pv)
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            this.pv = pv;
            if (p!=null)
            {
                modificacion = true;
                txtID.Text = p.id.ToString();
                txtCategoria.Text = p.categoria;
                txtMarca.Text = p.marca;
                txtModelo.Text = p.modelo;
                txtNombre.Text = p.nombre;
                txtPrecio.Text = p.precio;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!agregarProducto())
                    MessageBox.Show("Error al guardar datos!");
                else
                {
                    MessageBox.Show("Datos guardados exitosamente!");
                    Close();
                    Dispose();
                }
                    
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
            if (txtCategoria.Text != "" && txtMarca.Text != "" && txtNombre.Text != "" && txtModelo.Text != "" && txtPrecio.Text != "")
                return true;
            return false;
        }

        private bool agregarProducto()
        {
            if (validarCampos())
            {
                Producto p = new Producto();
                p.categoria = txtCategoria.Text;
                p.nombre = txtNombre.Text;
                p.modelo = txtModelo.Text;
                p.marca = txtMarca.Text;
                p.precio = txtPrecio.Text;
                if (modificacion)
                {
                    p.id = Convert.ToInt32(txtID.Text);
                    if (control.actualizarProducto(p))
                    {
                        return true;
                    }
                    else
                        throw new Exception("Error al actualizar producto");
                }
                else
                {
                    if (control.agregarProducto(p))
                    {
                            return true;
                    }
                    else
                        throw new Exception("Error al agregar producto");
                }
            }
            else
                MessageBox.Show("No dejar campos vacios");
            return false;
        }
    }
}
