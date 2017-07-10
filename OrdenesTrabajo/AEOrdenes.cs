using DAL;
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
    public partial class AEOrdenes : Form
    {
        public OrdenTrabajo Orden { get; set; }

        public AEOrdenes()
        {
            InitializeComponent();
            this.Text = "Alta Orden";
        }

        public AEOrdenes(OrdenTrabajo ordenAEditar, string accion)
        {
            ConfigForm(ordenAEditar, accion);
        }

        private void ConfigForm(OrdenTrabajo ordenAEditar, string accion)
        {
            //mapear
            //deshabilitar campos para los 2
            if (accion == "Editar")
                this.Text = "Edita Orden";
            else if (accion == "Ver")
            {
                this.Text = "Ver Orden";
                //deshabilitar los que faltan
            }
        }

        private void AEOrdenes_Load(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Valida())
            {
                //mapear orden
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Valida()
        {
            return true;
        }
    }
}
