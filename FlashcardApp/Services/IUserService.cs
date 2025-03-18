using FlashcardApp.Areas.Home.ViewModels;
using FlashcardApp.Models;
using System.Runtime.CompilerServices;

namespace FlashcardApp.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterViewModel model);
        Task<Member> LoginAsync(LoginViewModel model);
        Task<bool> LogoutAsync();
    }
}
