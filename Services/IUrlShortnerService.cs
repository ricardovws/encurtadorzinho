using encurtadorzinho.Requests;
using encurtadorzinho.Responses;

namespace encurtadorzinho.Services
{
    public interface IUrlShortnerService
    {
        UrlShortnerResponse Get(string urlId);
        UrlShortnerResponse Post(UrlShortnerRequest request);
    }
}
