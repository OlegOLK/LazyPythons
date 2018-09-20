using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LazyPythons.Sql.Data
{
    public class VotingPerson : Entity
    {
        [Required]
        public string User { get; set; }
        public List<FridgeRecordsVotingPersons> FridgeRecordsVotingPersons { get; set; }

        public VotingPerson()
        {
            FridgeRecordsVotingPersons = new List<FridgeRecordsVotingPersons>();
        }
    }
}
