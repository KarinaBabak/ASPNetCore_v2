using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NorthwindSystem.BLL.Interface;
using NorthwindSystem.Data.Models;
using NorthwindSystem.Persistence.Interface;
using CategoryDAOEntity = NorthwindSystem.Data.Entities.Category;

namespace NorthwindSystem.BLL.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository repository)
        {
            this._categoryRepository = repository;
        }

        public async Task<int> Add(Category entity)
        {
            var category = Mapper.Map<Category, CategoryDAOEntity>(entity);
            return await _categoryRepository.Add(category);
        }

        public async Task Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return Mapper.Map<IEnumerable<CategoryDAOEntity>, IEnumerable<Category>>(categories);
        }

        public async Task<Category> GetById(int entityId)
        {
            var category = await _categoryRepository.GetById(entityId);
            return Mapper.Map<CategoryDAOEntity, Category>(category);
        }

        public async Task Update(Category entity)
        {
            var category = Mapper.Map<Category, CategoryDAOEntity>(entity);
            await _categoryRepository.Update(category);
        }
    }
}
