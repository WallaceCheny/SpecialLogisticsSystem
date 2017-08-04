using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace SpecialLogisticsSystem.AppForm
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason != CloseReason.WindowsShutDown &&
           //     Messager.ShowConfirm(string.Format("Are you sure to exit {0} ?", this.ProductName)) != DialogResult.Yes)
           // {
            //    e.Cancel = true;
           //     return;
           // }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void biQuit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.Close();
                //http://stackoverflow.com/questions/7912052/system-invalidoperationexception-due-to-collection-modification-on-call-to-appli
                //Application.Exit();
            }
            catch
            {
            }
        }

        private void biSupperBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintLayoutDetail frm = new PrintLayoutDetail();
            FormHelper.OpenForm(this, frm);
        }
    }
}