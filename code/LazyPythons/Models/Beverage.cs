using System;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Models
{
    public class Beverage : Entity, IBeverage
    {
        public Beverage(Guid id, Guid menuId, string linkToImage, string name)
            : base(id)
        {
            MenuId = menuId;
            LinkToImage = linkToImage;
            Name = name;
        }

        public Guid MenuId { get; }
        public string LinkToImage { get; }
        public string Name { get; }
    }
}
