using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIBookProject.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private LoginModelRepository loginModelRepository;
        public AuthController(LoginModelRepository loginModelRepository)
        {
            this.loginModelRepository = loginModelRepository;
        }
    
        [HttpPost, Route("register")]
        public IActionResult Register(LoginModel loginModel)
        {
            byte[] bytes = new UTF8Encoding().GetBytes(loginModel.Password);
            byte[] hashedBytes;
            using (SHA256Managed hashingAlgorithm = new SHA256Managed())
            {
                hashedBytes = hashingAlgorithm.ComputeHash(bytes);
            }
            Convert.ToBase64String(hashedBytes);
            LoginModel registeredLoginModel = loginModelRepository.CreateUser(loginModel);
            return Ok(registeredLoginModel);
        }


        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            LoginModel loginModel = loginModelRepository.GetByName(user.UserName);
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            byte[] bytes = new UTF8Encoding().GetBytes(user.Password);
            byte[] hashedBytes;
            using (SHA256Managed hashingAlgorithm = new SHA256Managed())
            {
                hashedBytes = hashingAlgorithm.ComputeHash(bytes);
            }

            string hashedPassword = Convert.ToBase64String(hashedBytes);
            byte[] bytesForLoginModel = new UTF8Encoding().GetBytes(loginModel.Password);
            byte[] hashedBytesForLoginModel;
            using (SHA256Managed hashingAlgorithmForLoginModel = new SHA256Managed())

            {
                hashedBytesForLoginModel = hashingAlgorithmForLoginModel.ComputeHash(bytesForLoginModel);
            }

            string hashedPasswordForLoginModel = Convert.ToBase64String(hashedBytesForLoginModel);
            if (user.UserName == loginModel.UserName && hashedPasswordForLoginModel == hashedPassword)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeySecret993/4GdrunDRUN$"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
