using encurtadorzinho.Repositories;
using encurtadorzinho.Requests;
using encurtadorzinho.Responses;
using System.Security.Cryptography;
using System.Text;

namespace encurtadorzinho.Services
{
    public class UrlShortnerService : IUrlShortnerService
    {
        private readonly IUrlDataRepository _urlDataRepository;
        private readonly int _ttl = 1;

        public UrlShortnerService(IUrlDataRepository urlDataRepository)
        {
            _urlDataRepository = urlDataRepository;
        }

        public UrlShortnerResponse Get(string urlId)
        {
            var response = _urlDataRepository.Get(urlId);

            return response;
        }

        public UrlShortnerResponse Post(UrlShortnerRequest request)
        {
            var urlId = BuildUrlId(request.UrlToShort);

            var obj = new UrlShortnerResponse(
                urlId,
                request.UrlToShort,
                $"https://localhost:7194/{urlId}",
                DateTime.Now.ToString(),
                DateTime.Now.AddHours(_ttl).ToString()
                );

            _urlDataRepository.Post(obj);

            return obj;
        }
        
        private string BuildUrlId(string url)
        {
            var sha256 = GetSha256Hash(url);

            var urlId = sha256.Substring(0, 6);

            return urlId;
        }

        private string GetSha256Hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
