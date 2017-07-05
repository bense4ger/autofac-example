using System.Linq;
using System.Reflection;
using Autofac;
using autofac.example.domain.generic;

namespace autofac.example.domain.dependency
{
    public static class DependencyConfig
    {
        public static void Configure(ref ContainerBuilder builder)
        {
            //Configure dependent dependecies...
            data.dependency.DependencyConfig.Configure(ref builder);

            var assembly = typeof(DependencyConfig).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.IsAssignableTo<IDomainService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
