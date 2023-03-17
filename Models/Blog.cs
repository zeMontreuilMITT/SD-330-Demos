using System.ComponentModel.DataAnnotations;

namespace SD_330_Demos.Models
{
    // Configure Relationships in ModelBuilder
    // Configure property validation in Annotation
    public class Blog
    {
        public int BlogNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public virtual HashSet<Journal> Journals { get; set; } = new HashSet<Journal>();

        public virtual HashSet<BlogAuthorization> BlogAuthorizations { get; set; } = new HashSet<BlogAuthorization>();
        
    }
}
