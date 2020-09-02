using GraphQLTest.Data.Entities.Context;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLTest.Domain.Type
{
    public class TypeRepository : ITypeRepository
    {
        private readonly ApplicationContext _context;

        public TypeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Data.Entities.Type> GetAll() => _context.Type.ToList();
        public Data.Entities.Type GetTypeById(int Id) => _context.Type.FirstOrDefault(x => x.TypeId == Id);
    }
}
