using System;
using System.Threading.Tasks;
using autofac.example.data.entities;
using autofac.example.data.repositories;
using autofac.example.domain.generic;
using autofac.example.domain.models;

namespace autofac.example.domain.services
{
    public class FooService : IFooService, IDomainService
    {
        public FooService(IRepository<Foo> fooRepo)
        {
            FooRepo = fooRepo;
        }

        private IRepository<Foo> FooRepo { get; }

        public async Task<FooModel> GetById(Guid id)
        {
            var entity = await FooRepo.Get(id);
            return new FooModel
            {
                Id = entity.Id,
                Message = entity.Message
            };
        }

        public async Task<FooModel> GetByMessage(string message)
        {
            var entity = await FooRepo.Get(e => e.Message == message);
			return new FooModel
			{
				Id = entity.Id,
				Message = entity.Message
			};
        }
    }
}
