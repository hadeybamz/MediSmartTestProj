using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediSmartTestProjAPI.Dtos;
using MediSmartTestProjAPI.Interface;
using MediSmartTestProjAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MediSmartTestProjAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]

    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;

        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
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

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserForForLoginDTOW userForLoginDTOW)
        {
            var userFromRepo = await _repo.Login(userForLoginDTOW.username.ToLower(), userForLoginDTOW.password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                tokrn = tokenHandler.WriteToken(token)
            });
        }
    
    }
}
