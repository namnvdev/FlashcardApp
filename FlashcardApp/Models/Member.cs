using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashcardApp.Models
{
    public class Member : IdentityUser
    {
        public String? FullName { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        [NotMapped]
        public string? Role { get; set; }



        public ICollection<Deck> Decks { get; set; } // User-created decks
        public ICollection<StudySession> StudySessions { get; set; } // Track study progress
    }
}
