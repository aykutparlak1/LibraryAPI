using Microsoft.IdentityModel.Tokens;

namespace LibraryAPI.Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSingingCredentials(SecurityKey securityKey) 
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
