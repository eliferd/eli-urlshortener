using EliURLShortenerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EliURLShortenerApi.Database
{
    public class UrlDbContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }

        public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options)
        {
        }
    }
}
