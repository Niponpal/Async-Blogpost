using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BlogNestS.Migrations
{
    public class AddBlogPostRequest
    {
        public string Heading { get; set; }
        [Display(Name = "Page Title")]
        public string PageTitle { get; set; }
        public string Content { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Feature Image URL")]
        public string FeaturedImageUrl { get; set; }
        [Display(Name = "URL Handle")]
        public string UrlHandle { get; set; }
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        //display tags
        public IEnumerable<SelectListItem> Tags { get; set; }
        //collect tag
        public string[] SelectedTags { get; set; } = Array.Empty<string>();
    }
}
