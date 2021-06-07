using Microsoft.EntityFrameworkCore;
using ProductApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Services
{
    public class ProductService
    {
        private AppDbContext GetContext()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Product.db3");
            return new AppDbContext(dbPath);
        }

        public async Task<List<Product>> GetList()
        {
            var _dbContext = GetContext();
            var list = await _dbContext.Products.ToListAsync();
            return list;
        }

        public Task<Product> GetProduct(int id)
        {
            var _dbContext = GetContext();
            var product= _dbContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public void CreateProduct(Product product)
        {
            var _dbContext = GetContext();
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var _dbContext = GetContext();
            _dbContext.Products.Update(product);
           int p = await _dbContext.SaveChangesAsync();
            return p;
        }

        public void DeleteProduct(Product product)
        {
            var _dbContext = GetContext();
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }







    }
}
