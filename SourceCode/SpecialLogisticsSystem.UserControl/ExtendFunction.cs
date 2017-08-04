using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.UserControl
{
    /// <summary>
    /// 扩展功能类，抽象类
    /// </summary>
    public abstract class ExtendFunction
    {
        /// <summary>
        /// CustomGrid对象变量
        /// </summary>
        protected ASPxGridView _sgv;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExtendFunction()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sgv">CustomGrid对象</param>
        public ExtendFunction(ASPxGridView sgv)
        {
            this._sgv = sgv;
        }

        /// <summary>
        /// CustomGrid对象
        /// </summary>
        public ASPxGridView CustomGrid
        {
            get { return this._sgv; }
            set { this._sgv = value; }
        }

        /// <summary>
        /// 实现扩展功能
        /// </summary>
        public void Complete()
        {
            if (this._sgv == null)
            {
                throw new ArgumentNullException("CustomGrid", "扩展功能时未设置CustomGrid对象");
            }
            else
            {
                Execute();
            }
        }

        /// <summary>
        /// 扩展功能的具体实现
        /// </summary>
        protected abstract void Execute();
    }
}
