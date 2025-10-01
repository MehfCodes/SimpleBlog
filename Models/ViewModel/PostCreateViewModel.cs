using Microsoft.AspNetCore.Mvc.Rendering;
namespace SimpleBlog.Models.ViewModel;
public class PostCreateViewModel
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<Guid> SelectedTagIds { get; set; } = [];
    public IEnumerable<SelectListItem>? AllTags { get; set; }
}
