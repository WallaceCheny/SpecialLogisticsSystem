using System;
using System.Windows.Forms;

namespace SpecialLogisticsSystem.AppForm
{
    public static class FormHelper
    {
        /// <summary>
        /// to open the new form in the mdiparent of current form
        /// </summary>
        /// <param name="frmCurrent"></param>
        /// <param name="frm"></param>
        public static void OpenForm(Form frmCurrent, Form frm)
        {
            Form frmMdi = null;
            if (frmCurrent.IsMdiContainer)
                frmMdi = frmCurrent;
            else
                frmMdi = frmCurrent.MdiParent;

            if (frmMdi != null && frm != null)
            {
                frm.MdiParent = frmMdi;
                frm.Show();
            }
        }

        public static bool CloseOpenedChildForms(Form frm)
        {
            if (frm == null)
            {
                throw new ArgumentNullException("frm");
            }

            foreach (var childForm in frm.MdiChildren)
            {
                childForm.Close();
            }

            return frm.MdiChildren.Length == 0;
        }

        public static void DisplayForm(Form currentForm, Form newForm)
        {
            SetControlEnablitity(currentForm, false);
            newForm.Show();
            SetControlEnablitity(currentForm, true);
        }

        public static void DisplayDialog(Form currentForm, Form newForm)
        {
            SetControlEnablitity(currentForm, false);
            newForm.ShowDialog();
            newForm.Dispose();
            SetControlEnablitity(currentForm, true);
        }

        public static void SetControlEnablitity(Form form, bool enable)
        {
            foreach (Control item in form.Controls) item.Enabled = enable;
            //form.Cursor = (enable ? Cursors.Default : Cursors.WaitCursor);
            Application.DoEvents();
        }
    }
}