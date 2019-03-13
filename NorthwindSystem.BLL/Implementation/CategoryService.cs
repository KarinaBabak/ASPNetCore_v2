using NorthwindSystem.BLL.Interface;
using NorthwindSystem.Data.Models;
using NorthwindSystem.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            return await _categoryRepository.Add(entity);
        }

        public async Task Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int entityId)
        {
            return await _categoryRepository.GetById(entityId);
        }

        public async Task Update(Category entity)
        {
            await _categoryRepository.GetAll();
        }
    }
}
