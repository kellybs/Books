using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System.Collections.Generic;

namespace AspNetCore.Services.Abstracts
{
    public interface IBookTypeServices
    {
        /// <summary>
        /// 列表页
        /// </summary>
        /// <returns></returns>
        BookTypeUI Query();

        /// <summary>
        /// 获取所有父类
        /// </summary>
        /// <returns></returns>
        List<BookTypes> GetParentList();

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultInfo Create(BookTypeModel model);

        /// <summary>
        /// 获取单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BookTypes GetItem(int id);

        /// <summary>
        /// 全部记录
        /// </summary>
        /// <returns></returns>
        List<BookTypes> SearchAll();

        /// <summary>
        /// 根据父类ID，查找子类记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<BookTypes> GetListByParentID(int parentId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResultInfo Delete(int id);
    }
}
