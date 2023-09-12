using Application.Features.Auths.Constants;
using Application.Services.Repositories;
using Core.Security.Hashing;
using Domain.Entities;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
      
     
        public Task UserShouldBeExists(User? user)
        {
            if (user == null) throw new Exception(AuthBusinessExceptionMessages.UserDontExists);
            return Task.CompletedTask;
        }
        public async Task UserEmailShouldBeActive(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email.ToLower() == email.ToLower());
            if (user != null) throw new Exception(AuthBusinessExceptionMessages.UserMailAlreadyExists);
        }
        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception(AuthBusinessExceptionMessages.PasswordDontMatch);
        }
    
      
      
    }
}
