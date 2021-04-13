using Microsoft.EntityFrameworkCore;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestContext())
            {
                db.Add(new Author
                {
                    Blog = new DevBlog
                    {
                        Title = "Dev Blog",
                    }
                });
                db.Add(new Author
                {
                    Blog = new PhotoBlog
                    {
                        Title = "Photo Blog",
                    }
                });
                db.SaveChanges();
            }

            using (var db = new TestContext())
            { 
                foreach (var author in db.Authors.Include(a => a.Blog))
                {
                    Console.WriteLine($"Found author {author.Id} with Blog {author.Blog!.Title} of type {author.Blog.GetType()}.");
                }
            }
        }
    }
}
