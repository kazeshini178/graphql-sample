using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL; 

namespace SampleQL.DataTypes
{
    public class GraphQLRequest
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public Inputs Variables { get; set; } // TODO: After working version look at using InputType
    }
}
