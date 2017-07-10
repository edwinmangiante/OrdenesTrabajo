using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesTrabajo.Controles
{
    public class Controller
    {
        //acá hay que definir cosas que habría que ir a buscar cdo arranca la app
        //si hay un ws acá estaría una propiedad estática que crearía la conexión!

        public static void MensajeError(string msj)
        {
            MessageBox.Show(msj, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MensajeInformacion(string msj)
        {
            MessageBox.Show(msj, "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool MensajeYesNo(string msj)
        {
            DialogResult rta = MessageBox.Show(msj, "Consulta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static bool MensajeOkCancel(string msj)
        {
            DialogResult rta = MessageBox.Show(msj, "Consulta!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rta == DialogResult.OK)
                return true;
            else
                return false;
        }

        public static void MensajeWarning(string msj)
        {
            MessageBox.Show(msj, "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DateTime GetDateTime()
        {
            return OrdenTrabajo.GetDateTime();
        }
    }
}
