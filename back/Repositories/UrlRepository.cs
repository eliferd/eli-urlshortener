using EliURLShortenerApi.Database;
using EliURLShortenerApi.Models;
using Microsoft.EntityFrameworkCore;
using shortid;

namespace EliURLShortenerApi.Repositories
{
    public class UrlRepository : IUrlRepository<Url>
    {
        private UrlDbContext _context;
        public UrlRepository(UrlDbContext context)
        {
            this._context = context;
        }

        public Url? Get(string id)
        {
            Url? urlObj = this._context.Urls.Find(id);

            if (urlObj != null)
            {
                urlObj.ClickCount++;
                this._context.Urls.Update(urlObj);
                this._context.SaveChanges();
            }

            return urlObj;
        }

        public Url Create(string url)
        {
            Url urlObj = new Url
            {
                Id = ShortId.Generate(),
                ClickCount = 0,
                OriginalUrl = url
            };

            this._context.Urls.Add(urlObj);
            this._context.SaveChanges();
            return urlObj;
        }
    }
}
