
using Logacell_Admin.Control;
using Logacell_Admin.DataObject;
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

namespace Logacell_Admin
{
    public partial class ProductosMinMax : Form
    {
        ControlLogacell_Admin control;
        Producto producto;

        public ProductosMinMax(Producto p)
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance(); ;
            lblID.Text = p.id.ToString();
            lblCategoria.Text = p.categoria;
            lblNombre.Text = p.nombre;
            lblMarca.Text = p.marca;
            lblModelo.Text = p.modelo;
            producto = p;
            try
            {
                lblStock.Text = control.obtenerStockProducto(p.id.ToString()).ToString();
                if (lblStock.Text == "-1")
                    lblStock.Text = "0";
                int[] m = control.obtenerMinMaxProducto(p.id.ToString());
                if(m!= null)
                {
                    txtMin.Value = m[0];
                    txtMax.Value = m[1];
                }
            }
            catch (Exception ex) { }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
                if (control.actualizarMinMaxProducto(producto.id.ToString(), Convert.ToInt32(txtMin.Value), Convert.ToInt32(txtMax.Value)))
                {
                    MessageBox.Show("Valores actualizados exitosamente");
                    Dispose();
                }
                else
                    MessageBox.Show("Error al actualizar el valores");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
