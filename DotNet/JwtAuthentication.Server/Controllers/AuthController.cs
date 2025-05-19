using JwtAuthentication.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JwtAuthentication.Server.Controllers;

public class AuthController : Controller
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel user)
    {
        if (user is null)
        {
            return BadRequest("Invalid client request");
        }
        if (user.UserName == "johndoe" && user.Password == "def@123")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e6FGG2*jyrC@VF9wXsbUftAcYU9@fonNyQ6BgofXFatWfm7nG886VTK84sFcx-4PyU9AKc7PfPzkMuWq4BLFeJm37qousFKLvc7b"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7262",
                audience: "https://localhost:7262",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new AuthenticatedResponse { Token = tokenString });
        }
        return Unauthorized();
    }
}
