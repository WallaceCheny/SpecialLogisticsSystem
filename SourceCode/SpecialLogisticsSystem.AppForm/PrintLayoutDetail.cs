using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.UserDesigner;
using TitanMD.BussinessManager.Configuration;
using TitanMD.DataAccess;
using TitanMD.DataAccess.Entities;
using TitanMD.DataAccess.Enums;
using WinApp.Editors.Forms;
using WinApp.Exceptions;
using WinApp.GeneralModules.DataAccess.Accessor;
using WinApp.Objects;
using WinApp.UICommon;
using WinApp.DataHelpers;
using System.ComponentModel.Design;

namespace SpecialLogisticsSystem.AppForm
{
    public partial class PrintLayoutDetail : Form
    {
        private int _id;
        private PrintLayout _entity;
        private DataContextWrapper _dc;
        private XRDesignPanel _panel;
        private XtraReport1 _report = null;

        #region Parameter
        public string PrintName
        {
            get { return bartxtName.EditValue == null ? string.Empty : bartxtName.EditValue.ToString(); }
        }

        public string PrintCode
        {
            get { return bartxtCode.EditValue == null ? string.Empty : bartxtCode.EditValue.ToString(); }
        }

        public object MemberType
        {
            get { return barType.EditValue; }
        }

        public bool IsDefault
        {
            get { return barIsDefault.EditValue == null ? false : (bool)barIsDefault.EditValue; }
        }

        public bool IsSystem
        {
            get { return barChkIsSystem.EditValue == null ? false : (bool)barChkIsSystem.EditValue; }
        }

        public PrintLayoutType Type
        {
            get;
            set;
        }
        #endregion

        public PrintLayoutDetail()
        {
            InitializeComponent();
        }

        public PrintLayoutDetail(int id)
            : this()
        {
            this._dc = new DataContextWrapper(true);
            this._id = id;
        }

        public PrintLayoutDetail(DataContextWrapper dc, PrintLayout entity)
            : this()
        {
            this._dc = dc;
            this._entity = entity;
        }

        private void BindType()
        {
            foreach (PrintLayoutType item in Enum.GetValues(typeof(PrintLayoutType)))
            {
                cmbType.Items.Add(new IDName { ID = (int)item, Name = item.ToString() });
            }
        }

        private void PrintLayoutDetail_Load(object sender, EventArgs e)
        {
            BindType();
            _report = new XtraReport1();
            if (null == _entity)
            {
                if (_dc == null) _dc = new DataContextWrapper(true);

                _entity = PrintLayoutMgr.GetSingle(_dc, _id);
            }
            if (null != _entity)
            {
                _report.DisplayName = _entity.Name;
                bartxtName.EditValue = _entity.Name;
                bartxtCode.EditValue = _entity.Code;
                barType.EditValue = _entity.Type;
                barIsDefault.EditValue = _entity.IsDefault;
                barChkIsSystem.EditValue = _entity.IsSystem;
                _report.LoadLayoutFromXml(_entity.PrintMemoryContent);
                _entity.PrintMemoryContent.Close();
                _entity.PrintMemoryContent.Dispose();
            }
            if (null == _entity || _entity.ID == 0)
            {
                this.bartxtCode.EditValue = CodeGenerator.Generate(SequenceNumberType.PrintLayouts.ToString());
            }
            xrDesignMdiController1.OpenReport(_report);
            btnLoadTemplates.Enabled = true;
        }

        private void xrDesignMdiController1_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            _panel = (XRDesignPanel)sender;
            ChangeParameter(_entity == null ? PrintLayoutType.Prescription : _entity.PrintLayoutTypeEnum);
            xrDesignMdiController1.AddCommandHandler(new SaveCommandHandler(_panel, this, _entity));
        }

        private void PrintLayoutDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnLoadTemplates_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<PrintLayout> printList = PrintLayoutMgr.GetSystemList(_dc);
            var dlg = new FindDialog(printList);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                var entity = dlg.SelectedEntity;
                if (entity != null && entity.ID > 0)
                {
                    _report = new XtraReport1();
                    PrintLayout layoutItem = PrintLayoutMgr.GetSingle(_dc, entity.ID);
                    _report.LoadLayoutFromXml(layoutItem.PrintMemoryContent);
                    layoutItem.PrintMemoryContent.Close();
                    layoutItem.PrintMemoryContent.Dispose();
                    xrDesignMdiController1.OpenReport(_report);
                }
            }
        }


        private void barType_EditValueChanged(object sender, EventArgs e)
        {
            if (null != xrDesignMdiController1.ActiveDesignPanel)
            {
                PrintLayoutType type = (PrintLayoutType)Enum.Parse(typeof(PrintLayoutType), barType.EditValue.ToString());
                ChangeParameter(type);
            }
        }

        private void ChangeParameter(PrintLayoutType type)
        {
            if (_report == null) return;
            switch (type)
            {
                case PrintLayoutType.Order:
                    var ds1 = new PrintOrderParameter();
                    _report.DataSource = ds1;
                    break;
                case PrintLayoutType.Prescription:
                    var ds2 = new PrintPrescriptionParameter();
                    _report.DataSource = ds2;
                    break;
                default:
                    break;
            }

            // Update the Field List.
            //FieldListDockPanel fieldList =
            //    (FieldListDockPanel)fieldListDockPanel1[DesignDockPanelType.FieldList];
            IDesignerHost host =
                (IDesignerHost)_panel.GetService(typeof(IDesignerHost));
            fieldListDockPanel1.UpdateDataSource(host);

        }
    }



    public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
    {
        XRDesignPanel panel;
        PrintLayoutDetail _detail;
        PrintLayout _entity;

        public SaveCommandHandler(XRDesignPanel panel, PrintLayoutDetail detail, PrintLayout entity)
        {
            this.panel = panel;
            this._detail = detail;
            this._entity = entity;
        }

        private bool Save()
        {
            bool result = false;
            try
            {
                using (var ms = new MemoryStream())
                {
                    panel.Report.SaveLayoutToXml(ms);
                    if (_entity == null || _entity.ID == 0)
                    {
                        _entity = new PrintLayout
                        {
                            Name = this._detail.PrintName,
                            Code = this._detail.PrintCode,
                            IsSystem = this._detail.IsSystem,
                            PrintMemoryContent = ms,
                            Type = this._detail.MemberType == null ? string.Empty : this._detail.MemberType.ToString(),
                            IsDefault = this._detail.IsDefault
                        };
                        PrintLayoutMgr.Add(_entity);
                    }
                    else
                    {
                        DataContextWrapper dc = new DataContextWrapper(true);
                        PrintLayout entity = PrintLayoutMgr.GetSingle(dc, _entity.ID);
                        entity.Name = this._detail.PrintName;
                        entity.Code = this._detail.PrintCode;
                        entity.IsSystem = this._detail.IsSystem;
                        entity.PrintMemoryContent = ms;
                        entity.Type = this._detail.MemberType == null ? string.Empty : this._detail.MemberType.ToString();
                        entity.IsDefault = this._detail.IsDefault;
                        entity.Validate().ThrowException();
                        PrintLayoutMgr.Update(dc, entity);
                    }
                }
                result = true;
            }
            catch (ValidationException ex)
            {
                result = false;
                ValidationResultDialog.ShowValidationResult(this._detail, ex);
            }
            catch (BaseException ex)
            {
                result = false;
                Messager.ShowError(ex);
            }
            // Prevent the "Report has been changed" dialog from being shown.
            panel.ReportState = ReportState.Saved;
            return result;
        }

        public bool CanHandleCommand(ReportCommand command)
        {
            return (command == ReportCommand.SaveFile || command == ReportCommand.Closing);
        }

        public void HandleCommand(ReportCommand command, object[] args, ref bool handled)
        {
            handled = true;
            if (command == ReportCommand.Closing)
            {
                ////TODO Add validate
                //using (var ms = new MemoryStream())
                //{
                //    panel.Report.SaveLayoutToXml(ms);
                //    PrintLayout _newEntity = new PrintLayout
                //    {
                //        Name = this._detail.PrintName,
                //        Code = this._detail.PrintCode,
                //        IsSystem = this._detail.IsSystem,
                //        PrintMemoryContent = ms,
                //        Type = this._detail.MemberType == null ? string.Empty : this._detail.MemberType.ToString(),
                //        IsDefault = this._detail.IsDefault
                //    };
                //    if (_entity.Code == _newEntity.Code && _entity.Name == _newEntity.Name
                //        && _entity.IsSystem == _newEntity.IsSystem && _entity.IsDefault == _newEntity.IsDefault
                //        && _entity.Type == _newEntity.Type)
                //    {
                        return;
                    //}
                //}
                
            }
            Save();
            //if (Save())
            //{
            //    this._detail.Close();
            //}
        }
    }
}
