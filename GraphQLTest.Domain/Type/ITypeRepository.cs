using System.Collections.Generic;
using Entities = GraphQLTest.Data.Entities;

namespace GraphQLTest.Domain.Type
{
    public interface ITypeRepository
    {
        IEnumerable<Entities.Type> GetAll();
        Entities.Type GetTypeById(int Id);

    }
}
