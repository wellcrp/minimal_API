using Project.Minimal.Domain.Product;
using Project.Minimal.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Minimal.Infrastructure.Product
{
    public class ProductRepository<Tentity> : IProductRepository<Tentity> where Tentity : class
    {
        private readonly List<ProductModel> _productAll;

        public ProductRepository()
        {
            _productAll = new List<ProductModel>();
        }
        public Task<List<ProductModel>> GetProductAll()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < 6; i++)
            {
                string description = new string(Enumerable.Repeat(chars, i).Select(s => s[new Random().Next(i)]).ToArray());

                _productAll.Add(new ProductModel(Guid.NewGuid(), new Random().Next(999), description));
            }
            
            return Task.FromResult(_productAll);
        }

        public Task<ProductModel> GetProductBySku(int sku)
        {
            var result = _productAll.FirstOrDefault(x => x.ProductSKU.Equals(sku));

            return Task.FromResult(result);
        }
    }
}



