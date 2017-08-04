using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using DevExpress.Web.Data;
using System.ComponentModel;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using Newtonsoft.Json;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class User : BasePage<User>
    {
        [Dependency]
        public ICmUserDal _user { get; set; }
        [Dependency]
        public ICmRoleDal _role { get; set; }
        [Dependency]
        public ICmUserRoleRelationDal _user_role { get; set; }
        [Dependency]
        public ICmUserBranchRelationDal _user_branch { get; set; }
        [Dependency]
        public ICmBranchDal _branch { get; set; }

        #region "字段名称"
        /// <summary>
        /// 关联分支机构
        /// </summary>
        private static string BranchIdColumnName { get; set; }
        /// <summary>
        /// emp_Info_Id
        /// </summary>
        private static string EmpInfoIdColumnName { get; set; }

        /// <summary>
        /// user_status
        /// </summary>
        private static string UserStatusColumnName { get; set; }

        /// <summary>
        /// def_show_branch
        /// </summary>
        private static string DefShowBranchColumnName { get; set; }
        /// <summary>
        /// 参数类别
        /// </summary>
        private static string ParaTypeColumnName { get; set; }
        /// <summary>
        /// id
        /// </summary>
        private static string IdColumnName { get; set; }
        /// <summary>
        /// role_id
        /// </summary>
        private static string RoleIdColumnName { get; set; }
        /// <summary>
        /// user_id
        /// </summary>
        private static string UserIdColumnName { get; set; }
        /// <summary>
        /// can_show_branch
        /// </summary>
        private static string CanShowBranchColumnName { get; set; }
        /// <summary>
        /// 标记改用户是否是超级管理员
        /// </summary>
        private static string IsAdminColumnName { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.User;
                }
                GetColumnName();
                Session[CanShowBranchColumnName] = null;
                UserDataBind();
                DataBindDropDownList.DataBindBranch(branch_id, string.Empty);
            }
        }

        private void GetColumnName()
        {
            BranchIdColumnName = T_Cm_User.BranchIdColumnName;
            EmpInfoIdColumnName = T_Cm_User.EmpIdColumnName;
            UserStatusColumnName = T_Cm_User.UserStatusColumnName;
            DefShowBranchColumnName = T_Cm_User.DefShowBranchColumnName;
            ParaTypeColumnName = T_Cm_Code.TypeColumnName;
            IdColumnName = T_Cm_User.IdColumnName;
            RoleIdColumnName = T_Cm_UserRole_Relation.RoleIdColumnName;
            UserIdColumnName = T_Cm_UserRole_Relation.UserIdColumnName;
            CanShowBranchColumnName = T_Cm_User.CanShowBranchColumnName;
            IsAdminColumnName = T_Cm_User.IsAdminColumnName;
        }

        private void UserDataBind()
        {
            var queryInfo = new QueryInfo<T_Cm_User>();
            if (Session["cp_filter"] != null)
            {
                Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(Session["cp_filter"].ToString());
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
                //if (queryInfo.Query.ContainsKey("shop_id")) queryInfo.Query["shop_id"] = queryInfo.Query["shop_id"].ToString().Split(',');
            }
            gridUser.DataSource = _user.Select(queryInfo);
            gridUser.DataBind();
        }

        #region 用户
        protected void gridUser_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> userIds = gridUser.GetSelectedFieldValues(IdColumnName);
            object is_admin = gridUser.GetRowValues(gridUser.EditingRowVisibleIndex, "role_is_admin");
            if (ConvertHelper.ObjectToBool(is_admin))
            {
                ErrorGrid("系统管理员，无法删除！", e);
                return;
            }

            _user.Delete(userIds);
            _user_role.DeleteByUsers(userIds);
            _user_branch.DeleteByUsers(userIds);
            UserDataBind();
            FinishGrid(e);
            gridUser.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        protected void gridUser_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            if (!gridUser.IsNewRowEditing)
            {
                UIHelpers.UpdateControll<T_Cm_User>.SetValueToControl(gridUser);
                UIHelpers.UpdateControll<T_Cm_UserRole_Relation>.SetValueToControl(gridUser);
                object isAdmin = gridUser.GetRowValues(gridUser.EditingRowVisibleIndex, new string[] { IsAdminColumnName });
                if (ConvertHelper.ObjectToBool(isAdmin))
                {
                    UserControl.ASPxTextBox user_name = gridUser.FindEditFormTemplateControl(T_Cm_User.UserNameColumnName) as UserControl.ASPxTextBox;
                    user_name.IsReadOnly = true;
                }

                if (Session[CanShowBranchColumnName] == null)
                {
                    ASPxGridView gridShowBranch = gridUser.FindEditFormTemplateControl("gridShowBranch") as ASPxGridView;
                    string can_show_branch = ConvertHelper.ObjectToString(gridUser.GetRowValues(gridUser.EditingRowVisibleIndex, new string[] { CanShowBranchColumnName }));
                    string[] can_show_branchs = can_show_branch.Split(',');
                    List<CanShowBranchCls> can_show_branch_cls = new List<CanShowBranchCls>();
                    if (!string.IsNullOrEmpty(can_show_branch))
                    {
                        int i = 0;
                        foreach (string branchid in can_show_branchs)
                        {
                            T_Cm_Branch branch = _branch.GetSingle(branchid);
                            can_show_branch_cls.Add(new CanShowBranchCls { id = i++, branch_id = branchid, name = branch.name });
                        }
                    }
                    Session[CanShowBranchColumnName] = can_show_branch_cls;
                    BindCanShowBranch(gridShowBranch);
                }
              
            }
        }
        protected void gridUser_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            T_Cm_User user = new T_Cm_User();
            UIHelpers.TryUpdateModel<T_Cm_User>.ToUpdateModel(user, gridUser);
            var can_show_branchs = Session[CanShowBranchColumnName] as List<CanShowBranchCls>;
            if (can_show_branchs != null && can_show_branchs.Count > 0) user.can_show_branch = can_show_branchs.Select(p => p.branch_id).Distinct().Aggregate((i, j) => i + "," + j);
            Session[CanShowBranchColumnName] = null;

            user.id = Guid.NewGuid();
            //对默认密码进行加密
            user.password = Tool.DEncrypt.Encrypt("888888");
            user.add_date = user.update_date = DateTime.Now;
            user.update_opr = UIHelpers.UserProvide.GetCurrentUserName();

            //每增加一条用户，则在用户与角色关系表中进行添加一行数据，默认角色ID为空
            T_Cm_UserRole_Relation userRole = new T_Cm_UserRole_Relation();
            UIHelpers.TryUpdateModel<T_Cm_UserRole_Relation>.ToUpdateModel(userRole, gridUser);
            userRole.branch_id = user.branch_id;
            userRole.user_id = user.id;
            userRole.id = Guid.NewGuid();
            _user_role.Insert(userRole);

            _user.Insert(user);
            e.Cancel = true;
            grid.CancelEdit();
            UserDataBind();
        }


        protected void gridUser_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            T_Cm_User user = _user.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Cm_User>.ToUpdateModel(user, gridUser);
            var can_show_branchs = Session[CanShowBranchColumnName] as List<CanShowBranchCls>;
            if (can_show_branchs != null && can_show_branchs.Count > 0) user.can_show_branch = can_show_branchs.Select(p => p.branch_id).Distinct().Aggregate((i, j) => i + "," + j);
            Session[CanShowBranchColumnName] = null;

            QueryInfo<T_Cm_UserRole_Relation> queryInfo = new QueryInfo<T_Cm_UserRole_Relation>();
            queryInfo.SetQuery(T_Cm_UserRole_Relation.UserIdColumnName, user.id);
            T_Cm_UserRole_Relation userRole = _user_role.GetList(queryInfo).FirstOrDefault();
            UIHelpers.TryUpdateModel<T_Cm_UserRole_Relation>.ToUpdateModel(userRole, gridUser);
            _user_role.Update(userRole);

            _user.Update(user);
            e.Cancel = true;
            grid.CancelEdit();
            UserDataBind();
        }
        protected void gridUser_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var grid = sender as ASPxGridView;
            List<object> selectItems = grid.GetSelectedFieldValues("id");//这里是想要获取的字段名列表。   
            if (e.Parameters == "Delete")
            {
                _user.Delete(selectItems);
                _user_role.DeleteByUsers(selectItems);
            }
            else if (e.Parameters == "setPassword")
            {
                if (selectItems.Count == 0) return;
                foreach (object selectItemId in selectItems)
                {
                    T_Cm_User user = _user.GetSingle(selectItemId);
                    user.password = DEncrypt.Encrypt("888888");
                    _user.Update(user);
                }
            }
            UserDataBind();
        }
        protected void gridUser_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            if (e.CallbackName == "APPLYFILTER")
            {
                Session.Add("cp_filter", e.Args[0]);
                UserDataBind();
            }
        }
        protected void gridUser_PageIndexChanged(object sender, EventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            UserDataBind();
        }

        private void ErrorGrid(string retrunMessage, CancelEventArgs e)
        {
            gridUser.JSProperties[Constants.strCpMessage] = retrunMessage;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridUser.CancelEdit();
        }
        #endregion

        #region 可查看分支机构
        protected void gridUser_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            Session[CanShowBranchColumnName] = null;
        }
        /// <summary>
        /// grid 没有caching 只能用这种绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridShowBranch_DataBinding(object sender, EventArgs e)
        {
            var grid = sender as ASPxGridView;
            grid.DataSource = Session[CanShowBranchColumnName] as List<CanShowBranchCls>;
        }

        protected void gridShowBranch_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var branch_id = grid.FindEditFormTemplateControl(BranchIdColumnName) as ASPxComboBox;
            CanShowBranchCls model = new CanShowBranchCls();
            var can_show_branchs = Session[CanShowBranchColumnName] as List<CanShowBranchCls>;
            if (can_show_branchs == null) can_show_branchs = new List<CanShowBranchCls>();
            model.id = can_show_branchs.Count + 1;
            model.branch_id = ConvertHelper.ObjectToString(branch_id.Value);
            model.name = branch_id.Text;
            can_show_branchs.Add(model);
            Session[CanShowBranchColumnName] = can_show_branchs;
            e.Cancel = true;
            grid.CancelEdit();
            BindCanShowBranch(grid);
        }

        protected void gridShowBranch_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var branch_id = grid.FindEditFormTemplateControl(BranchIdColumnName) as ASPxComboBox;
            CanShowBranchCls model = new CanShowBranchCls();
            var can_show_branchs = Session[CanShowBranchColumnName] as List<CanShowBranchCls>;
            can_show_branchs.ForEach((p) =>
            {
                if (p.id == (int)e.Keys["id"])
                {
                    p.branch_id = ConvertHelper.ObjectToString(branch_id.Value);
                    p.name = branch_id.Text;
                }
            });
            e.Cancel = true;
            grid.CancelEdit();
            BindCanShowBranch(grid);
        }

       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridShowBranch_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var deleteId = grid.GetSelectedFieldValues(grid.KeyFieldName).Select(p => int.Parse(p.ToString()));
            var can_show_branch_cls = Session[CanShowBranchColumnName] as List<CanShowBranchCls>;
            if (can_show_branch_cls==null) return;
            can_show_branch_cls.RemoveAll((c) => { return deleteId.Contains(c.id); });
            e.Cancel = true;
            grid.CancelEdit();
            BindCanShowBranch(grid);
        }
        protected void gridShowBranch_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var branch_id = grid.FindEditFormTemplateControl(BranchIdColumnName) as ASPxComboBox;
            if (grid.IsNewRowEditing)
            {
                DataBindDropDownList.DataBindBranch(branch_id);
            }
            else
            {
                List<object> userObjects = grid.GetSelectedFieldValues(new string[] { 
                   BranchIdColumnName
                });
                //object[] row = (object[])userObjects[0];//这是得到第一行记录的值，如果是多行选择，可以循环取出。   
                DataBindDropDownList.DataBindBranch(branch_id, ConvertHelper.ObjectToString(userObjects.FirstOrDefault()));
            }
        }

        private void BindCanShowBranch(ASPxGridView grid)
        {
            if (null == Session[CanShowBranchColumnName]) return;
            grid.DataSource = Session[CanShowBranchColumnName] as List<CanShowBranchCls>;
            grid.DataBind();
        }
        public class CanShowBranchCls
        {
            public int id { get; set; }
            public string branch_id { get; set; }
            public string name { get; set; }
        }
        #endregion
    }
}