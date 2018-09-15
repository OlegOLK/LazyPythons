using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LazyPythons.Sql.Data
{
    public class Beverage : Entity
    {
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
        public string LinkToImage { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
