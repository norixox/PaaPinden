using PåPinden.Data;
using static System.Collections.Specialized.BitVector32;

namespace PåPinden.Models
{
    public class Post
    {
        public Guid PostId { get; set; } = Guid.NewGuid();
        public string Description { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? Owner { get; set; }

        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}
