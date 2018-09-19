using GraphQL.Types;
using SampleQL.DataTypes;
using System;

namespace SampleQL.GraphQLTypes
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = nameof(Book);

            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Title);
            Field(x => x.Authors, type: typeof(ListGraphType<AuthorType>));
            Field(x => x.AverageRating);
            Field(x => x.Description);
            Field(x => x.EditionInformation);
            Field(x => x.Format);
            Field(x => x.ImageUrl);
            Field(x => x.Isbn);
            Field(x => x.Isbn13);
            Field(x => x.LargeImageUrl);
            Field(x => x.Link);
            Field(x => x.NumPages, type: typeof(IntGraphType));
            Field(x => x.PublicationDay, type: typeof(IntGraphType));
            Field(x => x.PublicationMonth, type: typeof(IntGraphType));
            Field(x => x.PublicationYear, type: typeof(IntGraphType));
            Field(typeof(StringGraphType), "PublicationDate", resolve: x => $"{x.Source.PublicationYear}-{x.Source.PublicationMonth}-{x.Source.PublicationDay}");
            Field(x => x.Published, type: typeof(IntGraphType));
            Field(x => x.Publisher);
            Field(x => x.RatingsCount);
            Field(x => x.SmallImageUrl);
            Field(x => x.TextReviewsCount, type: typeof(IntGraphType));
            Field(x => x.TitleWithoutSeries);
            Field(x => x.Url);

            Interface<BookInterface>();
        }
    }
}