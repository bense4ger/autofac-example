using System.Collections.Generic;
using autofac.example.data.generic;

namespace autofac.example.data.data
{
    public interface IDbContext<TEntity> where TEntity: IEntity
    {
        ICollection<TEntity> DbSet { get; }
    }
}
