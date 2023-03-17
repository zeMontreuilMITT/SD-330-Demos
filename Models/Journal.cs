using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SD_330_Demos.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public int BlogNumber { get; set; }
        public virtual Blog? Blog { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
