using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VSApp.Business.Interfaces;
using VSApp.Business.Models;
using VSApp.Core.Entities;
using VSApp.Infrastructure.Data;

namespace VSApp.API.Controllers
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName ="v1")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginModel userLoginModel)
        {
            try
            {
                var user = await _userService.Login(userLoginModel);
                if(user == null)
                {
                    return Ok(new ResponseModel(ResponseStatusCode.BadRequest, "Invalid username or password"));
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Error(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserModel userModel)
        {
            try
            {
                var result = await _userService.Register(userModel);
                return Ok(new ResponseModel(result));
            }
            catch (Exception ex)
            {
                return Error(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> PutUser(UserModel user)
        {
            if(user != null)
            {
                await _userService.UpdateAsync(user);
                return Ok(new ResponseModel(user, ResponseStatusCode.Ok, "Successfully updated"));
            }
            return BadRequest();
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            if(id != 0)
            {
                var user = await _userService.GetByIdAsync(id);
                if(user == null)
                {
                    return NotFound();
                }
                return Ok(new ResponseModel(user));
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            var user = await _userService.DeleteAsync(id);
            return Ok(new ResponseModel(user, ResponseStatusCode.Ok, "Successfully deleted"));
        }
        [HttpGet("list")]

        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsersAsync()
        {
            List<UserModel> users = await _userService.GetAllAsync();
            return Ok(new ResponseModel(users));
        }

    }
}
