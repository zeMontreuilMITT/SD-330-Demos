namespace SD_330_Demos.Models
{
    public class BlogAuthorization
    {
        public int Id { get; set; }
        public int BlogNumber { get; set; }
        public virtual Blog Blog { get; set; }


        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
