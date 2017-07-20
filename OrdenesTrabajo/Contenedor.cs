using DAL.Login;
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
    public partial class Contenedor : Form
    {
        public Contenedor()
        {
            InitializeComponent();
        }

        private void ContenedorFrm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            if (Controller.Usuario != null)
            {
                //lblDataUser.Text = Controller.Usuario.ToString();
                if (Controller.Usuario.PerfilUsuario != null)
                {
                    if (Controller.Usuario.PerfilUsuario.Opciones != null && Controller.Usuario.PerfilUsuario.Opciones.Count > 0)
                    {
                        FillTreeView();
            treeViewOpciones.ExpandAll();
                    }
                    else
                        Controller.MensajeError("No se encontraron las opciones del perfil del usuario logueado en la aplicación. " +
                            "Por favor, cierre la aplicación y vuelva a ingresar.");
                }
                else
                    Controller.MensajeError("No se encontró el perfil del usuario logueado en la aplicación. " +
                        "Por favor, cierre la aplicación y vuelva a ingresar.");
            }
            else
                Controller.MensajeError("No se encontró usuario logueado en la aplicación. " +
                    "Por favor, cierre la aplicación y vuelva a ingresar.");
        }

        private void FillTreeView()
        {
            //treeViewOpciones.Nodes.Add("Opciones");
            foreach (Opcion item in Controller.Usuario.PerfilUsuario.Opciones)
                treeViewOpciones.Nodes[0].Nodes.Add(item.Descripcion);
        }

        private void treeViewOpciones_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //CloseOpenForms();

            try
            {
                if (e.Node.Text == "Ordenes")
                {
                    Ordenes ord = new Ordenes();
                    ord.MdiParent = this;
                    ord.Dock = DockStyle.Fill;
                    ord.FormBorderStyle = FormBorderStyle.None;
                    ord.Show();
                }
                else if (e.Node.Text == "Pedidos")
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CloseOpenForms()
        {
            FormCollection fc = Application.OpenForms;
            Form form = null;
            foreach (Form item in fc)
                if (item.Name != "ContenedorFrm")
                    form = item;
            if (form != null)
                form.Close();
        }
    }
}
