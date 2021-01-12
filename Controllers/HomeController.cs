using BlogVer2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using BlogVer2.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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
        // GET: Posts
        public async Task<IActionResult> Index()
        {
            // if (HttpContext.Session.GetString("h") != null) ;
            int i = _context.Post.Count();
            HttpContext.Session.SetString("h",  i.ToString());
            return View(await _context.Post.ToListAsync());

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
