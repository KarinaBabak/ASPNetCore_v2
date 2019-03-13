using NorthwindSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductDTOModel = NorthwindSystem.Data.Models.Product;

namespace NorthwindSystem.Persistence.Interface
{
    public interface IProductRepository : IRepository<ProductDTOModel>
    {
        Task<IEnumerable<ProductDTOModel>> GetNumberItems(int number);
    }
}
