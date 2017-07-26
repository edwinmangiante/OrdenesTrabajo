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

            try
            {
                if (Controller.Usuario != null)
                {
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
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error inesperado en la aplicación. " +
                        "Por favor, vuelva a intentar y si el error persiste comuniquese con sistemas. (" + ex.Message + ")");
            }
        }

        private void FillTreeView()
        {
            //treeViewOpciones.Nodes.Add("Opciones");
            foreach (Opcion item in Controller.Usuario.PerfilUsuario.Opciones)
                treeViewOpciones.Nodes[0].Nodes.Add(item.Descripcion);
        }

        private void treeViewOpciones_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CloseOpenForms();

            try
            {
                Form form = null;
                if (e.Node.Text == "Ordenes")
                    form = new Ordenes();
                /*else if (e.Node.Text == "Pedidos")
                    form = new Pedidos();*/
                else if (e.Node.Text == "Usuarios")
                    form = new Usuarios();
                /*else if (e.Node.Text == "Logs")
                    form = new Logs();*/
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Show();
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error inesperado al intentar abrir la ventana. " +
                        "Por favor, vuelva a intentar y si el error persiste comuniquese con sistemas. (" + ex.Message + ")");
            }
        }

        private void CloseOpenForms()
        {
            FormCollection fc = Application.OpenForms;
            Form form = null;
            foreach (Form item in fc)
                if (!item.IsMdiContainer)
                    form = item;
            if (form != null)
                form.Close();
        }

        private void Contenedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
