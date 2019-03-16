using NorthwindSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductDAOModel = NorthwindSystem.Data.Entities.Product;

namespace NorthwindSystem.Persistence.Interface
{
    public interface IProductRepository : IRepository<ProductDAOModel>
    {
        Task<IEnumerable<ProductDAOModel>> GetNumberItems(int number);
    }
}
