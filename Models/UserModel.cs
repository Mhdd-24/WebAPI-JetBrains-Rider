using System.ComponentModel.DataAnnotations;

namespace VibeCodeUserMgmtCRUD.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Full Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Display(Name = "Active")]
    public bool IsActive { get; set; } = false;
}
