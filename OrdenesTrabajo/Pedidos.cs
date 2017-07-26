using Microsoft.Office.Interop.Excel;
using OrdenesTrabajo.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesTrabajo
{
    public partial class Pedidos : Form
    {
        private bool btnSalirClicked = false;

        public Pedidos()
        {
            InitializeComponent();

            Inicializar();
        }

        private void Inicializar()
        {
            if (Controller.Usuario != null)
                lblDataUser.Text = Controller.Usuario.ToString();
            else
            {
                Controller.MensajeError("No se encontró usuario logueado en la aplicación. " +
                    "Por favor, cierre la aplicación y vuelva a ingresar.");
                this.Close();
            }
            //btnLimpiar.PerformClick();
            //inicializar combos!
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.CancelButton = btnSalir as IButtonControl;
            toolStripSalir.CausesValidation = false;
            btnSalirClicked = false;
            DateTime ahora = Controller.GetDateTime();
            dtpFechaDesde.Value = ahora.AddDays(-90);
            dtpFechaHasta.Value = ahora;
            dtpFechaDesde.MaxDate = new DateTime(ahora.Year, ahora.Month, ahora.Day, 23, 59, 59);
            dtpFechaHasta.MaxDate = new DateTime(ahora.Year, ahora.Month, ahora.Day, 23, 59, 59);
            /*if (ordenesTrabajo.DataSource.Count > 1)
                lblCantidad.Text = ordenesTrabajo.DataSource.Count.ToString() + " registros.";
            else
                lblCantidad.Text = ordenesTrabajo.DataSource.Count.ToString() + " registro.";*/
        }

        private void Pedidos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btnSalir.PerformClick();
                    break;
                case Keys.F3:
                    btnEliminar.PerformClick();
                    break;
                case Keys.F2:
                    btnLimpiar.PerformClick();
                    break;
                case Keys.F4:
                    btnVer.PerformClick();
                    break;
                case Keys.F5:
                    btnBuscar.PerformClick();
                    break;
                case Keys.F6:
                    btnAgregar.PerformClick();
                    break;
                case Keys.F7:
                    btnEditar.PerformClick();
                    break;
                case Keys.F11:
                    btnImprimir.PerformClick();
                    break;
                case Keys.F12:
                    btnExportar.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            btnSalirClicked = true;
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            //if (ordenesTrabajo.DataSource != null && ordenesTrabajo.DataSource.Count > 0)
                ExportToExcel();
            /*else
                Controller.MensajeInformacion("No hay datos en la grilla para exportar a excel.");*/
        }

        private void ExportToExcel()
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Pedidos";

                /*int nroFila = 1;
                foreach (OrdenTrabajo fila in ordenesTrabajo.DataSource)
                {
                    if (nroFila == 1)
                    {
                        //Crear header en la 1er fila!
                        worksheet.Cells[nroFila, 1] = "Orden";
                        worksheet.Cells[nroFila, 2] = "Descripción";
                        worksheet.Cells[nroFila, 3] = "Observación";
                        worksheet.Cells[nroFila, 4] = "Dirección";
                        worksheet.Cells[nroFila, 5] = "Tipo";
                        worksheet.Cells[nroFila, 6] = "Fecha LG";
                        worksheet.Cells[nroFila, 7] = "Usuario";
                        worksheet.Cells[nroFila, 8] = "Fecha Cierre";
                        worksheet.Cells[nroFila, 9] = "Fecha Alta";
                        worksheet.Cells[nroFila, 10] = "Fecha Baja";
                    }
                    else
                    {
                        worksheet.Cells[nroFila, 1] = fila.Codigo;
                        worksheet.Cells[nroFila, 2] = fila.Descripcion;
                        worksheet.Cells[nroFila, 3] = fila.Observaciones;
                        worksheet.Cells[nroFila, 4] = fila.Direccion;
                        worksheet.Cells[nroFila, 5] = fila.Tipo;
                        worksheet.Cells[nroFila, 6] = fila.FechaLG.ToString("dd/MM/yyyy");
                        worksheet.Cells[nroFila, 7] = fila.Usuario;
                        worksheet.Cells[nroFila, 8] = fila.FechaCierre;
                        worksheet.Cells[nroFila, 9] = fila.FechaAlta;
                        worksheet.Cells[nroFila, 10] = fila.FechaBaja;
                    }

                    nroFila++;
                }*/

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                save.FilterIndex = 2;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(save.FileName);
                    Controller.MensajeInformacion("Se exportó la grilla de las ordenes de trabajo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar exportar los datos a excel, por favor intente " +
                    "nuevamente y si el error persiste comuniquese con sistemas. (" + ex.Message + ").");
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void bindingSourcePedidos_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaDesde_Validating(object sender, CancelEventArgs e)
        {
            if (!btnSalirClicked)
                if (dtpFechaDesde.Value > dtpFechaHasta.Value)
                {
                    Controller.MensajeError("La fecha desde no puede ser mayor a la fecha hasta, verifique.");
                    DateTime ahora = Controller.GetDateTime();
                    dtpFechaDesde.Value = ahora.AddDays(-90);
                    dtpFechaHasta.Value = ahora;
                }
        }

        private void dtpFechaHasta_Validating(object sender, CancelEventArgs e)
        {
            if (!btnSalirClicked)
                if (dtpFechaDesde.Value > dtpFechaHasta.Value)
                {
                    Controller.MensajeError("La fecha hasta tiene que ser menor o igual a la fecha desde, verifique.");
                    DateTime ahora = Controller.GetDateTime();
                    dtpFechaDesde.Value = ahora.AddDays(-90);
                    dtpFechaHasta.Value = ahora;
                }
        }

        private void chbIncluirBajas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIncluirBajas.Checked && chbTodos.Checked)
                chbTodos.Checked = false;
        }

        private void chbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIncluirBajas.Checked && chbTodos.Checked)
                chbIncluirBajas.Checked = false;
        }
    }
}
