using System;
using System.Collections.Generic;
using System.Text;

namespace LazyPythons.Abstractions.Models
{
    public interface IFridgeRecord : IEntity
    {
        string Name { get; }
        int Votes { get; }
    }
}
