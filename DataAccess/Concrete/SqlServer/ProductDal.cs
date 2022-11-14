using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.SqlServer
{
    public class ProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public List<Product> GetLikeProducts(int subCategoryId, int productId)
        {
            using var context = new AppDbContext();
            var products = context.Products.Include(x => x.ProductPictures).ThenInclude(x => x.Picture).Where(x => x.SubCategoryId == subCategoryId && x.Id!=productId).ToList();
            return products;
        }

        public List<Product> GetPopularProducts()
        {
            using var _context = new AppDbContext();
            var products = _context.Products.Include(x => x.ProductPictures).ThenInclude(x => x.Picture).OrderByDescending(x => x.Hit).Take(8).ToList();
            return products;
        }

        public Product GetProduct(int id)
        {
            using var _context = new AppDbContext();
            var product = _context.Products.Include(x => x.ProductPictures).ThenInclude(x => x.Picture).FirstOrDefault(x => x.Id == id);
            return product;
        }

        public List<Product> GetRecentProducts()
        {
            using AppDbContext _context = new();
            return _context.Products.Include(x => x.ProductPictures).ThenInclude(x => x.Picture).OrderByDescending(x => x.Id).ToList();
        }
    }
}
