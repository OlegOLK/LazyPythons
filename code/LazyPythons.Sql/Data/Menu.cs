using System;
using System.Collections.Generic;
using System.Text;

namespace LazyPythons.Sql.Data
{
    public class Menu : Entity
    {
        public Guid CaffeId { get; set; }

        public Caffe Caffe { get; set; }

        public string Notes { get; set; }

        public List<Dish> Dishes { get; set; }
        public List<Beverage> Beverages { get; set; }


        public Menu()
        {
            Dishes = new List<Dish>();
            Beverages = new List<Beverage>();
        }
    }
}
