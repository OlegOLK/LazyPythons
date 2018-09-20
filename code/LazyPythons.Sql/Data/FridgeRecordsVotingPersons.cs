using System;
using System.Collections.Generic;
using System.Text;

namespace LazyPythons.Sql.Data
{
    public class FridgeRecordsVotingPersons
    {
        public Guid FreedgeRecordId { get; set; }
        public FridgeRecord FridgeRecord { get; set; }

        public Guid VotingPersonId { get; set; }
        public VotingPerson VotingPerson { get; set; }
    }
}
