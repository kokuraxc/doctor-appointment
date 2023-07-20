using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace doctor_appointment.Application.Common;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid id, string firstName, string lastName, string role)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key super-secret-key")
            ),
            SecurityAlgorithms.HmacSha256
        );
        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim("role", role)
        };

        var serucityToken = new JwtSecurityToken(
            issuer: "doctor-appointments-system",
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(serucityToken);
    }
}