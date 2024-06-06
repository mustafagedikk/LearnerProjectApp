using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
  public   interface IGenericService<T> where T:class
    {
        List<T> TGetList();
        T TGetbyId(int id);

        void TAdd(T entity);

        void TUpdate(T entitiy);

        void TDelete(T entity);

    }
}
