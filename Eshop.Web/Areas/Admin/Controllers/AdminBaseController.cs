using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class AdminBaseController : Controller
{
}