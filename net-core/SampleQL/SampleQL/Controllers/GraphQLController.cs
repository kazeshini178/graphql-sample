using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SampleQL.DataTypes;
using SampleQL.GraphQLTypes;

namespace SampleQL.Controllers
{
    //[Route("api/GraphQL")]
    //[Route("GraphQL")]
    //public class GraphQLController : Controller
    //{
    //    private readonly GoodReadsQuery goodReadsQuery;

    //    public GraphQLController(GoodReadsQuery goodReadsQuery)
    //    {
    //        this.goodReadsQuery = goodReadsQuery;
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> Get()
    //    {
    //        var schema = new Schema
    //        {
    //            Query = goodReadsQuery
    //        };

    //        var result = await new DocumentExecuter()
    //            .ExecuteAsync(_ =>
    //            {
    //                _.Schema = schema;
    //                _.Query = $"query {{{Request.Query.Keys.ElementAt(0)}}}";
    //            });

    //        var json = new DocumentWriter(indent: true).Write(result);
    //        return Content(json);
    //    }

    //    [HttpGet("{type}")]
    //    public async Task<IActionResult> GetTypeInfo(string type)
    //    {
    //        var schema = new Schema
    //        {
    //            Query = goodReadsQuery
    //        };

    //        var result = await new DocumentExecuter()
    //            .ExecuteAsync(_ =>
    //            {
    //                _.Schema = schema;
    //                _.Query = $"query {{__type(name:\"{type}\"){{name,description,ofType{{name}},fields(includeDeprecated: true){{name,isDeprecated,deprecationReason,type{{name,kind,ofType{{name}}}}}}}}}}";
    //                //_.Query = $"query {{{Request.Query.Keys.ElementAt(0)}}}";
    //            });

    //        var json = new DocumentWriter(indent: true).Write(result);
    //        return Content(json);
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Post([FromBody] GraphQLRequest request)
    //    {
    //        try
    //        {

    //            var schema = new Schema
    //            {
    //                Query = goodReadsQuery,
    //                Mutation = new CommentsMutation(),
    //            };

    //            var result = await new DocumentExecuter()
    //                .ExecuteAsync(_ =>
    //                {
    //                    _.Schema = schema;
    //                    _.Query = request.Query;
    //                    _.Inputs = request.Variables;
    //                });

    //            var json = new DocumentWriter(indent: true).Write(result);
    //            return Content(json,"application/json");
    //        }
    //        catch (Exception e)
    //        {
    //            return Content(e.Message);
    //        }
    //    }
    //}
}