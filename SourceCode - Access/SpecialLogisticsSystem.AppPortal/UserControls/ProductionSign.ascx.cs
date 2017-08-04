using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ProductionSign : BaseUserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 运单签收
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Save(object id)
        {
            int result = 0;
            IArrivalSignDal _sign = UIHelper.Resolve<IArrivalSignDal>();
            T_Arrival_Sign sign = new T_Arrival_Sign
            {
                id = Guid.NewGuid(),
                emp_id = emp_id.GetValue().Value,
                signer = signer.Text,
                signer_date = signer_date.Date,
                signer_identity = signer_identity.Text,
                way_id = ConvertHelper.ObjectToGuid(id).Value,
                signer_memo=signer_memo.Text
            };
            
            result=_sign.Insert(sign);
            return result > 0;
        }
    }
}