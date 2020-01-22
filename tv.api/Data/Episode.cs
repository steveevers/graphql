namespace tv.api.Data
{
    public class Episode
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public string Name { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

    }
}
