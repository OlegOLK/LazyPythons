using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Models
{
    public class Entity : IEntity
    {
        public Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
