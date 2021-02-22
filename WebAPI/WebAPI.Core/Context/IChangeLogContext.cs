using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Context
{
    public interface IChangeLogContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        TEntity FindEntity<TEntity>(Guid id) where TEntity : class;
        Task<int> SaveChanges();

    }
}
