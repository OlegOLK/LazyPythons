using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Abstractions.Models;

namespace LPCommandExecutor.ViewModels
{
    public class MenuViewModel
    {
        public string LinkToImage { get; set; }
        public string CaffeName { get; set; }
        public IEnumerable<IDish> Dishes { get; set; }
        public IEnumerable<IBeverage> Beverages { get; set; }
    }
}
