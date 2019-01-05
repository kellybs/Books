using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System;
using System.Collections.Generic;

namespace AspNet.Repository.Abs
{
    public interface IBookRepository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Create(Books model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Delete(Books model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Books model);

        /// <summary>
        /// 查找单条记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Books GetItem(Guid id);

        /// <summary>
        /// 分页信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PageList<BookQueryInfo> GetList(BookQuery query);

        /// <summary>
        /// 根据出版社ID，查找书籍数量
        /// </summary>
        /// <param name="publicHouse"></param>
        /// <returns></returns>
        int Count(int publicHouse);

        /// <summary>
        /// 根据子类ID，查找书籍数量
        /// </summary>
        /// <param name="subTypeId"></param>
        /// <returns></returns>
        int CountByTypeID(int subTypeId);
        
    }
}
