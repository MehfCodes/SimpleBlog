using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models.Domain;
using SimpleBlog.Repository;

namespace SimpleBlog.Controllers
{
    [Route("tags")]
    public class TagController : Controller
    {
        private readonly ITagRepository tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        // GET: /tags
        public async Task<IActionResult> Index()
        {
            var tags = await tagRepository.GetAllAsync();
            return View(tags);
        }

        // GET: /tags/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var tag = await tagRepository.GetByIdAsync(id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        // GET: /tags/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /tags/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                await tagRepository.AddAsync(tag);
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }

        // GET: /tags/edit/{id}
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetByIdAsync(id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        // POST: /tags/edit/{id}
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Tag tag)
        {
            if (id != tag.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await tagRepository.UpdateAsync(tag);
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }

        // POST: /tags/delete/{id}
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await tagRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
