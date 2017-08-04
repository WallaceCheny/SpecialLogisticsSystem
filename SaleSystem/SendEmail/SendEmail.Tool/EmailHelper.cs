using System;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Configuration;

namespace SendEmail.Tool
{
    public class EmailHelper
    {
            public static bool SendMail(string to, string mfrom, string subject, string content)
            {
                return SendMail(to, mfrom, subject, content, string.Empty, string.Empty, true);
            }
            public static bool SendMail(string to, string subject, string content)
            {
                return SendMail(to, string.Empty, subject, content, string.Empty, string.Empty, true);
            }
            public static bool SendMail(string to, string mfrom, string subject, string content, string cc, string bcc, bool isHTML)
            {
                bool result = false;
                MailMessage message = new MailMessage();
                message.Sender = new MailAddress(MailServerSetting.SMTPSender);
                if (mfrom.Length > 0)
                {
                    message.From = new MailAddress(mfrom);
                }
                else
                {
                    message.From = new MailAddress(MailServerSetting.SMTPSender);
                }

                if (to.Length > 0)
                {
                    if (to.IndexOfAny(new char[] { ',', ';', '|' }) > 0)
                    {
                        string[] targets = to.Split(new char[] { ',', ';', '|' });
                        foreach (string s in targets)
                        {
                            if (!string.IsNullOrEmpty(s))
                                message.To.Add(s);
                        }
                    }
                    else
                    {
                        message.To.Add(to);
                    }
                }

                if (cc.Length > 0)
                {
                    if (cc.IndexOfAny(new char[] { ',', ';', '|' }) > 0)
                    {
                        string[] targets = cc.Split(new char[] { ',', ';', '|' });
                        foreach (string s in targets)
                        {
                            if (!string.IsNullOrEmpty(s))
                                message.CC.Add(s);
                        }
                    }
                    else if (!string.IsNullOrEmpty(cc))
                    {
                        message.CC.Add(cc);
                    }
                }

                if (bcc.Length > 0)
                {
                    if (bcc.IndexOfAny(new char[] { ',', ';', '|' }) > 0)
                    {
                        string[] targets = bcc.Split(new char[] { ',', ';', '|' });
                        foreach (string s in targets)
                        {
                            if (!string.IsNullOrEmpty(s))
                                message.Bcc.Add(s);
                        }
                    }
                    else if (!string.IsNullOrEmpty(bcc))
                    {
                        message.Bcc.Add(bcc);
                    }
                }

                message.Subject = subject;
                message.IsBodyHtml = isHTML;
                message.Body = content;

                SmtpClient smtp = new SmtpClient(MailServerSetting.SMTPHost, MailServerSetting.SMTPPort);
                smtp.UseDefaultCredentials = true;
                if (MailServerSetting.SMTPUser.Length > 0)
                {
                    smtp.Credentials = new NetworkCredential(MailServerSetting.SMTPUser, MailServerSetting.SMTPPassword);
                }
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = MailServerSetting.SMTPSSL;
                smtp.Timeout = 30000;
                try
                {
                    smtp.Send(message);
                    result = true;
                }
                catch (Exception ex)
                {
                    ExceptionHelper.WriteLog(ex + MailServerSetting.SMTPUser + "," + SmtpDeliveryMethod.Network + "," + MailServerSetting.SMTPSSL);
                }
                return result;
            }
        }

        public static class MailServerSetting
        {
            #region email server setting
            public static string SMTPHost
            {
                get
                {
                    string host = string.Empty;
                    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
                    MailSettingsSectionGroup mailSettings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
                    if (mailSettings != null)
                    {
                        host = mailSettings.Smtp.Network.Host.Trim();
                    }
                    return host;
                }
            }
            public static int SMTPPort
            {
                get
                {
                    int port = 25;
                    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
                    MailSettingsSectionGroup mailSettings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
                    if (mailSettings != null)
                    {
                        port = mailSettings.Smtp.Network.Port;
                    }
                    return port;
                }
            }
            public static string SMTPUser
            {
                get
                {
                    string userName = string.Empty;
                    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
                    MailSettingsSectionGroup mailSettings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
                    if (mailSettings != null || null != mailSettings.Smtp.Network.UserName)
                    {
                        userName = null == mailSettings.Smtp.Network.UserName ? string.Empty : mailSettings.Smtp.Network.UserName.Trim();
                    }
                    return userName;
                }
            }
            public static string SMTPPassword
            {
                get
                {
                    string password = string.Empty;
                    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
                    MailSettingsSectionGroup mailSettings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
                    if (mailSettings != null)
                    {
                        password = null == mailSettings.Smtp.Network.Password ? string.Empty : mailSettings.Smtp.Network.Password;
                    }
                    return password;
                }
            }
            public static string SMTPSender
            {
                get
                {
                    string from = string.Empty;
                    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
                    MailSettingsSectionGroup mailSettings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
                    if (mailSettings != null)
                    {
                        from = mailSettings.Smtp.From.Trim();
                    }
                    return from;
                }
            }
            public static bool SMTPSSL
            {
                get
                {
                    bool ssl = false;
                    if (ConfigurationHelper.IsAppSettingsKeyExist("mail_ssl"))
                    {
                        ssl = ConvertHelper.ToBool(ConfigurationHelper.GetAppSettingsKeyValue("mail_ssl"));
                    }
                    return ssl;
                }
            }
            #endregion
        }
}
