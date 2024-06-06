using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICourseService:IGenericService<Course>
    {
        int CourseCount();
        int CoursePriceExpencive();

        string ExpenciveCourseName();

        List<Course> GetlistByEducatorUserName(string username);

        List<Course> GetPassiveCourseList();

        List<Course> GetlistwithReview();

        List<Course> GetListWtihSearch(string search);
    }
}
