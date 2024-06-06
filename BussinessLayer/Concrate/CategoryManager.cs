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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int CategoryCount()
        {
            return _categoryDal.List().Count();
        }

        public void TAdd(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category TGetbyId(int id)
        {
           return _categoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.List();
        }

        public void TUpdate(Category entitiy)
        {
            _categoryDal.Update(entitiy);
        }
    }
}
