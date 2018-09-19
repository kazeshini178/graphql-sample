using RestSharp;
using SampleQL.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleQL
{
    public class GoodReadsService
    {
        RestClient client;
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

        private async Task<GoodreadsResponse> GetResourceAsync(string resourcePath)
        {
            RestRequest request = new RestRequest(resourcePath);
            var resp = client.Get<GoodreadsResponse>(request);
            return await client.GetAsync<GoodreadsResponse>(request);
        }
    }
}
