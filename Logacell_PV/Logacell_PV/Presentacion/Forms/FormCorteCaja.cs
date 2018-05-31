using Logacell.Control;
using Logacell.DataObject;
using Logacell_PV.Presentacion.Forms;
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
    public partial class FormCorteCaja : Form
    {
        ControlLogacell control;
        public FormCorteCaja()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            /**try
            {
                if (control.corteDeCaja())
                {
                    MessageBox.Show("Compra guardada exitosamente");
                    Close();
                    Dispose();
                }
                else MessageBox.Show("Error al guardar compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }**/
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }


    }
}
