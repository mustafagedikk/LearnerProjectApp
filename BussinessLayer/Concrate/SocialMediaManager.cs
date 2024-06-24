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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SocialMedia entity)
        {
            throw new NotImplementedException();
        }

        public SocialMedia TGetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediaDal.List();
        }

        public void TUpdate(SocialMedia entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
