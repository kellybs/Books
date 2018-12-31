using Dapper.Contrib.Extensions;

namespace AspNetCore.Entitys
{
    [Table("PublishHouse")]
    public class PublishHouse
    {
        [Key]
        public int PublishHouseID { get; set; }

        public string PublishName { get; set; }

        public bool IsRecommend { get; set; }
    }
}
