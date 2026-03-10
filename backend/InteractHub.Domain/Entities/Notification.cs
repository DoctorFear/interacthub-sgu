namespace InteractHub.Domain.Entities;

public class Notification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid UserId { get; set; }  // người nhận
    public virtual ApplicationUser User { get; set; } = null!;

    public Guid? RelatedPostId { get; set; }
    public Guid? RelatedUserId { get; set; }  // người tương tác (like, comment, friend request...)
}

public enum NotificationType
{
    Like,
    Comment,
    FriendRequest,
    FriendAccepted,
    Mention,
    // thêm nếu cần
}