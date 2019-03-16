using NorthwindSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CategoryDAOEntity = NorthwindSystem.Data.Entities.Category;

namespace NorthwindSystem.Persistence.Interface
{
    public interface ICategoryRepository : IRepository<CategoryDAOEntity>
    {
    }
}
