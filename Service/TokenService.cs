using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Service;

using Microsoft.Extensions.Configuration;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _key;
    private readonly UserManager<AppUser> _userManager;

    public TokenService(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        _configuration = configuration;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
    }

    public string GenerateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.GivenName, user.UserName)
        };
        var roles = _userManager.GetRolesAsync(user).Result; // Roles'ı UserManager üzerinden alıyoruz
        foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role)); // Role'ü claim olarak ekliyoruz
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds,
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"]
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}