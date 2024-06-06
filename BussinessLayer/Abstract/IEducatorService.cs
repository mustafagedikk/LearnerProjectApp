using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
  public  interface IEducatorService:IGenericService<Educator>
    {

        Educator GetEducatorvalue(Educator educator);

        

    }
}
