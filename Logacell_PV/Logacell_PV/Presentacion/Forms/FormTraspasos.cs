using Logacell.Control;
using Logacell.DataObject;
using Logacell_PV.DataObject;
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
    public partial class FormTraspasos : Form
    {
        ControlLogacell control;
        bool modificacion = false;
        List<Producto> productos = new List<Producto>();
        List<PuntoVenta> pvs = new List<PuntoVenta>();
        Traspaso traspaso = new Traspaso();
        bool aceptar = false;
        public FormTraspasos(Traspaso tras)
        {
            InitializeComponent();
            control = ControlLogacell.getInstance();
            try
            {
                
                pvs = control.obtenerPuntoVentas();
                foreach (PuntoVenta p in pvs)
                {
                    cmbDestino.Items.Add(p.nombre);
                    cmbOrigen.Items.Add(p.nombre);
                }
                if (tras != null)
                {
                    aceptar = true;
                    this.traspaso = tras;
                    foreach (PuntoVenta pv in pvs)
                    {
                        if (pv.id == traspaso.idOrigen)
                        {
                            cmbOrigen.SelectedItem = pv.nombre;
                        }
                        if (pv.id == traspaso.idDestino)
                        {
                            cmbDestino.SelectedItem = pv.nombre;
                        }
                    }
                    cmbOrigen.Enabled = false;
                    cmbDestino.Enabled = false;
                    txtObservaciones.Text = traspaso.observaciones;
                    Producto p = control.consultarProducto(traspaso.producto.ToString());
                    productos.Add(p);
                    cmbProductos.Items.Add(p.marca + " " + p.modelo + " - " + p.nombre);
                    cmbProductos.SelectedIndex = 0;
                    cmbProductos.Enabled = false;
                    txtCantidad.Maximum = traspaso.cantidad;
                    txtCantidad.Value = traspaso.cantidad;
                    txtCantidad.Enabled = false;
                }
                else
                {
                    productos = control.obtenerProductosByPV();
                    foreach (Producto p in productos)
                    {
                        cmbProductos.Items.Add(p.marca + " " + p.modelo + " - " + p.nombre);
                    }
                    cmbOrigen.SelectedItem = ControlLogacell.idPV.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDestino.SelectedIndex >= 0 && cmbProductos.SelectedIndex >= 0 && cmbDestino.SelectedIndex != cmbOrigen.SelectedIndex)
                {
                    traspaso.idOrigen = pvs.ElementAt(cmbOrigen.SelectedIndex).id;
                    traspaso.idDestino = pvs.ElementAt(cmbDestino.SelectedIndex).id;
                    traspaso.producto = productos.ElementAt(cmbProductos.SelectedIndex).id;
                    traspaso.cantidad = Convert.ToInt32(txtCantidad.Value);
                    traspaso.observaciones = txtObservaciones.Text;
                    if (aceptar)
                    {
                        if (control.aceptarTraspaso(traspaso))
                        {
                            MessageBox.Show("Datos guardados exitosamente");
                            Close();
                            Dispose();
                        }
                        else
                            MessageBox.Show("Error al aceptar traspaso");
                    }
                    else
                    {
                        if (control.agregarTraspaso(traspaso))
                        {
                            MessageBox.Show("Datos guardados exitosamente");
                            Close();
                            Dispose();
                        }
                        else
                            MessageBox.Show("Error al crear traspaso");
                    }
                }
                else
                    MessageBox.Show("Debe seleccionar origen y destino diferentes, y un producto a transefir");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCantidad.Maximum = control.obtenerStockProducto(productos.ElementAt(cmbProductos.SelectedIndex).id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener stock del producto");
            }
        }
    }
}
