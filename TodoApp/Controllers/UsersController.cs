using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {

        }

        [HttpGet]
        public Task<IActionResult> Index()
        {
            return null;
            //var response = 

            //if (response.StatusCode == StatusCodes.Status500InternalServerError) return BadRequest(response);
            //if (response.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(response);
            //if (response.StatusCode == StatusCodes.Status401Unauthorized) return Unauthorized();
        }
    }
}
