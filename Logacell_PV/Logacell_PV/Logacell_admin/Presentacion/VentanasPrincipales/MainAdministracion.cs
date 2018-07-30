
using Logacell_Admin.Control;
using Logacell_Admin.DataObject;
using Logacell_Admin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell_Admin
{
    public partial class MainAdministracion : Form
    {
        DataGridViewPrinter MyDataGridViewPrinter;
        private static MainAdministracion instance;
        ControlLogacell_Admin control;
        DataTable dtDatosAll;
        public MainAdministracion()
        {
            InitializeComponent();
            control = ControlLogacell_Admin.getInstance();
            dtDatosAll = new DataTable();
            try
            {
                actualizarTablas();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void actualizarTablas()
        {
            try
            {
                actualizarTablaStock(control.datosTablaStock());
                actualizarTablaMin(control.datosTablaMin());
                actualizarTablaMax(control.datosTablaMax());
                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewAll.DataSource = dtDatosAll;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public static MainAdministracion getInstance()
        {
            if (instance == null)
            {
                instance = new MainAdministracion();
            }
            return instance;
        }

        private void actualizarTablaMin(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);
                DataRow row = dtDatosAll.NewRow();
                row.ItemArray = new string[] { };
                dtDatosAll.Rows.Add(row);
                data.Fill(dtDatosAll);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewMin.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de servicios
                dataGridViewMin.Columns[0].Width = 65;
                dataGridViewMin.Columns[1].Width = 150;
                dataGridViewMin.Columns[2].Width = 65;
                dataGridViewMin.Columns[3].Width = 70;
                dataGridViewMin.Columns[4].Width = 70;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void actualizarTablaMax(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                data.Fill(dtDatos);
                DataRow row = dtDatosAll.NewRow();
                row.ItemArray = new string[] {  };
                dtDatosAll.Rows.Add(row);

                data.Fill(dtDatosAll);
               

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewMax.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de servicios
                dataGridViewMax.Columns[0].Width = 65;
                dataGridViewMax.Columns[1].Width = 150;
                dataGridViewMax.Columns[2].Width = 65;
                dataGridViewMax.Columns[3].Width = 70;
                dataGridViewMax.Columns[4].Width = 70;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void actualizarTablaStock(MySqlDataAdapter data)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                // Con la información del adaptador se rellena el DataTable
                DataRow row = dtDatosAll.NewRow();
                row.ItemArray = new string[] { };
                dtDatosAll.Rows.Add(row);
                data.Fill(dtDatosAll);

                data.Fill(dtDatos);

                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewStock.DataSource = dtDatos;
                // actualiza el valor de la etiqueta donde se muestra el total de servicios
                dataGridViewStock.Columns[0].Width = 80;
                dataGridViewStock.Columns[1].Width = 245;
                dataGridViewStock.Columns[2].Width = 100;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }




        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting(dataGridViewMax, "Productos Por Encima del Stock Máximo"))
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private bool SetupThePrinting(DataGridView tabla, string mensaje)
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            //if (MyPrintDialog.ShowDialog() != DialogResult.OK)
            //    return false;

            MyPrintDocument.DocumentName = "Reporte de stock";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea centrar el reporte a la página?", "Centrar en página", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MyDataGridViewPrinter = new DataGridViewPrinter(tabla, MyPrintDocument, true, true, mensaje, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            }
            else
            {
                MyDataGridViewPrinter = new DataGridViewPrinter(tabla, MyPrintDocument, false, true, mensaje, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            }
            return true;
        }

        private void MyPrintDocument_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting(dataGridViewMin, "Productos Por Debajo del Stock Mínimo"))
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SetupThePrintingAll())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }
        private bool SetupThePrintingAll()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            //if (MyPrintDialog.ShowDialog() != DialogResult.OK)
            //    return false;

            MyPrintDocument.DocumentName = "Reporte de stock";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea centrar el reporte a la página?", "Centrar en página", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridViewAll, MyPrintDocument, true, true, "Reporte de Stock", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            }
            else
            {
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridViewAll, MyPrintDocument, false, true, "Reporte de Stock", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            }
            return true;
        }
    }
}
