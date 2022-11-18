using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web.Http;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;
using TritonExpress.APP.Models;

namespace TritonExpress.APP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenService _token;
        private readonly ICacheService _cache;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(SignInManager<IdentityUser> signInManager, ILogger<HomeController> logger, ITokenService token, ICacheService cache)
        {
            _logger = logger;
            _token = token;
            _cache = cache;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_cache.GetData<Token>("token")?.TokenCode == null)
                if (User.Identity?.Name != null)
                {
                    _token.GetToken(User.Identity?.Name);
                }
                else 
                {
                    await _signInManager.SignOutAsync();
                }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}