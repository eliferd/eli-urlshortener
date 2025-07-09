using EliURLShortenerApi.Models;
using EliURLShortenerApi.Repositories;

namespace EliURLShortenerApi.Services;

public class UrlService : IUrlService<Url>
{
    private IUrlRepository<Url> _urlRepository;
    
    public UrlService(IUrlRepository<Url> urlRepository)
    {
        this._urlRepository = urlRepository;
    }
    public Url? Get(string id)
    {
        return this._urlRepository.Get(id);
    }

    public Url Create(string url)
    {
        return this._urlRepository.Create(url);
    }
}