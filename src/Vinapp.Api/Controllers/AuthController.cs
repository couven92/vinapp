using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Vinapp.Api.Dto;
using Vinapp.Data.Models;

namespace Vinapp.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userMgr;
        private readonly IPasswordHasher<User> _hasher;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfigurationRoot _config;

        public AuthController(UserManager<User> userMgr, IPasswordHasher<User> hasher, ILogger<AuthController> logger,
            IConfigurationRoot config)
        {
            _userMgr = userMgr;
            _hasher = hasher;
            _logger = logger;
            _config = config;
        }

        [HttpPost("api/auth/token")]
        public async Task<IActionResult> CrateToken([FromBody] CredentialDto credentialDto)
        {
            try
            {
                var user = await _userMgr.FindByNameAsync(credentialDto.Username);
                if (user != null)
                {
                    if (_hasher.VerifyHashedPassword(user, user.PasswordHash, credentialDto.Password) ==
                        PasswordVerificationResult.Success)
                    {
                        var userClaims = await _userMgr.GetClaimsAsync(user);

                        var claims = CreateClaims(user, userClaims);
                        var creds = CreateCredentials();

                        var token = CreateJwtSecurityToken(claims, creds);

                        var returnToken = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return Ok(returnToken);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while creating JWT: {ex}");
            }

            return BadRequest("Failed to generate token");
        }

        private SigningCredentials CreateCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            return creds;
        }

        private static IEnumerable<Claim> CreateClaims(User user, IList<Claim> userClaims)
        {
            var claims = new[]
            {
                new Claim("Username", user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }.Union(userClaims);
            return claims;
        }

        private JwtSecurityToken CreateJwtSecurityToken(IEnumerable<Claim> claims, SigningCredentials creds)
        {
            var token = new JwtSecurityToken(
                issuer: _config["Tokens:Issuer"],
                audience: _config["Tokens:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds);
            return token;
        }
    }
}
