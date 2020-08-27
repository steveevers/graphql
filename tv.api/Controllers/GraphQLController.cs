using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using tv.api.GraphData;

namespace tv.api.Controllers
{
    [ApiController]
    [Route("graphql")]
    public class GraphQLController : ControllerBase
    {
        private TVSchema schema;
        private IDocumentExecuter documentExecutor;

        public GraphQLController(IDocumentExecuter documentExecutor, TVSchema schema)
        {
            this.documentExecutor = documentExecutor;
            this.schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLModel query)
        {
            var result = await documentExecutor
                .ExecuteAsync(new ExecutionOptions { Schema = schema, Query = query.Query })
                .ConfigureAwait(false);

            if (result.Errors?.Count() > 0)
                return BadRequest();
                
            return Ok(result.Data);
        }
    }
}
