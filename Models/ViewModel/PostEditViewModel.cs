using Microsoft.AspNetCore.Mvc.Rendering;
namespace SimpleBlog.Models.ViewModel;
public class PostEditViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<Guid> SelectedTagIds { get; set; } = [];
    public IEnumerable<SelectListItem>? AllTags { get; set; }
}
