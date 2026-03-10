namespace InteractHub.Domain.Entities;

public class Story
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? ImageUrl { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddHours(24);

    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; } = null!;
}