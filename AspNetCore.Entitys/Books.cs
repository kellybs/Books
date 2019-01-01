using Dapper.Contrib.Extensions;
using System;

namespace AspNetCore.Entitys
{
    /// <summary>
    /// 图书表
    /// </summary>
    [Table("Books")]
    [Serializable]
    public partial class Books
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public Guid BookId
        {
            get;
            set;
        }
        /// <summary>
        /// 书名
        /// </summary>
        public string BookName
        {
            get;
            set;
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get;
            set;
        }
        /// <summary>
        /// 出版社
        /// </summary>
        public int PublishHouseID
        {
            get;
            set;
        }

        /// <summary>
        /// 父类
        /// </summary>
        public int ParentType
        {
            get;
            set;
        }

        /// <summary>
        /// 子类
        /// </summary>
        public int SubType
        {
            get;
            set;
        }

        /// <summary>
        /// 原价
        /// </summary>
        public decimal CostPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal RealPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 发布日期
        /// </summary>
        public string PublishDate
        {
            get;
            set;
        }
        /// <summary>
        /// ISBN
        /// </summary>
        public string ISBN
        {
            get;
            set;
        }
        /// <summary>
        /// 书籍简介
        /// </summary>
        public string Summary
        {
            get;
            set;
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend
        {
            get;
            set;
        }
        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }

    }
}
