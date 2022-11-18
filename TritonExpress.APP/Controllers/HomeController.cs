using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;
using TritonExpress.APP.Models;

namespace TritonExpress.APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenService _token;
        private readonly ICacheService _cache;

        public HomeController(ILogger<HomeController> logger, ITokenService token, ICacheService cache)
        {
            _logger = logger;
            _token = token;
            _cache = cache;
        }

        public IActionResult Index()
        {
            if(_cache.GetData<Token>("token")?.TokenCode == null)
               _token.GetToken(User.Identity?.Name);

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