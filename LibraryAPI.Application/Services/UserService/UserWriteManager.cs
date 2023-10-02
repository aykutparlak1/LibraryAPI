using Core.Utilities.Security.Hashing;
using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Services.UserService
{
    public class UserWriteManager : IUserWriteService
    {
        public User CreateUser(CreateUserDto model)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                IdentityNumber = model.IdentityNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                BirthDate = model.BirthDate,
            }; 
            return user;
        }
    }
}
