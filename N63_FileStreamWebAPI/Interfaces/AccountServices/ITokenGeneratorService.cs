using N63_FileStreamWebAPI.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace N63_FileStreamWebAPI.Interfaces.AccountServices;


public interface ITokenGeneratorService
{
    string GetToken(User user);

    JwtSecurityToken GetJwtToken(User user);

    List<Claim> GetClaims(User user);
}