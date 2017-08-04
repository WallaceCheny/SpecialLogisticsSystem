using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Web.UI.WebControls;


namespace Common
{
    
    public static class ControlHelper
    {
        /// <summary>
        /// To omit ObjectDisposedException
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="action"></param>
        public static void Invoke(Control ctrl, Action action)
        {
            if (ctrl == null)
                throw new ArgumentNullException("ctrl");
            if (action == null)
                throw new ArgumentNullException("action");

            if (!ctrl.IsHandleCreated) return;

            try
            {
                if (ctrl.IsHandleCreated)
                    ctrl.Invoke(action);
            }
            catch (ObjectDisposedException)
            {
            }
        }

        #region <<Set the drop down list item>>
        public static void SetDropDownList(DropDownList ddl, string value, int defaultIndex)
        {
            if (value != null)
            {
                int index = -1;
                if (value.Trim().Length > 0)
                {
                    for (int i = 0; i < ddl.Items.Count; i++)
                    {
                        if (ddl.Items[i].Value.Trim().ToUpper() == value.Trim().ToUpper())
                        {
                            index = i;
                            break;
                        }
                    }
                }
                if (index == -1)
                {
                    index = defaultIndex;
                }
                ddl.SelectedIndex = index;
            }
            else
            {
                ddl.SelectedIndex = -1;
            }
        }
        public static void SetDropDownList(DropDownList ddl, string value)
        {
            SetDropDownList(ddl, value, -1);
        }

        public static void SetRadioList(RadioButtonList rbs, string value, int defaultIndex)
        {
            if (value != null)
            {
                int index = -1;
                if (value.Trim().Length > 0)
                {
                    for (int i = 0; i < rbs.Items.Count; i++)
                    {
                        if (rbs.Items[i].Value.Trim().ToUpper() == value.Trim().ToUpper())
                        {
                            index = i;
                            break;
                        }
                    }
                }
                if (index == -1)
                {
                    index = defaultIndex;
                }
                rbs.SelectedIndex = index;
            }
            else
            {
                rbs.SelectedIndex = -1;
            }
        }

        public static void SetRadioList(RadioButtonList rbs, string value)
        {
            SetRadioList(rbs, value, -1);
        }

        public static void SetRadioList<T>(RadioButtonList rbs, T value)
        {
            string result = string.Empty;
            if (null != value)
            {
                result = value.ToString();
            }
            SetRadioList(rbs, result, -1);
        }

        public static void SetCheckBoxList(CheckBoxList cbl, string value)
        {
            if (value != null)
            {
                if (value.Trim().Length > 0)
                {
                    for (int i = 0; i < cbl.Items.Count; i++)
                    {
                        if (cbl.Items[i].Value.Trim().ToUpper() == value.Trim().ToUpper())
                        {
                            cbl.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        public static void SetCheckBoxList<T>(CheckBoxList cbl, IEnumerable<T> values)
        {
            if (values != null)
            {
                //var list = values.ToArray<T>();
                //for (int i = 0; i < cbl.Items.Count; i++)
                //{
                //    foreach (var value in list)
                //    {
                //        if (cbl.Items[i].Value.Trim().ToUpper() == value.ToString())
                //        {
                //            cbl.Items[i].Selected = true;
                //        }
                //    }
                //}
            }
        }
        #endregion

        #region Init dropdownlist
        /// <summary>
        /// init the dropdown list with the number
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="isAddNull"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void InitNumberItems(DropDownList ddl, bool isAddNull, ListItem nullItem, int start, int end)
        {
            if (isAddNull)
            {
                ddl.Items.Add(nullItem);
            }
            if (start > end)
            {
                for (int i = start; i >= end; i--)
                {
                    ddl.Items.Add(new ListItem(i.ToString()));
                }
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    ddl.Items.Add(new ListItem(i.ToString()));
                }
            }
        }


        /// <summary>
        /// will be 0 to 59
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="isAddNull"></param>
        /// <param name="nullItem"></param>
        public static void InitMinuteItems(DropDownList ddl, bool isAddNull, ListItem nullItem)
        {
            if (isAddNull)
            {
                ddl.Items.Add(nullItem);
            }
            for (int i = 0; i <= 59; i++)
            {
                if (i < 10)
                {
                    ddl.Items.Add(new ListItem("0" + i.ToString()));
                }
                else
                {
                    ddl.Items.Add(new ListItem(i.ToString()));
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="isAddNull"></param>
        /// <param name="nullItem"></param>
        public static void InitIntervalItems(DropDownList ddl, bool isAddNull, ListItem nullItem)
        {
            if (isAddNull)
            {
                ddl.Items.Add(nullItem);
            }
            ddl.Items.Add(new ListItem("AM"));
            ddl.Items.Add(new ListItem("PM"));
        }

        /// <summary>
        /// will be 1 to 31
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="isAddNull"></param>
        /// <param name="nullItem"></param>
        public static void InitDayItems(DropDownList ddl, bool isAddNull, ListItem nullItem)
        {
            if (isAddNull)
            {
                ddl.Items.Add(nullItem);
            }
            for (int i = 1; i <= 31; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString()));
            }
        }

        /// <summary>
        /// will be 1 to 12
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="isAddNull"></param>
        /// <param name="nullItem"></param>
        public static void InitMonthItems(DropDownList ddl, bool isAddNull, ListItem nullItem)
        {
            if (isAddNull)
            {
                ddl.Items.Add(nullItem);
            }
            for (int i = 1; i <= 12; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString()));
            }
        }

        /// <summary>
        /// will to now to 1900 to now.
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="isAddNull"></param>
        /// <param name="nullItem"></param>
        /// <param name="range"></param>
        public static void InitYearItems(DropDownList ddl, bool isAddNull, ListItem nullItem, bool isAscend, params int[] range)
        {
            if (isAddNull)
            {
                ddl.Items.Add(nullItem);
            }
            int major = System.DateTime.Now.Year;
            int minor = 1900;
            if (null != range && range.Length == 2)
            {
                if (range[0] >= range[1])
                {
                    major = range[0];
                    minor = range[1];
                }
                else
                {
                    minor = range[0];
                    major = range[1];
                }
            }
            if (isAscend)
            {
                for (int i = minor; i <= major; i++)
                {
                    ddl.Items.Add(new ListItem(i.ToString()));
                }
            }
            else
            {
                for (int i = major; i >= minor; i--)
                {
                    ddl.Items.Add(new ListItem(i.ToString()));
                }
            }
        }

        #endregion

        #region Get Value from list items
        public static string GetValues(CheckBoxList list, string separator)
        {
            string result = string.Empty;
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Selected)
                {
                    result += list.Items[i].Value + separator;
                }
            }
            if (result.EndsWith(separator))
            {
                result = result.Substring(0, result.Length - separator.Length);
            }

            return result;
        }

        public static string GetTexts(CheckBoxList list, string separator)
        {
            string result = string.Empty;
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Selected)
                {
                    result += list.Items[i].Text + separator;
                }
            }
            if (result.EndsWith(separator))
            {
                result = result.Substring(0, result.Length - separator.Length);
            }

            return result;
        }
        #endregion
    }
}
