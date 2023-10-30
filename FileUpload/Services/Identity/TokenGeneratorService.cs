using FileUpload.Models.Constants;
using FileUpload.Models.Entities;
using FileUpload.Models.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FileUpload.Services.Identity;

public class TokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings) => _jwtSettings = jwtSettings.Value;
    
    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claimss = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credintails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claimss,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: credintails);
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new Claim (ClaimTypes.Email, user.Email),
            new Claim(ClaimConstants.UserId, user.Id.ToString())
        };
    }
}