using System.Collections.Generic;

namespace tv.api.Data
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Show()
        {
            Episodes = new List<Episode>();
        }

        public ICollection<Episode> Episodes { get; set; }
    }
}
