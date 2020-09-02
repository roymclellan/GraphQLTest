using API.GraphQL.GraphQLQueries;
using GraphQL;
using GraphQL.Types;
using GraphQLTest.API.GraphQL.GraphQLQueries;

namespace API.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}
