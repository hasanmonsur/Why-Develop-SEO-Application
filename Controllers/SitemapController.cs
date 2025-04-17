using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeoBlog.Data;

namespace SeoBlog.Controllers
{
    public class SitemapController : Controller
    {
        private readonly AppDbContext _context;

        public SitemapController(AppDbContext context)
        {
            _context = context;
        }

        [Route("sitemap.xml")]
        public async Task<IActionResult> Sitemap()
        {
            var posts = await _context.Posts.ToListAsync();
            var xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xml += "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">";

            foreach (var post in posts)
            {
                xml += "<url>";
                xml += $"<loc>https://yourdomain.com/blog/{post.Slug}</loc>";
                xml += $"<lastmod>{post.PublishedDate.ToString("yyyy-MM-dd")}</lastmod>";
                xml += "<changefreq>weekly</changefreq>";
                xml += "<priority>0.8</priority>";
                xml += "</url>";
            }

            xml += "</urlset>";
            return Content(xml, "application/xml");
        }
    }
}
