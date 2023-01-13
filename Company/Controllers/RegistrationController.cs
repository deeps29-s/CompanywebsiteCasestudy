using Company.Data;
using Company.Manager;
using Company.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
       

        private readonly IRegistrationManager _registration;
        public RegistrationController(IRegistrationManager registration, Microsoft.Extensions.Logging.ILogger<RegistrationController> @object)
        {
            _registration = registration;

        }
        [HttpPost("CreateRegistration")]
        public IActionResult Create([FromBody] RegistrationRequest request)
        {
           
            try
            {
                var Reg = _registration.Create(request);
                return Ok(Reg);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }


           
        }

       

        [HttpPost("login")]
        public IActionResult Get([FromBody] LLogin user)
        {
            var Log = _registration.gett(user.Email, user.Password);
            if (Log != null)
            {
                LoginDetails logindetails = new LoginDetails();
                logindetails.Email = Log.Email;
                logindetails.UserName = Log.UserName;
                logindetails.Id = Log.Id;

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:61605",
                    audience: "http://localhost:61605",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                logindetails.Token = tokenString;
                return Ok(logindetails);



            }
            else
            {
                return Unauthorized();
            }



        }

       
    }
}
