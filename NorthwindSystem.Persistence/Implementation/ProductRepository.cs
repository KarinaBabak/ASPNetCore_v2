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
        //private readonly NorthwindSystemContext _dbContext;
        private readonly DbContext _dbContext;

        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(ProductDAOEntity entity)
        {
            var resultEntity = _dbContext.Set<ProductDAOEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return resultEntity.Entity.ProductId;
        }


        public async Task Delete(ProductDAOEntity entity)
        {
            var product = _dbContext.Set<ProductDAOEntity>().Where(c => c.ProductId == entity.ProductId).FirstOrDefault();
            if (product != null)
            {
                _dbContext.Set<ProductDAOEntity>().Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDAOEntity>> GetAll()
        {
            return await _dbContext.Set<ProductDAOEntity>().ToListAsync();
        }

        public async Task<ProductDAOEntity> GetById(int entityId)
        {
            return await _dbContext.Set<ProductDAOEntity>().Where(a => a.ProductId == entityId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDAOEntity>> GetNumberItems(int number)
        {
            return  await _dbContext.Set<ProductDAOEntity>().Take(number).ToListAsync();
        }

        public async Task Update(ProductDAOEntity entity)
        {
            var product = _dbContext.Set<ProductDAOEntity>().Where(a => a.ProductId == entity.ProductId).FirstOrDefault();
            if (product != null)
            {
                product = entity;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
