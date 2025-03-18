using FlashcardApp.Models;

namespace FlashcardApp.Repositories
{
    public interface IUserRepository
    {
        Task<Member> GetByEmailAsync(string email);
        Task<bool> RegisterAsync(Member user, string password);
        Task<bool> CheckPasswordAsync(Member user, string password);
    }
}
