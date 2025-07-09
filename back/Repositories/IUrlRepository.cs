namespace EliURLShortenerApi.Repositories;

public interface IUrlRepository<T> where T : class
{
    T?  Get(string id);
    T Create(string url);
}