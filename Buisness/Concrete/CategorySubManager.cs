using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class CategorySubManager : ICategorySubService
    {
        private readonly ICategorySubDal _categorySubDal;

        public CategorySubManager(ICategorySubDal categorySubDal)
        {
            _categorySubDal = categorySubDal;
        }

        public void AddCategorySub(CategorySub categorySub)
        {
            _categorySubDal.Add(categorySub);
        }

        public void DeleteCategorySub(CategorySub categorySub)
        {
            _categorySubDal.Delete(categorySub);
        }

        public List<CategorySub> GetActiveCategorySubs()
        {
            return _categorySubDal.GetAll(x=>x.IsDeleted==false);
        }

        public List<CategorySub> GetAllCategorySubs()
        {
            return _categorySubDal.GetAll();
        }

        public CategorySub GetCategorySubById(int id)
        {
            return _categorySubDal.Get(x => x.Id == id);
        }

        public void UpdateCategorySub(CategorySub categorySub)
        {
            _categorySubDal.Update(categorySub);
        }
    }
}
