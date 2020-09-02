using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = GraphQLTest.Data.Entities;

namespace GraphQLTest.Domain.Account
{
    public interface IAccountRepository
    {
        IEnumerable<Entities.Account> GetAllAccountsPerOwner(int ownerId);
        Task<ILookup<int, Entities.Account>> GetAccountsByOwnerIds(IEnumerable<int> ownerIds);
        IEnumerable<Entities.Account> GetAll();
    }
}
