
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
    public partial class Login : Form
    {
        ControlLogacell_Admin control;
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
            control = ControlLogacell_Admin.getInstance();

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            
            if (txtUsuario.Text != "" && txtPassword.Text != "")
            {
                //Validaciones
                try
                {
                    Usuario user = control.consultarUsuario(txtUsuario.Text);
                    if (user == null)
                        MessageBox.Show("Usuario invalido");
                    else
                        if (user.contraseña != txtPassword.Text)
                        MessageBox.Show("Contraseña incorrecta");
                    else
                    {
                        string puesto = control.consultarEmpleado(user.empleado).puesto;
                        if (puesto != "Administrador" && puesto != "Encargado de envios")
                            MessageBox.Show("Error: No tiene acceso al sistema");
                        else
                        {
                            abrirVentanaPrincipal();
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Si fallo arroja una excepcion y la mostramos en un label
                    MessageBox.Show("Ha ocurrido un error con la base de datos");
                }
                //Si se agregó mostramos el mensaje en un label

            }else
            {
                MessageBox.Show("Ingrese usuario y contraseña");
            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (e.KeyChar == '\r')
            {
                btn_Login_Click(null,null);   
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void abrirVentanaPrincipal()
        {
            MainForm principal = MainForm.getInstance(txtUsuario.Text);
            principal.Show();
            //this.Close();
        }
    }
}
