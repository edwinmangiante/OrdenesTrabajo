using DAL;
using DAL.ParametrosBusqueda;
using OrdenesTrabajo.ClasesUtiles;
using OrdenesTrabajo.Colecciones;
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
using Microsoft.Office.Interop.Excel;

namespace OrdenesTrabajo
{
    public partial class Ordenes : Form
    {
        private bool btnSalirClicked = false;
        private ColeccionOrdenesTrabajo ordenesTrabajo = new ColeccionOrdenesTrabajo();

        public Ordenes()
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
            btnLimpiar.PerformClick();
            //inicializar combos!

            ordenesTrabajo.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "DataSource")
                {
                    bindingSourceOrdenes.DataSource = ordenesTrabajo.DataSource;
                    if (ordenesTrabajo.DataSource.Count > 1)
                        lblCantidad.Text = ordenesTrabajo.DataSource.Count.ToString() + " registros.";
                    else
                        lblCantidad.Text = ordenesTrabajo.DataSource.Count.ToString() + " registro.";
                }

                if (ordenesTrabajo.DataSource.Count == 0)
                {
                    btnVer.Enabled = false;
                    btnEditar.Enabled = false;
                    btnBaja.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnExportar.Enabled = false;
                }
                else
                {
                    btnVer.Enabled = true;
                    btnEditar.Enabled = true;
                    btnBaja.Enabled = true;
                    btnImprimir.Enabled = true;
                    btnExportar.Enabled = true;
                }

                if (e.PropertyName == "Current")
                {
                    btnVer.Enabled = ordenesTrabajo.Current != null;
                    btnEditar.Enabled = ordenesTrabajo.Current != null;
                    if (ordenesTrabajo.Current != null)
                    {
                        if (ordenesTrabajo.Current.FechaBaja.HasValue)
                        {
                            btnBaja.Enabled = false;
                            btnAlta.Enabled = true;
                        }
                        else
                        {
                            btnBaja.Enabled = true;
                            btnAlta.Enabled = false;
                        }
                        if (ordenesTrabajo.Current.FechaCierre.HasValue)
                            btnCierre.Enabled = false;
                        else
                            btnCierre.Enabled = true;
                    }
                    else
                    {
                        btnBaja.Enabled = false;
                        btnAlta.Enabled = false;
                        btnCierre.Enabled = false;
                    }
                }
            };
        }

        private void OrdenesFrm_Load(object sender, EventArgs e)
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
            if (ordenesTrabajo.DataSource.Count > 1)
                lblCantidad.Text = ordenesTrabajo.DataSource.Count.ToString() + " registros.";
            else
                lblCantidad.Text = ordenesTrabajo.DataSource.Count.ToString() + " registro.";
        }

        private void OrdenesFrm_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.F8:
                    btnBaja.PerformClick();
                    break;
                case Keys.F9:
                    btnAlta.PerformClick();
                    break;
                case Keys.F10:
                    btnCierre.PerformClick();
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
            btnSalirClicked = false;
            LimpiarCamposFormulario.InicializarControles(this);
            ordenesTrabajo.Limpiar();
            DateTime ahora = Controller.GetDateTime();
            dtpFechaDesde.Value = ahora.AddDays(-90);
            dtpFechaHasta.Value = ahora;
            DisEnaTxt(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            if (true) //solo si tiene los permisos pertinentes, sino no tendría que ver el botón!
            {
                if (ordenesTrabajo.Current != null)
                    if (Controller.MensajeYesNo("¿Está seguro que quiere eliminar la orden seleccionada?"))
                        ordenesTrabajo.Eliminar(ordenesTrabajo.Current);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            if (ordenesTrabajo.Current != null)
                using (AEOrdenes aerOrd = new AEOrdenes(ordenesTrabajo.Current.Clone(), "Ver"))
                    if (aerOrd.ShowDialog() == DialogResult.OK)
                    { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            //ver si hay que hacer validaciones!!
            ParametrosBusquedaOrdenes parametros = MapearParametrosBusqueda();
            ordenesTrabajo.ObtenerPorParametros(parametros);
        }

        private ParametrosBusquedaOrdenes MapearParametrosBusqueda()
        {
            ParametrosBusquedaOrdenes parametros = new ParametrosBusquedaOrdenes();
            if (!string.IsNullOrWhiteSpace(txtNroOrden.Text))
                parametros.Codigo = Convert.ToInt32(txtNroOrden.Text);
            else
            {
                if (!string.IsNullOrWhiteSpace(txtDescripcion.Text))
                    parametros.Descripcion = txtDescripcion.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtDireccion.Text))
                    parametros.Direccion = txtDireccion.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtSolicitante.Text))
                    parametros.Solicitante = txtSolicitante.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtTipo.Text))
                    parametros.Tipo = txtTipo.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
                    parametros.Usuario = txtUsuario.Text.Trim();
                parametros.IncluirBajas = 0;
                if (chbIncluirBajas.Checked)
                    parametros.IncluirBajas = 1;
                if (chbTodos.Checked)
                    parametros.IncluirBajas = 2;
                parametros.FechaDesde = new DateTime(dtpFechaDesde.Value.Year, dtpFechaDesde.Value.Month, dtpFechaDesde.Value.Day, 0, 0, 0);
                parametros.FechaHasta = new DateTime(dtpFechaHasta.Value.Year, dtpFechaHasta.Value.Month, dtpFechaHasta.Value.Day, 23, 59, 59);
            }

            return parametros;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            using (AEOrdenes aeOrd = new AEOrdenes())
                if (aeOrd.ShowDialog() == DialogResult.OK)
                    ordenesTrabajo.Crear(aeOrd.Orden);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            if (ordenesTrabajo.Current != null)
                using (AEOrdenes aerOrd = new AEOrdenes(ordenesTrabajo.Current.Clone(), "Editar"))
                    if (aerOrd.ShowDialog() == DialogResult.OK)
                        ordenesTrabajo.Editar(aerOrd.Orden);
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            if (ordenesTrabajo.Current != null && !ordenesTrabajo.Current.FechaBaja.HasValue)
                if (Controller.MensajeYesNo("¿Está seguro que quiere dar de baja la orden de trabajo seleccionada?"))
                    ordenesTrabajo.Baja(ordenesTrabajo.Current);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            if (ordenesTrabajo.Current != null && ordenesTrabajo.Current.FechaBaja.HasValue)
                if (Controller.MensajeYesNo("¿Está seguro que quiere dar de alta la orden de trabajo seleccionada?"))
                    ordenesTrabajo.Alta(ordenesTrabajo.Current);
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            if (ordenesTrabajo.Current != null && !ordenesTrabajo.Current.FechaCierre.HasValue)
                if (Controller.MensajeYesNo("¿Está seguro que quiere ponerle fecha de cierre a la orden de trabajo seleccionada?"))
                    ordenesTrabajo.Cierre(ordenesTrabajo.Current);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            if (ordenesTrabajo.DataSource != null && ordenesTrabajo.DataSource.Count > 0)
            {
                //imprimir grilla
                Controller.MensajeInformacion("Se imprimió la grilla de las ordenes de trabajo correctamente.");
            }
            else
                Controller.MensajeInformacion("No hay datos en la grilla para imprimir.");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            btnSalirClicked = false;
            if (ordenesTrabajo.DataSource != null && ordenesTrabajo.DataSource.Count > 0)
                ExportToExcel();
            else
                Controller.MensajeInformacion("No hay datos en la grilla para exportar a excel.");
        }

        private void ExportToExcel()
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Ordenes de Trabajo";

                int nroFila = 1;
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
                }

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

        private void bindingSourceOrdenes_CurrentChanged(object sender, EventArgs e)
        {
            ordenesTrabajo.Current = bindingSourceOrdenes.Current as OrdenTrabajo;
        }

        private void txtNroOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNroOrden_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNroOrden.Text))
            {
                //si sabemos el largo del nro validarlo acá
                //si valido el largo
                DisEnaTxt(false);
            }
            else
                DisEnaTxt(true);
        }

        private void DisEnaTxt(bool estado)
        {
            txtDescripcion.Enabled = estado;
            txtDireccion.Enabled = estado;
            txtSolicitante.Enabled = estado;
            txtTipo.Enabled = estado;
            txtUsuario.Enabled = estado;
            dtpFechaDesde.Enabled = estado;
            dtpFechaHasta.Enabled = estado;
            chbIncluirBajas.Enabled = estado;
            chbTodos.Enabled = estado;
            if (!estado)
            {
                txtDescripcion.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtSolicitante.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtUsuario.Text = string.Empty;
                chbIncluirBajas.Checked = false;
                chbTodos.Checked = false;
                DateTime ahora = Controller.GetDateTime();
                dtpFechaDesde.Value = ahora.AddDays(-90);
                dtpFechaHasta.Value = ahora;
            }
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
