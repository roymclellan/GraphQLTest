using GraphQL.Types;
using GraphQLTest.Data.Entities;
using GraphQLTest.Domain.Type;

namespace GraphQLTest.API.GraphQL.GraphQLTypes
{
    public class TypeType : ObjectGraphType<Type>
    {
        public TypeType()
        {
            Field(x => x.TypeId).Description("Id property from the type object");
            Field(x => x.Name).Description("Descritpion property from the type object");
        }
    }
}
