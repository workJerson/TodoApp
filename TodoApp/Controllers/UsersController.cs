using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        protected IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await userService.GetAll();

            if (response.StatusCode == StatusCodes.Status500InternalServerError) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status401Unauthorized) return Unauthorized();

            return Ok(response);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Show(Guid guid)
        {
            var response = await userService.Get(guid);

            if (response.StatusCode == StatusCodes.Status500InternalServerError) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status401Unauthorized) return Unauthorized();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserModel createUserModel)
        {
            var response = await userService.Create(createUserModel);

            if (response.StatusCode == StatusCodes.Status500InternalServerError) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status401Unauthorized) return Unauthorized();

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserModel updateUserModel)
        {
            var response = await userService.Update(updateUserModel);

            if (response.StatusCode == StatusCodes.Status500InternalServerError) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status401Unauthorized) return Unauthorized();

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var response = await userService.Delete(guid);

            if (response.StatusCode == StatusCodes.Status500InternalServerError) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(response);
            if (response.StatusCode == StatusCodes.Status401Unauthorized) return Unauthorized();

            return Ok(response);
        }
    }
}
