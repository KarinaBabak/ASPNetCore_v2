using System;
using NorthwindSystem.Persistence.Interface;
using System.Collections.Generic;

using ProductDTOModel = NorthwindSystem.Data.Models.Product;
using ProductDAOEntity = NorthwindSystem.Data.Entities.Product;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using NorthwindSystem.Data;
using NorthwindSystem.Data.Models;

namespace NorthwindSystem.Persistence.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindSystemContext _dbContext;


        public async Task<int> Add(ProductDTOModel entity)
        {
            var product = Mapper.Map<ProductDTOModel, ProductDAOEntity>(entity);
            var resultEntity = _dbContext.Set<ProductDAOEntity>().Add(product);
            await _dbContext.SaveChangesAsync();

            return resultEntity.Entity.ProductId;
        }


        public async Task Delete(ProductDTOModel entity)
        {
            var product = _dbContext.Set<ProductDAOEntity>().Where(c => c.ProductId == entity.Id).FirstOrDefault();
            if (product != null)
            {
                _dbContext.Set<ProductDAOEntity>().Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDTOModel>> GetAll()
        {
            var products = await _dbContext.Set<ProductDAOEntity>().ToListAsync();
            return Mapper.Map<List<ProductDAOEntity>, List<ProductDTOModel>>(products);
        }

        public async Task<ProductDTOModel> GetById(int entityId)
        {
            return await _dbContext.Set<ProductDAOEntity>().Where(a => a.ProductId == entityId)
                .Select(product => Mapper.Map<ProductDAOEntity, ProductDTOModel>(product)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDTOModel>> GetNumberItems(int number)
        {
            var products = await _dbContext.Set<ProductDAOEntity>().Take(number).ToListAsync();
            return Mapper.Map<List<ProductDAOEntity>, List<ProductDTOModel>>(products);
        }

        public async Task Update(ProductDTOModel entity)
        {
            var product = _dbContext.Set<ProductDAOEntity>().Where(a => a.ProductId == entity.Id).FirstOrDefault();
            if (product != null)
            {
                product = Mapper.Map<ProductDTOModel, ProductDAOEntity>(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
