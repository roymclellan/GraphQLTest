using API.GraphQL.GraphQLTypes;
using GraphQL;
using GraphQL.Types;
using GraphQLTest.API.GraphQL.GraphQLTypes;
using GraphQLTest.Domain.Account;
using GraphQLTest.Domain.Owner;
using GraphQLTest.Domain.Type;

namespace API.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(
            IOwnerRepository ownerRepository, 
            IAccountRepository accountRepository,
            ITypeRepository typeRepository)
        {
            Field<ListGraphType<OwnerType>>(
               "owners",
               resolve: context => ownerRepository.GetAll());

            Field<OwnerType>(
                "owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context =>
                {
                    if (!int.TryParse(context.GetArgument<string>("ownerId"), out int id))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for Id"));
                        return null;
                    }

                    return ownerRepository.GetById(id);
                }
            );

            Field<ListGraphType<AccountType>>(
                "account",
                resolve: context => accountRepository.GetAll());

            Field<ListGraphType<TypeType>>(
                "type",
                resolve: context => typeRepository.GetAll());
        }
    }
}
