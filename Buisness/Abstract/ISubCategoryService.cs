using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ISubCategoryService
    {
        void AddSubCategory(SubCategory subCategory);
        void DeleteSubCategory(SubCategory subCategory);
        void UpdateSubCategory(SubCategory subCategory);
        SubCategory GetSubCategoryById(int id);
        List<SubCategory> GetAllSubCategories();
        List<SubCategory> GetActiveSubCategories();
       
    }
}
