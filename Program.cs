using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
string _key = "this_is_my_super_ultra_password_anti_haking";

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

    opt.RequireHttpsMetadata = false;

    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = signingKey,
    };
});

var app = builder.Build();

//Token Maker//
app.MapGet("/auth/{user}/{pass}", (string user, string pass) =>
{
    if (user == "pepe" && pass == "el_mago")
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var byteKey = Encoding.UTF8.GetBytes(_key);
        var tokenDes = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user),
                new Claim("City","santiago"),
                new Claim(ClaimTypes.PostalCode,"8380000")
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                                                            SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDes);
        return tokenHandler.WriteToken(token);
    }
    else return "Invalid User";
});

app.MapGet("/protected",() => {return "Get closer to the truth even if it contradicts your beliefs";})
    .RequireAuthorization();

app.MapGet("/protected2",() => {return "Get closer to the truth even if it contradicts your beliefs";})
    .RequireAuthorization(p => p.RequireClaim("City","santiago","8380000"));

app.Run();