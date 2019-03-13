using NorthwindSystem.BLL.Interface;
using NorthwindSystem.Data.Models;
using NorthwindSystem.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.BLL.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILocalConfiguration _config;

        public ProductService(IProductRepository repository, ILocalConfiguration config)
        {
            this._productRepository = repository;
            _config = config;
        }

        public async Task<int> Add(Product entity)
        {
            return await _productRepository.Add(entity);
        }

        public async Task Delete(Product entity)
        {
            await _productRepository.Delete(entity);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            int maxProductNumber = _config.GetMaxProductsNumber();
            if (maxProductNumber > 0)
            {
                return await _productRepository.GetNumberItems(maxProductNumber);
            }

            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(int entityId)
        {
            return await _productRepository.GetById(entityId);
        }

        public async Task Update(Product entity)
        {
            await _productRepository.Update(entity);
        }
    }
}
