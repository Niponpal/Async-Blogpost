using BlogNestS.Models;
using BlogNestS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace BlogNestS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostController : Controller
    {
        private readonly IBlogPostRepository _blogPostRepository;
        public BlogPostController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        public async Task<IActionResult> Index()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            return View(blogPosts);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(Guid Id)
        {
            if(Id== Guid.Empty)
            {
                return View(new BlogPost());
            }
            else
            {
                var data = await _blogPostRepository.GetAsync(Id);
                return View(data);
            }  
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit( Guid Id,BlogPost blogPost)
        {
            if (Id == Guid.Empty)
            {
                    var data = await _blogPostRepository.AddAsync(blogPost);
                    return RedirectToAction("index"); 
            }
            else
            {
                await _blogPostRepository.UpdateAsync(blogPost);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var data = await _blogPostRepository.GetAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await _blogPostRepository.DeleteAsync(id);
            if(data == null) 
            {           
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
