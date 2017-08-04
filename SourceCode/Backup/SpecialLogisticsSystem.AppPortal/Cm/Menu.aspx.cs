using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.ASPxTreeList;
using System.Reflection;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.AppPortal.UIHelpers;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Menu : BasePage<Menu>
    {
        [Dependency]
        public ICmMenuDal _menu { get; set; }
        [Dependency]
        public ICmRoleMenuRelationDal _role_menu { get; set; }

        #region 字段名称
        private string IdColumnName { get; set; }
        private string ParentIdColumnName { get; set; }
        private string NameColumnName { get; set; }
        private string IconColumnName { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            GetColumnName();
            //ViewMenu.JSProperties.Add("cp_listID", treeList.ClientID);
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.IsTreeMenu = true;
                    master.IsShowSearch = false;
                }
                UIHelpers.IconHelper iconHelper = new UIHelpers.IconHelper();
                var icon = treeList.Columns[IconColumnName] as TreeListComboBoxColumn;
                icon.PropertiesComboBox.DataSource = iconHelper.GetIcons();
                icon.PropertiesComboBox.ImageUrlField = DynamicPropertyHelper.GetPropertyName<IconInfo>(p => p.FilePath); ;
                icon.PropertiesComboBox.TextField = NameColumnName;
                icon.PropertiesComboBox.ValueField = NameColumnName;
            }
            TreeUserDataBind(this.treeList);
        }

        private void GetColumnName()
        {
            IdColumnName = T_Cm_Menu.IdColumnName;
            ParentIdColumnName = T_Cm_Menu.ParentIdColumnName;
            NameColumnName = T_Cm_Menu.NameColumnName;
            IconColumnName = T_Cm_Menu.IconColumnName;
        }

        private void TreeUserDataBind(DevExpress.Web.ASPxTreeList.ASPxTreeList list)
        {
            list.ParentFieldName = ParentIdColumnName;
            list.KeyFieldName = IdColumnName;
            QueryInfo<T_Cm_Menu> queryInfo = new QueryInfo<T_Cm_Menu>();
            IList<T_Cm_Menu> menuList = _menu.GetList(queryInfo);
            list.DataSource = menuList;
            list.DataBind();

            TreeListComboBoxColumn c = this.treeList.Columns[ParentIdColumnName] as TreeListComboBoxColumn;
            c.PropertiesComboBox.DataSource = menuList.Where(p => p.is_main);
            c.PropertiesComboBox.TextField = NameColumnName;
            c.PropertiesComboBox.ValueField = IdColumnName;
        }

        protected void treeList_NodeUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            T_Cm_Menu model = new T_Cm_Menu();
            model.id = Guid.Parse(e.Keys[0].ToString());
            UIHelpers.TryUpdateModel<T_Cm_Menu>.ToUpdateModel(model, e);
            _menu.Update(model);
            e.Cancel = true;
            (sender as ASPxTreeList).CancelEdit();
            TreeUserDataBind(this.treeList);
        }

        bool IsStringValueNotEmpty(object value)
        {
            return value != null && value.ToString().Trim().Length > 0;
        }

        protected void treeList_NodeDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string strReturn = "删除成功！";
            object id = e.Keys[0];
            QueryInfo<T_Cm_RoleMenu_Relation> queryInfo = new QueryInfo<T_Cm_RoleMenu_Relation>();
            queryInfo.SetQuery(T_Cm_RoleMenu_Relation.PropertyMenuID, id);
            IList<T_Cm_RoleMenu_Relation> relations = _role_menu.GetList(queryInfo);
            if (relations.Count > 0)
            {
                strReturn = "菜单被其他角色引用，无法删除！";
                treeList.JSProperties[Constants.strCpMessage] = strReturn;
                e.Cancel = true;
                (sender as ASPxTreeList).CancelEdit();
                return;
            }
            List<object> ids = new List<object>();
            ids.Add(e.Keys[0]);
            _menu.Delete(ids);
            e.Cancel = true;
            (sender as ASPxTreeList).CancelEdit();
            TreeUserDataBind(this.treeList);
            treeList.JSProperties[Constants.strCpMessage] = strReturn;
        }

        protected void treeList_NodeInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            T_Cm_Menu model = new T_Cm_Menu();
            UIHelpers.TryUpdateModel<T_Cm_Menu>.ToInsertModel(model, e);
            model.id = Guid.NewGuid();
            _menu.Insert(model);
            e.Cancel = true;
            (sender as ASPxTreeList).CancelEdit();
            TreeUserDataBind(this.treeList);
        }

        protected void treeList_NodeValidating(object sender, TreeListNodeValidationEventArgs e)
        {
            if (e.NewValues[NameColumnName] == null)
            {
                e.Errors[NameColumnName] = "菜单名称不得为空 ！";
            }
            if (e.HasErrors)
                e.NodeError = "Please, correct all errors.";
        }

        protected void treeList_StartNodeEditing(object sender, TreeListNodeEditingEventArgs e)
        {
            //this.treeList.DoNodeValidation();
        }

        protected void treeList_NodeInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void treeList_InitNewNode(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            DevExpress.Web.ASPxTreeList.TreeListComboBoxColumn c = this.treeList.Columns[ParentIdColumnName] as TreeListComboBoxColumn;
        }
    }
}