using System.ComponentModel.DataAnnotations;

namespace SD_330_Demos.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 characters long")]
        public string Title { get; set; }


        [Required]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Description must be between 20 and 1000 characters")]
        public string Description { get; set; }


        public virtual HashSet<Journal> Journals { get; set; }
    }
}
