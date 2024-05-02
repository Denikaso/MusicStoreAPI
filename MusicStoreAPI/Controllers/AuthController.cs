using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicStoreAPI.Models;
using MusicStoreLibrary;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CustomerBD _customer;

        public AuthController(CustomerBD customer)
        {
            _customer = customer;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            Customer? customer = _customer.SearchByEmail(request.Email);
            if (customer == null)
            {
                return BadRequest("Пользователь с таким email не найден");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, customer.Password))
            {
                return BadRequest("Неверный пароль");
            }

            // Успешная аутентификация
            string token = GenerateJwtToken(customer.Id, customer.Email, customer.Role);

            return Ok(new { token });            
        }

        [HttpPost("verifyPassword")]
        public IActionResult VerifyPassword([FromBody] VerifyPasswordRequest request)
        {
            Customer? customer = _customer.SearchById(request.Id);

            // Проверка пароля
            if (BCrypt.Net.BCrypt.Verify(request.Password, customer.Password))
            {
                return Ok("Пароль подтвержден");
            }

            return BadRequest("Неверный пароль");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GenerateJwtToken(int id, string email, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("happyhappyhappyhappyhappyhappyha"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id", id.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: "MusicStore",
                audience: "YourUsers",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
