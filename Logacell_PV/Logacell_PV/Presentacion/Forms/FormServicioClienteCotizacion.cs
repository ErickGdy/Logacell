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

namespace Logacell_PV.Presentacion.Forms
{
    public partial class FormServicioClienteCotizacion : Form
    {
        public string id, folio;
        public FormServicioClienteCotizacion(string id, string folio)
        {
            InitializeComponent();
            try
            {
                txtCotizacion.Value = Convert.ToDecimal(ControlLogacell.getInstance().consultarServicioCliente(id).presupuesto);
            }
            catch (Exception ex)
            {

            }
            this.id = id;
            this.folio = folio;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlLogacell.getInstance().actualizarServicioClienteCotizacion(id, txtCotizacion.Value.ToString(), folio))
                {
                    MessageBox.Show("Cotización actulizada");
                    Close();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Error al actualizar cotización");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
