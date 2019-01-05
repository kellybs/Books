using AspNetCore.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.ViewModel
{
    public class HomeUI
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

        public PageList<BookQueryInfo> QueryList { get; set; }

        public IEnumerable<BookTypes> Parent { get; set; }

        public IEnumerable<BookTypes> Children { get; set; }

        public IEnumerable<PublishHouse> HoustList { get; set; }
    }
}
