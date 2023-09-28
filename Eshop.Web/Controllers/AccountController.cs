using System.Security.Claims;
using Eshop.Web.Context;
using Eshop.Web.Entities.Account;
using Eshop.Web.Services;
using Eshop.Web.Utilities;
using Eshop.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Controllers;

public class AccountController : Controller
{
    #region constructor

    private readonly ApplicationDbContext _context;
    private readonly IViewRendererService _rendererService;

    public AccountController(ApplicationDbContext context, IViewRendererService rendererService)
    {
        _context = context;
        _rendererService = rendererService;
    }

    #endregion

    #region register

    [HttpGet("register")]
    public IActionResult Register()
    {
        if (User.Identity.IsAuthenticated) return Redirect("/user");
        return View();
    }

    [HttpPost("register"), ValidateAntiForgeryToken]
    public IActionResult Register(RegisterUserViewModel register)
    {
        if (ModelState.IsValid)
        {
            // 1- check user is exists or not
            if (_context.Users.Any(u => u.Email == register.Email))
            {
                ModelState.AddModelError("Email", "کاربری با این ایمیل قبلا ثبت نام کرده است");
                return View(register);
            }

            // 2- create new instance of user
            var newUser = new User
            {
                Email = register.Email,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                RegisteredDate = DateTime.Now,
                EmailActiveCode = Guid.NewGuid().ToString("N")
            };
            // 3- add to db
            // Create, Update, Delete
            _context.Users.Add(newUser);
            _context.SaveChanges();

            // 4- send activation code

            EmailSenderService.SendEmail(
                newUser.Email,
                "فعالسازی حساب کاربری",
                _rendererService.RenderToString("ActivateAccount", newUser, HttpContext)
            );

            // 5- redirect to login view
            TempData["SuccessMessage"] = "ثبت نام شما با موفقیت انجام شد";
            return RedirectToAction("Login");
        }

        return View(register);
    }

    #endregion

    #region login

    [HttpGet("login")]
    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated) return Redirect("/user");

        return View();
    }


    [HttpPost("login"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginUserViewModel login)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == login.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "ایمیل یا کلمه عبور اشتباه است");
                return View(login);
            }

            if (user.Password != PasswordHelper.EncodePasswordMd5(login.Password))
            {
                ModelState.AddModelError("Email", "ایمیل یا کلمه عبور اشتباه است");
                return View(login);
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError("Email", "حساب کاربری شما فعال نشده است");
                return View(login);
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            AuthenticationProperties properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };
            await HttpContext.SignInAsync(claimsPrincipal, properties);
            return Redirect("/");
        }

        return View(login);
    }

    #endregion

    #region activate account

    [Route("activate-account/{emailActiveCode}")]
    public IActionResult ActivateAccount(string emailActiveCode)
    {
        var user = _context.Users.SingleOrDefault(u => u.EmailActiveCode == emailActiveCode);
        if (user == null)
        {
            return NotFound();
        }

        user.IsActive = true;
        user.EmailActiveCode = Guid.NewGuid().ToString("N");
        _context.Users.Update(user);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }

    #endregion
}