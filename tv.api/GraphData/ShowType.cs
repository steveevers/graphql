using GraphQL.Types;
using System.Linq;
using tv.api.Data;

namespace tv.api.GraphData
{
    public class ShowType : ObjectGraphType<Show>
    {
        public ShowType(TVDbContext dbContext)
        {
            Field(s => s.Id).Description("Show Id");
            Field(s => s.Name, nullable: false).Description("Show Title");

            Field<ListGraphType<EpisodeType>>(
                name: "episodes",
                description: "All episodes",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "skip" },
                    new QueryArgument<IntGraphType> { Name = "take" },
                    new QueryArgument<IntGraphType> { Name = "season" }
                ),
                resolve: context =>
                {
                    var skip = context.GetArgument<int>("skip");
                    var take = context.GetArgument<int>("take");
                    var season = context.GetArgument<int>("season");

                    IQueryable<Episode> es = dbContext
                        .Episodes
                        .Where(e => e.ShowId == context.Source.Id);

                    if (season > 0)
                        es = es.Where(e => e.SeasonNumber == season);

                    if (skip > 0)
                        es = es.Skip(skip);

                    if (take > 0)
                        es = es.Take(take);

                    return es;
                });
        }
    }
}
