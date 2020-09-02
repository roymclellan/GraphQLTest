using GraphQL.Types;
using GraphQLTest.Data.Entities;
using GraphQLTest.Domain.Type;

namespace GraphQLTest.API.GraphQL.GraphQLTypes
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType(ITypeRepository repository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(x => x.Description).Description("Description property from the account object.");
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field<TypeType>(
                "type",
                resolve: context => repository.GetTypeById(context.Source.TypeId));
        }
    }
}
