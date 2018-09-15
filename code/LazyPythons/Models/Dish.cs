using System;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Models
{
    public class Dish : Entity, IDish
    {
        public Dish(Guid id, Guid menuId, string linkToImage, string name, DishCategories category)
            : base(id)
        {
            MenuId = menuId;
            LinkToImage = linkToImage;
            Name = name;
            Category = category;
        }

        public Guid MenuId { get; }
       public string LinkToImage { get;  }
       public string Name { get; set; }
       public DishCategories Category { get; }
    }
}
