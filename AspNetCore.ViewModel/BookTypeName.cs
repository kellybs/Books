using AspNetCore.Entitys;

namespace AspNetCore.ViewModel
{
    public class BookTypeName: BookTypes
    {
        /// <summary>
        /// 父类名称
        /// </summary>
        public string ParentName { get; set; }
    }
}
