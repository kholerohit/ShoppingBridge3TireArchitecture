using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DAL.Repository
{
    public class ProductRepository: IProductRepository
    {
        ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Product> Create(Product product)
        {
            _dbContext.Product.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var product = await _dbContext.Product.FindAsync(id);
            _dbContext.Product.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _dbContext.Product.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _dbContext.Product.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }
    }
}
