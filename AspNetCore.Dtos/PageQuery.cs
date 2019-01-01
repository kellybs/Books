using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Dtos
{
    public class PageQuery
    {
        /// <summary>
        /// 页面索引
        /// </summary>
        private int _pageIndex;

        /// <summary>
        /// 页面分页总页数
        /// </summary>
        private int _pageSize = 10;

        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex < 1 ? 1 : _pageIndex; }
            set { _pageIndex = value; }
        }

        /// <summary>
        /// 每一页展示数量
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// 分页开始索引
        /// </summary>
        public virtual int StartIndex
        {
            get
            {
                return (PageIndex - 1) * PageSize + 1;
            }
        }

        /// <summary>
        /// 分页结束索引
        /// </summary>
        public virtual int EndIndex
        {
            get
            {
                return PageSize * PageIndex;
            }
        }

    }
}
