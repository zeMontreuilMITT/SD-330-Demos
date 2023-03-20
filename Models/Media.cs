using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SD_330_Demos.Models
{

    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public int MediaCollectionId { get; set; }
    }

    public class Song : Media
    {
        public Album Album { get; set; }

        public Song() : base()
        {

        }

        public Song(string title, int duration, Album album)
        {
            Title = title;
            DurationSeconds = duration;
            Album = album;
        }
    }

    public class Episode: Media
    {
        public Podcast Podcast { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AirDate { get; set; }
    }
}
