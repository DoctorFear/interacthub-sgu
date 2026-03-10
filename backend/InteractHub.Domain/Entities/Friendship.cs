namespace InteractHub.Domain.Entities;

public class Friendship
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public FriendshipStatus Status { get; set; } = FriendshipStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? AcceptedAt { get; set; }

    public Guid RequesterId { get; set; }
    public virtual ApplicationUser Requester { get; set; } = null!;

    public Guid RecipientId { get; set; }
    public virtual ApplicationUser Recipient { get; set; } = null!;
}

public enum FriendshipStatus
{
    Pending,
    Accepted,
    Rejected,
    Blocked
}