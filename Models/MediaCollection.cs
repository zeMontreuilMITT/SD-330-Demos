namespace SD_330_Demos.Models
{
    public class MediaCollection
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Album: MediaCollection
    {
        public HashSet<Song> Songs { get; set; } = new HashSet<Song> { };

        public Album()
        {

        }


        public Album(string title)
        {
            Title = title;
        }
    }

    public class Podcast: MediaCollection
    {
        public HashSet<Episode> Episodes { get; set; } = new HashSet<Episode> { };
    }
}
