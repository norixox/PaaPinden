using PåPinden.Data;

namespace PåPinden.Models
{
    public class Follow
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.Now;
        public FollowType Status { get; set; } = FollowType.Pending;

        public string FollowerId { get; set; } = string.Empty;
        public ApplicationUser? Follower { get; set; }

        public string FollowingId { get; set; } = string.Empty;
        public ApplicationUser? Following { get; set; }
    }
}
