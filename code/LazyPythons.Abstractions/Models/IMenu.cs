using System;
using System.Collections.Generic;

namespace LazyPythons.Abstractions.Models
{
    public interface IMenu : IEntity 
    {
        Guid CaffeId { get; }
        IEnumerable<Guid> DishIds { get; }
        IEnumerable<Guid> BeverageIds { get; }
    }
}
