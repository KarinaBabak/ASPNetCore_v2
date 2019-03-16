using System;
using NorthwindSystem.Persistence.Interface;
using System.Collections.Generic;
using CategoryDTOModel = NorthwindSystem.Data.Models.Category;
using CategoryDAOEntity = NorthwindSystem.Data.Entities.Category;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindSystem.Persistence.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _dbContext;

        public CategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(CategoryDAOEntity entity)
        {
            var resultEntity = _dbContext.Set<CategoryDAOEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return resultEntity.Entity.CategoryId;
        }

        public async Task Delete(CategoryDAOEntity entity)
        {
            var category = _dbContext.Set<CategoryDAOEntity>().Where(c => c.CategoryId == entity.CategoryId).FirstOrDefault();
            if (category != null)
            {
                _dbContext.Set<CategoryDAOEntity>().Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryDAOEntity>> GetAll()
        {
            return await _dbContext.Set<CategoryDAOEntity>().ToListAsync();
        }

        public async Task<CategoryDAOEntity> GetById(int entityId)
        {
            return await _dbContext.Set<CategoryDAOEntity>().Where(a => a.CategoryId == entityId).FirstOrDefaultAsync();
        }

        public async Task Update(CategoryDAOEntity entity)
        {
            var product = _dbContext.Set<CategoryDAOEntity>().Where(a => a.CategoryId == entity.CategoryId).FirstOrDefault();
            if (product != null)
            {
                product = entity;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
