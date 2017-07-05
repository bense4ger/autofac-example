using System;
using System.Collections.Generic;
using System.IO;
using autofac.example.data.extensions;
using autofac.example.data.generic;

namespace autofac.example.data.data
{
    public class CsvContext<TEntity> : IDbContext<TEntity> where TEntity : IEntity
    {
        public ICollection<TEntity> DbSet => ReadFile().ToEntityCollection<TEntity>();

        private string[] ReadFile()
        {
            var path = Path.Combine(AppContext.BaseDirectory, $"{typeof(TEntity).Name}.csv");
            return File.ReadAllLines(path);
        }
    }
}
