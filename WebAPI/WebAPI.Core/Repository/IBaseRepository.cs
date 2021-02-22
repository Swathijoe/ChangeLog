using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Repository
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<int> Delete(Guid id);        

    }
}
