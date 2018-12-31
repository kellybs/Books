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
        /// 书籍分类
        /// </summary>
        public int BookTypeId { get; set; }

        /// <summary>
        /// 出版社
        /// </summary>
        public int PublishHouseId { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool Recommend { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool Hot { get; set; }
    }
}
