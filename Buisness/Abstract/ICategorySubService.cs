using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICategorySubService
    {
        void AddCategorySub(CategorySub categorySub);
        void UpdateCategorySub(CategorySub categorySub);
        void DeleteCategorySub(CategorySub categorySub);
        CategorySub GetCategorySubById(int id);
        List<CategorySub> GetAllCategorySubs();
        List<CategorySub> GetActiveCategorySubs();
    }
}
