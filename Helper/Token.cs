using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using primetechmvc.DTO;

public class Token
{
    public static string CreateJWT(UserModel user)
    {
        var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("123456789123456789"));
        var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

        var claims = new[] // NOTE: could also use List<Claim> here
			{
            new Claim(ClaimTypes.Name, user.username), // this will be User Identity Name
			new Claim(JwtRegisteredClaimNames.Sub, user.username),
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
            };

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}