using CRUDUsersAPI.Models;
using CRUDUsersAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsersAPI.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> Get()
        {
            var usersData = _userRepository.GetAll();
            return Ok(usersData);
        }

        [HttpGet]
        [Route("Users/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userData = _userRepository.GetById(id);

            return userData == null ? NotFound() : Ok(userData);
        }

        [HttpGet]
        [Route("Users/{email}/{password}")]
        public async Task<IActionResult> GetByEmail([FromRoute] string email, [FromRoute] string password)
        {
            var userData = _userRepository.GetByEmail(email);
            if (userData == null) { return NotFound("User Not Found!"); }

            if(password != userData.Password) { return BadRequest("Wrong Password"); }

            return Ok(userData);
        }

        [HttpPost]
        [Route("Users")]
        public async Task<IActionResult> Add([FromBody] UserModel newUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _userRepository.Add(newUser);
                return Created($"v1/users/{newUser.Id}",newUser);
            }
            catch (Exception e)
            {

                return BadRequest();
            }
            

        }
        [HttpPut]
        [Route("Users/{id}")]
        public async Task<IActionResult> Edit([FromBody] UserModel userEdit , [FromRoute]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var userDb = _userRepository.GetById(id);

            if (userDb == null) return NotFound(id);

            try
            {
                _userRepository.Update(userEdit,id);
                return Ok(userEdit);
            }
            catch (Exception e)
            {

                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("Users/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (_userRepository.GetById(id) == null) return NotFound(id);

            _userRepository.Delete(id);
            return Ok(id);
        }
        
    }
}
