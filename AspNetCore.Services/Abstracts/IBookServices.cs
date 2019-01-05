using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System;

namespace AspNetCore.Services.Abstracts
{
    public interface IBookServices
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultInfo Create(BookUI model);

        /// <summary>
        /// 
        /// </summary>删除
        /// <param name="id"></param>
        /// <returns></returns>
        ResultInfo Delete(Guid id);

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Books GetItem(Guid id);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultInfo Update(BookUI model);

        /// <summary>
        /// 分页查找
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        PageList<BookQueryInfo> GetList(BookQuery query);

        /// <summary>
        /// 网站首页数据源
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        HomeUI Home(BookQuery query);
    }
}
