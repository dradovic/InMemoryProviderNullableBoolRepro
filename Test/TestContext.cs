#nullable enable
using Microsoft.EntityFrameworkCore;
using System;

namespace Test
{
    public class TestContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase("TestDb");
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
