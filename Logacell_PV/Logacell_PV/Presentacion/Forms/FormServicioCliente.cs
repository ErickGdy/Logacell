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

namespace Logacell.Presentacion
{
    public partial class FormServicioCliente : Form
    {
        ControlLogacell control;
        List<ServicioCliente> servicios;
        string patron = "";
        int contadorPatron = 1;
        public FormServicioCliente()
        {
            InitializeComponent();
            control = new ControlLogacell();
            lblFecha.Text = DateTime.Now.ToShortDateString();
            servicios = new List<ServicioCliente>();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try {
                if (validarCampos())
                {
                    SolicitudServicio s = new SolicitudServicio();
                    s.Folio=txtFolio.Text;
                    s.nombreCliente = txtNombre.Text;
                    s.telefonoCliente = txtTelefono.Text;
                    s.total = txtTotal.Text;
                    s.anticipo = txtAnticipo.Text;
                    s.pendiente = txtPendiente.Text;
                    s.servicios = servicios;
                    if (control.agregarSolicitudServicios(s))
                    {
                        MessageBox.Show("Datos guardados exitosamente");
                        Close();
                        this.Dispose();
                    }
                    else
                        MessageBox.Show("Error: verifique los campos y vuelva a intentarlo");
                }
                else
                    MessageBox.Show("No dejar campos vacios");
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void onlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            };
        }


        private void noSpaces_KeyPress(object sender, KeyPressEventArgs e)
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
        private bool validarCampos()
        {
            if (txtTelefono.Text != "" && txtNombre.Text != "" && txtTotal.Text!="" && txtTotal.Text != "0")
                return true;
            return false;
        }

        private void txtAnticipo_KeyUp(object sender, KeyEventArgs e)
        {
            actualizarTotal();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            servicios.RemoveAt(dataGridView1.CurrentRow.Index);
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            
            actualizarTotal();
        }

        private void actualizarTotal()
        {
            try
            {
                txtPendiente.Text = (Convert.ToInt32(txtTotal.Text) - Convert.ToInt32(txtAnticipo.Text)).ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtAnticipo_TextChanged(object sender, EventArgs e)
        {
            actualizarTotal();
        }

        private void txtAnticipo_Leave(object sender, EventArgs e)
        {
            if (txtAnticipo.Text == "")
                txtAnticipo.Text = "0";
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            ServicioCliente sc = new ServicioCliente();
            sc.descripcion = txtMarca.Text + " " + txtModelo.Text + ": " + txtMotivo.Text;
            sc.presupuesto = txtPresupuesto.Text;
            sc.contrasena = txtContra.Text;
            sc.chip = checkChip.Checked;
            sc.tapa= checkTapa.Checked;
            sc.pila=checkPila.Checked;
            sc.memoria=checkMemoria.Checked;
            servicios.Add(sc);
            dataGridView1.Rows.Insert(dataGridView1.RowCount, sc.descripcion, sc.presupuesto);
            txtTotal.Text = (Convert.ToInt32(txtTotal.Text) + Convert.ToInt32(txtPresupuesto.Text)).ToString();

            limpiarForm();
            btnBorrarPatron_Click(null, null);
        }

        private void limpiarForm()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtContra.Text = "";
            txtMotivo.Text = "";
            txtPresupuesto.Text = "";
            checkChip.Checked = false;
            checkMemoria.Checked = false;
            checkTapa.Checked = false;
            checkPila.Checked = false;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.Text = contadorPatron.ToString();
            patron = patron + "1";
            btn1.BackColor = Color.FromArgb(42,91,157);
            btn1.Enabled = false;
            contadorPatron++;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn2.Text = contadorPatron.ToString();
            patron = patron + "2";
            btn2.BackColor = Color.FromArgb(42, 91, 157);
            btn2.Enabled = false;
            contadorPatron++;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn3.Text = contadorPatron.ToString();
            patron = patron + "3";
            btn3.BackColor = Color.FromArgb(42, 91, 157);
            btn3.Enabled = false;
            contadorPatron++;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btn4.Text = contadorPatron.ToString();
            patron = patron + "4";
            btn4.BackColor = Color.FromArgb(42, 91, 157);
            btn4.Enabled = false;
            contadorPatron++;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btn5.Text = contadorPatron.ToString();
            patron = patron + "5";
            btn5.BackColor = Color.FromArgb(42, 91, 157);
            btn5.Enabled = false;
            contadorPatron++;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btn6.Text = contadorPatron.ToString();
            patron = patron + "6";
            btn6.BackColor = Color.FromArgb(42, 91, 157);
            btn6.Enabled = false;
            contadorPatron++;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btn7.Text = contadorPatron.ToString();
            patron = patron + "7";
            btn7.BackColor = Color.FromArgb(42, 91, 157);
            btn7.Enabled = false;
            contadorPatron++;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btn8.Text = contadorPatron.ToString();
            patron = patron + "8";
            btn8.BackColor = Color.FromArgb(42, 91, 157);
            btn8.Enabled = false;
            contadorPatron++;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btn9.Text = contadorPatron.ToString();
            patron = patron + "9";
            btn9.BackColor = Color.FromArgb(42, 91, 157);
            btn9.Enabled = false;
            contadorPatron++;
        }

        private void btnBorrarPatron_Click(object sender, EventArgs e)
        {
            patron = "";
            contadorPatron = 1; 
            btn1.BackColor = Color.FromArgb(215, 60, 39);
            btn1.Enabled =true;
            btn1.Text = "";
            btn2.BackColor = Color.FromArgb(215, 60, 39);
            btn2.Enabled = true;
            btn2.Text = "";
            btn3.BackColor = Color.FromArgb(215, 60, 39);
            btn3.Enabled = true;
            btn3.Text = "";
            btn4.BackColor = Color.FromArgb(215, 60, 39);
            btn4.Enabled = true;
            btn4.Text = "";
            btn5.BackColor = Color.FromArgb(215, 60, 39);
            btn5.Enabled = true;
            btn5.Text = "";
            btn6.BackColor = Color.FromArgb(215, 60, 39);
            btn6.Enabled = true;
            btn6.Text = "";
            btn7.BackColor = Color.FromArgb(215, 60, 39);
            btn7.Enabled = true;
            btn7.Text = "";
            btn8.BackColor = Color.FromArgb(215, 60, 39);
            btn8.Enabled = true;
            btn8.Text = "";
            btn9.BackColor = Color.FromArgb(215, 60, 39);
            btn9.Enabled = true;
            btn9.Text = "";
        }
    }
}
