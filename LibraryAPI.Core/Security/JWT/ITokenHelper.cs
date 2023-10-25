using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Views.UserViews;

namespace LibraryAPI.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserClaimsDto user);
    }
}
