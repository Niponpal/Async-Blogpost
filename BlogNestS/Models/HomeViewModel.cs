namespace BlogNestS.Models
{
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> blogPosts { get; set; }
        public IEnumerable<Tag> tags { get; set; }
    }
}
