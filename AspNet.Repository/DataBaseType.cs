using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Repository
{
    public enum DataBaseType
    {
        /// <summary>
        /// 主库
        /// </summary>
        Master,
        /// <summary>
        /// 从库
        /// </summary>
        Slave
    }
}
