using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleQL.GraphQLTypes
{
    public class QLSchema : Schema
    {
        public QLSchema(GoodReadsQuery query, CommentsMutation mutations, CommentsSubscriptions subscriptions)
        {
            Query = query;
            Mutation = mutations;
            Subscription = subscriptions;
        }
    }
}
