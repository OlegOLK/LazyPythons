using System;
using System.Collections.Generic;
using System.Linq;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Models
{
    public class Menu : Entity, IMenu
    {
        public Menu(Guid id, Guid caffeId, string linkToImage, IEnumerable<Guid> dishes, IEnumerable<Guid> beverages) : base(id)
        {
            CaffeId = caffeId;
            if (dishes == null)
            {
                DishIds = Enumerable.Empty<Guid>();
            }

            LinkToImage = linkToImage;
            DishIds = dishes;

            if (beverages == null)
            {
                BeverageIds = Enumerable.Empty<Guid>();
            }

            BeverageIds = beverages;
        }
        public Guid CaffeId { get; }
        public string LinkToImage { get; }
        public IEnumerable<Guid> DishIds { get; }
        public IEnumerable<Guid> BeverageIds { get; }
    }
}
