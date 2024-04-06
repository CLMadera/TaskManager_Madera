using Application.Services;
using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserAccountService _userAccountService;

        public UsersController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        


        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
              

            User? createdUser = _userAccountService.Create(userDto.UserName, userDto.Email, userDto.Role, userDto.PasswordHash);

            return Ok(createdUser);
        }



        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
