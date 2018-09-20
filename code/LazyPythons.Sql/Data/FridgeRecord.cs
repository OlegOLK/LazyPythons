using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LazyPythons.Sql.Data
{
    public class FridgeRecord : Entity
    {
        [Required]
        public string Name { get; set; }
        public List<FridgeRecordsVotingPersons> FreedgeRecordsVotingPersons { get; set; }

        public FridgeRecord()
        {
            FreedgeRecordsVotingPersons = new List<FridgeRecordsVotingPersons>();
        }
    }
}
