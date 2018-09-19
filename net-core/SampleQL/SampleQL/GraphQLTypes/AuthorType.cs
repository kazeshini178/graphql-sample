using GraphQL.Types;
using SampleQL.DataTypes;
using System.Linq;

namespace SampleQL.GraphQLTypes
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = nameof(Author);

            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Name);
            Field(x => x.About);
            Field(x => x.AverageRating);
            Field(x => x.Born);
            Field(x => x.Died);
            Field(nameof(Author.FansCount), x => x.FansCount.Value);
            Field(x => x.Gender);
            Field(x => x.GoodreadsAuthor, nullable: true);
            Field(x => x.Hometown);
            Field(x => x.ImageUrl);
            Field(x => x.Influences);
            Field(x => x.LargeImageUrl);
            Field(x => x.Link);
            Field(x => x.RatingsCount);
            Field(x => x.Role);
            Field(x => x.SmallImageUrl);
            //Field<StringGraphType>(nameof(Author.SmallImageUrl), resolve: x => x.Source.SmallImageUrl, deprecationReason: "Big url is good enough");
            Field(x => x.WorksCount, type: typeof(IntGraphType));


            Field(typeof(ListGraphType<BookType>),
                nameof(Author.Books),
                description: "Books by this author",
                arguments: new QueryArguments() {
                    new QueryArgument<IntGraphType>() {
                        Name = "limit"
                    }
                },
                resolve: x => x.GetArgument<int?>("limit").HasValue ? x.Source.Books.Take(x.GetArgument<int>("limit")) : x.Source.Books, deprecationReason: "Cause who reads books!");
        }
    }
}