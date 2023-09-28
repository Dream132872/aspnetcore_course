using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.Entities.Account;

public class User
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(200)] public string Email { get; set; }

    [Required] [MaxLength(300)] public string Password { get; set; }

    [MaxLength(200)] public string? ProfileImage { get; set; }

    [MaxLength(300)] public string? FirstName { get; set; }

    [MaxLength(300)] public string? LastName { get; set; }
    public DateTime RegisteredDate { get; set; }
    [MaxLength(50)] public string EmailActiveCode { get; set; }
    public bool IsActive { get; set; }
}