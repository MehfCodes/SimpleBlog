using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models.Domain;
using SimpleBlog.Repository;

namespace SimpleBlog.Controllers
{
    [Route("posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository postRepository;

        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public async Task<ActionResult> Index()
        {
            var posts = await postRepository.GetAllAsync();
            return View(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var post = await postRepository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            // var tags = await context.Tags.ToListAsync();
            // ViewBag.Tags = tags;
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                await postRepository.AddAsync(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var post = await postRepository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await postRepository.UpdateAsync(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
        
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var post = await postRepository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost("delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await postRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
