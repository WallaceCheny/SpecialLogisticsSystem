using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal
{
    public partial class Default : BasePage<Default>
    {
        public string Menus { get; set; }
        [Dependency]
        public ICmMenuDal _menu { get; set; }
        [Dependency]
        public ICmEmpDal _emp { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryInfo<T_Cm_Menu> queryInfo = new QueryInfo<T_Cm_Menu>();
                if (!UserProvide.GetCurrentUser().is_admin)
                {
                    queryInfo.SetQuery("user_id", UserProvide.GetCurrentUserId());
                }
                else
                {
                    queryInfo.SetXml("SelectByAdmin");
                }
                IList<dynamic> ListMenu = _menu.Select(queryInfo);
                Menus = JsonConvert.SerializeObject(LoadUserApplications(null, ListMenu), Formatting.None, new JsonSerializerSettings());
                if (!string.IsNullOrEmpty(UserProvide.GetCurrentUserId()))
                {
                    T_Cm_User user = UserProvide.GetCurrentUser();
                    this.lblUserName.Text = user.user_name;
                    T_Cm_Emp emp= _emp.GetSingle(user.emp_Info_Id);
                    if (null != emp) this.lblEmpName.Text = emp.emp_name;
                }
            }
        }

        protected List<TreeEntity> LoadUserApplications(Guid? parentID, IList<dynamic> apps)
        {
            ConnectionStringSettings conn = ConfigurationManager.ConnectionStrings["ConnectionString"];
            bool isAccess = conn.ProviderName == "System.Data.OleDb";
            List<TreeEntity> tree = new List<TreeEntity>();
            var list = apps.Where(p => p.parent_id == parentID);
            foreach (var item in list)
            {
                var treeEntity = new TreeEntity();
                treeEntity.attributes = new Dictionary<string, object>();
                if (item.id == null) continue;
                treeEntity.id = item.id.ToString();
                treeEntity.text = item.name;
                treeEntity.tip = item.tip;
                treeEntity.iconCls = item.icon;
                if (isAccess)
                {
                    treeEntity.attributes.Add("loadType", item.is_main == -1 ? "part" : "report");
                }
                else
                {
                    treeEntity.attributes.Add("loadType", item.is_main ? "part" : "report");
                }
                treeEntity.attributes.Add("url", item.action);
                treeEntity.children = LoadUserApplications(item.id, apps);
                tree.Add(treeEntity);
            }
            return tree;
        }
    }
}