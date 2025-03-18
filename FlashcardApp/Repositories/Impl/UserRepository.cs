using FlashcardApp.Models;
using Microsoft.AspNetCore.Identity;

namespace FlashcardApp.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<Member> _userManager;

        public UserRepository(UserManager<Member> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Member> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> RegisterAsync(Member user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> CheckPasswordAsync(Member user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
