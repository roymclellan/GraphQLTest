using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = GraphQLTest.Data.Entities;

namespace GraphQLTest.Domain.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Entities.Context.ApplicationContext _context;

        public AccountRepository(Entities.Context.ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, Entities.Account>> GetAccountsByOwnerIds(IEnumerable<int> ownerIds)
        {
            var accounts = await _context.Account.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }

        public IEnumerable<Entities.Account> GetAll() => _context.Account.ToList();

        public IEnumerable<Entities.Account> GetAllAccountsPerOwner(int ownerId) => _context.Account
            .Where(a => a.OwnerId.Equals(ownerId))
            .ToList();
    }
}
