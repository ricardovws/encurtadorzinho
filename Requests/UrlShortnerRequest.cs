using System.Text.Json.Serialization;

namespace encurtadorzinho.Requests
{
    public class UrlShortnerRequest
    {
        [JsonPropertyName("url")]
        public string UrlToShort { get; set; }
    }
}
