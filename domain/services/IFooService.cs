using System;
using System.Threading.Tasks;
using autofac.example.domain.models;

namespace autofac.example.domain.services
{
    public interface IFooService
    {
        Task<FooModel> GetById(Guid id);
        Task<FooModel> GetByMessage(string message);
    }
}
