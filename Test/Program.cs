#nullable enable
using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestContext())
            {
                db.Add(new Blog { Title = "First Blog" });
                db.Add(new Blog { Title = "Second Blog" });
                db.SaveChanges();

                foreach (var blog in db.Blogs.Where(b => b.Title == "First Blog"))
                {
                    Console.WriteLine("Found a blog called 'First Blog'.");
                }
            }
        }
    }
}
