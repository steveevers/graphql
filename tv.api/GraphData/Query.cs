using GraphQL.Types;
using System.Linq;
using tv.api.Data;

namespace tv.api.GraphData
{
    public class Query : ObjectGraphType
    {
        private TVDbContext dbContext;

        public Query(TVDbContext dbContext)
        {
            this.dbContext = dbContext;

            Name = "Query";
            Field<ListGraphType<ShowType>>(
                "shows", 
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" },
                    new QueryArgument<IntGraphType> { Name = "skip" },
                    new QueryArgument<IntGraphType> { Name = "take" }
                ),
                resolve: context => {
                    var id = context.GetArgument<int>("id");
                    var skip = context.GetArgument<int>("skip");
                    var take = context.GetArgument<int>("take");

                    if (id > 0)
                        return GetShowById(id);

                    return GetShows(skip, take);
                });
        }

        public IQueryable<Show> GetShowById(int id)
        {
            return dbContext.Shows.Where(s => s.Id == id);
        }

        public IQueryable<Show> GetShows(int skip = 0, int take = 0)
        {
            IQueryable<Show> q = dbContext.Shows;

            if (skip > 0)
                q = q.Skip(skip);

            if (take > 0)
                q = q.Take(take);

            return q;
        }
    }
}
