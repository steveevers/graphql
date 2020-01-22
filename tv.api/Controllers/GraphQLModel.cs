using Newtonsoft.Json.Linq;

namespace tv.api.Controllers
{
    public class GraphQLModel
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
