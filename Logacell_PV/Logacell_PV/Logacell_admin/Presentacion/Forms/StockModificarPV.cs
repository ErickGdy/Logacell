
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
    public partial class StockModificarPV : Form
    {
        ControlLogacell_Admin control;
        Producto producto;
        PuntoVenta puntoVenta;

        public StockModificarPV(Producto p, PuntoVenta pv)
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance(); ;
            lblID.Text = p.id.ToString();
            lblCategoria.Text = p.categoria;
            lblNombre.Text = p.nombre;
            lblMarca.Text = p.marca;
            lblModelo.Text = p.modelo;
            producto = p;
            puntoVenta = pv;
            lblPV.Text = pv.nombre;
            try
            {
                lblStock.Text = control.obtenerStockProducto(p.id.ToString(), pv.id).ToString();
                if (lblStock.Text == "-1")
                    lblStock.Text = "0";
            }
            catch (Exception ex) { }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(lblStock.Text!= txtStock.Value.ToString())
            {
                if (control.actualizarStockProducto(producto.id.ToString(), Convert.ToInt32(txtStock.Value), puntoVenta.id))
                {
                    MessageBox.Show("Stock actualizado exitosamente");
                    Dispose();
                }
                else
                    MessageBox.Show("Error al actualizar el stock");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
