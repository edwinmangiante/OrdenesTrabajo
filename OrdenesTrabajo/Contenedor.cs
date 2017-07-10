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
            treeViewOpciones.ExpandAll();
        }

        private void treeViewOpciones_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CloseOpenForms();

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
