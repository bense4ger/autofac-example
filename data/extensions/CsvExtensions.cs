using System;
using System.Reflection;
using System.Collections.Generic;
using autofac.example.data.generic;
using System.Linq;

namespace autofac.example.data.extensions
{
    public static class CsvExtensions
    {
        public static ICollection<TEntity> ToEntityCollection<TEntity>(this string[] csv) where TEntity : IEntity
        {
            var collection = new List<TEntity>();

            var headers = csv[0].Split(',');
            var props = typeof(TEntity).GetTypeInfo().DeclaredProperties;

            for (var i = 1; i < csv.Length; ++i)
            {
                var entity = Activator.CreateInstance<TEntity>();

                var parts = csv[i].Split(',');
                for (var j = 0; j < parts.Length; ++j)
                {
                    var prop = props.FirstOrDefault(p => p.Name == headers[j]);
                    var val = prop.PropertyType == typeof(Guid) ? (object)Guid.Parse(parts[j]) : parts[j];

                    prop.SetValue(entity, val);
                }

                collection.Add(entity);
            }

            return collection;
        }
    }
}
