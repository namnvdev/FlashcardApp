namespace FlashcardApp.Services.Impl
{
    using System.Threading.Tasks;
    using FlashcardApp.Areas.Home.ViewModels;
    using FlashcardApp.Models;
    using FlashcardApp.Repositories;
    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<Member> _signInManager;

        public UserService(IUserRepository userRepository, SignInManager<Member> signInManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            var user = new Member { UserName = model.Email, Email = model.Email, FullName = model.FullName };
            return await _userRepository.RegisterAsync(user, model.Password);
        }

        public async Task<Member> LoginAsync(LoginViewModel model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);
            if (user != null && await _userRepository.CheckPasswordAsync(user, model.Password))
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return user;
            }
            return null;
        }

        public async Task<bool> LogoutAsync()
        {
           await _signInManager.SignOutAsync();
            return false;
        }
    }

}
