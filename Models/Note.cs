using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SD_330_Demos.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int JournalId { get; set; }
        public Journal Journal { get; set; }
    }
}
