using encurtadorzinho.Responses;

namespace encurtadorzinho.Repositories
{
    public interface IUrlDataRepository
    {
        UrlShortnerResponse Get(string urlKey);
        void Post(UrlShortnerResponse request);
    }
}
