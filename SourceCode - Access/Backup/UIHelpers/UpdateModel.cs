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
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public static partial class TryUpdateModel<T> where T : Model.Entity, new()
    {
        public static void ToInsertModel(T model, ASPxDataInsertingEventArgs e)
        {
            var properties = model.GetType().GetProperties();
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                int index = Array.FindIndex(properties.ToArray(), (mactch) => { return mactch.Name.Equals(enumerator.Key.ToString(), StringComparison.OrdinalIgnoreCase); });
                {
                    if (index < 0) continue;
                    var pro = properties.ElementAt(index);
                    pro.SetValue(model, GetValue(pro.PropertyType, enumerator.Value), null);
                }
            }
        }
        public static void ToUpdateModel(T model, ASPxDataUpdatingEventArgs e)
        {
            var properties = model.GetType().GetProperties();
            model.GetPkPropertyInfo().SetValue(model, e.Keys[0], null);
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                int index = Array.FindIndex(properties.ToArray(), (mactch) => { return mactch.Name.Equals(enumerator.Key.ToString(), StringComparison.OrdinalIgnoreCase); });
                if (index != -1)
                {
                    var pro = properties.ElementAt(index);
                    pro.SetValue(model, GetValue(pro.PropertyType, enumerator.Value), null);
                }
            }
        }
        public static void ToUpdateModel(T model, ASPxGridView grid)
        {
            //if (model == null) model = Activator.CreateInstance<T>();
            var properties = model.GetType().GetProperties();//.Where(p=>p.GetCustomAttributes(typeof(PrimaryKey), false));
            foreach (var propertyInfo in properties)
            {
                Control control = grid.FindEditFormTemplateControl(propertyInfo.Name);
                if (control == null) continue;
                string typeName = control.GetType().Name;
                if (control is ASPxLabel)
                {
                    var lbl = (ASPxLabel)control;
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, lbl.Value), null);
                }
                else if (control is ASPxTextBox)
                {
                    var tbx = (ASPxTextBox)control;
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, tbx.Value), null);
                }
                else if (control is ASPxSpinEdit)
                {
                    var set = (ASPxSpinEdit)control;
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, set.Value), null);
                }
                else if (control is ASPxMemo)
                {
                    var mem = (ASPxMemo)control;
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, mem.Value), null);
                }
                else if (control is ASPxComboBox)
                {
                    var cbb = (ASPxComboBox)control;
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbb.Value), null);
                }
                else if (control is ASPxCheckBox)
                {
                    var cbx = (ASPxCheckBox)control;
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbx.Checked), null);
                }
                else if (control is ASPxDateEdit)
                {
                    var det = (ASPxDateEdit)control;
                    DateTime? date = ConvertHelper.ObjectToDateTime(det.Value);
                    if (!date.HasValue || date.Value == DateTime.MinValue) continue; 
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, det.Value), null);
                }
                else if (control is ASPxCheckBoxList)
                {
                    var cbl = (ASPxCheckBoxList)control;
                    string cblVal = string.Empty;
                    foreach (string v in cbl.SelectedValues)
                        cblVal += v + ",";
                    cblVal = cblVal.TrimEnd(',');
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cblVal), null);
                }
                else if (control is ASPxListBox)
                {
                    var lb = (ASPxListBox)control;
                    string lbVal = string.Empty;
                    foreach (string v in lb.SelectedValues)
                        lbVal += v + ",";
                    lbVal = lbVal.TrimEnd(',');
                    propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, lbVal), null);
                }
                else if (control is ComoboxCode)
                {
                    var cbCode = (ComoboxCode)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbCode.GetValue()), null);
                    }
                }
                else if (control is ComboxSystem)
                {
                    var cbCodeSystem = (ComboxSystem)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbCodeSystem.GetValue()), null);
                    }
                }
                else if (control is LinkMan)
                {
                    continue;
                    //var linkMan = (LinkMan)control;
                    //if(propertyInfo is T_Cm_Link)
                    //{
                    //    propertyInfo.SetValue(model, GetValue(), null);
                    //    link = linkMan.GetLink();
                    //}
                }
                else if (control is BranchLookUp)
                {
                    var branchLookUp = (BranchLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, branchLookUp.GetValue()), null);
                    }
                }
                else if (control is EmployeeLookUp)
                {
                    var employeeLookUpLookUp = (EmployeeLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, employeeLookUpLookUp.GetValue()), null);
                    }
                }
                else if (control is RoleLookUp)
                {
                    var roleLookUp = (RoleLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, roleLookUp.GetValue()), null);
                    }
                }
                else if (control is CustomerLookUp)
                {
                    var customerLookUp = (CustomerLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, customerLookUp.GetValue()), null);
                    }
                }
                else if (control is GeneralNumber)
                {
                    var generalNumber = (GeneralNumber)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, generalNumber.GetNewNumber()), null);
                    }
                }
                else if (control is DistrictLookUp)
                {
                    var districtLookUp = (DistrictLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, districtLookUp.GetDistrictValue()), null);
                    }
                }
                else if (control is CityLookUp)
                {
                    var cityLookUp = (CityLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cityLookUp.GetCityValue()), null);
                    }
                }
                else if (control is ProductionLookUp)
                {
                    var productionLookUp = (ProductionLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, productionLookUp.GetValue()), null);
                    }
                }
                else if (control is CarLookUp)
                {
                    var carLookUp = (CarLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, carLookUp.GetValue()), null);
                    }
                }
                else if (control is ServicerLookUp)
                {
                    var servicerLookUp = (ServicerLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, servicerLookUp.GetValue()), null);
                    }
                }
                else if (control is WayLookUp)
                {
                    var wayLookUp = (WayLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, wayLookUp.GetValue()), null);
                    }
                }
                else if (control is StowageLookUp)
                {
                    var stowageLookUp = (StowageLookUp)control;
                    {
                        propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, stowageLookUp.GetValue()), null);
                    }
                }
            }
        }

        private static object GetValue(Type type, object val)
        {
            object result = val;
            if (type == typeof(Guid?) || type == typeof(Guid))
            {
                return ConvertHelper.ObjectToGuid(val);
            }
            else if (type == typeof(int))
            {
                return ConvertHelper.ObjectToInt(val);
            }
            else if (type == typeof(Int32))
            {
                return ConvertHelper.ObjectToInt32(val);
            }
            else if (type == typeof(Int64))
            {
                return ConvertHelper.ObjectToInt64(val);
            }
            else if (type == typeof(decimal))
            {
                return ConvertHelper.ObjectToDecimal(val);
            }
            else if (type == typeof(decimal))
            {
                return ConvertHelper.ObjectToDecimal(val);
            }
            else if (type == typeof(long))
            {
                return ConvertHelper.ObjectToLong(val);
            }
            else if (type == typeof(double) || type == typeof(double?))
            {
                return ConvertHelper.ObjectToDouble(val);
            }
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                return ConvertHelper.ObjectToDateTime(val);
            }
            else if (type == typeof(float))
            {
                return ConvertHelper.ObjectToFloat(val);
            }
            else if (type == typeof(string))
            {
                return ConvertHelper.ObjectToString(val);
            }
            return result;
        }
    }

    public static partial class UpdateControll<T> where T : Model.Entity, new()
    {
        public static void SetValueToControl(ASPxGridView grid)
        {
            var model = Activator.CreateInstance<T>();
            var properties = model.GetType().GetProperties();
            object currentVaule = null;
            foreach (var propertyInfo in properties)
            {
                Control control = grid.FindEditFormTemplateControl(propertyInfo.Name);
                if (control == null) continue;
                string typeName = control.GetType().Name;
                if (!grid.IsNewRowEditing)
                {
                    currentVaule = grid.GetRowValues(grid.EditingRowVisibleIndex, propertyInfo.Name);
                }
                if (control is ASPxLabel)
                {
                    var lbl = (ASPxLabel)control;
                    lbl.Text = ConvertHelper.ObjectToString(currentVaule);
                }
                else if (control is ASPxTextBox)
                {
                    var tbx = (ASPxTextBox)control;
                    tbx.Text = ConvertHelper.ObjectToString(currentVaule);
                }
                else if (control is ASPxSpinEdit)
                {
                    var set = (ASPxSpinEdit)control;
                    set.Text = ConvertHelper.ObjectToString(currentVaule);
                }
                else if (control is ASPxMemo)
                {
                    var mem = (ASPxMemo)control;
                    mem.Text = ConvertHelper.ObjectToString(currentVaule);
                }
                else if (control is ASPxComboBox)
                {
                    var cbb = (ASPxComboBox)control;
                    {
                        var defaultItem = cbb.Items.FindByValue(ConvertHelper.ObjectToString(currentVaule));
                        if (defaultItem != null) defaultItem.Selected = true;
                    }
                }
                else if (control is ASPxCheckBox)
                {
                    var cbx = (ASPxCheckBox)control;
                    cbx.Checked = ConvertHelper.ObjectToBool(currentVaule);
                }
                else if (control is ASPxDateEdit)
                {
                    var det = (ASPxDateEdit)control;
                    DateTime? date=ConvertHelper.ObjectToDateTime(currentVaule);
                    if(date.HasValue && date.Value!=DateTime.MinValue)
                        det.Date = date.Value;
                }
                else if (control is ComoboxCode)
                {
                    var cbCode = (ComoboxCode)control;
                    {
                        cbCode.SetValue(ConvertHelper.ObjectToString(currentVaule));
                    }
                }
                else if (control is ComboxSystem)
                {
                    var cbCodeSystem = (ComboxSystem)control;
                    {
                        cbCodeSystem.SetValue(ConvertHelper.ObjectToString(currentVaule));
                    }
                }
                else if (control is LinkMan)
                {
                    var linkMan = (LinkMan)control;
                    {
                        linkMan.SetData(ConvertHelper.ObjectToGuid(currentVaule));
                    }
                }
                else if (control is BranchLookUp)
                {
                    var branchLookUp = (BranchLookUp)control;
                    {
                        branchLookUp.SetValue(ConvertHelper.ObjectToGuid(currentVaule));
                    }
                }
                else if (control is EmployeeLookUp)
                {
                    Guid? empID = ConvertHelper.ObjectToGuid(currentVaule);
                    if (!empID.HasValue || empID.Value == Guid.Empty) return; 
                    var employeeLookUpLookUp = (EmployeeLookUp)control;
                    {
                        employeeLookUpLookUp.SetValue(empID);
                    }
                }
                else if (control is RoleLookUp)
                {
                    var roleLookUp = (RoleLookUp)control;
                    {
                        roleLookUp.SetValue(ConvertHelper.ObjectToGuid(currentVaule));
                    }
                }
                else if (control is CustomerLookUp)
                {
                    var customerLookUp = (CustomerLookUp)control;
                    {
                        Guid? customerId = ConvertHelper.ObjectToGuid(currentVaule);
                        if (customerLookUp.CustomerEnum == CustomerType.Deliver) 
                        { 
                            customerLookUp.SendID = customerId;
                        }
                        else {
                            customerLookUp.BindConsigneeData();
                        }
                        customerLookUp.SetValue(customerId);
                    }
                }
                else if (control is GeneralNumber)
                {
                    var generalNumber = (GeneralNumber)control;
                    {
                        generalNumber.SetValue(ConvertHelper.ObjectToString(currentVaule));
                    }
                }
                else if (control is DistrictLookUp)
                {
                    var districtLookUp = (DistrictLookUp)control;
                    {
                        districtLookUp.SetDistrictValue(ConvertHelper.ObjectToLong(currentVaule));
                    }
                }
                else if (control is CityLookUp)
                {
                    var cityLookUp = (CityLookUp)control;
                    {
                        cityLookUp.SetCityValue(ConvertHelper.ObjectToString(currentVaule));
                    }
                }
                else if (control is ProductionLookUp)
                {
                    var productionLookUp = (ProductionLookUp)control;
                    {
                        productionLookUp.SetValue(ConvertHelper.ObjectToGuid(currentVaule));
                    }
                }
                else if (control is CarLookUp)
                {
                    var carLookUp = (CarLookUp)control;
                    {
                        carLookUp.SetValue(ConvertHelper.ObjectToGuid(currentVaule));
                    }
                }
                else if (control is ServicerLookUp)
                {
                    var servicerLookUp = (ServicerLookUp)control;
                    {
                        servicerLookUp.SetValue(ConvertHelper.ObjectToGuid(currentVaule));
                    }
                }
                else if (control is LabelWayStatue)
                {
                    var labelWayStatue = (LabelWayStatue)control;
                    {
                        labelWayStatue.SetValue(ConvertHelper.ObjectToString(currentVaule));
                    }
                }
                else if (control is EditToolBar)
                {
                    var labelWayStatue = (EditToolBar)control;
                    {
                        labelWayStatue.SetStatue(ConvertHelper.ObjectToString(currentVaule));
                    }
                }
                else if (control is WayLookUp)
                {
                    var wayLookup = (WayLookUp)control;
                    {
                        wayLookup.SetValue(ConvertHelper.ObjectToGuid(currentVaule));
                    }
                }
                else if (control is StowageLookUp)
                {
                    var stowageLookup = (StowageLookUp)control;
                    {
                        stowageLookup.SetValue(ConvertHelper.ObjectToGuid(currentVaule));
                    }
                }
            }
        }
    }

    public static partial class UpdateDynamic
    {
        public static void ToUpdateDynamic(dynamic model, DevExpress.Web.ASPxGridView.ASPxGridView grid)
        {
            var names = model.GetDynamicMemberNames();
            foreach (var name in names)
            {
                Control control = grid.FindEditFormTemplateControl(name);
                if (control == null) continue;
                string typeName = control.GetType().Name;
                switch (typeName)
                {
                    case "ASPxTextBox":
                        var tbx = (ASPxTextBox)control;
                        model[name] = tbx.Value;
                        //propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, tbx.Value, tbx.ClientInstanceName), null);
                        break;
                    case "ASPxSpinEdit":
                        var set = (ASPxSpinEdit)control;
                        model[name] = set.Value;
                        //propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, set.Value, set.ClientInstanceName), null);
                        break;
                    case "ASPxMemo":
                        var mem = (ASPxMemo)control;
                        model[name] = mem.Value;
                        //propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, mem.Value, mem.ClientInstanceName), null);
                        break;
                    case "ASPxComboBox":
                        var cbb = (ASPxComboBox)control;
                        model[name] = cbb.Value;
                        //propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbb.Value, cbb.ClientInstanceName), null);
                        break;
                    case "ASPxCheckBox":
                        var cbx = (ASPxCheckBox)control;
                        model[name] = cbx.Checked;
                        //propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, cbx.Checked, cbx.ClientInstanceName), null);
                        break;
                    case "ASPxDateEdit":
                        var det = (ASPxDateEdit)control;
                        model[name] = det.Value;
                        //propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, det.Value, det.ClientInstanceName), null);
                        break;
                    default:
                        var edt = (ASPxEdit)control;
                        model[name] = edt.Value;
                        //propertyInfo.SetValue(model, GetValue(propertyInfo.PropertyType, edt.Value, edt.ClientInstanceName), null);
                        break;
                }
            }
        }
        public static void ToUpdateModel<T>(T model, dynamic dr) where T : Model.Entity, new()
        {
            var properties = model.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(Model.NoColumn), false).Length != 1);
            foreach (var propertyInfo in properties)
            {
                object result = null;
                object value = dr[propertyInfo.Name];
                if (value == null) continue;
                Type type = propertyInfo.PropertyType;
                if (UIHelper.IsNullableType(type))
                    result = Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
                else
                    result = Convert.ChangeType(value, type);
                propertyInfo.SetValue(model, result, null);
            }
        }
    }
}