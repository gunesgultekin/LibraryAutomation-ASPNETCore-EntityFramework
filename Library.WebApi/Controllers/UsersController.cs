
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private DBContext _context;
        private IUsersRepository usersRepository;

        public UsersController(DBContext context, IUsersRepository usersRepository,IConfiguration Configuration)
        {
            this._context = context;
            this.usersRepository = usersRepository;
            this._configuration = Configuration;
        }

        [HttpGet("GetUserInfo")]
        public Users GetUserInfo(String userName)
        {
            return usersRepository.GetUserInfo(userName);
        }

        [HttpGet("LoginAuth")]
        public ActionResult LoginAuth(string username, string password)
        {
            var user = _context.Users.Include(u => u.role)
                .Where(
                u => u.username == username && u.password == password).FirstOrDefault();
            if (user == null) {
                return BadRequest();        
            }
            else
            {
                string token = CreateToken(user);
                return Ok(token);
            }
        }

        private string CreateToken(Users user)
        {          
            List<Claim> claims = new List<Claim> {
                
                new Claim(ClaimTypes.Name, user.name),
                new Claim(ClaimTypes.Surname, user.surname),
                new Claim(ClaimTypes.Role, user.role?.name)             
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(

                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        [HttpPost("Register")]
        public int Register(string username, string password, string name, string surname)
        {
            return usersRepository.Register(username, password, name, surname);
        }
    }
}
