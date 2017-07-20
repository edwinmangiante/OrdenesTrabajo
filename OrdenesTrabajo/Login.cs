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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Environment.UserDomainName))
                txtDominio.Text = Environment.UserDomainName;
            if (!string.IsNullOrWhiteSpace(Environment.UserName))
                txtUsuario.Text = Environment.UserName;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                Controller.ObtenerUsuario(txtUsuario.Text, txtDominio.Text, EncryptPass(txtContraseña.Text));
                if (Controller.Usuario != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    Controller.MensajeError("El DOMINIO, usuario o contraseña son erroneos. Por favor, verifique.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool Valida()
        {
            if (string.IsNullOrWhiteSpace(txtDominio.Text))
            {
                Controller.MensajeError("No ingreso a la PC con un usuario de dominio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Controller.MensajeError("Debe completar el usuario.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                Controller.MensajeError("Debe completar la Contraseña.");
                return false;
            }

            return true;
        }

        public static string EncryptPass(string password)
        {
            var passwordEncode = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordEncode);
        }
    }
}
