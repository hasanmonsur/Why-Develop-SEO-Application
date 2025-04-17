using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeoBlog.Data;
using System;

namespace SeoBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Post(string slug)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Slug == slug);
            if (post == null) return NotFound();

            // Pass SEO data to the view
            ViewBag.Title = post.Title;
            ViewBag.MetaDescription = post.MetaDescription;
            ViewBag.MetaKeywords = post.MetaKeywords;

            return View(post);
        }
    }
}
