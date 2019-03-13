using NorthwindSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CategoryDTOModel = NorthwindSystem.Data.Models.Category;

namespace NorthwindSystem.Persistence.Interface
{
    public interface ICategoryRepository : IRepository<CategoryDTOModel>
    {
        /// <summary>
        /// Adding category
        /// </summary>
        /// <param name="entity">category for adding</param>
        //Task<int> Add(CategoryDTOModel entity);
        //Task Delete(CategoryDTOModel entity);
        //Task Update(CategoryDTOModel entity);
        //Task<CategoryDTOModel> GetById(int entityId);
        //Task<IEnumerable<CategoryDTOModel>> GetAll();
    }
}
