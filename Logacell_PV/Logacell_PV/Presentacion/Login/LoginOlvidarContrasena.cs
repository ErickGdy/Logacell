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
    public partial class LoginOlvidarContrasena : Form
    {
        //ControlAS control;
        public LoginOlvidarContrasena()
        {
            InitializeComponent();
            this.CenterToScreen();
            //control = new ControlAS();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //if (control.consultarEmpleado(txtCorreo.Text) != null)
            //    EnviarCorreo();
            //else
            //{
            //    MessageBox.Show("Correo invalido");
            //}
        }
        private void EnviarCorreo()
        {
            //ControlAS control = new ControlAS();
            //String mensaje =
            //    "Hola " + control.consultarEmpleado(txtCorreo.Text).Nombre + "\n\n" +
            //    "Hemos recibido tu solicitud de recuperación de contraseña!  \n\n"+

            //    "Tus datos son:\n\n"+
            //    "Usuario: "+control.consultarEmpleado(txtCorreo.Text).Nombre +
            //    "Contraseña: "+control.consultarEmpleado(txtCorreo.Text).Contraseña+
            //    "\n\n\n"+
            //    "NOTA: Si usted no está intentando recuperar su contraseña, es posible que los datos de su cuenta están siendo comprometidos."+
            //    "Le recomendamos ponerse en contacto con el equipo de soporte \n\n"+
            //    "No responda a esta misiva, porque solo tiene el objetivo de informar.\n"+
            //    "Si usted ha recibido esta transmisión por error, notifíquenos inmediatamente por esta misma vía, y borre el archivo y sus anexos." ;


            //if (control.enviaMail(txtCorreo.Text, mensaje,"Recuperar contraseña", null))
            //{
            //    MessageBox.Show("Correo enviado satisfactoriamente: \n Sus datos han sido enviados a su direccion de correo electronico");
            //    this.Dispose();
            //}
            //else
            //{
            //    MessageBox.Show("Error al enviar el correo, verifique los datos y vuelva a intentarlo");
            //}
        }
    }
}
