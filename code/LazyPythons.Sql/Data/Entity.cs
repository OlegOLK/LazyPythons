using System;
using System.Collections.Generic;
using System.Text;

namespace LazyPythons.Sql.Data
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
