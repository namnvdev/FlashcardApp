using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashcardApp.Models
{
    public class StudySession
    {
        public int Id { get; set; }

        // Foreign Keys
        [Required]
        public string MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
        [Required]
        public int DeckId { get; set; }
        [ForeignKey(nameof (DeckId))]
        public Deck Deck { get; set; }

        public int TotalFlashcards { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    }

}
