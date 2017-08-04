using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Tool;
using System.Net;
using System.IO;
using System.Text;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public static class SmsHelper
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="aimcodes">短信号码</param>
        /// <param name="content">短信内容</param>
        /// <returns></returns>
        public static string SendSms(String aimcodes, String content)
        {
            string strResult = string.Empty;
            ICmConfigDal _config = UIHelper.Resolve<ICmConfigDal>();
            IList<T_Cm_Config> configList=_config.GetList(new QueryInfo<T_Cm_Config>()); 
            string accName= configList.FirstOrDefault(p=>p.parameter_name==ConfigType.SmsAccountName.ToString()).parameter_value;
            string accPwd = configList.FirstOrDefault(p=>p.parameter_name==ConfigType.SmsAccountPassword.ToString()).parameter_value;
            string smsSigner = configList.FirstOrDefault(p => p.parameter_name == ConfigType.SmsSigned.ToString()).parameter_value;
            string formUrl = "http://www.lx198.com/sdk/send";//url地址
            //参数
            string formData = "";
            DateTime Date = DateTime.Now;

            formData = formData + "&accName=" + accName.Trim() +
                "&accPwd=" + DEncrypt.MD5Encrypt(accPwd.Trim()) +
                "&content=" + content.Trim() + string.Format("【{0}】", smsSigner) +
                "&aimcodes=" + aimcodes.Trim() +
                "&bizId=" + string.Format("{0:yyyyMMddHHmmss}", Date);

            CookieContainer cookieContainer = new CookieContainer();
            // 将提交的字符串数据转换成字节数组
            //byte[] postData = Encoding.UTF8.GetBytes(formData);
            Encoding myc = Encoding.GetEncoding("UTF-8");
            byte[] postData = myc.GetBytes(formData);
            // 设置提交的相关参数
            HttpWebRequest request = WebRequest.Create(formUrl) as HttpWebRequest;
            Encoding myEncoding = Encoding.GetEncoding("UTF-8");
            request.Method = "POST";
            request.KeepAlive = false;
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
            request.CookieContainer = cookieContainer;
            request.ContentLength = postData.Length;

            // 提交请求数据
            System.IO.Stream outputStream = request.GetRequestStream();
            outputStream.Write(postData, 0, postData.Length);
            outputStream.Close();

            HttpWebResponse response;
            Stream responseStream;
            StreamReader reader;
            string srcString;
            response = request.GetResponse() as HttpWebResponse;
            responseStream = response.GetResponseStream();
            reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
            strResult = reader.ReadToEnd(); //返回值
            reader.Close();
            return strResult;
        }

        //public static string SendSms(String aimcodes, String content)
        //{
        //    string strResult = string.Empty;
        //    ICmConfigDal _config = UIHelper.Resolve<ICmConfigDal>();
        //    IList<T_Cm_Config> configList = _config.GetList(new QueryInfo<T_Cm_Config>());
        //    string accName = configList.FirstOrDefault(p => p.parameter_name == ConfigType.SmsAccountName.ToString()).parameter_value;
        //    string accPwd = configList.FirstOrDefault(p => p.parameter_name == ConfigType.SmsAccountPassword.ToString()).parameter_value;
        //    string formUrl = "http://www.smsadmin.cn/smsmarketing/wwwroot/api/get_send/";//url地址

        //    int retval = -1;
        //    WebClient client = new WebClient();
        //    formUrl += "?uid=" + accName + "&pwd=" + accPwd + "&mobile=" + aimcodes + "&msg=" + HttpContext.Current.Server.UrlEncode(content) + "&dtime=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //    Stream data = client.OpenRead(formUrl);
        //    StreamReader reader = new StreamReader(data, Encoding.Default);
        //    string s = reader.ReadToEnd();
        //    s = s.Trim().Substring(0, 1);
        //    if (s == "1")
        //    {
        //        strResult = "用户名或密码错误";
        //    }
        //    else if (s == "2")
        //    {
        //        strResult = "余额不足";
        //    }
        //    else if (s == "3")
        //    {
        //        strResult = "超过发送最大量100条";
        //    }
        //    else if (s == "4")
        //    {
        //        strResult = "此用户不允许发送";
        //    }
        //    else if (s == "5")
        //    {
        //        strResult = "手机号或发送信息不能为空";
        //    }
        //    else if (s == "6")
        //    {
        //        strResult = "含有敏感字,请修改后发送";

        //    }

        //    data.Close();
        //    reader.Close();

        //    if (s == "0")
        //        retval = 1;
        //    return strResult;
        //    ////参数
        //    //string formData = "";
        //    //DateTime Date = DateTime.Now;

        //    //formData = formData + "&accName=" + accName.Trim() +
        //    //    "&accPwd=" + DEncrypt.MD5Encrypt(accPwd.Trim()) +
        //    //    "&content=" + content.Trim() +
        //    //    "&aimcodes=" + aimcodes.Trim() +
        //    //    "&bizId=" + string.Format("{0:yyyyMMddHHmmss}", Date);

        //    //CookieContainer cookieContainer = new CookieContainer();
        //    //// 将提交的字符串数据转换成字节数组
        //    ////byte[] postData = Encoding.UTF8.GetBytes(formData);
        //    //Encoding myc = Encoding.GetEncoding("UTF-8");
        //    //byte[] postData = myc.GetBytes(formData);
        //    //// 设置提交的相关参数
        //    //HttpWebRequest request = WebRequest.Create(formUrl) as HttpWebRequest;
        //    //Encoding myEncoding = Encoding.GetEncoding("UTF-8");
        //    //request.Method = "POST";
        //    //request.KeepAlive = false;
        //    //request.AllowAutoRedirect = true;
        //    //request.ContentType = "application/x-www-form-urlencoded";
        //    //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
        //    //request.CookieContainer = cookieContainer;
        //    //request.ContentLength = postData.Length;

        //    //// 提交请求数据
        //    //System.IO.Stream outputStream = request.GetRequestStream();
        //    //outputStream.Write(postData, 0, postData.Length);
        //    //outputStream.Close();

        //    //HttpWebResponse response;
        //    //Stream responseStream;
        //    //StreamReader reader;
        //    //string srcString;
        //    //response = request.GetResponse() as HttpWebResponse;
        //    //responseStream = response.GetResponseStream();
        //    //reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
        //    //strResult = reader.ReadToEnd(); //返回值
        //    //reader.Close();
        //    //return strResult;
        //}
    }
}