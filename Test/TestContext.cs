using Microsoft.EntityFrameworkCore;

namespace Test
{
    public class TestContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("TestDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>()
                .HasDiscriminator<bool>(nameof(Blog.IsPhotoBlog))
                .HasValue<DevBlog>(false)
                .HasValue<PhotoBlog>(true);
        }
    }

    public class Author
    {
        public int Id { get; set; }
        public Blog Blog { get; set; }
    }

    public abstract class Blog
    {
        public int Id { get; set; }
        public bool IsPhotoBlog { get; set; }
        public string Title { get; set; }
    }

    public class DevBlog : Blog
    {
        public DevBlog()
        {
            IsPhotoBlog = false;
        }
    }

    public class PhotoBlog : Blog
    {
        public PhotoBlog()
        {
            IsPhotoBlog = true;
        }

        public int NumberOfPhotos { get; set; } // stops working when commented in
    }
}
