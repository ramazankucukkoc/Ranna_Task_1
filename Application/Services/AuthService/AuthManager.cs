using Application.Services.Repositories;
using Application.Services.UserService;
using Core.Persistence.Paging;
using Core.Security.JWT;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                 await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                 include: u => u.Include(x => x.OperationClaim));

            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(x => new OperationClaim
                {
                    Id = x.OperationClaim.Id,
                    Name = x.OperationClaim.Name,
                }).ToArray();
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }
    }
}
