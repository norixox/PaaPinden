using PåPinden.Data;

namespace PåPinden.Models
{
    public class Reaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ReactionType Type { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public Guid PostId { get; set; }
        public Post? Post { get; set; }
    }
}
