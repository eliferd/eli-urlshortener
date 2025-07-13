using System.Text.Json;
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

            return Ok(JsonSerializer.Serialize(Uri.UnescapeDataString(url.OriginalUrl)));
        }

        [HttpPost("/")]
        public ActionResult<string> CreateUrl([FromBody] string url)
        {
            Url urlObj = this._urlService.Create(url);

            return Ok(JsonSerializer.Serialize(urlObj.Id));
        }
    }
}
