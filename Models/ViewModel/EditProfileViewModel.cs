using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models.ViewModel;

public class EditProfileViewModel
{
    [Required]
    [Display(Name = "Username")]
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }
}
