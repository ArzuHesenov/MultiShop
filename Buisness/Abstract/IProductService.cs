using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IProductService
    {
        void AddProduct(Product product);
        List<Product> GetAllRecentProduct();
        List<Product> GetAllPopularProducts();
        Product GetProductById(int id);
        List<Product> GetProductsBySubCategoryId(int subCategoryId, int productId);
    }
}
