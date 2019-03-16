using NorthwindSystem.Data.Models;
using NorthwindSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindSystem.BLL.Interface
{
    public interface ICategoryService
    {
        Task<int> Add(Category model);
        Task Update(Category model);
        Task Delete(Category model);
        Task<Category> GetById(int modelId);
        Task<IEnumerable<Category>> GetAll();
    }
}
