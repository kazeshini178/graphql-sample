namespace SampleQL.GraphQLTypes
{
    public class Comment
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string CommentDetails { get; set; }
        public int? BookId { get; set; }
        public Rating Rating { get; set; }
    }
}
