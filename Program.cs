using CsharpAdvance;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

string[] _keys = new string[]
{
    "this_is_my_super_ultra_password_anti_haking",
    "another_super_secret_key_idhdshdshksjdkdsjlkajdlkaj",
    "yet_another_secret_key_234234fdsfsdfad241243352"
};

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;

    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        //De esta forma podemos agregar varias Secrets Key al servicio//
        IssuerSigningKeyResolver = (token, securityToken, kid, validationParameters) =>
        {
            var keys = new List<SecurityKey>();
            foreach (var key in _keys)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                keys.Add(signingKey);
            }
            return keys;
        }
    };
});

// Construir la aplicación
var app = builder.Build();

// Ruta para generar tokens
app.MapGet("/auth/{user}/{pass}", (string user, string pass) => {
    // Verificar las credenciales del usuario
    if (user == "pepe" && pass == "el_mago")
    {
        List<string> listKey = new List<string>();
        JsonEngine je = new JsonEngine();

        foreach(var key in _keys){
            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(key);
            
            // Describir las propiedades del token
            var tokenDes = new SecurityTokenDescriptor
            {
                // Establecer las reclamaciones (claims) del token
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim("City","santiago"),
                    new Claim(ClaimTypes.PostalCode,"8380000")
                }),
                Expires = DateTime.UtcNow.AddMinutes(10), // Establecer la expiración del token
                
                /*La construcción explícita del header no es visible porque la biblioteca JwtSecurityTokenHandler
                se encarga de crear y gestionar estas partes automáticamente. El header se genera implícitamente
                con la información proporcionada en las SigningCredentials.*/
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };
            // Crear el token
            var token = tokenHandler.CreateToken(tokenDes);
            listKey.Add(tokenHandler.WriteToken(token));
        }
        
        return je.MakeJson(listKey);//=>{"Token":["bla1bla","bla2bla","bla3bla"]}
    }
    else return "Invalid User"; // Devolver mensaje de usuario inválido si las credenciales no coinciden
});

// Ruta protegida que requiere autenticación
app.MapGet("/protected",() => {return "Get closer to the truth even if it contradicts your beliefs";})
    .RequireAuthorization();

// Ruta protegida que requiere autenticación y ciertas reclamaciones
app.MapGet("/protected2",() => {return "You are form Santiago de Chile";})
    .RequireAuthorization(p => p.RequireClaim("City","santiago","8380000"));

// Ejecutar la aplicación
app.Run();