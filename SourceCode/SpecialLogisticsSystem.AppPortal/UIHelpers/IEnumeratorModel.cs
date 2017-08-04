using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.ASPxGridView;
using System.Web.UI;
using DevExpress.Web.ASPxEditors;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public abstract class IEnumeratorModel<T> where T : Entity, new()
    {
        //protected abstract void HandlerControl(model);

        //public static void ToEnumeratorModel(ASPxGridView grid)
        //{
        //    var model = Activator.CreateInstance<T>();
        //    ToEnumeratorModel(model, grid);
        //}

        //public static void ToEnumeratorModel(T model, ASPxGridView grid)
        //{
        //    var properties = model.GetType().GetProperties();
        //    foreach (var propertyInfo in properties)
        //    {
        //        Control control = grid.FindEditFormTemplateControl(propertyInfo.Name);
        //        if (control == null) continue;
        //        string typeName = control.GetType().Name;
        //        switch (typeName)
        //        {
        //            case "ASPxTextBox":
        //                var tbx = (ASPxTextBox)control;
        //                HandlerTextBoxControl();
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, tbx.Value, tbx.ClientInstanceName), null);
        //                break;
        //            case "ASPxSpinEdit":
        //                var set = (ASPxSpinEdit)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, set.Value, set.ClientInstanceName), null);
        //                break;
        //            case "ASPxMemo":
        //                var mem = (ASPxMemo)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, mem.Value, mem.ClientInstanceName), null);
        //                break;
        //            case "ASPxComboBox":
        //                var cbb = (ASPxComboBox)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbb.Value, cbb.ClientInstanceName), null);
        //                break;
        //            case "ASPxCheckBox":
        //                var cbx = (ASPxCheckBox)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbx.Checked, cbx.ClientInstanceName), null);
        //                break;
        //            case "ASPxDateEdit":
        //                var det = (ASPxDateEdit)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, det.Value, det.ClientInstanceName), null);
        //                break;
        //            case "ASPxCheckBoxList":
        //                var cbl = (ASPxCheckBoxList)control;
        //                string cblVal = string.Empty;
        //                foreach (string v in cbl.SelectedValues)
        //                    cblVal += v + ",";
        //                cblVal = cblVal.TrimEnd(',');
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cblVal, cbl.ClientInstanceName), null);
        //                break;
        //            case "ASPxListBox":
        //                var lb = (ASPxListBox)control;
        //                string lbVal = string.Empty;
        //                foreach (string v in lb.SelectedValues)
        //                    lbVal += v + ",";
        //                lbVal = lbVal.TrimEnd(',');
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, lbVal, lb.ClientInstanceName), null);
        //                break;
        //            case "usercontrols_linkman_ascx":
        //                var linkMan = (LinkMan)control;
        //                break;
        //            default:
        //                var edt = (ASPxEdit)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, edt.Value, edt.ClientInstanceName), null);
        //                break;
        //        }
        //    }
        //}
    }
}