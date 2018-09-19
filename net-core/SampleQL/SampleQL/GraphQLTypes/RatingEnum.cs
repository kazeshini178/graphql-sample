using GraphQL.Types;

namespace SampleQL.GraphQLTypes
{
    public class RatingEnum : EnumerationGraphType
    {
        public RatingEnum()
        {
            Name = "Rating";
            Description = "Rating for the given book";

            AddValue(new EnumValueDefinition()
            {
                Name = nameof(Rating.Great),
                Value = Rating.Great
            });
            AddValue(new EnumValueDefinition()
            {
                Name = nameof(Rating.Good),
                Value = Rating.Good
            });
            AddValue(new EnumValueDefinition()
            {
                Name = nameof(Rating.Fair),
                Value = Rating.Fair
            });
            AddValue(new EnumValueDefinition()
            {
                Name = nameof(Rating.Ok),
                Value = Rating.Ok
            });
            AddValue(new EnumValueDefinition()
            {
                Name = nameof(Rating.Bad),
                Value = Rating.Bad
            });
            AddValue(new EnumValueDefinition()
            {
                Name = nameof(Rating.None),
                Value = Rating.None
            });
        }
    }
}
