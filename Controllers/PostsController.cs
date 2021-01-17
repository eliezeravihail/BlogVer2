using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogVer2.Data;
using Microsoft.AspNetCore.Http;

namespace BlogVer2.Controllers
{
    public class PostsController : Controller
    {
        private readonly BlogVer2Context _context;

        public PostsController(BlogVer2Context context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {

            if (HttpContext.Session.GetString("user") != null)
            {

                TempData["user"] = "userin";
            }
            return View(await _context.Post.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("user") != null)
            {

                TempData["user"] = "userin";
            }
            // {
            //     return RedirectToAction("Login", "Users");
            // }

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {

            if (HttpContext.Session.GetString("user") != null)
            {

                TempData["user"] = "userin";
            }
            return HttpContext.Session.GetString("user") == null ? RedirectToAction("Login", "Users") : (IActionResult)View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PublishDate,Title,BodyText")] Post post)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else {
                TempData["user"] = "userin";
            }
            
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                TempData["user"] = "userin";
            }
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PublishDate,Title,Writer,BodyText")] Post post)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                TempData["user"] = "userin";
            }
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                TempData["user"] = "userin";
            }
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                TempData["user"] = "userin";
            }
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }


        //// GET: Posts/Delete/5
        //public async Task<IActionResult> Search(string searcher)
        //{
        //    var allFinded = from Post in _context.Post select Post;

        //    return View(await allFinded.ToListAsync());
        //}

        // GET: Posts/Delete/5
        public async Task<IActionResult> Search()
        {
            return View(_context.Post.ToListAsync());
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string? search)
        {
            if (search == null)
            {
                search = "";
            }
            var allFinded = from Post in _context.Post where Post.Title.Contains(search) || Post.BodyText.Contains(search) select Post;
            int o = allFinded.Count();
            if(o==0)
            {
                ViewData["not found"] = "not found";
            }
            if (HttpContext.Session.GetString("user") != null)
            {

                TempData["user"] = "userin";
            }

            return View(await allFinded.ToListAsync());
        }

        [HttpPost, ActionName("OldPost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OldPot(string OldPost)
        {

            if (HttpContext.Session.GetString("user") != null)
            {

                TempData["user"] = "userin";
            }

            int i = _context.Post.Count();

            if (HttpContext.Session.GetString("h") == null)
            {
                int z = i;
                HttpContext.Session.SetString("h", z.ToString());
            }
            else
            {
                string l = HttpContext.Session.GetString("h");
                int o = int.Parse(l) - 1;
                HttpContext.Session.SetString("h", o.ToString());

                var c = _context.Post.Where(p => p.Id == o);

                return View(await c.ToListAsync());
            }
            var b = _context.Post.Where(p => p.Id == i - 1);
        //    return RedirectToAction("Post", "Detailse");
            return View(await b.ToListAsync());
        }
    }
}
