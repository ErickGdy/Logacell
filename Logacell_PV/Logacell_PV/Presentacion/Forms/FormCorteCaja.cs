﻿using Logacell.Control;
using Logacell.DataObject;
using Logacell_PV.Presentacion.Forms;
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

namespace Logacell.Presentacion
{
    public partial class FormCorteCaja : Form
    {
        ControlLogacell control;
        public FormCorteCaja()
        {
            try
            {
                InitializeComponent();
                control = ControlLogacell.getInstance();
                lblFecha.Text = DateTime.Now.ToShortDateString();
                Caja caja = control.consultarCaja();
                lblPuntoVenta.Text = ControlLogacell.idPV.nombre;
                lblFondoInicial.Text = caja.fondoInicial.ToString("C2");
                List<double> datos = control.datosCorteCaja();
                //ingreso
                lblIngresos.Text = datos.ElementAt(0).ToString("C2");
                //egreso
                lblEgresos.Text = datos.ElementAt(1).ToString("C2");
                //compras
                lblCompras.Text = datos.ElementAt(2).ToString("C2");
                //servicios efectivo
                lblServiciosEfectivo.Text = datos.ElementAt(3).ToString("C2");
                lblEfectivoServicios.Text = datos.ElementAt(3).ToString("C2");
                //servicios tarjeta
                lblTarjetaServicios.Text = datos.ElementAt(4).ToString("C2");
                //ventas efectivo
                lblVentasEfectivo.Text = datos.ElementAt(5).ToString("C2");
                lblVentasEfectivo2.Text = datos.ElementAt(5).ToString("C2");
                //ventas tarjeta
                lblVentasTarjetaCredito.Text = datos.ElementAt(6).ToString("C2");
                //abonos efectivo
                lblAbonosEnEfectivo.Text = datos.ElementAt(7).ToString("C2");
                lblTotalEnCaja.Text = caja.fondoActual.ToString("C2");
                lblTotalVentas2.Text = datos.ElementAt(9).ToString("C2");
                lblTotalServicios.Text = datos.ElementAt(8).ToString("C2");
                actualizarTabla(control.corteCajaTable());

                this.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dispose();
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CerrarCaja fc = new CerrarCaja();
                fc.FormClosed += new FormClosedEventHandler(form_CloseVentas);
                fc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    private void form_CloseVentas(object sender, FormClosedEventArgs e)
    {
            //aqui actualizas o recargas la info del Form1
            this.Dispose();
    }
    private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void actualizarTabla(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridView1.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de productos
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "Tipo";
                dataGridView1.Columns[1].Width = 240;
                dataGridView1.Columns[1].HeaderText = "Operación";
                dataGridView1.Columns[2].Width = 125;
                dataGridView1.Columns[2].HeaderText = "Folio";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Total";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }

}
