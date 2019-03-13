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

        public async Task<int> Add(CategoryDTOModel entity)
        {
            var category = Mapper.Map<CategoryDTOModel, CategoryDAOEntity>(entity);
            var resultEntity = _dbContext.Set<CategoryDAOEntity>().Add(category);
            await _dbContext.SaveChangesAsync();

            return resultEntity.Entity.CategoryId;
        }

        public async Task Delete(CategoryDTOModel entity)
        {
            var category = _dbContext.Set<CategoryDAOEntity>().Where(c => c.CategoryId == entity.Id).FirstOrDefault();
            if (category != null)
            {
                _dbContext.Set<CategoryDAOEntity>().Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryDTOModel>> GetAll()
        {
            var categories = await _dbContext.Set<CategoryDAOEntity>().ToListAsync();
            return Mapper.Map<List<CategoryDAOEntity>, List<CategoryDTOModel>>(categories);
        }

        public async Task<CategoryDTOModel> GetById(int entityId)
        {
            return await _dbContext.Set<CategoryDAOEntity>().Where(a => a.CategoryId == entityId)
                .Select(post => Mapper.Map<CategoryDAOEntity, CategoryDTOModel>(post)).FirstOrDefaultAsync();
        }

        public async Task Update(CategoryDTOModel entity)
        {
            var product = _dbContext.Set<CategoryDAOEntity>().Where(a => a.CategoryId == entity.Id).FirstOrDefault();
            if (product != null)
            {
                product = Mapper.Map<CategoryDTOModel, CategoryDAOEntity>(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
