using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediSmartTestProjAPI.Dtos;
using MediSmartTestProjAPI.Interface;
using MediSmartTestProjAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediSmartTestProjAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]

    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserForRegisterDTOW userForRegisterDTOW)
        {
            userForRegisterDTOW.username = userForRegisterDTOW.username.ToLower();

            if (await _repo.UserExists(userForRegisterDTOW.username))
                return BadRequest("Username already Exist");

            var userToCreate = new User
            {
                Username = userForRegisterDTOW.username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDTOW.password);

            return StatusCode(201);
        }


    }
}
