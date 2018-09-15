using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace LazyPythons.Sql.Data
{
    public class Caffe : Entity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public string Notes { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public short Rating { get; set; }
        public string LinkToImage { get; set; }
        public Menu Menu { get; set; }
        public bool IsFreeBeverages { get; set; }
        public int Lunch2Price { get; set; }
        public int Lunch3Price { get; set; }
    }
}
