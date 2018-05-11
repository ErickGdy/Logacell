using Logacell.Control;
using Logacell.DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell_PV.Presentacion.Login
{
    public partial class LoginPV : Form
    {
        ControlLogacell control;
        public LoginPV()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            List<String> auxNombres = new List<string>();
            List<String> auxId = new List<string>();
            foreach (PuntoVenta p in control.obtenerPuntoVentas())
            {
                auxNombres.Add(p.nombre);
                auxId.Add(p.id.ToString());
            }
            cmbSucursal.DataSource = auxNombres;
            cmbID.DataSource = auxId;
            string pv = control.leerPVDoc();
            if (pv != "")
            {
                cmbID.SelectedItem = pv;
                cmbSucursal.SelectedIndex = cmbID.SelectedIndex;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cmbID.SelectedIndex = cmbSucursal.SelectedIndex;
            control.setIDPV(cmbID.SelectedValue.ToString());
            Dispose();
        }

        private void LoginPV_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the Closing event from closing the form.
            e.Cancel = true;
            
        }
    }
}
