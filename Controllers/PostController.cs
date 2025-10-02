using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleBlog.Models.Domain;
using SimpleBlog.Models.ViewModel;
using SimpleBlog.Repository;

namespace SimpleBlog.Controllers
{
    [Route("posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly ITagRepository tagRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(IPostRepository postRepository, ITagRepository tagRepository, UserManager<ApplicationUser> userManager)
        {
            this.postRepository = postRepository;
            this.tagRepository = tagRepository;
            this.userManager = userManager;
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
        public async Task<IActionResult> Create()
        {
            var tags = await tagRepository.GetAllAsync();
            var vm = new PostCreateViewModel
            {
                AllTags = tags.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                })
            };
            return View(vm);
        }
        // [Authorize]
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var tags = await tagRepository.GetAllAsync();
                model.AllTags = tags.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                });
                return View(model);
            }

            var selectedTags = await tagRepository.GetByIdsAsync(model.SelectedTagIds);
            // var currentUser = await userManager.GetUserAsync(User);
            // var currentUserId = userManager.GetUserId(User);
            var testUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var testUser = new ApplicationUser
            {
                Id = testUserId,
                UserName = "TestUser"
            };

            var post = new Post
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content,
                CreatedAt = DateTime.UtcNow,
                Tags = [.. selectedTags],
                AuthorId = testUserId,
                // Author = testUser!
            };

            await postRepository.AddAsync(post);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var post = await postRepository.GetByIdAsync(id);
            if (post == null) return NotFound();

            var model = new PostEditViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                SelectedTagIds = post.Tags?.Select(t => t.Id).ToList() ?? [],
                AllTags = (await tagRepository.GetAllAsync())
                    .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name })
            };

            return View(model);
        }
        
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllTags = (await tagRepository.GetAllAsync())
                    .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
                return View(model);
            }

            var post = await postRepository.GetByIdAsync(model.Id);
            if (post == null) return NotFound();

            post.Title = model.Title;
            post.Content = model.Content;

            post.Tags = new List<Tag>();
            if (model.SelectedTagIds != null && model.SelectedTagIds.Any())
            {
                var tags = await tagRepository.GetAllAsync();
                post.Tags = tags.Where(t => model.SelectedTagIds.Contains(t.Id)).ToList();
            }

            await postRepository.UpdateAsync(post);

            return RedirectToAction(nameof(Index));
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
