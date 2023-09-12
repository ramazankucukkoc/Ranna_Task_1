using Application.Features.Users.Contants;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Hashing;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public UserBusinessRules(IUserRepository userRepository)
        => (_userRepository) = (userRepository);
        public Task UserShouldBeExists(User? user)
        {
            if (user == null) throw new Exception(UserMessages.UserDontExists);
            return Task.CompletedTask;
        }
        public Task UserPasswordShouldBeMatch(User user, string password)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception(UserMessages.PasswordDontMatch);
            return Task.CompletedTask;
        }
        public async Task UserIdShouldExistsWhenSelected(int id)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (user == null) throw new Exception(UserMessages.UserDontExists);
        }
        public async Task UserEmailShouldExistsWhenSelected(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null) throw new Exception(UserMessages.UserDontExists);
        }
        public async Task UserConNotBeDuplicatedWhenUpdated(int id, string email)
        {
            var result = await _userRepository.Query().Where(u => u.Email == email).AnyAsync();
            if (result)
            {
                result = await _userRepository.Query().Where(u => (u.Id == id && u.Email == email)).AnyAsync();
                if (!result) throw new Exception("Email Adresi kullanılmamaktadır.");
            }
        }
        public async Task ThereShouldBeSomeDataInUserListAsRequired(IPaginate<User> users)
        {
            if (!users.Items.Any()) throw new Exception("Kullanıcılar bulunamadı");
        }

    }
}
