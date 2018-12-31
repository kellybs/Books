using AspNet.Repository.Abs;
using AspNetCore.Entitys;
using AspNetCore.Services.Abstracts;
using AspNetCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Services.Impl
{
    public class PublishHouseServices : IPublishHouseServices
    {

        private readonly IPublishHouseRepository service;

        public PublishHouseServices(IPublishHouseRepository _service)
        {
            service = _service;
        }

        public ResultInfo Create(PublishHouse model)
        {
            ResultInfo ri = new ResultInfo()
            {
                Code = -1
            };

            try
            {
                service.Create(model);
                ri.Url = "/Publish";
                ri.Code = 0;

            }
            catch(Exception e)
            {
                ri.Msg = "添加的出版社名称已经存在";
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
    }
}
