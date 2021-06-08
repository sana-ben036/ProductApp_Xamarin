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
            return new AppDbContext();
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

        public int CreateProduct(Product product)
        {
            var _dbContext = GetContext();
            _dbContext.Products.Add(product);
            int p =  _dbContext.SaveChanges();
            return p;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var _dbContext = GetContext();
            _dbContext.Products.Update(product);
            int p = await _dbContext.SaveChangesAsync();
            return p;
        }

        public int DeleteProduct(Product product)
        {
            var _dbContext = GetContext();
            _dbContext.Products.Remove(product);
            int p = _dbContext.SaveChanges();
            return p;
        }







    }
}
