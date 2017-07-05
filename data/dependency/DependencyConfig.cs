using autofac.example.data.data;
using autofac.example.data.repositories;
using Autofac;

namespace autofac.example.data.dependency
{
    public static class DependencyConfig
    {
        public static void Configure (ref ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(CsvContext<>))
                   .As(typeof(IDbContext<>))
                   .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerLifetimeScope();
        }
    }
}
