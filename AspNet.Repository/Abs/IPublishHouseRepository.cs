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
        long Create(PublishHouse model);

        bool Update(PublishHouse model);

        bool Delete(PublishHouse model);

        IEnumerable<PublishHouse> GetList();

        PublishHouse GetItem(int id);

        PublishHouse Exists(string name);
    }
}
