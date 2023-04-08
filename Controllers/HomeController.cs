using BookStoreCet.Data;
using BookStoreCet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStoreCet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var cheapestBooks = context.Books.OrderBy(x => x.Price).Take(3).ToList();
            _logger.LogError(cheapestBooks.Count() + " kitap getrildi.");
            return View(cheapestBooks);
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