using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.ViewModels.Account;

public class RegisterUserViewModel
{
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
    [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "تکرار کلمه عبور")]
    [Required(ErrorMessage = "لطفا تکرار کلمه عبور را وارد کنید")]
    [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
    public string ConfirmPassword { get; set; }
}