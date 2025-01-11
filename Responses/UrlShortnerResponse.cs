using System.Text.Json.Serialization;

namespace encurtadorzinho.Responses
{
    public class UrlShortnerResponse
    {
        public string UrlId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("shortUrl")]
        public string ShortUrl { get; set; }

        [JsonPropertyName("created_in")]
        public string CreatedIn { get; set; }

        [JsonPropertyName("expires_in")]
        public string ExpiresIn { get; set; }


        public UrlShortnerResponse(string urlId, string url, string shortUrl, string createdIn, string expiresIn)
        {
            UrlId = urlId;
            Url = url;
            ShortUrl = shortUrl;
            CreatedIn = createdIn;
            ExpiresIn = expiresIn;
        }
    }
}
