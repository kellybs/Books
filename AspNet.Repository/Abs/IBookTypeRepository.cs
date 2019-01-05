using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System.Collections.Generic;

namespace AspNet.Repository.Abs
{
    public interface IBookTypeRepository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Create(BookTypes model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Delete(BookTypes model);

        /// <summary>
        /// 查找全部记录，包括当前信息的父类
        /// </summary>
        /// <returns></returns>
        List<BookTypeName> GetList();

        /// <summary>
        /// 获取所有父类
        /// </summary>
        /// <returns></returns>
        List<BookTypes> GetParentList();

        /// <summary>
        /// 查找全部记录
        /// </summary>
        /// <returns></returns>
        List<BookTypes> SearchAll();

        /// <summary>
        /// 获取某个分类下的子类
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<BookTypes> GetChildList(int parentId);

        /// <summary>
        /// 查找单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BookTypes GetItem(int id);

        /// <summary>
        /// 根据名称查找分类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        BookTypes GetItemByName(string name);
    }
}
