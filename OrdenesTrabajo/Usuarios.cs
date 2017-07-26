using DAL.Login;
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

namespace OrdenesTrabajo
{
    public partial class Usuarios : Form
    {
        private ColeccionUsuarios usuarios = new ColeccionUsuarios();

        public Usuarios()
        {
            InitializeComponent();
            //bindingSourceUsuarios.DataSource = new ColeccionUsuarios();
            Inicializar();        }

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
                    //btnImprimir.Enabled = false;
                    btnExportar.Enabled = false;
                }
                else
                {
                    btnVer.Enabled = true;
                    btnEditar.Enabled = true;
                    btnBaja.Enabled = true;
                    //btnImprimir.Enabled = true;
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
            if (!string.IsNullOrWhiteSpace(hacerCombo.Text))
                parametros.CodigoPerfil = 0;
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

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

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
