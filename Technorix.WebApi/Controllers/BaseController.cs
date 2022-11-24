using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Technorix.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class BaseController : Controller
    {
        internal readonly ILogger<BaseController> _logger;
        ///<Summary>
        /// Gets the answer
        ///</Summary>
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
    }

}
