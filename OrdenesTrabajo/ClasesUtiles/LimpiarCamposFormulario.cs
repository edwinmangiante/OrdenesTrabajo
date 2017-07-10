using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesTrabajo.ClasesUtiles
{
    public abstract class LimpiarCamposFormulario
    {
        /// <summary>
        /// Limpia los controles de un form
        /// </summary>
        /// <param name="frm"></param>
        public static void InicializarControles(Control frm)
        {
            List<Control> lstControls = GetAllControls(frm.Controls);

            LimpiarCtrl(lstControls);
        }

        /// <summary>
        /// Limpia los controles de una lista que recibe por parametro
        /// </summary>
        /// <param name="listaCtrl"></param>
        private static void LimpiarCtrl(List<Control> listaCtrl)
        {
            //Busco los Labels
            foreach (Label lbl in listaCtrl.OfType<Label>().Where(x => x.Name.Contains("lbl")))
                lbl.Text = string.Empty;
            
            //Busco los textbox y los limpio
            foreach (TextBox txt in listaCtrl.OfType<TextBox>())
                txt.Clear();

            //Busco los textbox y los limpio
            foreach (MaskedTextBox txt in listaCtrl.OfType<MaskedTextBox>())
                txt.Clear();

            //Los combos los desselecciono
            foreach (ComboBox cmb in listaCtrl.OfType<ComboBox>().Where(x => x.Items.Count > 0))
                cmb.SelectedIndex = 0;

            foreach (DataGridView dgv in listaCtrl.OfType<DataGridView>())
            {
                if (dgv.DataSource is BindingSource)
                    ((BindingSource)dgv.DataSource).DataSource = null;
            }

            //Los pick de fecha...
            foreach (DateTimePicker dtp in listaCtrl.OfType<DateTimePicker>())
            {
                dtp.Value = DateTime.Today;

                if (dtp.ShowCheckBox)
                    dtp.Checked = false;
            }

            foreach (CheckBox chk in listaCtrl.OfType<CheckBox>())
                chk.Checked = false;
        }

        /// <summary>
        /// Devuelve los controles "hijos" de uno que recibe por parametro
        /// </summary>
        /// <param name="ctrls"></param>
        /// <returns></returns>
        private static List<Control> GetAllControls(IList ctrls)
        {
            List<Control> RetCtrls = new List<Control>();
            foreach (Control ctl in ctrls)
            {
                RetCtrls.Add(ctl);
                List<Control> SubCtrls = GetAllControls(ctl.Controls);
                RetCtrls.AddRange(SubCtrls);
            }

            return RetCtrls;
        }
    }
}
