using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasty_Talks_BackEnd.Model.Domian;
using Tasty_Talks_BackEnd.Model.DTO;
using Tasty_Talks_BackEnd.Repositories;

namespace Tasty_Talks_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UserController(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }


        //Create User Function--------------------------------------------------

        [HttpPost]

        public async Task<IActionResult> CreateUser([FromBody] AddUserDTO addUserDTO)
        {
            var userDomainModel = mapper.Map<User>(addUserDTO);

            userDomainModel = await usersRepository.CreateuserAsync(userDomainModel);

            return Ok(userDomainModel);
        }


        //Read User Function---------------------------------------------------

        [HttpGet]

        public async Task<IActionResult> GetUsers()
        {
            var usersDomainModel = await usersRepository.GetUsersAsync();

            if (usersDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<UsersDTO>>(usersDomainModel));

        }


        [HttpGet]
        [Route("id")]

        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            var userDomainModel = await usersRepository.GetUserByIdAsync(id);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UsersDTO>(userDomainModel));
        }


        //Update User Function------------------------------------------------


        [HttpPut]
        [Route("id")]

        public async Task<IActionResult> UpdateUser([FromQuery] int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            var userDomainModel = mapper.Map<User>(updateUserDTO);

            userDomainModel = await usersRepository.UpdateUserAsync(id, userDomainModel);


            if (userDomainModel == null)
            {

                return NotFound();
            }

            return Ok(mapper.Map<UsersDTO>(userDomainModel));



        }


        //Delete User Function-----------------------------------------------

        [HttpDelete]
        [Route("id")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            var userDomainModel = await usersRepository.DeleteUserAsync(id);

            if (userDomainModel == null)
            {

                return NotFound();
            }

            return Ok();




        }


    }
}