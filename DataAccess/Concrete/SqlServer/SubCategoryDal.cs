using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.SqlServer
{
    public class SubCategoryDal : EfRepositoryBase<SubCategory, AppDbContext>, ISubCategoryDal
    {
        public void AddSubCategoryWithCategories(SubCategory subCategory, List<int> categoryIds)
        {
            using var context = new AppDbContext();

            context.SubCategories.Add(subCategory);
            context.SaveChanges();

            for (int i = 0; i < categoryIds.Count; i++)
            {
                CategorySub categorySub = new()
                {
                    CategoryId = categoryIds[i],
                    SubCategoryId = subCategory.Id
                };

                context.CategorySubs.Add(categorySub);
                context.SaveChanges();
            }
        }
    }
}
