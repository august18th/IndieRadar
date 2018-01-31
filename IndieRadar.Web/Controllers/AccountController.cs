using System;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces.Managers;
using IndieRadar.Services.Managers;
using IndieRadar.Web.Infrastructure;
using IndieRadar.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace IndieRadar.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private ISignInService _signInService;

        public AccountController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        protected ISignInService SignInService
            => _signInService ?? (_signInService = HttpContext.GetOwinContext().Get<ISignInService>());


        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.Email);

            var result = await SignInService.PasswordSignInAsync(model.Email, model.Password,
                model.RememberMe, shouldLockout: true);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Register");
                case SignInStatus.LockedOut:
                    ModelState.AddModelError("", "Вы привысили количество попыток входа. Попробуйте авторизоваться позже");
                    return View(model);
                default:
                    ModelState.AddModelError("", "Неудачная попытка входа.");
                    return View(model);
            }
        }

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = _mapper.Map<RegisterClientViewModel, UserDTO>(model);
                IdentityResult result;
                try
                {
                    result = await _userManager.CreateAsync(user, user.Password);
                }
                catch (ArgumentNullException exception)
                {
                    return Content(exception.Message);
                }

                if (result.Succeeded)
                {
                    return Content("Register is success");
                }
            }

            return View(model);
        }
    }
}