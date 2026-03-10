namespace InteractHub.Domain.Entities;

public class PostReport
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Reason { get; set; } = string.Empty;
    public ReportStatus Status { get; set; } = ReportStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid PostId { get; set; }
    public virtual Post Post { get; set; } = null!;

    public Guid ReporterId { get; set; }
    public virtual ApplicationUser Reporter { get; set; } = null!;
}

public enum ReportStatus
{
    Pending,
    Reviewed,
    Resolved,
    Rejected
}