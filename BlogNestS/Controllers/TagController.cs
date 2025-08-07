using BlogNestS.Models;
using BlogNestS.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace BlogNestS.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;
        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<IActionResult> Index()
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            return View(tags);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View(new Tag());
            }
            else
            {
                var data = await _tagRepository.GetAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Guid id, Tag tag)
        {
            if (id == Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var data = await _tagRepository.AddAsync(tag);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var data = await _tagRepository.UpdateAsync(tag);
                return RedirectToAction("Index");
            }
            return View(tag);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var data = await _tagRepository.GetAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await _tagRepository.DeleteAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
