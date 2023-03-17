using Microsoft.AspNetCore.Mvc;
using SD_330_Demos.Data;
using SD_330_Demos.Models;

namespace SD_330_Demos.Controllers
{
    public class JournalController : Controller
    {
        private SD_330_DemosContext _context;
        public JournalController(SD_330_DemosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int blogId)
        {
            Blog? blog = _context.Blog.Find(blogId);

            if(blog == null)
            {
                return NotFound();
            }
            ViewBag.blogId = blogId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Body, BlogId")] Journal journal)
        {
            Blog? blog = _context.Blog.Find(journal.BlogNumber);

            if(blog == null)
            {
                return NotFound();
            } else
            {
                journal.Blog = blog;
            }

            if (ModelState.IsValid)
            {
                _context.Journal.Add(journal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(journal);
        }
    }
}
