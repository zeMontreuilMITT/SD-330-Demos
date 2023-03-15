using System.ComponentModel.DataAnnotations;

namespace SD_330_Demos.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Notes must be between 5 and 1000 characters long")]
        public string Body { get; set; }

        public int JournalId { get; set; }  
        public virtual Journal Journal { get; set; }
    }
}
