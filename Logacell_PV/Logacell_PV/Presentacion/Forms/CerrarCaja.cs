
using Logacell.Control;
using Logacell.DataObject;
using Logacell.Presentacion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell
{
    public partial class CerrarCaja : Form
    {
        private static CerrarCaja instance;
        ControlLogacell control;
        Caja caja;

        public CerrarCaja()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            try
            {
                caja = control.consultarCaja();
            }catch(Exception e)
            {
                MessageBox.Show("Error al obtener datos de caja");
                Dispose();
            }
            txtFondoInicial.Text = "0.00";
            ShowDialog();
        }

        private void txtFondoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == '.')
            {
                if (e.KeyChar == '.')
                    if (!txtFondoInicial.Text.Contains('.') && txtFondoInicial.Text.Length!=0)
                    {
                        e.Handled = false;
                        return;
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }
                e.Handled = false;
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (control.cerrarCaja(txtFondoInicial.Text))
                {
                    MessageBox.Show("Corte de caja exitoso: La caja ha sido cerrada");
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Error al realizar corte de caja");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
