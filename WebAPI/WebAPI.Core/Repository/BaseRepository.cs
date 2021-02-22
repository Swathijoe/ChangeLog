using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Context;

namespace WebAPI.Core.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IContextGenerator _context;
        public readonly IChangeLogContext _changeLogContext;
        public BaseRepository(IContextGenerator context)
        {
            _context = context;
            _changeLogContext = _context.GenerateContext();
        }

        public async Task<TEntity> Add(TEntity entity)
        {            
            var entryEntity = _changeLogContext.Set<TEntity>().Add(entity);            
            await _changeLogContext.SaveChanges();
            return entryEntity.Entity;
        }

        public async Task<int> Delete(Guid id)
        {
            var entity = _changeLogContext.FindEntity<TEntity>(id);
            if (entity != null)
            {
                _changeLogContext.Set<TEntity>().Remove(entity);
            }
            return await _changeLogContext.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return _changeLogContext.Set<TEntity>();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var entryEntity = _changeLogContext.Set<TEntity>().Update(entity);
            await _changeLogContext.SaveChanges();
            return entryEntity.Entity;
        }
    }
}
