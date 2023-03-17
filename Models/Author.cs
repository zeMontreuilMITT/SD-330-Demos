namespace SD_330_Demos.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        // authors can only publish on blogs they are authorized for
        // and they are associated with the Journals that they write

        public virtual HashSet<BlogAuthorization> AuthorizedBlogs { get; set; } = new HashSet<BlogAuthorization>();

        public virtual HashSet<Journal> Journals { get; set; } = new HashSet<Journal> { };
    }
}
