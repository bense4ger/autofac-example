using System;
using Autofac;
using autofac.example.domain.dependency;
using autofac.example.domain.services;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            DependencyConfig.Configure(ref builder);

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var theId = new Guid("81b29827-eeeb-47aa-a2f1-124fb491fd06");
                var service = scope.Resolve<IFooService>();

                var result = service.GetById(theId).Result;

                Console.WriteLine(result.Message);
                Console.ReadKey();
            }
        }
    }
}
