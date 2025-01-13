using System.Collections.Generic;
using System.Linq;
using RulerHub.Components.Blogs.Entities;
using RulerHub.Data;

namespace RulerHub.Components.Blogs.Services;

public class BlogService
{
    private readonly ApplicationDbContext _context;

    public BlogService(ApplicationDbContext context)
    {
        _context = context;
    }

    private readonly List<Blog> _blogs = new();

    public IEnumerable<Blog> GetAllBlogs()
    {
        return _blogs;
    }

    public Blog GetBlogById(int id)
    {
        return _blogs.FirstOrDefault(b => b.Id == id);
    }

    public void CreateBlog(Blog blog)
    {
        blog.Id = _blogs.Count > 0 ? _blogs.Max(b => b.Id) + 1 : 1;
        blog.CreatedAt = DateTime.Now;
        _blogs.Add(blog);
    }

    public void UpdateBlog(Blog blog)
    {
        var existingBlog = GetBlogById(blog.Id);
        if (existingBlog != null)
        {
            existingBlog.Title = blog.Title;
            existingBlog.Content = blog.Content;
        }
    }

    public void DeleteBlog(int id)
    {
        var blog = GetBlogById(id);
        if (blog != null)
        {
            _blogs.Remove(blog);
        }
    }
}
