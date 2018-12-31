using Dapper.Contrib.Extensions;
using System;

namespace AspNetCore.Entitys
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class BookTypes
    {
        [Key]
        /// <summary>
        /// 主键 自增
        /// </summary>
        public int BookTypeId
        {
            get;
            set;
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string TypeName
        {
            get;
            set;
        }
        /// <summary>
        /// 父类ID 0 是顶级ID
        /// </summary>
        public int ParentId
        {
            get;
            set;
        }

    }
}
