using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookingStore.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;

namespace Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            this._userService = userService;
        }

        [HttpGet("/users")]
        public async Task<ActionResult> GetAllUsers() 
        {
            var employees = await _userService.GetAllUsers();
            return Ok(employees);
        } 
        [HttpGet("/user/{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id) 
        {
            try 
            {
                var result = await _userService.GetUserById(id);
                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }

            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        } 

        
        [HttpPost("/users")]
        public async Task<ActionResult<User>> AddNewUser(User user) 
        {
            try 
            {
                if(user == null)
                {
                    return BadRequest();
                }

                var createdUser = await _userService.AddNewUser(user);

                return CreatedAtAction(nameof(GetUserById), new {id = createdUser.ID}, createdUser);
            }

            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        } 

/* 
{
  "id": 1,
  "username": "Daniel123",
  "role": "Admin",
  "emailAddress": "danielpretlove5@gmail.com",
  "password": "Gintama22"
}*/
        
        [HttpPut("/user/{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user) 
        {
            try
            {
                // if(id != user.ID)
                // {
                //     return BadRequest("User ID do not match");
                // }

                var userToUpdate = await _userService.GetUserById(id);

                if(userToUpdate == null)
                {
                    return NotFound($"User with ID = {id} not found");
                }

                return await _userService.UpdateUser(user);
            }

            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when updating {id}");
            }
        } 

        
        [HttpDelete("/users/{id:int}")]
        public async Task<ActionResult<User>> DeleteUsers(int id) 
        {
            try 
            {
                var userToDelete = await _userService.GetUserById(id);

                if (userToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _userService.DeleteUser(id);

            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error deleting user");
            }
        } 
    }
}