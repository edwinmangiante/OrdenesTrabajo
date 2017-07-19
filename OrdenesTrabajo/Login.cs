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
            if(!string.IsNullOrWhiteSpace(Environment.UserDomainName) && !string.IsNullOrWhiteSpace(Environment.UserName))
                txtUsuario.Text = Environment.UserDomainName + @"\" + Environment.UserName;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(Valida())
            {
                if(true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    Controller.MensajeError("El DOMINIO, usuario o contraseña son erroneos. Por favor, verifique.");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool Valida()
        {
            if(string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Controller.MensajeError("Debe completar DOMINIO y usuario.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                Controller.MensajeError("Debe completar la Contraseña.");
                return false;
            }

            return true;
        }
    }
}
