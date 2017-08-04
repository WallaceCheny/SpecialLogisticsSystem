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
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.Tool;
using DevExpress.Web.ASPxGridView;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class RoleMenu : BasePage<RoleMenu>
    {
        [Dependency]
        public ICmMenuDal _menu { get; set; }
        [Dependency]
        public ICmRoleDal _role { get; set; }
        [Dependency]
        public ICmRoleMenuRelationDal _role_menu { get; set; }
        [Dependency]
        public ICmUserRoleRelationDal _role_user { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack || IsCallback)
            {
                TreeRoleDataBind(this.gridRole);
            }
            TreeMenuDataBind(this.treeListMenu, false);
        }

        protected void treeListMenu_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
        {
            string gridIdstr = e.Argument;
            T_Cm_Role info = _role.GetSingle(gridIdstr);
            TreeMenuDataBind((ASPxTreeList)sender, info.is_admin);
            if (!info.is_admin)
            {
                SetNodeSelectionSettings((ASPxTreeList)sender, gridIdstr);
            }
        }


        /// <summary>
        /// 菜单绑定
        /// </summary>
        /// <param name="list">ASPxTreeList</param>
        private void TreeMenuDataBind(DevExpress.Web.ASPxTreeList.ASPxTreeList list, bool isAdmin)
        {
            list.ParentFieldName = T_Cm_Menu.ParentIdColumnName;
            list.KeyFieldName = T_Cm_Menu.IdColumnName;
            list.SettingsSelection.Enabled = true;
            list.SettingsSelection.AllowSelectAll = true;
            list.SettingsSelection.Recursive = false;
            list.Settings.ShowTreeLines = true;
            list.DataSource = _menu.GetList(new QueryInfo<T_Cm_Menu>());
            list.DataBind();
            list.ExpandToLevel(2);
            list.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowAllNodes;
            list.Settings.GridLines = GridLines.Both;
            if (isAdmin)
            {
                list.Enabled = false;
                list.SelectAll();
            }
        }

        /// <summary>
        /// 角色绑定
        /// </summary>
        /// <param name="list"></param>
        private void TreeRoleDataBind(DevExpress.Web.ASPxGridView.ASPxGridView list)
        {
            list.DataSource = _role.GetList(new QueryInfo<T_Cm_Role>());
            list.DataBind();
            list.Settings.GridLines = GridLines.Both;
            list.SettingsEditing.Mode = DevExpress.Web.ASPxGridView.GridViewEditingMode.EditFormAndDisplayRow;
            list.KeyFieldName = T_Cm_Role.PropertyId;

        }

        string SaveNodeSelection()
        {
            List<object> table = this.gridRole.GetSelectedFieldValues(new string[] { this.gridRole.KeyFieldName, "role_type", "role_name", "update_date", "description" });//这里是想要获取的字段名列表。   
            if (table.Count == 0) return "请选中对应角色后进行操作!";
            if (treeListMenu.GetSelectedNodes().Count == 0) return "请选中对应菜单后进行操作!";

            object[] row = (object[])table[0];//这是得到第一行记录的值，如果是多行选择，可以循环取出。   

            string role_id = row[0].ToString();
            string role_name = row[2].ToString();
            List<object> ids = new List<object>();
            ids.Add(role_id);
            _role_menu.DeleteByRole(ids);
            foreach (TreeListNode item in treeListMenu.GetSelectedNodes())
            {
                T_Cm_RoleMenu_Relation model = new T_Cm_RoleMenu_Relation();
                model.id = Guid.NewGuid();
                model.menu_id = Guid.Parse(item.Key);
                model.role_id = Guid.Parse(role_id);
                model.branch_id = UserProvide.GetCurrentBranchID();
                _role_menu.Insert(model);
            }
            return "角色权限保存成功 !";
        }

        /// <summary>
        /// 绑定菜单权限
        /// </summary>
        /// <param name="obj">ASPxTreeList 对象</param>
        /// <param name="_role_id">角色ID</param>
        void SetNodeSelectionSettings(ASPxTreeList obj, string _role_id)
        {

            if (_role_id == null) return;
            obj.UnselectAll();
            QueryInfo<T_Cm_RoleMenu_Relation> queryInfo = new QueryInfo<T_Cm_RoleMenu_Relation>();
            queryInfo.SetQuery(T_Cm_RoleMenu_Relation.PropertyRoleID, _role_id);
            IList<T_Cm_RoleMenu_Relation> modelList = _role_menu.GetList(queryInfo);
            TreeListNodeIterator iterator = obj.CreateNodeIterator();
            TreeListNode node;
            //循环绑定TreeListMenu 是否选中行
            while (true)
            {
                node = iterator.GetNext();
                if (node == null) break;
                for (int i = 0; i < modelList.Count; i++)
                {
                    if (modelList[i].menu_id == Guid.Parse(node.Key))
                    {
                        node.Selected = true;
                    }
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            gridRole.JSProperties[Constants.strCpMessage] = SaveNodeSelection();
        }

        protected void gridRole_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            T_Cm_Role model = new T_Cm_Role();
            UIHelpers.TryUpdateModel<T_Cm_Role>.ToInsertModel(model, e);
            model.id = Guid.NewGuid();
            model.branch_id = UIHelpers.UserProvide.GetCurrentBranchID();
            model.update_date = DateTime.Now.ToString();
            _role.Insert(model);
            e.Cancel = true;
            (sender as DevExpress.Web.ASPxGridView.ASPxGridView).CancelEdit();
            TreeRoleDataBind(this.gridRole);
        }

        protected void gridRole_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            //要将角色表进行删除，并且角色权限菜单表也统一进行删除
            //TODO 不能删除已经关联的用户, 不能删除管理员
            string strReturn = Constants.strSuccessMessage;
            object id = e.Keys[0];
            T_Cm_Role role = _role.GetSingle(id);
            if (role.is_admin)
            {
                strReturn = "系统管理员无法删除！";
                gridRole.JSProperties[Constants.strCpMessage] = strReturn;
                e.Cancel = true;
                return;
            }
            IList<T_Cm_UserRole_Relation> roleUser = _role_user.GetList(new QueryInfo<T_Cm_UserRole_Relation>().SetQuery(T_Cm_UserRole_Relation.RoleIdColumnName, id));
            if (roleUser.Count > 0)
            {
                strReturn = "该角色已经关联一些用户，无法删除！";
                gridRole.JSProperties[Constants.strCpMessage] = strReturn;
                e.Cancel = true;
                return;
            }
            List<object> ids = new List<object>();
            ids.Add(id);
            _role.Delete(ids);
            _role_menu.DeleteByRole(ids);
            e.Cancel = true;
            (sender as ASPxGridView).CancelEdit();
            TreeRoleDataBind(this.gridRole);
            gridRole.JSProperties[Constants.strCpMessage] = strReturn;
        }

        protected void gridRole_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            T_Cm_Role model = new T_Cm_Role();
            //model.id =Guid.Parse( e.Keys[0].ToString();
            UIHelpers.TryUpdateModel<T_Cm_Role>.ToUpdateModel(model, e);
            model.branch_id = UIHelpers.UserProvide.GetCurrentBranchID();
            model.update_date = DateTime.Now.ToString();
            _role.Update(model);
            e.Cancel = true;
            (sender as DevExpress.Web.ASPxGridView.ASPxGridView).CancelEdit();
            TreeRoleDataBind(this.gridRole);
        }
    }
}