using GraphQL.Types;
using SampleQL.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleQL.GraphQLTypes
{
    public class BookInterface : InterfaceGraphType<Book>
    {
        public BookInterface()
        {
            Field(m => m.Id);
            Field(m => m.Title);
            Field(m => m.TitleWithoutSeries);
            Field(m => m.Link);
            Field(m => m.SmallImageUrl);
            Field(m => m.ImageUrl);
            Field(x => x.NumPages, type: typeof(IntGraphType));
            Field(m => m.Isbn);
            Field(m => m.Isbn13);
            Field(typeof(IntGraphType), "work", resolve: (ctx) => ctx.Source.Work.Id);
            Field(m => m.AverageRating);
            Field(m => m.RatingsCount);
            Field(x => x.PublicationDay, type: typeof(IntGraphType));
            Field(x => x.PublicationMonth, type: typeof(IntGraphType));
            Field(x => x.PublicationYear, type: typeof(IntGraphType));
            Field(typeof(DateGraphType), "PublicationDate", resolve: x => new DateTime(int.Parse(x.Source.PublicationYear), int.Parse(x.Source.PublicationMonth), int.Parse(x.Source.PublicationDay), 0, 0, 0, DateTimeKind.Utc));
            Field(x => x.Authors, type: typeof(ListGraphType<AuthorType>));
        }
    }
}
