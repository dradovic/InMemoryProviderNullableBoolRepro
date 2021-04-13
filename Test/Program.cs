#nullable enable
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Test
{
    class Program
    {
        public class Query
        {
            private readonly string _title;

            public Query(string title)
            {
                _title = title;
            }

            public Expression<Func<Blog, bool>> Filter => b => b.Title == _title;
        }

        static void Main(string[] args)
        {
            using (var db = new TestContext())
            {
                db.Add(new Blog
                {
                    Title = "First Blog",
                    Posts = {
                        new Post { Title = "First Post" }
                    }
                });
                db.Add(new Blog { Title = "Second Blog" });
                db.SaveChanges();

                var query = new Query("First Blog");
                foreach (var blog in db.Blogs.Where(query.Filter).Include(b => b.Posts))
                {
                    Console.WriteLine($"Found a blog called 'First Blog' with Id {blog.Id} and {blog.Posts.Count} post(s).");
                }
            }
        }
    }
}
