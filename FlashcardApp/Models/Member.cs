using Microsoft.AspNetCore.Identity;

namespace FlashcardApp.Models
{
    public class Member : IdentityUser
    {
        public String FullName { get; set; }

        public ICollection<Deck> Decks { get; set; } // User-created decks
        public ICollection<StudySession> StudySessions { get; set; } // Track study progress
    }
}
