using Microsoft.EntityFrameworkCore;
using SeoBlog.Data;
using SeoBlog.Models;

var builder = WebApplication.CreateBuilder(args);


// Register DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Seed sample data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!dbContext.Posts.Any())
    {
        dbContext.Posts.Add(new Post
        {
            Title = "Sample Post",
            Slug = "sample-post",
            Content = "This is a sample post.",
            MetaDescription = "Sample post description",
            MetaKeywords = "sample, post, seo",
            PublishedDate = DateTime.UtcNow
        });
        dbContext.SaveChanges();
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "blog",
    pattern: "blog/{slug}",
    defaults: new { controller = "Blog", action = "Post" });


app.Run();
