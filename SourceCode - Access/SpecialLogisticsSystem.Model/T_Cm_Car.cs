using System;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Model
{

       [DisplayName("车辆信息")]
    public class T_Cm_Car : Entity
    {
        //#region 计算列
        ///// <summary>
        ///// 车辆类型-名称
        ///// </summary>
        //[NoColumn]
        //public string car_type_name
        //{
        //    get
        //    {
        //        return CodeName.Instance.iCodeName.GetCodeName(CodeType.car_type, car_type);
        //    }
        //}
        ///// <summary>
        ///// 车辆性质-名称
        ///// </summary>
        //[NoColumn]
        //public string car_nature_name
        //{
        //    get
        //    {
        //        return CodeName.Instance.iCodeName.GetCodeName(CodeType.car_nature, car_nature);
        //    }
        //}
        //#endregion

        #region "字段名称"
        /// <summary>
        /// 车牌号
        /// </summary>
        public static string CarNoColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Car>(p => p.car_no);
            }
        }
        #endregion
        private Guid _id;
        /// <summary>
        /// id
        /// </summary>
        [PrimaryKey(true)]
        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _car_area_id;
        /// <summary>
        /// 关联车牌类型
        /// </summary>	
        public int car_area_id
        {
            get { return _car_area_id; }
            set { _car_area_id = value; }
        }
        private string _car_no;
        /// <summary>
        /// 车牌号
        /// </summary>	
        public string car_no
        {
            get { return _car_no; }
            set { _car_no = value; }
        }
        private string _insurance_number;
        /// <summary>
        /// 保险单号
        /// </summary>	
        public string insurance_number
        {
            get { return _insurance_number; }
            set { _insurance_number = value; }
        }
        private string _car_produce_no;
        /// <summary>
        /// 厂牌型号
        /// </summary>	
        public string car_produce_no
        {
            get { return _car_produce_no; }
            set { _car_produce_no = value; }
        }
        private string _car_type;
        /// <summary>
        /// 车辆类型
        /// </summary>	
        public string car_type
        {
            get { return _car_type; }
            set { _car_type = value; }
        }
        private string _car_nature;
        /// <summary>
        /// 车辆性质
        /// </summary>	
        public string car_nature
        {
            get { return _car_nature; }
            set { _car_nature = value; }
        }
        private string _car_engine_number;
        /// <summary>
        /// 发动机号
        /// </summary>	
        public string car_engine_number
        {
            get { return _car_engine_number; }
            set { _car_engine_number = value; }
        }
        private string _car_drive_no;
        /// <summary>
        /// 行驶证号
        /// </summary>	
        public string car_drive_no
        {
            get { return _car_drive_no; }
            set { _car_drive_no = value; }
        }
        private string _car_owner;
        /// <summary>
        /// 车主
        /// </summary>	
        public string car_owner
        {
            get { return _car_owner; }
            set { _car_owner = value; }
        }
        private Guid _car_link;
        /// <summary>
        /// 关联司机
        /// </summary>	
        public Guid car_link
        {
            get { return _car_link; }
            set { _car_link = value; }
        }
        private T_Cm_Link _link;
        /// <summary>
        /// 关联联系人及地址
        /// </summary>
        [NoColumn]
        public T_Cm_Link link
        {
            get { return _link; }
            set
            {
                _link = value;
                car_link = _link.id;
                car_memo = _link.link_memo;
            }
        }
        private string _car_memo;
        /// <summary>
        /// 备注
        /// </summary>	
        public string car_memo
        {
            get { return _car_memo; }
            set { _car_memo = value; }
        }
        private Guid _branch_id;
        /// <summary>
        /// 所属部门
        /// </summary>	
        public Guid branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }
    }
}

