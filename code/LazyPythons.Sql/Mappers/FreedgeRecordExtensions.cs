using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Abstractions.Models;
using LazyPythons.Models;

namespace LazyPythons.Sql.Mappers
{
    public static class FreedgeRecordExtensions
    {
        public static IFridgeRecord ToApi(this Data.FridgeRecord obj)
        {
            return new FridgeRecord(obj.Id, obj.Name, obj.FreedgeRecordsVotingPersons.Count);
        }
    }
}
