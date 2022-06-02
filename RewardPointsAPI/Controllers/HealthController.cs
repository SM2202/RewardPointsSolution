using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace RewardPoints
{
    /// <summary>
    /// Health Controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/rewards")]
    public class HealthController : Controller
    {
        /// <summary>
        /// Check health of API
        /// </summary>
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            try
            {
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}