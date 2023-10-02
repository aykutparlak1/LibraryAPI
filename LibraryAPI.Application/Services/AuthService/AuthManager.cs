﻿using Core.Utilities.Security.JWT;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        public AuthManager( ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }
        public AccessToken CreateAccesToken(User user)
        {
            AccessToken accessToken = _tokenHelper.CreateToken(user);
            return accessToken;
        }
    }
}
