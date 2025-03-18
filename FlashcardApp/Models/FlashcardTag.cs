using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashcardApp.Models
{
    public class FlashcardTag
    {
        [Key]
        [Column(Order = 0)]
        public int FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }

        [Key]
        [Column(Order = 1)]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

}
