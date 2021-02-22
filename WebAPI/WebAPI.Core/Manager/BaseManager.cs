using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Repository;

namespace WebAPI.Core.Manager
{
    public class BaseManager<TEntity> : IBaseManager<TEntity>
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseManager(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            return await _baseRepository.Add(entity);
        }

        public async Task<int> Delete(Guid id)
        {
            return await _baseRepository.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _baseRepository.Get();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await _baseRepository.Update(entity);
        }
    }
}
