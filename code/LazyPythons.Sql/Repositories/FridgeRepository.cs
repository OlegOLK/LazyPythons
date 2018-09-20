using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Repositories;
using LazyPythons.Sql.Data;
using LazyPythons.Sql.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LazyPythons.Sql.Repositories
{
    public class FridgeRepository : SqlRepository, IFridgeRepository
    {
        public FridgeRepository(DbContextOptions<LazyPhytonsContext> settings) : base(settings)
        {
        }

        public async Task<IEnumerable<IFridgeRecord>> GetPropositions()
        {
            List<Data.FridgeRecord> freedgeRecords = null;
            using (var context = CreateLazyPhytonsContext())
            {
                freedgeRecords = await context.FreedgeRecords
                    .Include(x => x.FreedgeRecordsVotingPersons)
                    .AsNoTracking()
                    .ToListAsync()
                    .ConfigureAwait(false);
            }

            if (freedgeRecords == null)
            {
                return Enumerable.Empty<IFridgeRecord>();
            }

            return freedgeRecords.Select(x => x.ToApi());
        }

        public async Task<FridgeVoteResponses> VoteForProposition(string positionName, string user)
        {
            Data.FridgeRecord fridgeRecord = null;
            using (var context = CreateLazyPhytonsContext())
            {
                fridgeRecord = await context.FreedgeRecords
                    .Include(x => x.FreedgeRecordsVotingPersons)
                    .ThenInclude(x => x.VotingPerson)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Name.Equals(positionName, StringComparison.OrdinalIgnoreCase))
                    .ConfigureAwait(false);
            }

            if (fridgeRecord == null)
            {
                return FridgeVoteResponses.Fail;
            }

            var votinPerson = fridgeRecord.FreedgeRecordsVotingPersons.Any(x =>
                x.VotingPerson.User.Equals(user, StringComparison.OrdinalIgnoreCase));

            if (votinPerson)
            {
                return FridgeVoteResponses.AlreadyVoted;
            }

            using (var context = CreateLazyPhytonsContext())
            {
                var dbVotingPerson = context.VotingPersons.Add(new VotingPerson()
                {
                    User = user
                });

                context.FreedgeRecordsVotingPersons.Add(new FridgeRecordsVotingPersons()
                {
                    FreedgeRecordId = fridgeRecord.Id,
                    VotingPersonId = dbVotingPerson.Entity.Id
                });
                await context.SaveChangesAsync().ConfigureAwait(false);
            }


            return FridgeVoteResponses.Ok;
        }

        public async Task<FridgeVoteResponses> VoteForProposition(Guid id, string user)
        {
            Data.FridgeRecord fridgeRecord = null;
            using (var context = CreateLazyPhytonsContext())
            {
                fridgeRecord = await context.FreedgeRecords
                    .Include(x => x.FreedgeRecordsVotingPersons)
                    .ThenInclude(x => x.VotingPerson)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id.Equals(id))
                    .ConfigureAwait(false);
            }

            if (fridgeRecord == null)
            {
                return FridgeVoteResponses.Fail;
            }

            var votinPerson = fridgeRecord.FreedgeRecordsVotingPersons.Any(x =>
                x.VotingPerson.User.Equals(user, StringComparison.OrdinalIgnoreCase));

            if (votinPerson)
            {
                return FridgeVoteResponses.AlreadyVoted;
            }

            using (var context = CreateLazyPhytonsContext())
            {
                var dbVotingPerson = context.VotingPersons.Add(new VotingPerson()
                {
                    User = user
                });

                context.FreedgeRecordsVotingPersons.Add(new FridgeRecordsVotingPersons()
                {
                    FridgeRecord = fridgeRecord,
                    FreedgeRecordId = fridgeRecord.Id,
                    VotingPerson = dbVotingPerson.Entity,
                    VotingPersonId = dbVotingPerson.Entity.Id
                });

                await context.SaveChangesAsync().ConfigureAwait(false);
            }


            return FridgeVoteResponses.Ok;
        }

        public async Task<FridgeAddResponses> AddProposition(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return FridgeAddResponses.Fail;
            }
            using (var context = CreateLazyPhytonsContext())
            {
                var dbfreedgeRecord = await context.FreedgeRecords.AnyAsync(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ConfigureAwait(false);

                if (dbfreedgeRecord)
                {
                    return FridgeAddResponses.AlreadyExist;
                }

                await context.FreedgeRecords.AddAsync(new FridgeRecord()
                {
                    Name = name
                });

                await context.SaveChangesAsync().ConfigureAwait(false);
            }

            return FridgeAddResponses.Ok;
        }
    }
}
