using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using autofac.example.data.generic;

namespace autofac.example.data.repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Get(Guid id);
        Task<TEntity> Get(Func<TEntity, bool> expression);
    }
}
