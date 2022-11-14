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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProduct(Product product)
        {
            _productDal.Add(product);
        }

        public List<Product> GetAllPopularProducts()
        {
            return _productDal.GetPopularProducts();
        }

        public List<Product> GetAllRecentProduct()
        {
            return _productDal.GetRecentProducts();
        }

        public Product GetProductById(int id)
        {
            return _productDal.GetProduct(id);
        }

        public List<Product> GetProductsBySubCategoryId(int subCategoryId, int productId)
        {
            return _productDal.GetLikeProducts(subCategoryId, productId);
        }
    }
}
