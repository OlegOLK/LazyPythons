using System;
using System.Collections.Generic;
using System.Linq;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Models
{
    public class Menu : Entity, IMenu
    {
        public Menu(Guid id, Guid caffeId, IEnumerable<Guid> dishIds, IEnumerable<Guid> beverageIds) : base(id)
        {
            CaffeId = caffeId;
            if (dishIds == null)
            {
                DishIds = Enumerable.Empty<Guid>();
            }

            DishIds = dishIds;

            if (beverageIds == null)
            {
                BeverageIds = Enumerable.Empty<Guid>();
            }

            BeverageIds = beverageIds;
        }
        public Guid CaffeId { get; }
        public IEnumerable<Guid> DishIds { get; }
        public IEnumerable<Guid> BeverageIds { get; }
    }
}
