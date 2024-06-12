using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrate
{
    public class CourseVideoManager : ICourseVideoService
    {
        ICourseVideoDal _courseVideoDal;

        public CourseVideoManager(ICourseVideoDal courseVideoDal)
        {
            _courseVideoDal = courseVideoDal;
        }

        public List<CourseVideo> GetListMyCourseVideowithId(int id)
        {
            return _courseVideoDal.List(x => x.CourseId == id);
        }

        public void TAdd(CourseVideo entity)
        {
            _courseVideoDal.Insert(entity);
        }

        public void TDelete(CourseVideo entity)
        {
            _courseVideoDal.Delete(entity);
        }

        public CourseVideo TGetbyId(int id)
        {
            return _courseVideoDal.Get(x => x.CourseVideoId == id);
        }

        public List<CourseVideo> TGetList()
        {
            return _courseVideoDal.List();
        }

        public void TUpdate(CourseVideo entitiy)
        {
            _courseVideoDal.Update(entitiy);
        }
    }
}
