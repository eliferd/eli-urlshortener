namespace EliURLShortenerApi.Models
{
    public class Url
    {
        public string Id { get; set; }
        public string OriginalUrl { get; set; }
        public int ClickCount { get; set; }
    }
}
