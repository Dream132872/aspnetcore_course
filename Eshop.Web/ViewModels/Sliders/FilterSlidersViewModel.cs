using Eshop.Web.Entities.Catalog;
using Eshop.Web.ViewModels.Pagination;

namespace Eshop.Web.ViewModels.Sliders
{
    public class FilterSlidersViewModel : Paging<Slider>
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
    }
}
