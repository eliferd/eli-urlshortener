using System.Web;
using EliURLShortenerApi.Models;
using EliURLShortenerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EliURLShortenerApi.Controllers
{
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlService<Url> _urlService;
        public UrlShortenerController(IUrlService<Url> urlService)
        {
            this._urlService = urlService;
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetUrl(string id)
        {
            Url? url = this._urlService.Get(id);

            if (url == null)
            {
                return NotFound();
            }

            return Uri.UnescapeDataString(url.OriginalUrl);
        }

        [HttpPost("{url}")]
        public ActionResult<string> CreateUrl(string url)
        {
            Url urlObj = this._urlService.Create(url);

            return Ok(urlObj.Id);
        }
    }
}
