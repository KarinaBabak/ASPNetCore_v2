using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.BLL.Interface
{
    public interface IService<TModel>
    {
        Task<int> Add(TModel model);
        Task Update(TModel model);
        Task Delete(TModel model);
        Task<TModel> GetById(int modelId);
        Task<IEnumerable<TModel>> GetAll();
    }
}
