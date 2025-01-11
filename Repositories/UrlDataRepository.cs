using encurtadorzinho.Responses;

namespace encurtadorzinho.Repositories
{
    public class UrlDataRepository : IUrlDataRepository
    {
        private List<UrlShortnerResponse> _listResponse;

        public UrlDataRepository()
        {
            _listResponse = new List<UrlShortnerResponse>();
        }

        public UrlShortnerResponse Get(string urlId)
        {
            var response = _listResponse.FirstOrDefault(x => x.UrlId == urlId);

            if(response == null)
                return null;

            return response;
        }

        public void Post(UrlShortnerResponse obj)
        {
            _listResponse.Add(obj);
        }
    }
}
