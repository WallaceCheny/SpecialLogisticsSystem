using System;
using System.Windows.Forms;
using Common;
using System.Threading;

namespace SendEmail.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtReceiver.Text = "";
            txtSubject.Text = "你的未来不是梦！";
            txtContent.Text = "物流行业在未来发展是不断完善的，竞争也很激烈，所以必须要有一款使用的软件来管理自己的公司，而且传统手工操作容易出错，一旦出错，客户的信任度就会大大降低。如果有需要物流管理系统，请联系<a target=\"_blank\" href=\"http://www.ewlxt.com\">易运物流系统</a>";
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)((object state) => { this.SendEmail(txtReceiver.Text, txtSubject.Text, txtContent.Text); }), null);
        }

        private void SendEmail(string strReceiver, string strSubject, string strContent)
        {
            int success = 0;
            int fail = 0;
            string to = strReceiver;
            string receiver = string.Empty;
            if (to.IndexOfAny(new char[] { ',', ';', '|' }) > 0)
            {
                string[] targets = to.Split(new char[] { ',', ';', '|' });
                foreach (string s in targets)
                {
                    receiver = receiver + ";" + s;
                    bool toIsOver = to.Split(new char[] { ',', ';', '|' }).Length > 39;
                    if (receiver.Split(';').Length >= 39 && toIsOver)
                    {
                        bool isSuccess = EmailHelper.SendMail(receiver.Trim(';'), "", strSubject, strContent);
                        if (isSuccess)
                        {
                            success = success + 1;
                        }
                        else
                        {
                            fail = fail + 1;
                        }
                        to = to.Replace(receiver, string.Empty);
                        receiver = string.Empty;
                    }
                    else if(!toIsOver)
                    {
                        bool isSuccess = EmailHelper.SendMail(receiver.Trim(';'), "", strSubject, strContent);
                         if (isSuccess)
                        {
                            success = success + 1;
                        }
                        else
                        {
                            fail = fail + 1;
                        }
                        break;
                    }
                }
            }
            else
            {
                bool isSuccess = EmailHelper.SendMail(receiver.Trim(';'), "", strSubject, strContent);
                if (isSuccess)
                {
                    success = success + 1;
                }
                else
                {
                    fail = fail + 1;
                }
            }
            ControlHelper.Invoke(this, delegate
            {
                lblTip.Text = string.Format("成功：{0},失败：{1}", success, fail);
            });
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog filDialog = new OpenFileDialog();
            filDialog.DefaultExt = "*.txt";
            if (DialogResult.OK == filDialog.ShowDialog())
            {
                string[] files = filDialog.FileNames;
                foreach (var item in files)
                {
                    txtReceiver.Text = FileHelper.GetContent(item);
                }
            }
        }


    }
}
