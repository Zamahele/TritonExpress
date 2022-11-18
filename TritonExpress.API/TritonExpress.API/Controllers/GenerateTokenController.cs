using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Persistence;
using TritonExpress.API.Domain.Entities.Authentication;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateTokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IApplicationDbContext _context;
        private readonly ICacheService _cache;

        public GenerateTokenController(IConfiguration config, IApplicationDbContext context, ICacheService cache)
        {
            _configuration = config;
            _context = context;
            _cache = cache;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Token>> GetToken(string userId)
        {
            if (userId != null)
            {
                var user = await GetUser(userId);
                if (user != null)
                {   
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWTSettings:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                        new Claim("Id", user.Id),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email),
                        new Claim("SecurityStamp", user.SecurityStamp)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["JWTSettings:Issuer"], _configuration["JWTSettings:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    var generatedToken =new Token{TokenCode = new JwtSecurityTokenHandler().WriteToken(token).ToString()};

                    return generatedToken;
                }
                else
                {
                    return new Token();
                }
            }
            else
            {
                return new Token();
            }
        }

        private async Task<AspNetUsers> GetUser( string userId)
        {
            try
            {
                return await _context.AspNetUsers.FirstOrDefaultAsync(x=>x.UserName == userId);
            }
            catch (Exception e)
            {
                    Console.WriteLine(e);
                    throw;
            }
        }
    }
}