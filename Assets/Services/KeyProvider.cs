using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CsharpAdvance.Assets.Services
{

    public interface IKeyProvider
    {
        IEnumerable<SecurityKey> GetSigningKeys();
    }

    public class KeyProvider:IKeyProvider
    {
        private readonly IConfiguration _configuration;
        private DAL _dal = new DAL();

        public KeyProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<SecurityKey> GetSigningKeys()
        {
            var keys = new List<SecurityKey>();

            string[] keyList = _dal.GetSecretKeys();

            foreach (var key in keyList)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                keys.Add(signingKey);
            }

            return keys;
        }
    }
}