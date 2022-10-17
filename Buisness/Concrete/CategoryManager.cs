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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetActiveCategories()
        {
            return _categoryDal.GetAll(x => x.IsDeleted == false);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryDal.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryDal.Get(x => x.Id == id);
        }

        public void UpdateCategory(Category category)
        {
           _categoryDal.Update(category);
        }
    }
}
