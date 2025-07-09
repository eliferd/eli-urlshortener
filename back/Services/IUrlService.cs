namespace EliURLShortenerApi.Services;

public interface IUrlService<T> where T : class
{
    T? Get(string url);
    T Create(string url);
}