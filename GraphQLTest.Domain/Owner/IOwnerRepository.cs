using System.Collections.Generic;
using Entities = GraphQLTest.Data.Entities;

namespace GraphQLTest.Domain.Owner
{
    public interface IOwnerRepository
    {
        IEnumerable<Entities.Owner> GetAll();
        Entities.Owner GetById(int Id);
        Entities.Owner CreateOwner(Entities.Owner owner);
        Entities.Owner UpdateOwner(Entities.Owner dbOwner, Entities.Owner owner);
        void DeleteOwner(Entities.Owner owner);
    }
}
