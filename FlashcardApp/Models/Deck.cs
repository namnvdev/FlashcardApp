namespace FlashcardApp.Models
{
    public class Deck
    {
        public int Id { get; set; }

        // Foreign Key
        public string MemberId { get; set; }
        public Member Member { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsPublic { get; set; } = false; // Public or private deck?

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Flashcard> Flashcards { get; set; }
        public ICollection<StudySession> StudySessions { get; set; }

    }

}
