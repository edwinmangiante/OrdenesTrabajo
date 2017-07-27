using DAL.Login;
using DAL.ParametrosBusqueda;
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
    public partial class AEUsuarios : Form
    {
        public Usuario Usuario { get; set; }
        public string Accion { get; set; }

        AssemblyProductAttribute myProduct = (AssemblyProductAttribute)AssemblyProductAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(AssemblyProductAttribute));

        public AEUsuarios()
        {
            InitializeComponent();
        }

        private void AEUsuarios_Load(object sender, EventArgs e)
        {
            if (Usuario == null)
                this.Text = "Alta Usuario";
            else
                ConfigForm();
            FillCombos();
        }

        private void ConfigForm()
        {
            txtDominio.Text = Usuario.Domain;
            txtUsuario.Text = Usuario.User;
            txtContraseña.Text = Usuario.Password;
            txtNombre.Text = Usuario.Nombre;
            txtApellido.Text = Usuario.Apellido;
            
            txtUsuario.Enabled = false;
            txtUsuario.ReadOnly = true;
            if (Accion == "Editar")
                this.Text = "Edita Usuario";
            else if (Accion == "Ver")
            {
                this.Text = "Ver Usuario";
                txtContraseña.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                cmbPerfil.Enabled = false;
                txtContraseña.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                btnAceptar.Visible = false;
                btnCancelar.Text = "&Cerrar";
            }
        }

        private void FillCombos()
        {
            cmbPerfil.Items.Clear();
            List<Perfil> perfiles = DAL.Login.Perfil.ObtenerPerfiles(myProduct.Product);

            cmbPerfil.DisplayMember = "Descripcion";
            cmbPerfil.ValueMember = "Codigo";
            if (perfiles != null && perfiles.Count > 0)
                foreach (Perfil item in perfiles)
                    cmbPerfil.Items.Add(item);
            if (Usuario != null)
                cmbPerfil.SelectedItem = Usuario.PerfilUsuario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                if (CanMapearUsr())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private bool CanMapearUsr()
        {
            try
            {
                if (Usuario == null)
                {
                    Usuario = new Usuario();
                    Usuario.PerfilUsuario = new Perfil();
                }
                Usuario.Domain = txtDominio.Text.Trim();
                Usuario.User = txtUsuario.Text.Trim();
                Usuario.Password = EncryptPass(txtContraseña.Text.Trim());
                Usuario.Nombre = txtNombre.Text.Trim();
                Usuario.Apellido = txtApellido.Text.Trim();
                Perfil perfil = cmbPerfil.SelectedItem as Perfil;
                Usuario.CodigoPerfil = perfil.Codigo;
                Usuario.PerfilUsuario = perfil;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool Valida()
        {
            if(!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Controller.MensajeError("Debe completar el usuario.");
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                Controller.MensajeError("Debe completar la contraseña.");
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Controller.MensajeError("Debe completar el nombre.");
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                Controller.MensajeError("Debe completar el apellido.");
                return false;
            }
            Perfil perfil = cmbPerfil.SelectedItem as Perfil;
            if (perfil == null)
            {
                Controller.MensajeError("Debe completar el perfil.");
                return false;
            }

            return true;
        }

        public static string EncryptPass(string password)
        {
            var passwordEncode = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordEncode);
        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Perfil perfil = cmbPerfil.SelectedItem as Perfil;
            if (perfil != null)
            {
                List<Opcion> opciones = Opcion.ObtenerPorPerfil(perfil.Codigo, myProduct.Product);
                bindingSourceOpciones.DataSource = opciones;
            }
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                ParametrosBusquedaUsuarios parametros = new ParametrosBusquedaUsuarios();
                parametros.Dominio = txtDominio.Text;
                parametros.User = txtUsuario.Text;
                List<Usuario> usuarios = Usuario.ObtenerPorParametros(parametros);
                if(usuarios != null && usuarios.Count > 0)
                {
                    Usuario = usuarios.First();
                    Accion = "Editar";
                    ConfigForm();
                    FillCombos();
                }
            }
        }
    }
}
