using AspNetCore.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Repository.Abs
{
    public interface IPublishHouseRepository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long Create(PublishHouse model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(PublishHouse model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Delete(PublishHouse model);

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        IEnumerable<PublishHouse> GetList();

        /// <summary>
        /// 获取单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PublishHouse GetItem(int id);

        /// <summary>
        /// 根据名称查找记录是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        PublishHouse Exists(string name);
    }
}
