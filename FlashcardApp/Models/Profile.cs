namespace FlashcardApp.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
