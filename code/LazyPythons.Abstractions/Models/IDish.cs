using System;

namespace LazyPythons.Abstractions.Models
{
    public interface IDish : IEntity
    {
        Guid MenuId { get; }
        string LinkToImage { get; }
        string Name { get; }
        DishCategories Category { get; }
    }
}
