using hSenidPOS.BLL.IManager;
using hSenidPOS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hSenidPOS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDummyManager _idummyManager;

        public HomeController(ILogger<HomeController> logger, IDummyManager dummyManager)
        {
            _idummyManager = dummyManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _idummyManager.InsertData();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}