using FlashcardApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FlashcardApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Member>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // 👇 Define Composite Primary Key for FlashcardTag
            builder.Entity<FlashcardTag>()
                .HasKey(ft => new { ft.FlashcardId, ft.TagId });

            // 👇 Define Foreign Key Relationships
            builder.Entity<FlashcardTag>()
                .HasOne(ft => ft.Flashcard)
                .WithMany(f => f.FlashcardTags)
                .HasForeignKey(ft => ft.FlashcardId);

            builder.Entity<FlashcardTag>()
                .HasOne(ft => ft.Tag)
                .WithMany(t => t.FlashcardTags)
                .HasForeignKey(ft => ft.TagId);

            builder.Entity<StudySession>()
            .HasOne(ss => ss.Member)
            .WithMany(u => u.StudySessions)
            .HasForeignKey(ss => ss.MemberId)
            .OnDelete(DeleteBehavior.Restrict);  

            builder.Entity<StudySession>()
                .HasOne(ss => ss.Deck)
                .WithMany(d => d.StudySessions)
                .HasForeignKey(ss => ss.DeckId)
                .OnDelete(DeleteBehavior.Restrict);

        }


       public DbSet<Member> Members { get; set; }
       public DbSet<Flashcard> Flashcards { get; set; }
       public DbSet<Deck> Decks { get; set; }
       public DbSet<Tag> Tags { get; set; }
       public DbSet<FlashcardTag> FlashcardTags { get; set; }
       public DbSet<StudySession> StudySessions { get; set; }
    }
}
