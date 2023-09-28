using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.ViewComponents
{
    public class SiteFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("SiteFooter");
        }
    }
}
