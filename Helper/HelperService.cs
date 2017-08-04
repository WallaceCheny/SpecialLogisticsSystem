
namespace MyNamespace.Data
{
	/// <summary>
	/// Singleton "controller" for Helper classes.
	/// </summary>
	public class Helpers
	{

		#region Helper Service for TArrivalDeliverHelper
		private static volatile TArrivalDeliverHelper _TArrivalDeliverHelper = null;
		public static TArrivalDeliverHelper TArrivalDeliver ()
		{
			if (_TArrivalDeliverHelper == null)
			{
				lock (typeof (TArrivalDeliverHelper))
				{
					if (_TArrivalDeliverHelper == null) // double-check
						_TArrivalDeliverHelper = new TArrivalDeliverHelper ();
				}
			}
			return _TArrivalDeliverHelper;
		}
		#endregion
		

		#region Helper Service for TArrivalDeliverGoodHelper
		private static volatile TArrivalDeliverGoodHelper _TArrivalDeliverGoodHelper = null;
		public static TArrivalDeliverGoodHelper TArrivalDeliverGood ()
		{
			if (_TArrivalDeliverGoodHelper == null)
			{
				lock (typeof (TArrivalDeliverGoodHelper))
				{
					if (_TArrivalDeliverGoodHelper == null) // double-check
						_TArrivalDeliverGoodHelper = new TArrivalDeliverGoodHelper ();
				}
			}
			return _TArrivalDeliverGoodHelper;
		}
		#endregion
		

		#region Helper Service for TArrivalSignHelper
		private static volatile TArrivalSignHelper _TArrivalSignHelper = null;
		public static TArrivalSignHelper TArrivalSign ()
		{
			if (_TArrivalSignHelper == null)
			{
				lock (typeof (TArrivalSignHelper))
				{
					if (_TArrivalSignHelper == null) // double-check
						_TArrivalSignHelper = new TArrivalSignHelper ();
				}
			}
			return _TArrivalSignHelper;
		}
		#endregion
		

		#region Helper Service for TCmBranchHelper
		private static volatile TCmBranchHelper _TCmBranchHelper = null;
		public static TCmBranchHelper TCmBranch ()
		{
			if (_TCmBranchHelper == null)
			{
				lock (typeof (TCmBranchHelper))
				{
					if (_TCmBranchHelper == null) // double-check
						_TCmBranchHelper = new TCmBranchHelper ();
				}
			}
			return _TCmBranchHelper;
		}
		#endregion
		

		#region Helper Service for TCmCarHelper
		private static volatile TCmCarHelper _TCmCarHelper = null;
		public static TCmCarHelper TCmCar ()
		{
			if (_TCmCarHelper == null)
			{
				lock (typeof (TCmCarHelper))
				{
					if (_TCmCarHelper == null) // double-check
						_TCmCarHelper = new TCmCarHelper ();
				}
			}
			return _TCmCarHelper;
		}
		#endregion
		

		#region Helper Service for TCmCarAreaHelper
		private static volatile TCmCarAreaHelper _TCmCarAreaHelper = null;
		public static TCmCarAreaHelper TCmCarArea ()
		{
			if (_TCmCarAreaHelper == null)
			{
				lock (typeof (TCmCarAreaHelper))
				{
					if (_TCmCarAreaHelper == null) // double-check
						_TCmCarAreaHelper = new TCmCarAreaHelper ();
				}
			}
			return _TCmCarAreaHelper;
		}
		#endregion
		

		#region Helper Service for TCmCityHelper
		private static volatile TCmCityHelper _TCmCityHelper = null;
		public static TCmCityHelper TCmCity ()
		{
			if (_TCmCityHelper == null)
			{
				lock (typeof (TCmCityHelper))
				{
					if (_TCmCityHelper == null) // double-check
						_TCmCityHelper = new TCmCityHelper ();
				}
			}
			return _TCmCityHelper;
		}
		#endregion
		

		#region Helper Service for TCmCodeHelper
		private static volatile TCmCodeHelper _TCmCodeHelper = null;
		public static TCmCodeHelper TCmCode ()
		{
			if (_TCmCodeHelper == null)
			{
				lock (typeof (TCmCodeHelper))
				{
					if (_TCmCodeHelper == null) // double-check
						_TCmCodeHelper = new TCmCodeHelper ();
				}
			}
			return _TCmCodeHelper;
		}
		#endregion
		

		#region Helper Service for TCmConfigHelper
		private static volatile TCmConfigHelper _TCmConfigHelper = null;
		public static TCmConfigHelper TCmConfig ()
		{
			if (_TCmConfigHelper == null)
			{
				lock (typeof (TCmConfigHelper))
				{
					if (_TCmConfigHelper == null) // double-check
						_TCmConfigHelper = new TCmConfigHelper ();
				}
			}
			return _TCmConfigHelper;
		}
		#endregion
		

		#region Helper Service for TCmCustomerHelper
		private static volatile TCmCustomerHelper _TCmCustomerHelper = null;
		public static TCmCustomerHelper TCmCustomer ()
		{
			if (_TCmCustomerHelper == null)
			{
				lock (typeof (TCmCustomerHelper))
				{
					if (_TCmCustomerHelper == null) // double-check
						_TCmCustomerHelper = new TCmCustomerHelper ();
				}
			}
			return _TCmCustomerHelper;
		}
		#endregion
		

		#region Helper Service for TCmDistrictHelper
		private static volatile TCmDistrictHelper _TCmDistrictHelper = null;
		public static TCmDistrictHelper TCmDistrict ()
		{
			if (_TCmDistrictHelper == null)
			{
				lock (typeof (TCmDistrictHelper))
				{
					if (_TCmDistrictHelper == null) // double-check
						_TCmDistrictHelper = new TCmDistrictHelper ();
				}
			}
			return _TCmDistrictHelper;
		}
		#endregion
		

		#region Helper Service for TCmEmpHelper
		private static volatile TCmEmpHelper _TCmEmpHelper = null;
		public static TCmEmpHelper TCmEmp ()
		{
			if (_TCmEmpHelper == null)
			{
				lock (typeof (TCmEmpHelper))
				{
					if (_TCmEmpHelper == null) // double-check
						_TCmEmpHelper = new TCmEmpHelper ();
				}
			}
			return _TCmEmpHelper;
		}
		#endregion
		

		#region Helper Service for TCmFeeTypeHelper
		private static volatile TCmFeeTypeHelper _TCmFeeTypeHelper = null;
		public static TCmFeeTypeHelper TCmFeeType ()
		{
			if (_TCmFeeTypeHelper == null)
			{
				lock (typeof (TCmFeeTypeHelper))
				{
					if (_TCmFeeTypeHelper == null) // double-check
						_TCmFeeTypeHelper = new TCmFeeTypeHelper ();
				}
			}
			return _TCmFeeTypeHelper;
		}
		#endregion
		

		#region Helper Service for TCmLinkHelper
		private static volatile TCmLinkHelper _TCmLinkHelper = null;
		public static TCmLinkHelper TCmLink ()
		{
			if (_TCmLinkHelper == null)
			{
				lock (typeof (TCmLinkHelper))
				{
					if (_TCmLinkHelper == null) // double-check
						_TCmLinkHelper = new TCmLinkHelper ();
				}
			}
			return _TCmLinkHelper;
		}
		#endregion
		

		#region Helper Service for TCmMenuHelper
		private static volatile TCmMenuHelper _TCmMenuHelper = null;
		public static TCmMenuHelper TCmMenu ()
		{
			if (_TCmMenuHelper == null)
			{
				lock (typeof (TCmMenuHelper))
				{
					if (_TCmMenuHelper == null) // double-check
						_TCmMenuHelper = new TCmMenuHelper ();
				}
			}
			return _TCmMenuHelper;
		}
		#endregion
		

		#region Helper Service for TCmProvinceHelper
		private static volatile TCmProvinceHelper _TCmProvinceHelper = null;
		public static TCmProvinceHelper TCmProvince ()
		{
			if (_TCmProvinceHelper == null)
			{
				lock (typeof (TCmProvinceHelper))
				{
					if (_TCmProvinceHelper == null) // double-check
						_TCmProvinceHelper = new TCmProvinceHelper ();
				}
			}
			return _TCmProvinceHelper;
		}
		#endregion
		

		#region Helper Service for TCmRoleHelper
		private static volatile TCmRoleHelper _TCmRoleHelper = null;
		public static TCmRoleHelper TCmRole ()
		{
			if (_TCmRoleHelper == null)
			{
				lock (typeof (TCmRoleHelper))
				{
					if (_TCmRoleHelper == null) // double-check
						_TCmRoleHelper = new TCmRoleHelper ();
				}
			}
			return _TCmRoleHelper;
		}
		#endregion
		

		#region Helper Service for TCmRoleMenuRelationHelper
		private static volatile TCmRoleMenuRelationHelper _TCmRoleMenuRelationHelper = null;
		public static TCmRoleMenuRelationHelper TCmRoleMenuRelation ()
		{
			if (_TCmRoleMenuRelationHelper == null)
			{
				lock (typeof (TCmRoleMenuRelationHelper))
				{
					if (_TCmRoleMenuRelationHelper == null) // double-check
						_TCmRoleMenuRelationHelper = new TCmRoleMenuRelationHelper ();
				}
			}
			return _TCmRoleMenuRelationHelper;
		}
		#endregion
		

		#region Helper Service for TCmTemplateHelper
		private static volatile TCmTemplateHelper _TCmTemplateHelper = null;
		public static TCmTemplateHelper TCmTemplate ()
		{
			if (_TCmTemplateHelper == null)
			{
				lock (typeof (TCmTemplateHelper))
				{
					if (_TCmTemplateHelper == null) // double-check
						_TCmTemplateHelper = new TCmTemplateHelper ();
				}
			}
			return _TCmTemplateHelper;
		}
		#endregion
		

		#region Helper Service for TCmUserHelper
		private static volatile TCmUserHelper _TCmUserHelper = null;
		public static TCmUserHelper TCmUser ()
		{
			if (_TCmUserHelper == null)
			{
				lock (typeof (TCmUserHelper))
				{
					if (_TCmUserHelper == null) // double-check
						_TCmUserHelper = new TCmUserHelper ();
				}
			}
			return _TCmUserHelper;
		}
		#endregion
		

		#region Helper Service for TCmUserBranchRelationHelper
		private static volatile TCmUserBranchRelationHelper _TCmUserBranchRelationHelper = null;
		public static TCmUserBranchRelationHelper TCmUserBranchRelation ()
		{
			if (_TCmUserBranchRelationHelper == null)
			{
				lock (typeof (TCmUserBranchRelationHelper))
				{
					if (_TCmUserBranchRelationHelper == null) // double-check
						_TCmUserBranchRelationHelper = new TCmUserBranchRelationHelper ();
				}
			}
			return _TCmUserBranchRelationHelper;
		}
		#endregion
		

		#region Helper Service for TCmUserRoleRelationHelper
		private static volatile TCmUserRoleRelationHelper _TCmUserRoleRelationHelper = null;
		public static TCmUserRoleRelationHelper TCmUserRoleRelation ()
		{
			if (_TCmUserRoleRelationHelper == null)
			{
				lock (typeof (TCmUserRoleRelationHelper))
				{
					if (_TCmUserRoleRelationHelper == null) // double-check
						_TCmUserRoleRelationHelper = new TCmUserRoleRelationHelper ();
				}
			}
			return _TCmUserRoleRelationHelper;
		}
		#endregion
		

		#region Helper Service for TFinanceCustomerHelper
		private static volatile TFinanceCustomerHelper _TFinanceCustomerHelper = null;
		public static TFinanceCustomerHelper TFinanceCustomer ()
		{
			if (_TFinanceCustomerHelper == null)
			{
				lock (typeof (TFinanceCustomerHelper))
				{
					if (_TFinanceCustomerHelper == null) // double-check
						_TFinanceCustomerHelper = new TFinanceCustomerHelper ();
				}
			}
			return _TFinanceCustomerHelper;
		}
		#endregion
		

		#region Helper Service for TFinanceDailyHelper
		private static volatile TFinanceDailyHelper _TFinanceDailyHelper = null;
		public static TFinanceDailyHelper TFinanceDaily ()
		{
			if (_TFinanceDailyHelper == null)
			{
				lock (typeof (TFinanceDailyHelper))
				{
					if (_TFinanceDailyHelper == null) // double-check
						_TFinanceDailyHelper = new TFinanceDailyHelper ();
				}
			}
			return _TFinanceDailyHelper;
		}
		#endregion
		

		#region Helper Service for TFinanceDriverHelper
		private static volatile TFinanceDriverHelper _TFinanceDriverHelper = null;
		public static TFinanceDriverHelper TFinanceDriver ()
		{
			if (_TFinanceDriverHelper == null)
			{
				lock (typeof (TFinanceDriverHelper))
				{
					if (_TFinanceDriverHelper == null) // double-check
						_TFinanceDriverHelper = new TFinanceDriverHelper ();
				}
			}
			return _TFinanceDriverHelper;
		}
		#endregion
		

		#region Helper Service for TFinanceGoodHelper
		private static volatile TFinanceGoodHelper _TFinanceGoodHelper = null;
		public static TFinanceGoodHelper TFinanceGood ()
		{
			if (_TFinanceGoodHelper == null)
			{
				lock (typeof (TFinanceGoodHelper))
				{
					if (_TFinanceGoodHelper == null) // double-check
						_TFinanceGoodHelper = new TFinanceGoodHelper ();
				}
			}
			return _TFinanceGoodHelper;
		}
		#endregion
		

		#region Helper Service for TFinanceServiceHelper
		private static volatile TFinanceServiceHelper _TFinanceServiceHelper = null;
		public static TFinanceServiceHelper TFinanceService ()
		{
			if (_TFinanceServiceHelper == null)
			{
				lock (typeof (TFinanceServiceHelper))
				{
					if (_TFinanceServiceHelper == null) // double-check
						_TFinanceServiceHelper = new TFinanceServiceHelper ();
				}
			}
			return _TFinanceServiceHelper;
		}
		#endregion
		

		#region Helper Service for TStowageDetailHelper
		private static volatile TStowageDetailHelper _TStowageDetailHelper = null;
		public static TStowageDetailHelper TStowageDetail ()
		{
			if (_TStowageDetailHelper == null)
			{
				lock (typeof (TStowageDetailHelper))
				{
					if (_TStowageDetailHelper == null) // double-check
						_TStowageDetailHelper = new TStowageDetailHelper ();
				}
			}
			return _TStowageDetailHelper;
		}
		#endregion
		

		#region Helper Service for TStowageMainHelper
		private static volatile TStowageMainHelper _TStowageMainHelper = null;
		public static TStowageMainHelper TStowageMain ()
		{
			if (_TStowageMainHelper == null)
			{
				lock (typeof (TStowageMainHelper))
				{
					if (_TStowageMainHelper == null) // double-check
						_TStowageMainHelper = new TStowageMainHelper ();
				}
			}
			return _TStowageMainHelper;
		}
		#endregion
		

		#region Helper Service for TStowageSiteHelper
		private static volatile TStowageSiteHelper _TStowageSiteHelper = null;
		public static TStowageSiteHelper TStowageSite ()
		{
			if (_TStowageSiteHelper == null)
			{
				lock (typeof (TStowageSiteHelper))
				{
					if (_TStowageSiteHelper == null) // double-check
						_TStowageSiteHelper = new TStowageSiteHelper ();
				}
			}
			return _TStowageSiteHelper;
		}
		#endregion
		

		#region Helper Service for TTransferDetailHelper
		private static volatile TTransferDetailHelper _TTransferDetailHelper = null;
		public static TTransferDetailHelper TTransferDetail ()
		{
			if (_TTransferDetailHelper == null)
			{
				lock (typeof (TTransferDetailHelper))
				{
					if (_TTransferDetailHelper == null) // double-check
						_TTransferDetailHelper = new TTransferDetailHelper ();
				}
			}
			return _TTransferDetailHelper;
		}
		#endregion
		

		#region Helper Service for TTransferMainHelper
		private static volatile TTransferMainHelper _TTransferMainHelper = null;
		public static TTransferMainHelper TTransferMain ()
		{
			if (_TTransferMainHelper == null)
			{
				lock (typeof (TTransferMainHelper))
				{
					if (_TTransferMainHelper == null) // double-check
						_TTransferMainHelper = new TTransferMainHelper ();
				}
			}
			return _TTransferMainHelper;
		}
		#endregion
		

		#region Helper Service for TWayBillHelper
		private static volatile TWayBillHelper _TWayBillHelper = null;
		public static TWayBillHelper TWayBill ()
		{
			if (_TWayBillHelper == null)
			{
				lock (typeof (TWayBillHelper))
				{
					if (_TWayBillHelper == null) // double-check
						_TWayBillHelper = new TWayBillHelper ();
				}
			}
			return _TWayBillHelper;
		}
		#endregion
		

		#region Helper Service for TWayProductionHelper
		private static volatile TWayProductionHelper _TWayProductionHelper = null;
		public static TWayProductionHelper TWayProduction ()
		{
			if (_TWayProductionHelper == null)
			{
				lock (typeof (TWayProductionHelper))
				{
					if (_TWayProductionHelper == null) // double-check
						_TWayProductionHelper = new TWayProductionHelper ();
				}
			}
			return _TWayProductionHelper;
		}
		#endregion
		

		#region Helper Service for TWaySmHelper
		private static volatile TWaySmHelper _TWaySmHelper = null;
		public static TWaySmHelper TWaySm ()
		{
			if (_TWaySmHelper == null)
			{
				lock (typeof (TWaySmHelper))
				{
					if (_TWaySmHelper == null) // double-check
						_TWaySmHelper = new TWaySmHelper ();
				}
			}
			return _TWaySmHelper;
		}
		#endregion
		

		#region Helper Service for TWayTrackHelper
		private static volatile TWayTrackHelper _TWayTrackHelper = null;
		public static TWayTrackHelper TWayTrack ()
		{
			if (_TWayTrackHelper == null)
			{
				lock (typeof (TWayTrackHelper))
				{
					if (_TWayTrackHelper == null) // double-check
						_TWayTrackHelper = new TWayTrackHelper ();
				}
			}
			return _TWayTrackHelper;
		}
		#endregion
		
/* for sqlmap.config

		<sqlMaps>
		<sqlMap resource="${root}resources/TArrivalDeliverHelper.xml" />
		<sqlMap resource="${root}resources/TArrivalDeliverGoodHelper.xml" />
		<sqlMap resource="${root}resources/TArrivalSignHelper.xml" />
		<sqlMap resource="${root}resources/TCmBranchHelper.xml" />
		<sqlMap resource="${root}resources/TCmCarHelper.xml" />
		<sqlMap resource="${root}resources/TCmCarAreaHelper.xml" />
		<sqlMap resource="${root}resources/TCmCityHelper.xml" />
		<sqlMap resource="${root}resources/TCmCodeHelper.xml" />
		<sqlMap resource="${root}resources/TCmConfigHelper.xml" />
		<sqlMap resource="${root}resources/TCmCustomerHelper.xml" />
		<sqlMap resource="${root}resources/TCmDistrictHelper.xml" />
		<sqlMap resource="${root}resources/TCmEmpHelper.xml" />
		<sqlMap resource="${root}resources/TCmFeeTypeHelper.xml" />
		<sqlMap resource="${root}resources/TCmLinkHelper.xml" />
		<sqlMap resource="${root}resources/TCmMenuHelper.xml" />
		<sqlMap resource="${root}resources/TCmProvinceHelper.xml" />
		<sqlMap resource="${root}resources/TCmRoleHelper.xml" />
		<sqlMap resource="${root}resources/TCmRoleMenuRelationHelper.xml" />
		<sqlMap resource="${root}resources/TCmTemplateHelper.xml" />
		<sqlMap resource="${root}resources/TCmUserHelper.xml" />
		<sqlMap resource="${root}resources/TCmUserBranchRelationHelper.xml" />
		<sqlMap resource="${root}resources/TCmUserRoleRelationHelper.xml" />
		<sqlMap resource="${root}resources/TFinanceCustomerHelper.xml" />
		<sqlMap resource="${root}resources/TFinanceDailyHelper.xml" />
		<sqlMap resource="${root}resources/TFinanceDriverHelper.xml" />
		<sqlMap resource="${root}resources/TFinanceGoodHelper.xml" />
		<sqlMap resource="${root}resources/TFinanceServiceHelper.xml" />
		<sqlMap resource="${root}resources/TStowageDetailHelper.xml" />
		<sqlMap resource="${root}resources/TStowageMainHelper.xml" />
		<sqlMap resource="${root}resources/TStowageSiteHelper.xml" />
		<sqlMap resource="${root}resources/TTransferDetailHelper.xml" />
		<sqlMap resource="${root}resources/TTransferMainHelper.xml" />
		<sqlMap resource="${root}resources/TWayBillHelper.xml" />
		<sqlMap resource="${root}resources/TWayProductionHelper.xml" />
		<sqlMap resource="${root}resources/TWaySmHelper.xml" />
		<sqlMap resource="${root}resources/TWayTrackHelper.xml" />
		</sqlMaps>
*/
	}
}

