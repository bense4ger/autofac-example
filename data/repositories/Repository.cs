using System;
using System.Linq;
using System.Threading.Tasks;
using autofac.example.data.data;
using autofac.example.data.generic;

namespace autofac.example.data.repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        public Repository(IDbContext<TEntity> dbContext)
        {
            DbContext = dbContext;
        }

        private IDbContext<TEntity> DbContext { get; }

        public async Task<TEntity> Get(Guid id)
        {
            return DbContext.DbSet.FirstOrDefault(e => e.Id == id);
        }

        public async Task<TEntity> Get(Func<TEntity, bool> expression)
        {
            return DbContext.DbSet.FirstOrDefault(expression);
        }
    }
}
