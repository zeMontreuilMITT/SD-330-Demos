using System.ComponentModel.DataAnnotations;

namespace SD_330_Demos.Models
{
    public class Journal
    {
        public int Id { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Journal must have a body of at least 20 characters")]
        public string Body { get; set; }

        public virtual Blog Blog { get; set; }
        public int BlogId { get; set; }
        public virtual HashSet<Note> Notes { get; set; }
    }
}
