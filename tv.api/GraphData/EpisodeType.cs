using GraphQL.Types;
using tv.api.Data;

namespace tv.api.GraphData
{
    public class EpisodeType : ObjectGraphType<Episode>
    {
        public EpisodeType(TVDbContext dbContext)
        {
            Field(e => e.Id).Description("Episode Id");
            Field(e => e.Name).Description("Episode Title");
            Field(e => e.SeasonNumber).Description("Which season the episode aired in");
            Field(e => e.EpisodeNumber).Description("The episode number for the season");
        }
    }
}
