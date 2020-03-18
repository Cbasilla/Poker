using Microsoft.AspNetCore.Mvc;
using Poker.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Controllers
{
    public class HealthController : Controller
    {
        [HttpGet(ApiRoutes.Health.HealthCheck)]
        public IActionResult HealthCheck()
        {
            return Ok(new { Status = "Ok" });
        }
    }
}
