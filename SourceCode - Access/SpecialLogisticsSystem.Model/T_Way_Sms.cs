using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace SpecialLogisticsSystem.Model
{
    //运单短信通知
    public class T_Way_Sms : Entity
    {

        /// <summary>
        /// id
        /// </summary>		
        private Guid _id;
        [PrimaryKey(true)]
        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}

