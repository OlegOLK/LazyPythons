using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Models
{
    public class FridgeRecord : Entity, IFridgeRecord
    {
        public FridgeRecord(Guid id, string name, int votes)
        : base(id)
        {
            Name = name;
            Votes = votes;
        }
        public Guid Id { get; }
        public string Name { get; }
        public int Votes { get; }
    }
}
