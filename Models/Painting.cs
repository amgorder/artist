using artist.Model;

namespace artist.Models
{
    public class Painting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}