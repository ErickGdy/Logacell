using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell_PV.Presentacion.Forms
{
    public partial class FormVentaDescuentoDialog : Form
    {
        int descuento =-1;
        public FormVentaDescuentoDialog()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            descuento = Convert.ToInt32(txtDescuento.Value);
            Close();
        }
        public int discount()
        {
            return descuento;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
