using AspNet.Repository.Abs;
using AspNetCore.Entitys;
using AspNetCore.Services.Abstracts;
using AspNetCore.ViewModel;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Services.Impl
{
    public class BookTypeServices : IBookTypeServices
    {
        private readonly IBookTypeRepository bookTypeRepository;
        private readonly IBookRepository bookRepository;
        private ILog log;
        public BookTypeServices(IBookTypeRepository _bookTypeRepository, IBookRepository _bookRepository)
        {
            bookTypeRepository = _bookTypeRepository;
            bookRepository = _bookRepository;
            log = LogManager.GetLogger("NETCoreRepository", typeof(BookTypeServices));
        }

        /// <summary>
        /// 列表页
        /// </summary>
        /// <returns></returns>
        public BookTypeUI Query()
        {
            List<BookTypeName> list = bookTypeRepository.GetList();
            BookTypeUI ui = new BookTypeUI() {
                BookList = list
            };

            if (null != list && list.Count > 0)
            {
                ui.ParentBooks = list.Where(t => t.ParentId == 0).ToList();
            }
            return ui;
        }

        /// <summary>
        /// 获取所有父类
        /// </summary>
        /// <returns></returns>
        public List<BookTypes> GetParentList()
        {
            return bookTypeRepository.GetParentList();
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public List<BookTypes> SearchAll()
        {
            return bookTypeRepository.SearchAll();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResultInfo Create(BookTypeModel model)
        {

            ResultInfo ri = new ResultInfo() {
                Code=-1
            };

            if (model.BookType == null)
            {
                ri.Msg = "无法获取数据";
                return ri;
            }

            BookTypes bookTypes = model.BookType;
            if (string.IsNullOrWhiteSpace(bookTypes.TypeName))
            {
                ri.Msg = "请输入分类名称";
                return ri;
            }

            if (bookTypes.ParentId > 0)
            {
                var queryModel = bookTypeRepository.GetItem(bookTypes.ParentId);
                if (queryModel == null)
                {
                    ri.Msg = "选择的父类不存在";
                    return ri;
                }
            }

            if (bookTypeRepository.GetItemByName(bookTypes.TypeName)!=null)
            {
                ri.Msg = "添加名称已经存在";
                return ri;
            }

            bookTypeRepository.Create(bookTypes);
            ri.Code = 0;
            ri.Msg = "Success";
            ri.Url = "/BookType";
            return ri;
        }

        /// <summary>
        /// 获取单条记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public BookTypes GetItem(int id)
        {
            return bookTypeRepository.GetItem(id);
        }

        /// <summary>
        /// 根据父类ID，查找子类记录
        /// </summary>
        /// <param name="parentId">父类ID</param>
        /// <returns></returns>
        public List<BookTypes> GetListByParentID(int parentId)
        {
            if (parentId == 0) return null;
            var list = SearchAll();
            return list.Where(t => t.ParentId == parentId).ToList();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultInfo Delete(int id)
        {
            ResultInfo ri = new ResultInfo();

            var model = bookTypeRepository.GetItem(id);
            if (model == null)
            {
                ri.Msg = "删除数据不存在";
                return ri;
            }

            if (model.ParentId == 0)
            {
                var list = bookTypeRepository.GetChildList(model.BookTypeId);

                if (list != null && list.Count() > 0)
                {
                    ri.Msg = "要删除的数据含有子类，不允许删除";
                    return ri;
                }
            }
            else
            {
                int count = bookRepository.CountByTypeID(model.BookTypeId);

                if (count > 0)
                {
                    ri.Msg = "删除分类下含有书籍，不允许删除";
                    return ri;
                }
            }

            try
            {
                bookTypeRepository.Delete(model);
                ri.Code = 0;
            }
            catch (Exception e)
            {
                ri.Msg = "删除异常";
                log.Error("Delete", e);
            }
           
            return ri;
        }
    }
}
