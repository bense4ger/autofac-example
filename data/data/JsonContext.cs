using System;
using System.IO;
using System.Collections.Generic;
using autofac.example.data.generic;
using Newtonsoft.Json;

namespace autofac.example.data.data
{
    public class JsonContext<TEntity> : IDbContext<TEntity> where TEntity: IEntity
    {
        public ICollection<TEntity> DbSet => JsonConvert.DeserializeObject<ICollection<TEntity>>(ReadFile());

        private string ReadFile()
        {
            var path = Path.Combine(AppContext.BaseDirectory, $"{typeof(TEntity).Name}.json");
            return File.ReadAllText(path);
        }
    }
}
