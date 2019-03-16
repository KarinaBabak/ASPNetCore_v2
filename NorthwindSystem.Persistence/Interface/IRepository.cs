using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindSystem.Data.Models;

namespace NorthwindSystem.Persistence.Interface
{
    public interface IRepository<TModel>
    {
        Task<int> Add(TModel entity);
        Task Delete(TModel entity);
        Task Update(TModel entity);
        Task<TModel> GetById(int entityId);
        Task<IEnumerable<TModel>> GetAll();
    }
}
