using GraphQL.Types;

namespace SampleQL.GraphQLTypes
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            GoodReadsService service = new GoodReadsService();
            Name = nameof(Comment);

            Field(x => x.Id);
            Field(x => x.User);
            Field(x => x.CommentDetails);
            Field(x => x.BookId, nullable: true);
            Field(x => x.Rating, type: typeof(RatingEnum));
            Field(typeof(BookType), "Book", resolve:
                ctx => service.GetBook(ctx.Source.BookId.Value));
        }
    }
}
