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

        IEnumerable<PublishHouse> GetList();

        PublishHouse GetItem(int id);
    }
}
