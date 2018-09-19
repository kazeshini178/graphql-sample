using GraphQL.Types;

namespace SampleQL.GraphQLTypes
{
    public class GoodReadsQuery : ObjectGraphType
    {
        GoodReadsService service;

        public GoodReadsQuery(GoodReadsService goodReadsService)
        {
            service = goodReadsService;

            Field<AuthorType>("author",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>()
                    {
                        Name = "id"
                    }
                ),
                resolve: context => service.GetAuthor(context.GetArgument<int>("id")));
            Field<BookType>("book",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>()
                    {
                        Name = "id"
                    }
                ),
                resolve: context => service.GetBook(context.GetArgument<int>("id")));
            Field<CommentType>("comment");
        }
    }
}