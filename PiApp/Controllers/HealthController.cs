using Microsoft.AspNetCore.Mvc;

namespace PiApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "ok";
        }
    }
}
