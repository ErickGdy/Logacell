
using Logacell_Admin.DataObject;
using Logacell_Admin.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Logacell_Admin
{
    public partial class MainEmpleado : Form
    {
        private static MainEmpleado instance;
        ControlLogacell_Admin control;
       
        public MainEmpleado()
        {
            InitializeComponent();
            control = new ControlLogacell_Admin();
            try
            {
                actualizarTablaEmpleados(control.obtenerEmpleadosTable());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void actualizarTablaEmpleados(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridView1.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                lblTotal.Text = dataGridView1.RowCount.ToString();
                dataGridView1.Columns[0].Width = 180;
                dataGridView1.Columns[1].Width = 180;
                dataGridView1.Columns[2].Width = 110;
                dataGridView1.Columns[3].Width = 180;
                dataGridView1.Columns[4].Width = 110;
                lblTotal.Text = dataGridView1.RowCount.ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static MainEmpleado getInstance()
        {
                if (instance == null)
                {
                    instance = new MainEmpleado();
                }
                return instance;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormEmpleado form = new FormEmpleado(null, null);

            form.FormClosed += new FormClosedEventHandler(form_Closed);
            form.Show();
        }
        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            //aqui actualizas o recargas la info del Form1
            actualizarTablaEmpleados(control.obtenerEmpleadosTable());
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                actualizarTablaEmpleados(control.obtenerEmpleadosTable(txtBuscar.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String correo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            MessageBox.Show("aqui se mostraran los datos relevantes del cliente: " + correo);
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String correo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            try
            {
                Empleado empleado = control.consultarEmpleado(correo);
                Usuario user = control.consultarUsuario(correo);
                FormEmpleado fc = new FormEmpleado(empleado, user);
                fc.FormClosed += new FormClosedEventHandler(form_Closed);
                fc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String correo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("¿Desea eliminar el Empleado?", "Eliminar Empleado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (control.eliminarEmpleado(correo))
                    {
                        MessageBox.Show("Empleado Eliminado");
                        actualizarTablaEmpleados(control.obtenerEmpleadosTable());
                    }
                    else MessageBox.Show("Error al eliminar Empleado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
