using System;
using autofac.example.domain.generic;

namespace autofac.example.domain.models
{
    public class FooModel : IModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
