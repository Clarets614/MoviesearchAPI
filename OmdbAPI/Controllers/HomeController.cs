using Microsoft.AspNetCore.Mvc;
using OmdbAPI.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace OmdbAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieSearch(string name)
        {
            MovieModel result = MovieDAL.GetMovie(name);
            return View(result);
        }


        [HttpGet]
        public IActionResult MovieNight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieNight(string n1, string n2, string n3)
        {
            MovieModel title1 = MovieDAL.GetMovie(n1);
            MovieModel title2 = MovieDAL.GetMovie(n2);
            MovieModel title3 = MovieDAL.GetMovie(n3);
            List<MovieModel> allmovies = new List<MovieModel>();
            allmovies.Add(title1);
            allmovies.Add(title2);
            allmovies.Add(title3);
            return View(allmovies);
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
