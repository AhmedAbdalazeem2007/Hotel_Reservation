using Hotel_Core_Layer.Models.Identity;
using Hotel_Core_Layer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sercices_Hotel
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration configuration;

        public TokenServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(ApplicationUser applicationUser, UserManager<ApplicationUser> userManager)
        {
            var authcliam = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName,applicationUser.F_Name),
                new Claim(ClaimTypes.Email,applicationUser.Email),
            };
            var userrols = await userManager.GetRolesAsync(applicationUser);
            foreach (var claim in userrols)
            {
                authcliam.Add(new Claim(ClaimTypes.Role, claim));
            }
            var authkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWt:Key"]));
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:ValidIssuer"],
                audience: configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddDays(double.Parse(configuration["DurationInDays"])),
               claims: authcliam,
               signingCredentials: new SigningCredentials(authkey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
