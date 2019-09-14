using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TheCoffeehouse.Data.Models;
using TheCoffeehouse.Data.Models.Domains;
using TheCoffeehouse.Data.Models.Repositories;
using TheCoffeehouse.Data.Models.Uow;
using TheCoffeehouse.Data.Models.View;

namespace TheCoffeeHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : BaseController
    {
        public AppUserController(IUnitOfWork uow) : base(uow)
        {

        }
        //desc: register new account
        //url : AppUserController/register
        [HttpPost("register")]
        public IActionResult Register(AppUserRegisterView model)
        {
            var repo = _uow.GetService<AppUsersDomains>();
            if (repo.CheckExistedUser(model.username))
            {
                return BadRequest("User have existed.");
            }
            if(model.password == model.confirm)
            {
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                string saltSave = "";
                for (int i = 0; i < salt.Length; i++)
                {
                    saltSave = saltSave + salt[i] + " ";
                }
                //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
                // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: model.password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));
                var newUser = new AppUsers
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = model.username,
                    Password = hashed,
                    Salt = saltSave,
                    Phone = model.phone,
                    Fullname = model.fullname,
                    Role = "user",
                };
                repo.Create(newUser);
                _uow.SaveChanges();
                return Ok(newUser);
            }

            return BadRequest("Password must match with Confirm Password");
        }

        //desc : Login to system
        //url : AppUserController/login
        [HttpPost("login")]
        public IActionResult Login(AppUserLoginView login) 
        {
            var repo = _uow.GetService<AppUsersDomains>();
            var user = repo.GetAll().FirstOrDefault(u => u.Username == login.username);
            if(user == null)
            {
                return BadRequest("Username or password have wrong .");
            }

            string saltSave = user.Salt;
            string password2 = user.Password;

            string[] byteArrString = saltSave.Split(" ");
            byteArrString = byteArrString.Take(byteArrString.Count() - 1).ToArray();
            var salt = Array.ConvertAll(byteArrString, Byte.Parse); ;

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                   password: login.password,
                   salt: salt,
                   prf: KeyDerivationPrf.HMACSHA1,
                   iterationCount: 10000,
                   numBytesRequested: 256 / 8));
            if(hashed != password2)
            {
                return BadRequest("Username or password have wrong.");
            }
            else
            {
                var role = user.Role;
                var resp = new Dictionary<string, object>();
                //generate token
                #region Generate JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.Default.GetBytes(JWT.SECRET_KEY);
                var issuer = JWT.ISSUER;
                var audience = JWT.AUDIENCE;

                var identity = new ClaimsIdentity("Application");
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                identity.AddClaim(new Claim(ClaimTypes.Actor, user.Fullname));

                var now = DateTime.UtcNow;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = issuer,
                    Audience = audience,
                    Subject = identity,
                    IssuedAt = now,
                    Expires = now.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature),
                    NotBefore = now
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                #endregion
                resp["access_token"] = tokenString;
                resp["token_type"] = "bearer";
                resp["expires_utc"] = tokenDescriptor.Expires;
                resp["issued_utc"] = tokenDescriptor.IssuedAt;

                return Ok(resp);
            }
        }


    }
}
