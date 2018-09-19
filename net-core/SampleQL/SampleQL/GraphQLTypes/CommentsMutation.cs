using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleQL.GraphQLTypes
{
    public class CommentsMutation : ObjectGraphType
    {
        public List<Comment> Comments { get; set; }

        public CommentsMutation()
        {
            Name = "CommentsMutations";

            Comments = new List<Comment>();

            Field<CommentType>(
                "addComment",
                arguments: new QueryArguments()
                {
                    new QueryArgument<NonNullGraphType<CommentInputType>> { Name = "comment"}
                },
                resolve: context =>
                {
                    Comment comment = context.GetArgument<Comment>("comment");
                    Comments.Add(comment);
                    comment.Id = Comments.Count;
                    return comment;
                });
        }
    }

    public class CommentsSubscriptions : ObjectGraphType
    {

    }
}
