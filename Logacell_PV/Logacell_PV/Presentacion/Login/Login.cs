using Logacell;
using Logacell.Control;
using Logacell.DataObject;
using Logacell_PV.Presentacion.Login;
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
    public partial class Login : Form
    {
        ControlLogacell control;
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
            control = ControlLogacell.getInstance();
            txtUsuario.Text = control.leerUserDoc();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            
            if (txtUsuario.Text != "" && txtPassword.Text != "")
            {
                //Validaciones
                try
                {
                    Usuario user = control.consultarUsuario(txtUsuario.Text);
                    if (user==null)
                        MessageBox.Show("Usuario invalido");
                    else                     
                        if (user.contraseña!=txtPassword.Text)
                            MessageBox.Show("Contraseña incorrecta");
                        else
                            abrirVentanaPrincipal();
                }
                catch (Exception ex)
                {
                    //Si fallo arroja una excepcion y la mostramos en un label
                    MessageBox.Show("Ha ocurrido un error con la base de datos" + ex.ToString());
                }
                //Si se agregó mostramos el mensaje en un label

            }else
            {
                MessageBox.Show("Ingrese usuario y contraseña");
            }

        }

        private void linkOlvidarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginOlvidarContrasena lc = new LoginOlvidarContrasena();
            lc.Show();
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
            ControlLogacell control = ControlLogacell.getInstance();
            LoginPV lpv = new LoginPV();
            lpv.ShowDialog();
            try
            {
                control.setCurrentUser(txtUsuario.Text);
                control.entradaEmpleado();
            }
            catch (Exception ex) { }
            Main principal = new Main();
            principal.Show();
            this.Hide();
        }
    }
}
