using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using System;
using System.Collections.Generic;

namespace SampleQL.GraphQLTypes
{
    public class CommentsMutation : ObjectGraphType
    {
        private readonly GoodReadsService service;
        
        public CommentsMutation(GoodReadsService goodReadsService)
        {
            service = goodReadsService;

            Name = "CommentsMutations";
            

            Field<CommentType>(
                "addComment",
                arguments: new QueryArguments()
                {
                    new QueryArgument<NonNullGraphType<CommentInputType>> { Name = "comment"}
                },
                resolve: context =>
                {
                    Comment comment = context.GetArgument<Comment>("comment");
                    comment.Id = service.AllComments.Count + 1;
                     
                    return service.AddComment(comment); 
                });
        }
    }

    public class CommentsSubscriptions : ObjectGraphType
    {
        private readonly GoodReadsService service;

        public CommentsSubscriptions(GoodReadsService goodReadsService)
        {
            service = goodReadsService;

            AddField(new EventStreamFieldType
            {
                Name = "commentAddedForBook",
                Type = typeof(CommentType),
                Arguments= new QueryArguments()
                {
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "bookId"}
                },
                Resolver = new FuncFieldResolver<Comment>(ResolveComment),
                Subscriber = new EventStreamResolver<Comment>(Subscribe)
            });
        }

        private Comment ResolveComment(ResolveFieldContext context) => context.Source as Comment;

        private IObservable<Comment> Subscribe(ResolveEventStreamContext context) => service.Comments();
    }
}
