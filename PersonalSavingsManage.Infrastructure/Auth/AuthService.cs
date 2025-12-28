using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonalSavingsManage.Core.Services;
using PersonalSavingsManage.Infrastructure.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PersonalSavingsManage.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IOptions<JwtOptions> _options;

    public AuthService(IOptions<JwtOptions> options)
    {
        _options = options;
    }

    public string ComputeSha256Hash(string password)
    {
        using (var hash = SHA256.Create())
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var hashBytes = hash.ComputeHash(passwordBytes);

            var builder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

    public string GenerateJwtToken(string email, string role)
    {
        var issuer = _options.Value.Issuer;
        var audience = _options.Value.Audience;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("username", email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(issuer, audience, claims, null, DateTime.Now.AddHours(2), credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
