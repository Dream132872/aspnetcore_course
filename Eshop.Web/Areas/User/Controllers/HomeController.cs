using System.Security.Claims;
using Eshop.Web.ContextHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Areas.User.Controllers;

public class HomeController : UserBaseController
{
    // GET
    public IActionResult Index()
    {
        ViewBag.userId = User.GetUserId();
        ViewBag.email = User.GetUserEmail();
        return View();
    }
}