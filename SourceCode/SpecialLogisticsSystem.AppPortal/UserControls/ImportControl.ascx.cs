using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.UserControl;
using SpecialLogisticsSystem.Tool;
using DevExpress.Web.ASPxUploadControl;
using System.IO;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ImportControl : BaseUserControl
    {
        public string Note
        {
            set
            {
                lblNote.Text = value;
            }
        }
        public int Index
        {
            set
            {
                ASPxUploadControl1.ID = ASPxUploadControl1.ID + value.ToString();
                btnSubmit.ID = btnSubmit.ID + value.ToString();
            }
        }
        private ImportType _currentImportType;
        public ImportType CurrentImportType
        {
            set
            {
                _currentImportType = value;
                string newClientInstanceName= this.ASPxUploadControl1.ClientInstanceName  + value.ToString();
                this.ASPxUploadControl1.ClientInstanceName = newClientInstanceName;
                btnSubmit.JSProperties[ConstantsHelper.ClientInstanceName]= newClientInstanceName;
                string description = ConvertHelper.GetEnumAttribute(value.ToString(), typeof(ImportType));
                lblTitle.Text = description;
                linkModel.NavigateUrl =string.Format("/Files/{0}模版.xlsx",description);
            }
            get
            {
                return _currentImportType;
            }
        }

        protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SaveFile(e.UploadedFile);
        }

        protected string SaveFile(UploadedFile uploadedFile)
        {
            string fileName = string.Empty;
            string newFileName=string.Empty;
            if (uploadedFile.IsValid)
            {
                string path =Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,@"Files\ExcelTemp\");
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                fileName = uploadedFile.FileName;
                newFileName = path + Guid.NewGuid() + fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));
                //fileName = string.Format("{0}{1}", MapPath("~/"), uploadedFile.FileName);
                if (File.Exists(newFileName))
                    File.Delete(newFileName);
                uploadedFile.SaveAs(newFileName); //uncomment this line
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(new IDNameDescription(1,newFileName,CurrentImportType.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}