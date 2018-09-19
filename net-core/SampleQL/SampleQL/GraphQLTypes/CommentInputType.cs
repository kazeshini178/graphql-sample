using GraphQL.Types;

namespace SampleQL.GraphQLTypes
{
    public class CommentInputType : InputObjectGraphType
    {
        public CommentInputType()
        {
            Name = "CommentInput";

            Field<NonNullGraphType<StringGraphType>>("user");
            Field<NonNullGraphType<StringGraphType>>("commentDetails");
            Field<IntGraphType>("bookId");
            Field<RatingEnum>("rating");
        }
    }
}
