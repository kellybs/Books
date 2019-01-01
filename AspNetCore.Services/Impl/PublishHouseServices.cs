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
    public class PublishHouseServices : IPublishHouseServices
    {

        private readonly IPublishHouseRepository service;
        private readonly IBookRepository book;
        private ILog log;
        public PublishHouseServices(IPublishHouseRepository _service, IBookRepository bookRepository)
        {
            service = _service;
            book = bookRepository;
            log = LogManager.GetLogger("NETCoreRepository", typeof(PublishHouseServices));
        }

        public ResultInfo Create(PublishHouse model)
        {
            ResultInfo ri = new ResultInfo();

            if (string.IsNullOrWhiteSpace(model.PublishName))
            {
                ri.Msg = "请输入出版社名称";
                return ri;
            }

            try
            {
                service.Create(model);
                ri.Url = "/Publish";
                ri.Code = 0;

            }
            catch(Exception e)
            {
                log.Error("Create Error:", e);
                ri.Msg = "添加的出版社名称已经存在";
            }
            return ri;
        }

        public ResultInfo Delete(int id)
        {
            ResultInfo ri = new ResultInfo();
            var model = service.GetItem(id);

            if (null == model)
            {
                ri.Msg = "删除的数据不存在";
                return ri;
            }

            int count = book.Count(id);
            if (count > 0)
            {
                ri.Msg = "当前出版社已包含书籍，不允许删除";
                return ri;
            }

            try
            {
                service.Delete(model);

                ri.Code = 0;
                
            }
            catch (Exception e)
            {
                log.Error("Delete:",e);
                ri.Msg = "删除异常";
            }

            return ri;
        }

        public PublishHouse GetItem(int id)
        {
            return service.GetItem(id);
        }

        public List<PublishHouse> GetList()
        {
            return service.GetList().ToList();
        }

        public ResultInfo Update(PublishHouse model)
        {
            ResultInfo ri = new ResultInfo();

            if (string.IsNullOrWhiteSpace(model.PublishName))
            {
                ri.Msg = "请输入出版社名称";
                return ri;
            }

            PublishHouse house = service.Exists(model.PublishName);
            if (house != null && house.PublishHouseID != model.PublishHouseID)
            {
                ri.Msg = "修改的名称重复";
                return ri;
            }

            try
            {
                service.Update(model);
                ri.Url = "/Publish";
                ri.Code = 0;

            }
            catch (Exception e)
            {
                log.Error("Create Error:", e);
                ri.Msg = "修改的出版社名称已经存在";
            }
            return ri;
        }
    }
}
