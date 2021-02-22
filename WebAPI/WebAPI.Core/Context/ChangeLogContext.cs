using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebAPI.Core.Entity;

namespace WebAPI.Core.Context
{
    public partial class ChangeLogContext : DbContext, IChangeLogContext
    {
        public ChangeLogContext()
        {
        }
        public ChangeLogContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<ChangeLog> ChangeLog { get; set; }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangeLog>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(d => d.User)
                   .WithMany(p => p.ChangeLogs)
                   .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasMany(u => u.ChangeLogs)
                .WithOne(c => c.User).HasForeignKey(x => x.Id);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public new async Task<int> SaveChanges()
        {

            return await base.SaveChangesAsync();
        }


        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public TEntity FindEntity<TEntity>(Guid id) where TEntity : class
        {
            return base.Set<TEntity>().Find(id);
        }
    }
}
