namespace SeoBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
