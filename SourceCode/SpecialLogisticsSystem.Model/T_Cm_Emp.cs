using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    //员工基本信息录入表
    [DisplayName("员工基本信息")]
    public class T_Cm_Emp : Entity
    {
        public T_Cm_Emp()
        {
            this.add_date = DateTime.Now;
            this.update_date = DateTime.Now;
        }

        public static string PropertyId { get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Emp>(p => p.id); } }
        public static string EmpNameColumnName { get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Emp>(p => p.emp_name); } }
        public static string BranchIDColumnName { get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Emp>(p => p.branch_id); } }
        private Guid _id;
        /// <summary>
        /// 员工编号
        /// </summary>	
        [PrimaryKey(true)]
        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Guid _branch_id;
        /// <summary>
        /// 关联分支机构
        /// </summary>	
        public Guid branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }
        private string _emp_name;
        /// <summary>
        /// 员工名称
        /// </summary>	
        public string emp_name
        {
            get { return _emp_name; }
            set { _emp_name = value; }
        }
        private string _emp_no;
        /// <summary>
        /// 员工编号
        /// </summary>	
        public string emp_no
        {
            get { return _emp_no; }
            set { _emp_no = value; }
        }
        private int _sex_ind;
        /// <summary>
        /// 性别
        /// </summary>	
        public int sex_ind
        {
            get { return _sex_ind; }
            set { _sex_ind = value; }
        }
        private string _job;
        /// <summary>
        /// 职务
        /// </summary>	
        public string job
        {
            get { return _job; }
            set { _job = value; }
        }
        private decimal _basic_wages;
        /// <summary>
        /// 基本工资
        /// </summary>	
        public decimal basic_wages
        {
            get { return _basic_wages; }
            set { _basic_wages = value; }
        }
        private decimal _supp_wages;
        /// <summary>
        /// 岗位补贴
        /// </summary>	
        public decimal supp_wages
        {
            get { return _supp_wages; }
            set { _supp_wages = value; }
        }
        private string _status;
        /// <summary>
        /// 试用期、正式员工、离职员工
        /// </summary>	
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        private DateTime? _birthday;
        /// <summary>
        /// 出生年月
        /// </summary>	
        public DateTime? birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        private string _native;
        /// <summary>
        /// 籍贯
        /// </summary>	
        public string native
        {
            get { return _native; }
            set { _native = value; }
        }
        private string _nationality;
        /// <summary>
        /// 民族
        /// </summary>	
        public string nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
        private string _cert_no;
        /// <summary>
        /// 证件号码
        /// </summary>	
        public string cert_no
        {
            get { return _cert_no; }
            set { _cert_no = value; }
        }
        private string _degree;
        /// <summary>
        /// 学历
        /// </summary>	
        public string degree
        {
            get { return _degree; }
            set { _degree = value; }
        }
        private string _graduated;
        /// <summary>
        /// 毕业院校
        /// </summary>	
        public string graduated
        {
            get { return _graduated; }
            set { _graduated = value; }
        }
        private string _open_bank;
        /// <summary>
        /// 开户银行
        /// </summary>	
        public string open_bank
        {
            get { return _open_bank; }
            set { _open_bank = value; }
        }
        private string _acct_no;
        /// <summary>
        /// 工资帐号
        /// </summary>	
        public string acct_no
        {
            get { return _acct_no; }
            set { _acct_no = value; }
        }
        private string _telphone;
        /// <summary>
        /// 联系电话
        /// </summary>	
        public string telphone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }
        private string _home_addr;
        /// <summary>
        /// 家庭住址
        /// </summary>	
        public string home_addr
        {
            get { return _home_addr; }
            set { _home_addr = value; }
        }
        private string _qq;
        /// <summary>
        /// QQ
        /// </summary>	
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }
        private string _email;
        /// <summary>
        /// Email
        /// </summary>	
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _dept;
        /// <summary>
        /// 部门
        /// </summary>	
        public string dept
        {
            get { return _dept; }
            set { _dept = value; }
        }
        private string _emp_type_cd;
        /// <summary>
        /// 采购员、店长、销售经理、施工员
        /// </summary>	
        public string emp_type_cd
        {
            get { return _emp_type_cd; }
            set { _emp_type_cd = value; }
        }
        private string _work_history;
        /// <summary>
        /// 工作经历
        /// </summary>	
        public string work_history
        {
            get { return _work_history; }
            set { _work_history = value; }
        }
        private string _remark;
        /// <summary>
        /// 备注
        /// </summary>	
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private DateTime _add_date;
        /// <summary>
        /// 记录时间
        /// </summary>	
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; }
        }
        private string _update_opr;
        /// <summary>
        /// 更新人
        /// </summary>	
        public string update_opr
        {
            get { return _update_opr; }
            set { _update_opr = value; }
        }
        private DateTime _update_date;
        /// <summary>
        /// 更新日期\还可以作为离职日期使用
        /// </summary>	
        public DateTime update_date
        {
            get { return _update_date; }
            set { _update_date = value; }
        }
        private string _acct_name;
        /// <summary>
        /// acct_name
        /// </summary>	
        public string acct_name
        {
            get { return _acct_name; }
            set { _acct_name = value; }
        }
        private string _mobilephone;
        /// <summary>
        /// 手机
        /// </summary>	
        public string mobilephone
        {
            get { return _mobilephone; }
            set { _mobilephone = value; }
        }
        private bool _is_active;
        /// <summary>
        /// is_active
        /// </summary>	
        public bool is_active
        {
            get { return _is_active; }
            set { _is_active = value; }
        }       
    }
}

