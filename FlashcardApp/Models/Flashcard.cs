namespace FlashcardApp.Models
{
    public class Flashcard
    {
        public int Id { get; set; }

        // Foreign Key
        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }

        public string ImageUrl { get; set; } // Optional image for the flashcard

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<FlashcardTag> FlashcardTags { get; set; } // Many-to-Many with Tags
    }

}
