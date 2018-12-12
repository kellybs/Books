using AspNetCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Services.Abstracts
{
    public interface IBookTypeServices
    {
        BookTypeUI Query();
        
    }
}
