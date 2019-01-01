using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Services.Abstracts
{
    public interface IPublishHouseServices
    {
        List<PublishHouse> GetList();

        PublishHouse GetItem(int id);

        ResultInfo Create(PublishHouse model);


        ResultInfo Update(PublishHouse model);

        ResultInfo Delete(int id);
    }
}
