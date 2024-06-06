using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class EfCourseDal : GenericRepository<Course>, ICourseDal
    {
       
    }
}
