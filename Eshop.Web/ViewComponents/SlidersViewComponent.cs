using Eshop.Web.Context;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.ViewComponents
{
    public class SlidersViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SlidersViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var sliders = _context.Sliders.ToList();

            return View("Sliders", sliders);
        }
    }
}
