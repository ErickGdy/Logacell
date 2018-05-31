
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
    public partial class AbrirCaja : Form
    {
        private static AbrirCaja instance;
        ControlLogacell control;
        Caja caja;

        public AbrirCaja()
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            try
            {
                caja = control.consultarCaja();
                if (caja == null)
                {
                    control.agregarCaja();
                    caja = control.consultarCaja();
                }
            }catch(Exception e)
            {
                MessageBox.Show("Error al obtener datos de caja");
                Dispose();
                return;
            }
            txtFondoInicial.Text = caja.fondoActual.ToString("F2");
            ShowDialog();
        }

        public static AbrirCaja getInstance()
        {
            if (instance == null)
            {
                instance = new AbrirCaja();
            }
            return instance;
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
                if (control.abrirCaja(txtFondoInicial.Text))
                {
                    MessageBox.Show("Caja abierta");
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Error al actualizar datos de caja");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
