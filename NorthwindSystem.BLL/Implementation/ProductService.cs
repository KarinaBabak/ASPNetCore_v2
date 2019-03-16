using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NorthwindSystem.BLL.Interface;
using NorthwindSystem.Data.Models;
using NorthwindSystem.Persistence.Interface;
using ProductDAOEntity = NorthwindSystem.Data.Entities.Product;


namespace NorthwindSystem.BLL.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILocalConfiguration _config;

        public ProductService(IProductRepository repository, ILocalConfiguration config)
        {
            _productRepository = repository;
            _config = config;
        }

        public async Task<int> Add(Product entity)
        {
            var product = Mapper.Map<Product, ProductDAOEntity>(entity);
            return await _productRepository.Add(product);
        }

        public async Task Delete(Product entity)
        {
            var product = Mapper.Map<Product, ProductDAOEntity>(entity);
            await _productRepository.Delete(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<ProductDAOEntity> items;
            int maxProductNumber = _config.GetMaxProductsNumber();
            if (maxProductNumber > 0)
            {
                items = await _productRepository.GetNumberItems(maxProductNumber);
            }
            else
            {
                items = await _productRepository.GetAll();
            }
            
            return Mapper.Map<IEnumerable<ProductDAOEntity>, IEnumerable<Product>>(items);
        }

        public async Task<Product> GetById(int entityId)
        {
            var product = await _productRepository.GetById(entityId);
            return Mapper.Map<ProductDAOEntity, Product>(product);
        }

        public async Task Update(Product entity)
        {
            var product = Mapper.Map<Product, ProductDAOEntity>(entity);
            await _productRepository.Update(product);
        }
    }
}
