using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Debe tener más de 15 caracteres para que funcione
string key = "HolaMundo123456hadasjdhkahkajdshkjgjghjdsgdfgfdgdf";

builder.Services.AddAuthorization();
//builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(authService => {
    var signigKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var signigCredentials = new SigningCredentials(signigKey,SecurityAlgorithms.HmacSha256Signature);

    authService.RequireHttpsMetadata = false;//Para que no pida metadata
    authService.TokenValidationParameters = new TokenValidationParameters() {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = signigKey
    };
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

/*
 * To get the content of this endpoint we need a JWT.
 * To get the token run the next command on terminal => dotnet user-jwts create
 * We need to add in postman client a Header like image ![imgs/Bearer Authorization.png]
 * Tokens going to save in directory C:\Users\Danpier\AppData\Roaming\Microsoft\UserSecrets
 *  and the token id it's in the file "JWT.csproj" in the tag <UserSecretsId>
 */
//app.MapGet("/protected", () => "contenido protegido: Dios ha muerto").RequireAuthorization();

/*
 * Error example: ![imgs\pepeelmago Auth.png]
 * Good example: ![imgs\Ok Auth.png]
 */
app.MapGet("/user-credentials/{user}/{pass}", (string user,string pass) =>
{
    if (user == "Danpier" && pass == "MyPass1234") {
        var tokenHandler = new JwtSecurityTokenHandler();
        var byteKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        //Aquí definimos lo que tendrá el Body de nuestro token
        var tokenDescriptor = new SecurityTokenDescriptor() {

            //Los Claims son piezas de información que estrán en el cuerpo del token
            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user)
            }),
            Expires = DateTime.UtcNow.AddMonths(3), //El token expirará en tres meses
            SigningCredentials = new SigningCredentials(byteKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    else { return "Invalid User"; }
});

/*
 * Con las credenciales que optenemos en el endpoint anterior podemos consultar
 * el endpoint "/protected2 (Exmaple Image: ![imgs/Bearer Authorization Two.png])"
 */
app.MapGet("/protected2", () => "contenido protegido: Dios ha muerto").RequireAuthorization();

app.Run();
