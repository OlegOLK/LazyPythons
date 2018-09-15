using System;

namespace LazyPythons.Abstractions.Models
{
    public interface IBeverage
    {
        Guid MenuId { get; }
        string LinkToImage { get; }
        string Name { get; }
    }
}
