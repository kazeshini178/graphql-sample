using RestSharp;
using SampleQL.DataTypes;
using SampleQL.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace SampleQL
{
    public class GoodReadsService
    {
        private readonly ISubject<Comment> _commentStream = new ReplaySubject<Comment>(5);

        private RestClient client;

        public List<Comment> AllComments { get; } = new List<Comment>();

        public GoodReadsService()
        {
            client = new RestClient("https://www.goodreads.com/");
            client.DefaultParameters.Clear();

            client.AddDefaultParameter("key", Environment.GetEnvironmentVariable("API_KEY"), ParameterType.QueryString);
            client.AddDefaultHeader("accept", "application/xml");
        }

        public async Task<Author> GetAuthor(int id)
        {
            GoodreadsResponse result = await GetResourceAsync($"author/show/{id}");
            return result.Author;
        }

        public async Task<Book> GetBook(int id)
        {
            GoodreadsResponse result = await GetResourceAsync($"book/show/{id}");
            return result.Book;
        }

        public Comment AddComment(Comment comment)
        {
            AllComments.Add(comment);
            _commentStream.OnNext(comment);
            return comment;
        }

        public Comment GetComment(int id) => AllComments.First(c => c.Id == id);
        public IEnumerable<Comment> GetCommentsForBook(int bookId) => AllComments.Where(c => c.BookId == bookId);
        public IObservable<Comment> Comments() => _commentStream.AsObservable();

        private async Task<GoodreadsResponse> GetResourceAsync(string resourcePath)
        {
            RestRequest request = new RestRequest(resourcePath);
            var resp = client.Get<GoodreadsResponse>(request);
            return await client.GetAsync<GoodreadsResponse>(request);
        }
    }
}
