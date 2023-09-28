using Eshop.Web.Context;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        // domain.com/about-us
        //[Route("product/vp-{productId}/{productName}")]
        [Route("about-us")]
        public IActionResult AboutUs(int productId, string productName)
        {
            return View();
        }
    }
}