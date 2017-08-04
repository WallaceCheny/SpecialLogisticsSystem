using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Model
{
    public enum UserState
    {
        [Description("启用")]
        Enable = 0,
        [Description("禁用")]
        Forbidden = 1,
    }
    public enum Sex
    {
        [Description("男")]
        Male = 0,
        [Description("女")]
        Female = 1,
    }
    public enum BranchType
    {
        [Description("分支机构")]
        Branch = 1,
        [Description("服务商")]
        Servicer = 2,

    }

    /// <summary>
    /// 编码类别
    /// </summary>
    public enum CodeType
    {
        [Description("网点类型")]
        site_type,
        [Description("任职状态")]
        office_statue,
        [Description("用户状态")]
        user_status,
        [Description("性别")]
        sex,
        [Description("代收类型")]
        agency_type,
        [Description("运输方式")]
        carriage_type,
        [Description("客户信誉等级")]
        customer_credit,
        [Description("客户类型")]
        customer_type,
        [Description("交货方式")]
        delivery_type,
        [Description("交接方式")]
        connect_type,
        [Description("运单结算方式")]
        settle_type,
        [Description("订单类型"), Category("Hidden")]
        way_type,
        [Description("包装方式")]
        wrap_type,
        [Description("计费方式")]
        price_type,
        [Description("日期类型")]
        date_type,
        [Description("车辆类型")]
        car_type,
        [Description("车辆性质")]
        car_nature,
        [Description("财务结算方式")]
        finance_settle_type,
        [Description("财务科目")]
        finance_category,
    }

    /// <summary>
    /// 需要编号的表
    /// </summary>
    public enum CodeTable
    {
        [Description("员工编号")]
        Emp,
        [Description("运单号")]
        Way,
        [Description("公司网点编号")]
        Branch,
        [Description("发车单号")]
        Stowage,
        [Description("中转单号")]
        Transfer,
        [Description("服务商单号")]
        Servicer,
        [Description("送货单号")]
        Deliver,
        [Description("单据编号")]
        Finance,
    }

    /// <summary>
    /// 客户类型
    /// </summary>
    public enum CustomerType
    {
        /// <summary>
        /// 收货人
        /// </summary>
        [Description("收货人")]
        Consignee,
        /// <summary>
        /// 发货人
        /// </summary>
        [Description("发货人")]
        Deliver,
    }
    /// <summary>
    /// 订单类型
    /// </summary>
    public enum WayType
    {
        [Description("专线单")]
        Special,
        [Description("中线单")]
        Transfer,
    }
    /// <summary>
    /// 根据不同页面设置不同的菜单
    /// </summary>
    public enum PageType
    {
        [Description("字典管理")]
        Code,
        [Description("运单管理")]
        Way,
        [Description("配载发车")]
        Stowage,
        [Description("中转外包")]
        Transfer,
        [Description("用户管理")]
        User,
        [Description("编号管理")]
        Number,
        [Description("导入")]
        Export,
        [Description("系统配置")]
        Config,
        [Description("到货管理")]
        Arrival,
        [Description("送货管理")]
        Deliver,
        [Description("选择菜单")]
        SelectedMenu,
        [Description("客户结算")]
        CustomerPay,
        [Description("回扣发放")]
        DiscountPay,
        [Description("司机结算")]
        DriverPay,
        [Description("服务商结算")]
        TransferPay,
        [Description("帮助菜单")]
        Help,
    }
    /// <summary>
    /// 根据不同功能设置不同的菜单
    /// </summary>
    public enum FunctionType
    {
        [Description("显示帮助")]
        ShowHelp,
        [Description("子菜单")]
        SubMenu,
        [Description("弹出菜单")]
        PopupMenu,
        [Description("树菜单")]
        TreeMenu,
        [Description("选择菜单")]
        SelectedMenu,
        [Description("帮助菜单")]
        HelpMenu,
        [Description("短信菜单")]
        SmsMenu,
        [Description("运单菜单")]
        WayMenu,
        [Description("配载菜单")]
        StowageMenu,
    }
    /// <summary>
    /// 系统参数设置
    /// </summary>
    public enum ConfigType
    {
        [Description("主题")]
        Theme,
        [Description("始发站")]
        StartCity,
        [Description("目的站")]
        EndCity,
        [Description("接货费免费")]
        IsFreeGet,
        [Description("送货费免费")]
        IsFreeSet,
        [Description("其他费免费")]
        OtherIsFree,
        [Description("查询类型")]
        SearchType,
        [Description("短信帐号")]
        SmsAccountName,
        [Description("短信密码")]
        SmsAccountPassword,
        [Description("短信签名")]
        SmsSigned,
    }
    /// <summary>
    /// 查询类型
    /// </summary>
    public enum SearchType
    {
        [Description("按天查询")]
        ByDate,
        [Description("按周查询")]
        ByWeek,
        [Description("按月查询")]
        ByMonth,
        [Description("按季度查询")]
        BySeason,
        [Description("按年查询")]
        ByYear
    }
    /// <summary>
    /// 图表查询类型
    /// </summary>
    public enum ChartSearchType
    {
        [Description("按天查询")]
        ByDate,
        [Description("按月查询")]
        ByMonth,
        [Description("按年查询")]
        ByYear
    }
    /// <summary>
    /// 导入类型
    /// </summary>
    public enum ImportType
    {
        [Description("客户资料")]
        Customer,
        [Description("托运单")]
        Way,
        [Description("发车单")]
        Stowage,
    }

    /// <summary>
    /// 运单状态
    /// </summary>
    public enum WayStatue
    {
        [Description("新建")]
        New,
        [Description("入库")]
        Storage,
        [Description("未发车")]
        UnSend,
        [Description("已发车")]
        Sended,
        [Description("中转处理")]
        Transfer,
        [Description("已到达")]
        Arrival,
        [Description("派件出库")]
        Outbound,
        [Description("已签收")]
        Received,
        [Description("回单")]
        Receipt,
    }
    /// <summary>
    /// 发车状态
    /// </summary>
    public enum StowageStatue
    {
        [Description("未发车")]
        UnSend,
        [Description("已发车")]
        Sended,
        [Description("已到车")]
        Arrival,
    }
    /// <summary>
    /// 客户结算类型
    /// </summary>
    public enum CustomerSettleType
    {
        [Description("发货方结算")]
        Deliver,
        [Description("收货方结算")]
        Consignee,
    }
    /// <summary>
    /// 司机结算类型
    /// </summary>
    public enum StowageSettleType
    {
        [Description("预付")]
        PrePay,
        [Description("到付")]
        ArrivalPay,
        [Description("回付")]
        BackPay,
    }
    /// <summary>
    /// 打印页面
    /// </summary>
    public enum PrintType
    {
        [Description("托运单")]
        Way,
        [Description("发车单")]
        Stowage,
    }
    /// <summary>
    /// 帮助类型
    /// </summary>
    public enum HelpeType
    {
        [Description("新手上路")]
        New,
        [Description("常见问题")]
        Question,
    }
}
