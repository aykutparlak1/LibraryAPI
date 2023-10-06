using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
