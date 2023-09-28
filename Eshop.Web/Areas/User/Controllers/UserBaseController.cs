using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Areas.User.Controllers;

[Area("User")]
[Authorize]
public class UserBaseController : Controller
{
}