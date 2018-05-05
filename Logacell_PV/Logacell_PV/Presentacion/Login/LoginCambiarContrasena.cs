
using Logacell.Control;
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
    public partial class LoginCambiarContrasena : Form
    {
        //ControlAS control;
        public static LoginCambiarContrasena instance;
        public LoginCambiarContrasena()
        {
            InitializeComponent();
            this.CenterToScreen();
            txtUsuario.Text = ControlLogacell.currentUser.usuario;
            //control = new ControlAS();
        }
        public static LoginCambiarContrasena Instance()
        {
            if (instance == null)
            {
                instance = new LoginCambiarContrasena();
            }
            return instance;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //if (!control.buscarUsuario(txtUsuario.Text))
            //    MessageBox.Show("Usuario invalido");
            //else if (!control.validarUsuario(txtUsuario.Text, txtPasswordNueva.Text))
            //    MessageBox.Show("Contraseña incorrecta");
            //else if (txtPasswordNueva.Text != txtPasswordNueva2.Text)
            //    MessageBox.Show("Las contraseñas no corresponden, favor de repetir la contraseña de forma correcta");
            //else if (control.modificarUsuario(txtUsuario.Text, txtPasswordNueva.Text))
            //    {
            //        MessageBox.Show("Contraseña cambiada");
            //        Dispose();
            //    }
            //    else
            //        MessageBox.Show("Error al cambiar la contraseña, verifique los datos y vuelva a intentarlo");
        }
    }
}
