using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Reflection;
using System.Text.RegularExpressions;
using DevExpress.Web.ASPxEditors;
using Ms.Data;
using System.ComponentModel;
using SpecialLogisticsSystem.Tool;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Data;
using SpecialLogisticsSystem.AppPortal.UserControls;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public abstract class IUpdateMode<T> where T : Model.Entity, new()
    {
        ///// <summary>
        ///// 给控件或对象赋值
        ///// </summary>
        ///// <param name="propertyInfo"></param>
        ///// <param name="getValue"></param>
        ///// <param name="setValue"></param>
        //protected abstract void OperationLabel(T model, PropertyInfo[] propertyInfo, ASPxLabel lbl, string setValue);
        //protected abstract void OperationText(T model, PropertyInfo[] propertyInfo, ASPxTextBox tbx, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);
        ////protected abstract void OperationLabel(PropertyInfo[] propertyInfo, object getValue, string setValue);

        //public static void EnumerableControl(T model, ASPxGridView grid)
        //{
        //    try
        //    {
        //        var properties = model.GetType().GetProperties();
        //        foreach (var propertyInfo in properties)
        //        {
        //            Control control = grid.FindEditFormTemplateControl(propertyInfo.Name);
        //            if (control == null) continue;
        //            object currentVaule = null;
        //            string typeName = control.GetType().Name;
        //            if (!grid.IsNewRowEditing)
        //            {
        //                currentVaule = grid.GetRowValues(grid.EditingRowVisibleIndex, propertyInfo.Name);
        //            }
        //            if (control is ASPxLabel)
        //            {
        //                var lbl = (ASPxLabel)control;
        //                OperationLabel(model,propertyInfo, lbl, ConvertHelper.ObjectToString(currentVaule));
        //            }
        //            else if (control is ASPxTextBox)
        //            {
        //                var tbx = (ASPxTextBox)control;
        //                OperationText(propertyInfo, tbx, ConvertHelper.ObjectToString(currentVaule));
        //                //propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, tbx.Value), null);
        //            }
        //            else if (control is ASPxSpinEdit)
        //            {
        //                var set = (ASPxSpinEdit)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, set.Value), null);
        //            }
        //            else if (control is ASPxMemo)
        //            {
        //                var mem = (ASPxMemo)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, mem.Value), null);
        //            }
        //            else if (control is ASPxComboBox)
        //            {
        //                var cbb = (ASPxComboBox)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbb.Value), null);
        //            }
        //            else if (control is ASPxCheckBox)
        //            {
        //                var cbx = (ASPxCheckBox)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbx.Checked), null);
        //            }
        //            else if (control is ASPxDateEdit)
        //            {
        //                var det = (ASPxDateEdit)control;
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, det.Value), null);
        //            }
        //            else if (control is ASPxCheckBoxList)
        //            {
        //                var cbl = (ASPxCheckBoxList)control;
        //                string cblVal = string.Empty;
        //                foreach (string v in cbl.SelectedValues)
        //                    cblVal += v + ",";
        //                cblVal = cblVal.TrimEnd(',');
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cblVal), null);
        //            }
        //            else if (control is ASPxListBox)
        //            {
        //                var lb = (ASPxListBox)control;
        //                string lbVal = string.Empty;
        //                foreach (string v in lb.SelectedValues)
        //                    lbVal += v + ",";
        //                lbVal = lbVal.TrimEnd(',');
        //                propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, lbVal), null);
        //            }
        //            else if (control is ComoboxCode)
        //            {
        //                var cbCode = (ComoboxCode)control;
        //                {
        //                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbCode.GetValue()), null);
        //                }
        //            }
        //            else if (control is LinkMan)
        //            {
        //                var linkMan = (LinkMan)control;
        //                //     }else if(control is ASPxSpinEdit)
        //                //default:
        //                //    var edt = (ASPxEdit)control;
        //                //    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, edt.Value), null);
        //                //    break;
        //            }
        //            else if (control is BranchLookUp)
        //            {
        //                var branchLookUp = (BranchLookUp)control;
        //                {
        //                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, branchLookUp.GetValue()), null);
        //                }
        //            }
        //            else if (control is EmployeeLookUp)
        //            {
        //                var employeeLookUpLookUp = (EmployeeLookUp)control;
        //                {
        //                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, employeeLookUpLookUp.GetValue()), null);
        //                }
        //            }
        //            else if (control is RoleLookUp)
        //            {
        //                var roleLookUp = (RoleLookUp)control;
        //                {
        //                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, roleLookUp.GetValue()), null);
        //                }
        //            }
        //            else if (control is GeneralNumber)
        //            {
        //                var generalNumber = (GeneralNumber)control;
        //                {
        //                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, generalNumber.GetNewNumber()), null);
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(string.Empty, ex);
        //    }
        //}


    
    }
}