using encurtadorzinho.Requests;
using encurtadorzinho.Services;
using Microsoft.AspNetCore.Mvc;

namespace encurtadorzinho.Controllers
{
    [ApiController]
    [Route("/")]
    public class UrlController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private IUrlShortnerService _urlShortnerService;

        public UrlController(ILogger<WeatherForecastController> logger, IUrlShortnerService urlShortnerService)
        {
            _logger = logger;
            _urlShortnerService = urlShortnerService;
        }

        [HttpGet("{urlId}")]
        public ActionResult Get([FromRoute] string urlId)
        {
            var response = _urlShortnerService.Get(urlId);

            if(response == null)
                return NotFound();

            return Redirect(response.Url);
        }

        [HttpPost]
        public CreatedResult Post([FromBody] UrlShortnerRequest request)
        {
            var response = _urlShortnerService.Post(request);
         
            return Created(response.ShortUrl, response);
        }
    }
}
