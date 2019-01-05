using Dapper.Contrib.Extensions;

namespace AspNetCore.Entitys
{
    [Table("PublishHouse")]
    public class PublishHouse
    {
        [Key]
        public int PublishHouseID { get; set; }

        /// <summary>
        /// 出版社名称
        /// </summary>
        public string PublishName { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }
    }
}
