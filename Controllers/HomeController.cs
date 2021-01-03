using BlogVer2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using BlogVer2.Data;


namespace BlogVer2.Controllers
{
    public class HomeController : Controller
    {
        private BlogVer2Context _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BlogVer2Context context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {

            ViewBag.posts = from Post in _context.Post
                            orderby Post.PublishDate
                            select Post;
            return View();
        }



        public IActionResult About()
        {
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
