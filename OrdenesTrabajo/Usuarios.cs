using DAL.Login;
using DAL.ParametrosBusqueda;
using Microsoft.Office.Interop.Excel;
using OrdenesTrabajo.ClasesUtiles;
using OrdenesTrabajo.Colecciones;
using OrdenesTrabajo.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesTrabajo
{
    public partial class Usuarios : Form
    {
        private ColeccionUsuarios usuarios = new ColeccionUsuarios();

        public Usuarios()
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

            FillCombos();

            usuarios.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "DataSource")
                {
                    bindingSourceUsuarios.DataSource = usuarios.DataSource;
                    if (usuarios.DataSource.Count > 1)
                        lblCantidad.Text = usuarios.DataSource.Count.ToString() + " registros.";
                    else
                        lblCantidad.Text = usuarios.DataSource.Count.ToString() + " registro.";
                }

                if (usuarios.DataSource.Count == 0)
                {
                    btnVer.Enabled = false;
                    btnEditar.Enabled = false;
                    btnBaja.Enabled = false;
                    btnExportar.Enabled = false;
                }
                else
                {
                    btnVer.Enabled = true;
                    btnEditar.Enabled = true;
                    btnBaja.Enabled = true;
                    btnExportar.Enabled = true;
                }

                if (e.PropertyName == "Current")
                {
                    btnVer.Enabled = usuarios.Current != null;
                    btnEditar.Enabled = usuarios.Current != null;
                    if (usuarios.Current != null)
                    {
                        if (usuarios.Current.FechaBaja.HasValue)
                        {
                            btnBaja.Enabled = false;
                            btnAlta.Enabled = true;
                        }
                        else
                        {
                            btnBaja.Enabled = true;
                            btnAlta.Enabled = false;
                        }
                    }
                    else
                    {
                        btnBaja.Enabled = false;
                        btnAlta.Enabled = false;
                    }
                }
            };
        }

        private void FillCombos()
        {
            AssemblyProductAttribute myProduct = (AssemblyProductAttribute)AssemblyProductAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(AssemblyProductAttribute));
            string appName = myProduct.Product;
            List<Perfil> perfiles = DAL.Login.Perfil.ObtenerPerfiles(appName);

            cmbPerfil.DisplayMember = "Descripcion";
            cmbPerfil.ValueMember = "Codigo";
            Perfil per = new DAL.Login.Perfil()
            {
                Codigo = 0,
                Descripcion = "Todos"
            };
            cmbPerfil.Items.Add(per);
            if (perfiles != null && perfiles.Count > 0)
                foreach (Perfil item in perfiles)
                    cmbPerfil.Items.Add(item);
            cmbPerfil.SelectedItem = per;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.CancelButton = btnSalir as IButtonControl;
            toolStripSalir.CausesValidation = false;
            if (usuarios.DataSource.Count > 1)
                lblCantidad.Text = usuarios.DataSource.Count.ToString() + " registros.";
            else
                lblCantidad.Text = usuarios.DataSource.Count.ToString() + " registro.";
        }

        private void Usuarios_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.F12:
                    btnExportar.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposFormulario.InicializarControles(this);
            usuarios.Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (usuarios.Current != null)
                using (AEUsuarios aeUsu = new AEUsuarios())
                {
                    aeUsu.Usuario = usuarios.Current.Clone();
                    aeUsu.Accion = "Ver";
                    if (aeUsu.ShowDialog() == DialogResult.OK)
                    { }
                }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ParametrosBusquedaUsuarios parametros = MapearParametros();
            usuarios.ObtenerPorParametros(parametros);
        }

        private ParametrosBusquedaUsuarios MapearParametros()
        {
            ParametrosBusquedaUsuarios parametros = new ParametrosBusquedaUsuarios();
            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
                parametros.User = txtUsuario.Text;
            Perfil per = cmbPerfil.SelectedItem as Perfil;
            parametros.CodigoPerfil = per.Codigo;
            if (!string.IsNullOrWhiteSpace(txtDescripcion.Text))
                parametros.NomApe = txtDescripcion.Text;
            parametros.IncluirBajas = 0;
            if (chbIncluirBajas.Checked)
                parametros.IncluirBajas = 1;
            if (chbTodos.Checked)
                parametros.IncluirBajas = 2;

            return parametros;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (AEUsuarios aeUsu = new AEUsuarios())
                if (aeUsu.ShowDialog() == DialogResult.OK)
                    usuarios.Crear(aeUsu.Usuario);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuarios.Current != null)
                using (AEUsuarios aeUsu = new AEUsuarios())
                {
                    aeUsu.Usuario = usuarios.Current.Clone();
                    aeUsu.Accion = "Editar";
                    if (aeUsu.ShowDialog() == DialogResult.OK)
                        usuarios.Editar(aeUsu.Usuario);
                }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (usuarios.Current != null)
                using (AEUsuarios aeUsu = new AEUsuarios())
                {
                    aeUsu.Usuario = usuarios.Current.Clone();
                    aeUsu.Accion = "Editar";
                    if (aeUsu.ShowDialog() == DialogResult.OK)
                        usuarios.Baja(aeUsu.Usuario);
                }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (usuarios.Current != null)
                using (AEUsuarios aeUsu = new AEUsuarios())
                {
                    aeUsu.Usuario = usuarios.Current.Clone();
                    aeUsu.Accion = "Editar";
                    if (aeUsu.ShowDialog() == DialogResult.OK)
                        usuarios.Alta(aeUsu.Usuario);
                }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (usuarios.DataSource != null && usuarios.DataSource.Count > 0)
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
                worksheet.Name = "Usuarios";

                int nroFila = 1;
                foreach (Usuario fila in usuarios.DataSource)
                {
                    if (nroFila == 1)
                    {
                        //Crear header en la 1er fila!
                        worksheet.Cells[nroFila, 1] = "Dominio";
                        worksheet.Cells[nroFila, 2] = "Usuario";
                        worksheet.Cells[nroFila, 3] = "Nombre";
                        worksheet.Cells[nroFila, 4] = "Apellido";
                        worksheet.Cells[nroFila, 5] = "Perfil";
                        worksheet.Cells[nroFila, 6] = "Fecha Moficación";
                        worksheet.Cells[nroFila, 7] = "Fecha Baja";
                    }

                    nroFila++;

                    worksheet.Cells[nroFila, 1] = fila.Domain;
                    worksheet.Cells[nroFila, 2] = fila.User;
                    worksheet.Cells[nroFila, 3] = fila.Nombre;
                    worksheet.Cells[nroFila, 4] = fila.Apellido;
                    worksheet.Cells[nroFila, 5] = fila.PerfilUsuario.Descripcion;
                    worksheet.Cells[nroFila, 6] = fila.FechaAlta.ToString("dd/MM/yyyy");
                    worksheet.Cells[nroFila, 7] = fila.FechaBaja;//.ToString("dd/MM/yyyy");
                }

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                save.FilterIndex = 2;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(save.FileName);
                    Controller.MensajeInformacion("Se exportó la grilla de los usuarios correctamente.");
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

        private void bindingSourceUsuarios_CurrentChanged(object sender, EventArgs e)
        {
            usuarios.Current = bindingSourceUsuarios.Current as Usuario;
        }
    }
}
