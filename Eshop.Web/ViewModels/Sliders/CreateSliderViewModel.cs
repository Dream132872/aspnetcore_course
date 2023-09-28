using System.ComponentModel.DataAnnotations;

namespace Eshop.Web.ViewModels.Sliders;

public class CreateSliderViewModel
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
    public string Title { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
    public string Description { get; set; }

    [Display(Name = "آدرس Url")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
    public string Url { get; set; }

    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public IFormFile Image { get; set; }
}