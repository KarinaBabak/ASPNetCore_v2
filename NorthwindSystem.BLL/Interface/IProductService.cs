using NorthwindSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindSystem.BLL.Interface
{
    public interface IProductService
    {
        Task<int> Add(Product model);
        Task Update(Product model);
        Task Delete(Product model);
        Task<Product> GetById(int modelId);
        Task<IEnumerable<Product>> GetAll();
    }
}
