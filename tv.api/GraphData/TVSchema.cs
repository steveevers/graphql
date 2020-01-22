using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace tv.api.GraphData
{
    public class TVSchema : Schema
    {
        public ISchema GraphQLSchema { get; private set; }

        public TVSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<Query>();
            //Mutation = provider.GetRequiredService<Mutation>();
        }
    }
}
