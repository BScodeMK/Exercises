using Microsoft.AspNetCore.Mvc;
using Ogani.Data;
using Ogani.Data.Entities;
using Ogani.Models;
using System.Diagnostics;

namespace Ogani.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
            _context = context;
		}

		public IActionResult Index()
		{
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
		}

        public IActionResult Shop()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult ProductDetails(int id)
        {
            return View();
        }

        public IActionResult BlogDetails(int id)
        {
            return View();
        }

        public IActionResult ShoppingBag()
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