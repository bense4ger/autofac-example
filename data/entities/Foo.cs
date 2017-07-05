using System;
using autofac.example.data.generic;

namespace autofac.example.data.entities
{
    public class Foo : IEntity
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
