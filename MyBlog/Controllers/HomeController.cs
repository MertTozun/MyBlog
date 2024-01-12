using Microsoft.AspNetCore.Mvc;
using MyBlog.Context;
using MyBlog.Models;
using System.Diagnostics;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

		public HomeController(ILogger<HomeController> logger, BlogContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
        {
            var list = _context.BlogPost.Take(4).Where(b=>b.IsPublish).OrderByDescending(x=>x.CreateTime).ToList();
            foreach (var blog in list)
            {
                blog.Author = _context.Author.Find(blog.AuthorId);
            }
            return View(list);
        }

        public IActionResult About()
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
        public IActionResult OlderPosts()
        {
            var list = _context.BlogPost.Where(b => b.IsPublish).OrderByDescending(x => x.CreateTime).ToList();
            foreach (var blog in list)
            {
                blog.Author = _context.Author.Find(blog.AuthorId);
            }
            return View(list);
        }

        public IActionResult Post(int Id)
        {
            var blog = _context.BlogPost.FirstOrDefault(blog => blog.Id == Id);
            
            if (blog==null)
            {
                return NotFound();
            }
            blog.Author = _context.Author.Find(blog.AuthorId);

            return View(blog);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
