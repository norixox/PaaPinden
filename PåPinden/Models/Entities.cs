
public class Reaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public ReactionType Type { get; set; }
    public string? Text { get; set; } // ? betyder, at den må være null (til likes)
    public DateTime Date { get; set; } = DateTime.Now;

    // Fremmednøgler
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }

    // Navigation properties (gør det nemt at hente data)
    public User User { get; set; } = null!;
    public Post Post { get; set; } = null!;
}

// Follow.cs
public class Follow
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public FollowStatus Status { get; set; } = FollowStatus.Pending;
    public DateTime Date { get; set; } = DateTime.Now;

    // Fremmednøgler
    public Guid FollowerId { get; set; }
    public Guid FollowingId { get; set; }

    // Navigation properties
    public User Follower { get; set; } = null!;
    public User Following { get; set; } = null!;
}