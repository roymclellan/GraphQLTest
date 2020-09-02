using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLTest.Data.Entities;
using GraphQLTest.Domain.Account;

namespace API.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(x => x.Name).Description("Name property from the owner object.");
            Field(x => x.Address).Description("Address property from the owner object.");
            Field<ListGraphType<GraphQLTest.API.GraphQL.GraphQLTypes.AccountType>>(
                "account",
                resolve: context => //repository.GetAllAccountsPerOwner(context.Source.Id)); <-- Queries the DB for accounts one-at-a-time per ownerId
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, Account>("GetAccountsByOwnerIds", repository.GetAccountsByOwnerIds);
                    return loader.LoadAsync(context.Source.Id);
                }); // <-- Queries the DB "WHERE OwnerId IN (X,Y,Z)"
        }
    }
}
