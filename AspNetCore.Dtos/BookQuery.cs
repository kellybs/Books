using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Dtos
{
    public class BookQuery:PageQuery
    {
        /// <summary>
        /// 父类
        /// </summary>
        public int ParentType { get; set; }

        /// <summary>
        /// 子类
        /// </summary>
        public int SubType { get; set; }

        /// <summary>
        /// 出版社
        /// </summary>
        public int PublishHouseId { get; set; }

       
    }
}
