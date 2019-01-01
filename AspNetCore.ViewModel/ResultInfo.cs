using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.ViewModel
{
    public class ResultInfo
    {
        public ResultInfo()
        {
            this.Code = -1;
        }

        /// <summary>
        /// 操作是否成功 0 成功 其它值失败
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 成功或者失败提示信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 跳转网址
        /// </summary>
        public string Url { get; set; }
    }
}
