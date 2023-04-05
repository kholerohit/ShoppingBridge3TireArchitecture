using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BAL.Service
{
    public class ProductService
    {
        private readonly IProductRepository _product;

        public ProductService(IProductRepository product)
        {
            _product = product;
        }

        //GET All Product Details 
        public  async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return await _product.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET Product by Id
        public async Task<Product> GetProducts(int id)
        {
            return  await _product.Get(id);
        }

        //Add Product
        public async Task<Product> AddProduct(Product Product)
        {
            return await _product.Create(Product);
        }

        //Delete Person 
        public bool DeleteProduct(int id)
        {

            try
            {
                _product.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        public bool UpdateProduct(Product product)
        {
            try
            {
                _product.Update(product);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
