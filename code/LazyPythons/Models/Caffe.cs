using System;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Models
{
    public class Caffe : Entity, ICaffe
    {
        public Caffe(Guid id,
            string name,
            string description,
            long latitude,
            long longitude,
            short rating,
            string linkToImage,
            Guid menuId,
            bool isFreeBeverages,
            int lunch2Price,
            int lunch3Price)
        : base(id)
        {
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            Rating = rating;
            LinkToImage = linkToImage;
            MenuId = menuId;
            IsFreeBeverages = isFreeBeverages;
            Lunch2Price = lunch2Price;
            Lunch3Price = lunch3Price;
        }
        public string Name { get; }
        public string Description { get; }
        public long Latitude { get; }
        public long Longitude { get; }
        public short Rating { get; }
        public string LinkToImage { get; }
        public Guid MenuId { get; }
        public bool IsFreeBeverages { get; }
        public int Lunch2Price { get; }
        public int Lunch3Price { get; }
    }
}
