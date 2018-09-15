using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Sql.Data
{
    public class Dish : Entity
    {
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
        public string LinkToImage { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public DishCategories Category { get; set; }
        public string Notes { get; set; }
    }

}
