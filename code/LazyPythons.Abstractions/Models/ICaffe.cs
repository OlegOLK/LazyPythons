using System;

namespace LazyPythons.Abstractions.Models
{
    public interface ICaffe : IEntity
    {
        string Name { get; }
        string Description { get; }
        long Latitude { get; }
        long Longitude { get; }
        short Rating { get; }
        string LinkToImage { get; }
        Guid MenuId { get; }
        bool IsFreeBeverages { get; }
        int Lunch2Price { get; }
        int Lunch3Price { get; }
        int DistanceFromOffice { get; }
    }
}
